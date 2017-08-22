using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

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
            };

            return benefitDictionary;
        }

        private static void Main(string[] args)
        {

            var benfitCategory = "MM";
            var primaryBenefits = "EE, ES, EC, EF";
            var secondaeryBenefits = "6A, 6B, AE, AG, BE, FB, FE, HT, P1, QT, UR, XP, XX";
            var plans = "HDHP, PPO";

            BenefitBuilder.BuildPrimaryBenefit(primaryBenefits, benfitCategory, plans, secondaeryBenefits, BenefitDictionary);
        }

        
    }
}
