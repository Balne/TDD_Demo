using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDDemoConsole
{
    public class Calculator
    {

        /* 
         * Below is the method that satisfies the conditions metioned in STEP 1 unit test case
         */

        public int Add_Step1(string numbers)
        {
            var splitNumbers = numbers.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (!splitNumbers.Any())
            {
                return 0;
            }
            if (splitNumbers.Length == 1)
            {
                return int.Parse(splitNumbers[0]);
            }
            return int.Parse(splitNumbers[0]) + int.Parse(splitNumbers[1]);
        }


        /*
         * Below is the refactored code of Add_Step1 and it now satisifes conditions mentioned in STEP 1 & STEP 2 unit test cases
         */

        public int Add_Step2(string numbers)
        {
            var splitNumbers = numbers.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse);
            return splitNumbers.Sum();
        }

        /*
         * Below is the refactored code of Add_Step2 and it now satisifes conditions mentioned in STEP 1 & STEP 2 & STEP3 unit test cases.
         * Even has refactored code for STEP4 and executes Add_ShouldThrowException_ForInvalidString test method
         */

        public int Add_Step3(string numbers)
        {
            var delimiters = new[] { ',', '|' };



            var splitNumbers = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse);

            #region STEP4 refactoring
            var negativeNumbers = splitNumbers.Where(n => n < 0).ToList();

            if (negativeNumbers.Any())
            {
                throw new Exception($"Negatives not allowed: {string.Join(",", negativeNumbers)}");
            }
            #endregion

            return splitNumbers.Sum();
        }
    }
}
