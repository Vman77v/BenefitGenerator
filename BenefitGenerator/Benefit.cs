using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitGenerator
{
    internal class Benefit
    {
        public string CaseNum;
        public string PlanNum;
        public string BenefitCategory;
        public string BenefitGroup;
        public string BenefitCode;
        public DateTime EnableDate;
        public DateTime? DisableDate = null;
        public int LevelOfCoverage;
        public int TermOtherCoverage;
        public int CoverdClmts = 0;
        public string FormatId;

        public Benefit(string caseNum, DateTime minEffDate, string benefitCode, string currentPlan, string benfitCategory, int levelOfCoverage, string benefitGroup, int termOtherCoverage, string formatId)
        {
            CaseNum = caseNum;
            EnableDate = minEffDate;
            BenefitCode = benefitCode;
            PlanNum = currentPlan;
            BenefitCategory = benfitCategory;
            BenefitGroup = benefitGroup;            
            LevelOfCoverage = levelOfCoverage;
            TermOtherCoverage = termOtherCoverage;
            FormatId = formatId;
        }       
    }
}
