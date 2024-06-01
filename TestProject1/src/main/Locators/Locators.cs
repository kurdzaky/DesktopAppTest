using System.Windows.Automation;
using TestProject1.src.main.BaseTestConfigurations;
using TestProject1.src.main.Operations;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestProject1.src.main.Locators
{
    public class Locators : TestConfigurations
    {

        public Button num1Button;
        public Button num2Button;
        public Button num3Button;
        public Button num4Button;
        public Button num5Button;
        public Button num6Button;
        public Button num7Button;
        public Button num8Button;
        public Button num9Button;
        public Button num0Button;
        public Button percentButton;
        public Button backSpaceButton;
        public Button divideButton;
        public Button plusButton;
        public Button minusButton;
        public Button multiplyButton;
        public Button decimalSeparatorButton;
        public Button equalButton;
        public Button xpower2Button;
        public Button togglePaneButton;
        public Button negateButton;
        public Button clearButton;
        public Button maximizeButton;
        public Button closeButton;
        public AutomationElement titleBar;
        public AutomationElement calculatorResults;
        

        public Locators(Window window)
        {
            num1Button = window.Get<Button>(SearchCriteria.ByAutomationId("num1Button"));
            num2Button = window.Get<Button>(SearchCriteria.ByAutomationId("num2Button"));
            num3Button = window.Get<Button>(SearchCriteria.ByAutomationId("num3Button"));
            num4Button = window.Get<Button>(SearchCriteria.ByAutomationId("num4Button"));
            num5Button = window.Get<Button>(SearchCriteria.ByAutomationId("num5Button"));
            num6Button = window.Get<Button>(SearchCriteria.ByAutomationId("num6Button"));
            num7Button = window.Get<Button>(SearchCriteria.ByAutomationId("num7Button"));
            num8Button = window.Get<Button>(SearchCriteria.ByAutomationId("num8Button"));
            num9Button = window.Get<Button>(SearchCriteria.ByAutomationId("num9Button"));
            num0Button = window.Get<Button>(SearchCriteria.ByAutomationId("num0Button"));
            percentButton = window.Get<Button>(SearchCriteria.ByAutomationId("percentButton"));
            backSpaceButton = window.Get<Button>(SearchCriteria.ByAutomationId("backSpaceButton"));
            divideButton = window.Get<Button>(SearchCriteria.ByAutomationId("divideButton"));
            plusButton = window.Get<Button>(SearchCriteria.ByAutomationId("plusButton"));
            minusButton = window.Get<Button>(SearchCriteria.ByAutomationId("minusButton"));
            multiplyButton = window.Get<Button>(SearchCriteria.ByAutomationId("multiplyButton"));
            decimalSeparatorButton = window.Get<Button>(SearchCriteria.ByAutomationId("decimalSeparatorButton"));
            equalButton = window.Get<Button>(SearchCriteria.ByAutomationId("equalButton"));
            xpower2Button = window.Get<Button>(SearchCriteria.ByAutomationId("xpower2Button"));
            clearButton = window.Get<Button>(SearchCriteria.ByAutomationId("clearButton"));
            //togglePaneButton = window.Get<Button>(SearchCriteria.ByAutomationId("togglePaneButton"));
            negateButton = window.Get<Button>(SearchCriteria.ByAutomationId("backSpaceButton"));
            closeButton = window.Get<Button>(SearchCriteria.ByAutomationId("Close"));
            maximizeButton = window.Get<Button>(SearchCriteria.ByAutomationId("Maximize"));
            titleBar = window.AutomationElement.FindFirst(TreeScope.Descendants,new PropertyCondition(AutomationElement.ClassNameProperty, "ApplicationFrameTitleBarWindow"));
            calculatorResults = window.AutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "CalculatorResults"));

            
        }
    }
}