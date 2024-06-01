
using System.Diagnostics;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace TestProject1.src.main.BaseTestConfigurations
{
    public class TestConfigurations
    {
        protected Application calculatorApp;
        protected Window calculatorWindow;

        public Window CalculatorWindow()
        {
            return calculatorWindow;
        }
        public Application CalculatorApp()
        {
            return calculatorApp;
        }

        public void Setup()
        {
            calculatorApp = Application.Launch("calc.exe");
            Thread.Sleep(1000);
            // Get the main window of the Calculator
            var desktop = Desktop.Instance;
            var windows = desktop.Windows();
            calculatorWindow = windows.FirstOrDefault(x => x.Name.Contains("Калькулятор"));
            Assert.IsNotNull(calculatorWindow, "window is null");
        }

        public void TearDown()
        {
            if (calculatorApp != null)
            {
                foreach (var process in Process.GetProcessesByName("calc"))
                {
                    process.Kill(); // Terminate the process associated with the Calculator application

                }
            }
        }
    }
}
