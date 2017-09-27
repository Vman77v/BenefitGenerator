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
            const string caseNum = "1234567";
            //enter in min effective date here
            var minEffDate = new DateTime(2017, 09, 01);


            var primaryBenefit = primaryBenefits;            
            var benfitCategory = benfitCategorys.Trim(',', ' ');
            var benefitGroup = benfitCategorys.Trim(',', ' ');

            var hardCodedSecondaryBenefit = new[]
            {
                "UR","FD","1F","OF","6Y","1S","XR","AG","4F","6F",
                "DF","TD","1C","A1","VS","BE","EF","BC","6X","DL",
                "LE","AS","LC","IF","AH","DC","XL","LR","SA","CR",
                "NS","QT","LT","YD","XT","ZE","CF","AE","WI","4S",
                "CK","CG","6Z","A3","FV","S2","FO","6S","VF","TC",
                "VC","FE","FQ","NL","XB","HT","TE","BS","UM","YS",
                "FA","YF","RX","FB","FH","BF","5E","UC","YL","6L",
                "AF","LA","DS","TF","4C","VE","YC","1Z","HC","5M",
                "6A","ZF","FC","DE","CO","XX","6C","CM","FX","UD",
                "AC","FM","IE","6E","TS",
            };

            var newSecodaryBenefits = secondaryBenefits.Intersect(hardCodedSecondaryBenefit).ToArray();             


            foreach (var t in plans)
            {
                var currentPlan = t.TrimEnd(',', ' ');
                foreach (var item in primaryBenefit)
                {                                       
                    benefitCodeResults.Add(new Benefit(caseNum, minEffDate, item.Trim(',', ' '), currentPlan, benfitCategory, levelOfCoverage, benefitGroup, 1));
                    benefitCodeResults.AddRange(newSecodaryBenefits.Select(secondBen => new Benefit(caseNum, minEffDate, secondBen.Trim(',', ' '), currentPlan, benfitCategory, levelOfCoverage, "FEE", 0)));
                }
                if (primaryBenefits.Length > 0) continue;
                foreach (var item in secondaryBenefits)
                {   
                var newLevelOfCoverage = levelOfCoverage.ToString().Select(c => Convert.ToInt32(c.ToString())).ToArray();
                    foreach (var i in newLevelOfCoverage)
                    {
                        benefitCodeResults.Add(new Benefit(caseNum, minEffDate, item.Trim(',', ' '), currentPlan, benfitCategory, i, "FEE", 0));
                    }
                }
            }            
        }
    }
}
