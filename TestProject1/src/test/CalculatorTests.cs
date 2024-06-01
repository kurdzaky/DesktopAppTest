
using Castle.Core.Logging;

using TestProject1.src.main.BaseTestConfigurations;
using TestProject1.src.main.DataProviders;
using TestProject1.src.main.Locators;
using TestProject1.src.main.Operations;
using Serilog;
using Serilog.Core;
using Serilog.Configuration;



namespace TestProject1.src.test
{
    [TestClass]
    public class CalculatorTests : TestConfigurations
    {
        private Locators locators;
        private Operations operations;
        private DataProviders dataProvider = new DataProviders(); 



        [TestInitialize]
        public void SetUp()
        {
            Setup();
            locators = new Locators(calculatorWindow);
            operations = new Operations(calculatorWindow);
         

        }
        public void TearDown()
        {
            base.TearDown();
        }

        [TestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void TestMultiplication(int num1, int num2)
        {
            // Arrange
            operations.PressNumberButton(num1);
            locators.multiplyButton.Click();
            operations.PressNumberButton(num2);
            locators.equalButton.Click();
            Thread.Sleep(2000);

            var expectedResult = num1 * num2;
            var resultText = locators.calculatorResults.Current.Name;
            Console.WriteLine("resultText " + resultText);
            var resultNumber = operations.ExtractNumberFromResult(resultText);

            Assert.AreEqual(expectedResult.ToString(), resultNumber);
        }

        [TestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void TestAddition(int num1, int num2)
        {
            operations.PressNumberButton(num1);
            locators.plusButton.Click();
            operations.PressNumberButton(num2);
            locators.equalButton.Click();
            Thread.Sleep(2000);

            var expectedResult = num1 + num2;
            var resultText = locators.calculatorResults.Current.Name;
            var resultNumber = operations.ExtractNumberFromResult(resultText);

            Assert.AreEqual(expectedResult.ToString(), resultNumber);
        }

        [TestMethod]
        [DynamicData(nameof(DataProviders.GetTestCases), DynamicDataSourceType.Method)]
        public void TestDivision(int num1, int num2)
        {
            // Arrange
            operations.PressNumberButton(num1);
            locators.divideButton.Click();
            operations.PressNumberButton(num2);
            locators.equalButton.Click();
            Thread.Sleep(2000);

            var resultText = locators.calculatorResults.Current.Name;
            var resultNumberStr = operations.ExtractNumberFromResult(resultText);

            if (!decimal.TryParse(resultNumberStr, out decimal resultNumber))
            {
                Assert.Fail("Failed to parse the result number.");
            }

            var expectedResult = (decimal)num1 / num2;
            var roundedExpectedResult = operations.RoundExpectedResult(expectedResult, resultNumberStr);

            Assert.AreEqual(roundedExpectedResult, resultNumber, $"Expected: {roundedExpectedResult}, Actual: {resultNumber}");
        }

        [TestMethod]
        [DynamicData(nameof(DataProviders.GetTestCases), DynamicDataSourceType.Method)]
        public void TestPercentage(int num1, int num2)
        {
            operations.PressNumberButton(num1);
            locators.multiplyButton.Click();
            operations.PressNumberButton(num2);
            locators.percentButton.Click();
            locators.equalButton.Click();
            Thread.Sleep(2000);


            var expectedResult = (num1 * num2) / 100.0; 
            var resultText = locators.calculatorResults.Current.Name;
            Console.WriteLine(resultText + "is a result text");   
            var resultNumber = operations.ExtractNumberFromResult(resultText);

     
            Assert.AreEqual(expectedResult.ToString(), resultNumber);
        }

        public static IEnumerable<object[]> GetTestCases()
        {
            var dataProvider = new DataProviders();
            return dataProvider.GetTestCases();
            }


        }
    }
