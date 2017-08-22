using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BenefitGenerator
{
    class FileWriter
    {
        internal static void WriteFile(List<Benefit> benefitCodeResults)
        {
            TextWriter tw = new StreamWriter("C:\\TEMP\\BenefitCodes.txt");

            foreach (var benefit in benefitCodeResults)
            {
                tw.WriteLine($"1" +
                             $"\t{benefit.CaseNum}" +
                             $"\t{benefit.PlanNum}" +
                             $"\t{benefit.BenefitCategory}" +
                             $"\t{benefit.BenefitGroup}" +
                             $"\t{benefit.LevelOfCoverage}" +
                             $"\t{benefit.BenefitCode}" +
                             $"\t{benefit.EnableDate}" +
                             $"\t{benefit.DisableDate}" +
                             $"\t{benefit.TermOtherCoverage}" +
                             $"\t{benefit.CoverdClmts}"                                                                                                                                          

                    );    
            }    
            tw.Close();
        }
    }
}
