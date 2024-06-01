using System;
using System.Collections.Generic;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using TestProject1.src.main.BaseTestConfigurations;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;
using TestProject1.src.main.Locators;
using System.Text.RegularExpressions;

namespace TestProject1.src.main.Operations
{
    public class Operations : TestConfigurations
    {
        private readonly Window calculatorWindow;
        private readonly Locators.Locators locators;
        private static readonly Random random = new Random();



        public Operations(Window window)
        {
            calculatorWindow = window;
            locators = new Locators.Locators(window);

        }
        public string ExtractNumberFromResult(string resultText)
        {
            resultText = resultText.Replace("\u00A0", " ");

            var match = Regex.Match(resultText, @"-?\d{1,3}(?:\s\d{3})*(?:[.,]\d+)?");
            if (!match.Success)
            {
                throw new FormatException("No valid number found in result text.");
            }

            string resultNumber = match.Value.Replace(" ", "");

            if (resultNumber.Contains("."))
            {
                resultNumber = resultNumber.Replace(".", ",");
            }

            return resultNumber;
        }
        public decimal RoundExpectedResult(decimal expectedResult, string actualResultStr)
        {
            int decimalPlaces = 0;
            if (actualResultStr.Contains(","))
            {
                var parts = actualResultStr.Split(',');
                if (parts.Length > 1)
                {
                    decimalPlaces = parts[1].Length;
                }
            }

            return Math.Round(expectedResult, decimalPlaces);
        }

        public List<UIItem> GetElementsList()
        {
            List<UIItem> uiItems = new List<UIItem>();
            Assert.IsNotNull(calculatorWindow, "window is null");

            var allElements = calculatorWindow.GetMultiple(SearchCriteria.All);
            foreach (var element in allElements)
            {
                uiItems.Add((UIItem)element);
            }

            return uiItems;
        }

        public void PrintAllUIItems()
        {

            var allElementss = calculatorWindow.AutomationElement.FindAll(TreeScope.Descendants, System.Windows.Automation.Condition.TrueCondition);
            foreach (AutomationElement element in allElementss)
            {
                Console.WriteLine("Element found:");
                Console.WriteLine($"  Name: {element.Current.Name}");
                Console.WriteLine($"  AutomationId: {element.Current.AutomationId}");
                Console.WriteLine($"  ControlType: {element.Current.ControlType.ProgrammaticName}");
                Console.WriteLine($"  ClassName: {element.Current.ClassName}");
                Console.WriteLine($"  IsEnabled: {element.Current.IsEnabled}");
                Console.WriteLine($"  IsOffscreen: {element.Current.IsOffscreen}");
                Console.WriteLine($"  BoundingRectangle: {element.Current.BoundingRectangle}");
                Console.WriteLine($"  FrameworkId: {element.Current.FrameworkId}");


            }
        }
        public void PressNumberButton(int number)
        {
            string numberStr = number.ToString();
            foreach (char digit in numberStr)
            {
                switch (digit)
                {
                    case '0':
                        locators.num0Button.Click();
                        break;
                    case '1':
                        locators.num1Button.Click();
                        break;
                    case '2':
                        locators.num2Button.Click();
                        break;
                    case '3':
                        locators.num3Button.Click();
                        break;
                    case '4':
                        locators.num4Button.Click();
                        break;
                    case '5':
                        locators.num5Button.Click();
                        break;
                    case '6':
                        locators.num6Button.Click();
                        break;
                    case '7':
                        locators.num7Button.Click();
                        break;
                    case '8':
                        locators.num8Button.Click();
                        break;
                    case '9':
                        locators.num9Button.Click();
                        break;
                }
            }
        }
    }
}