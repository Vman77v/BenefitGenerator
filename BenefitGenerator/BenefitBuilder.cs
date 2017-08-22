using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenefitGenerator
{
    class BenefitBuilder
    {
        internal static void BuildPrimaryBenefit(string primaryBenefits, string benfitCategorys, string plans, string secondaeryBenefits, Dictionary<string, int> BenefitDictionary)
        {

            var benefitCodeResults = new List<Benefit>();
            var benfitCategory = benfitCategorys.TrimEnd(',', ' ');
            var benefitGroup = benfitCategorys.TrimEnd(',', ' ');
            var primaryBenefit = primaryBenefits.Split();
            var secondaryBenefit = secondaeryBenefits.Split();

            var plan = plans.Split();



            for (var i = 0; i < plan.Length - 1; i++)
            {
                foreach (var item in primaryBenefit)
                {
                    var currentPlan = plan[i].TrimEnd(',', ' ');


                    var levelOfCoverage = BenefitDictionary[item.TrimEnd(',', ' ')];


                    benefitCodeResults.Add(new Benefit(item.TrimEnd(',', ' '), currentPlan, benfitCategory, levelOfCoverage, benefitGroup, 1));
                    benefitCodeResults.AddRange(secondaryBenefit.Select(secondBen => new Benefit(secondBen.TrimEnd(',', ' '), currentPlan, benfitCategory, levelOfCoverage, benefitGroup, 0)));
                }
            }
            FileWriter.WriteFile(benefitCodeResults);
        }
    }
}
