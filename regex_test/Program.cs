using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using AcmeCorp.Training.Services;

namespace regex_test
{
    class Program
    {
        static void Main(string[] args)
        {
            LegacyObjectMetadataProvider.V7 metadataProviderVersion = new LegacyObjectMetadataProvider.V7();

            string metadata = metadataProviderVersion.ProvideMetadata();

            Console.WriteLine($"Getting product code from {metadata}");

            string code = GetCode(metadata);

            Console.WriteLine($"Recognized code as [{code}]");

            ObjectCodeValidator validator = new ObjectCodeValidator();

            validator.AssertCodeIsValid(code, metadata);

            Console.WriteLine($"Code [{code}] is valid");

            Console.ReadKey();
        }

        static string GetCode(string metadata)
        {
            string pattern = @"(((_|~|<Code>)[A-Z0-9]{3,7})(~|<))";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(metadata);
            if (metadata.Contains("<Code>"))
            {
                return matches[0].ToString().Replace("_", "").Replace("~", "").Replace("<Code>", "").Replace("<", "").Replace("PL", "").Replace("BG", "").Replace("EL", "");
            }
            else if (metadata.Contains("ItemType"))
            {
                return matches[0].ToString().Replace("_", "").Replace("~", "").Replace("<Code>", "").Replace("<", "");
            }
            else
            {
                return rgx.Matches(metadata)[1].ToString().Replace("_", "").Replace("~", "");
            }
        }
    }

}
