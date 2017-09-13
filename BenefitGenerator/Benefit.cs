using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitGenerator
{
    internal class Benefit
    {      
        public string CaseNum = "0118002";
        public string PlanNum;
        public string BenefitCategory;
        public string BenefitGroup;
        public string BenefitCode;
        public DateTime EnableDate = new DateTime(2018, 01, 01);
        public DateTime? DisableDate = null;
        public int LevelOfCoverage;
        public int TermOtherCoverage;
        public int CoverdClmts = 0;

        public Benefit(string benefitCode, string currentPlan, string benfitCategory, int levelOfCoverage, string benefitGroup, int termOtherCoverage)
        {
            BenefitCode = benefitCode;
            PlanNum = currentPlan;
            BenefitCategory = benfitCategory;
            BenefitGroup = benefitGroup;            
            LevelOfCoverage = levelOfCoverage;
            TermOtherCoverage = termOtherCoverage;            
        }       
    }
}
