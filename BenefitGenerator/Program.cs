using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BenefitGenerator
{
    internal static class Program
    {
        private static readonly Dictionary<string, int> BenefitDictionary;


        static Program()
        {
            BenefitDictionary = CreateBenefitWhiteList(); 
        }

        private static Dictionary<string, int> CreateBenefitWhiteList()
        {
            var benefitDictionary = new Dictionary<string, int>
            {
                ["EE"] = 1,
                ["ES"] = 2,
                ["EC"] = 4,
                ["EF"] = 5,
                ["EH"] = 3,
                ["EN"] = 9,
                ["DE"] = 1,
                ["DS"] = 2,
                ["DC"] = 4,
                ["DF"] = 5,
                ["VE"] = 1,
                ["VS"] = 2,
                ["VC"] = 4,
                ["VF"] = 5,
                ["EMP"] = 1,["ESP"] = 2,["E1D"] = 3,["ECH"] = 4,["FAM"] = 5, //Main Levels of coverage
                ["TWO"] = 0,                
                ["E3D"] = 3,
                ["SPO"] = 6,["E5D"] = 6,
                ["CHD"] = 7,["E2D"] = 7,
                ["E7D"] = 8,["SPC"] = 8,
                ["E8D"] = 8,["E6D"] = 9
            };

            return benefitDictionary;
        }

        private static void Main(string[] args)
        {                       

            var list = new List<string>();
            var benefitCodeResults = new List<Benefit>();
            using (var reader = new StreamReader("C:\\TEMP\\Benefits.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line); // Add to list.
                    Console.WriteLine(line); // Write to console.
                }
            }

            var hardCodedPrimaryBenefits = new[]
            {
                //Medical
                "EE","EC","ES","EF",
                "EH", "EN",
                "XS","XK","XF","XP",
                //Dental
                "DE","DC","DS","DF",
                "TE","TC","TS","TF",
                //Vision
                "VE","VC","VS","VF",
                "OE","OC","OS","OF",
                //Life
                "AK"
            };

            foreach (var lineItem in list)
            {
                if (string.IsNullOrWhiteSpace(lineItem)) continue;

                var specificItem = lineItem.Split('\t');

            //Step 1                               
                var benefitCodes = specificItem[0].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);                

                var primaryBenefits = benefitCodes.Intersect(hardCodedPrimaryBenefits);
                var secondaryBenefits = benefitCodes.Except(primaryBenefits); 

            //Step 2
                var plans = specificItem[2].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            //Step 3
                var benefitCategory = specificItem[3];              

                //Step 4
                var levelOfCoverage = BenefitDictionary[specificItem[4].TrimEnd(',', ' ')];                

                //Main Builder Method
                BenefitBuilder.BuildBenefit(primaryBenefits.ToArray(), secondaryBenefits.ToArray(), benefitCategory, plans, BenefitDictionary, benefitCodeResults, levelOfCoverage);
            }
            FileWriter.WriteFile(benefitCodeResults);
        }       
    }
}
