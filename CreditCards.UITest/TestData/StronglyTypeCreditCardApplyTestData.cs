using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCards.UITest.TestData
{
    //[InlineData("Alice", "Johnson", "345678-D", "40", "80000", "Married", "Word of Mouth")]
    //public void SubmitFormMultiData_RefferToHuman(string firstName, string lastName, string frequentFlyerNumber, string age, string grossAnnualIncome, string maritalStatus, string businessSource)

    public class StronglyTypeCreditCardApplyTestData : TheoryData<string, string, string, string, string, string, string>
    {
        public StronglyTypeCreditCardApplyTestData()
        {
            var testDataLine = File.ReadAllLines("TestData/MyData.csv");
            foreach (var line in testDataLine)
            {
                var data = line.Split(',');
                if (data.Length == 7)
                {
                    Add(data[0], data[1], data[2], data[3], data[4], data[5], data[6]);
                }
                else
                {
                    throw new ArgumentException("Each line must contain exactly 7 comma-separated values.");
                }
            }
        }
    }
}
