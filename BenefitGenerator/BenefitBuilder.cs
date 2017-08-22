using System.Collections.Generic;
using System.Linq;

namespace BenefitGenerator
{
    class BenefitBuilder
    {
        internal static void BuildBenefit(string[] primaryBenefits, string benfitCategorys, string[] plans, string[] secondaeryBenefits, Dictionary<string, int> BenefitDictionary, List<Benefit> benefitCodeResults)
        {

            
            var benfitCategory = benfitCategorys.TrimEnd(',', ' ');
            var benefitGroup = benfitCategorys.TrimEnd(',', ' ');
            var primaryBenefit = primaryBenefits;
            var secondaryBenefit = secondaeryBenefits;         


            for (var i = 0; i < plans.Length - 1; i++)
            {
                foreach (var item in primaryBenefit)
                {
                    var currentPlan = plans[i].TrimEnd(',', ' ');


                    var levelOfCoverage = BenefitDictionary[item.TrimEnd(',', ' ')];


                    benefitCodeResults.Add(new Benefit(item.TrimEnd(',', ' '), currentPlan, benfitCategory, levelOfCoverage, benefitGroup, 1));
                    benefitCodeResults.AddRange(secondaryBenefit.Select(secondBen => new Benefit(secondBen.TrimEnd(',', ' '), currentPlan, benfitCategory, levelOfCoverage, "FEE", 0)));
                }
            }            
        }
    }
}
