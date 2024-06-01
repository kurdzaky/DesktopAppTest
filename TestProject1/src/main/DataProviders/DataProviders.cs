using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.src.main.DataProviders
{
    public class DataProviders
    {
        private readonly Random random = new Random();

        public int GenerateRandomNumber(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue + 1);
        }

        public IEnumerable<object[]> GetTestCases()
        {
            yield return new object[] { GenerateRandomNumber(0, 9), GenerateRandomNumber(0, 9) };          // 1-digit number
            yield return new object[] { GenerateRandomNumber(10, 99), GenerateRandomNumber(10, 99) };        // 2-digit number
            yield return new object[] { GenerateRandomNumber(100, 999), GenerateRandomNumber(100, 999) };      // 3-digit number
            yield return new object[] { GenerateRandomNumber(1000, 9999), GenerateRandomNumber(1000, 9999) };    // 4-digit number
            yield return new object[] { GenerateRandomNumber(10000, 99999), GenerateRandomNumber(10000, 99999) };  // 5-digit number
        }
    }
}
