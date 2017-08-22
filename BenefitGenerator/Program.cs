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
                ["SPO"] = 6,
                ["E5D"] = 6,
                ["CHD"] = 7,
                ["E2D"] = 7,
                ["E7D"] = 8,
                ["SPC"] = 8,
                ["E8D"] = 8,
                ["E6D"] = 9
            };

            return benefitDictionary;
        }

        private static void Main(string[] args)
        {
            //var inputFile = Environment.CurrentDirectory = "Benefit.txt";                   

            List<string> list = new List<string>();
            var benefitCodeResults = new List<Benefit>();
            using (StreamReader reader = new StreamReader("C:\\TEMP\\Benefit.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line); // Add to list.
                    Console.WriteLine(line); // Write to console.
                }
            }

            foreach (var lineItem in list)
            {
                var specificItem = lineItem.Split('\t');
                var benefitCategory = specificItem[0];
                if (benefitCategory.ToUpper() == "MEDICAL") benefitCategory = "MM";
                else if (benefitCategory.ToUpper() == "DENTAL") benefitCategory = "DEN";
                else benefitCategory = "VIS";

                //need to split between primary and secondary
                var benefitCodes = specificItem[1].Split(',');
                //find a better way to pluck out primary benefits
                var hardCodedPrimaryBenefits = new string[]
                {
                    "EE","EC","ES","EF","DE","DC","DS","DF","VE","VC","VS","VF"
                };

                var primaryBenefits = benefitCodes.Intersect(hardCodedPrimaryBenefits);

                var secondaryBenefits = benefitCodes.Except(primaryBenefits); 

                var plans = specificItem[2].Split();
                var levelOfCoverage = specificItem[3];

                BenefitBuilder.BuildBenefit(primaryBenefits.ToArray(), benefitCategory, plans, secondaryBenefits.ToArray(), BenefitDictionary, benefitCodeResults);
            }
            FileWriter.WriteFile(benefitCodeResults);
        }
    }
}
