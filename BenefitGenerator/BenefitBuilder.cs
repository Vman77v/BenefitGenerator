using System;
using System.Collections.Generic;
using System.Linq;

namespace BenefitGenerator
{
    class BenefitBuilder
    {
        internal static void BuildBenefit(string[] primaryBenefits, string[] secondaryBenefits, string benfitCategorys, string[] plans, Dictionary<string, int> BenefitDictionary, List<Benefit> benefitCodeResults, int levelOfCoverage)
        {
            //enter in case number here
            const string caseNum = "0712010";
            const string formatId = "0712010AVO";
            //enter in min effective date here
            var minEffDate = new DateTime(2018, 01, 01);


            var primaryBenefit = primaryBenefits;            
            var benfitCategory = benfitCategorys.Trim(',', ' ');
            var benefitGroup = benfitCategorys.Trim(',', ' ');
      


            foreach (var t in plans)
            {
                var currentPlan = t.TrimEnd(',', ' ');
                foreach (var item in primaryBenefit)
                {                                       
                    benefitCodeResults.Add(new Benefit(caseNum, minEffDate, item.Trim(',', ' '), currentPlan, benfitCategory, levelOfCoverage, benefitGroup, 1, formatId));
                    benefitCodeResults.AddRange(secondaryBenefits.Select(secondBen => new Benefit(caseNum, minEffDate, secondBen.Trim(',', ' '), currentPlan, benfitCategory, levelOfCoverage, "FEE", 0, formatId)));
                }
                if (primaryBenefits.Length > 0) continue;
                foreach (var item in secondaryBenefits)
                {   
                var newLevelOfCoverage = levelOfCoverage.ToString().Select(c => Convert.ToInt32(c.ToString())).ToArray();
                    foreach (var i in newLevelOfCoverage)
                    {
                        benefitCodeResults.Add(new Benefit(caseNum, minEffDate, item.Trim(',', ' '), currentPlan, benfitCategory, i, "FEE", 0, formatId));
                    }
                }
            }            
        }
    }
}
