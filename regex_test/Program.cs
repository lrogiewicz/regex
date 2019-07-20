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
            //LegacyObjectMetadataProvider.V7 metadataProviderVersion = new LegacyObjectMetadataProvider.V7();

            //string metadata = metadataProviderVersion.ProvideMetadata();

            //Console.WriteLine($"Getting product code from {metadata}");

            //string code = GetCode(metadata);

            //Console.WriteLine($"Recognized code as [{code}]");

            //ObjectCodeValidator validator = new ObjectCodeValidator();

            //validator.AssertCodeIsValid(code, metadata);

            //Console.WriteLine($"Code [{code}] is valid");

            //Console.ReadKey();

            int iterations = 10000;

            for (int i = 1; i <= iterations; i++)
            {
                LegacyObjectMetadataProvider.V1 metadataProviderVersion = new LegacyObjectMetadataProvider.V1();
                string metadata = metadataProviderVersion.ProvideMetadata();
                string code = GetCode(metadata);
                ObjectCodeValidator validator = new ObjectCodeValidator();
                validator.AssertCodeIsValid(code, metadata);
                Console.WriteLine($"Code [{code}] is valid");
            }
            for (int i = 1; i <= iterations; i++)
            {
                LegacyObjectMetadataProvider.V2 metadataProviderVersion = new LegacyObjectMetadataProvider.V2();
                string metadata = metadataProviderVersion.ProvideMetadata();
                string code = GetCode(metadata);
                ObjectCodeValidator validator = new ObjectCodeValidator();
                validator.AssertCodeIsValid(code, metadata);
                Console.WriteLine($"Code [{code}] is valid");
            }
            for (int i = 1; i <= iterations; i++)
            {
                LegacyObjectMetadataProvider.V3 metadataProviderVersion = new LegacyObjectMetadataProvider.V3();
                string metadata = metadataProviderVersion.ProvideMetadata();
                string code = GetCode(metadata);
                ObjectCodeValidator validator = new ObjectCodeValidator();
                validator.AssertCodeIsValid(code, metadata);
                Console.WriteLine($"Code [{code}] is valid");
            }
            for (int i = 1; i <= iterations; i++)
            {
                LegacyObjectMetadataProvider.V4 metadataProviderVersion = new LegacyObjectMetadataProvider.V4();
                string metadata = metadataProviderVersion.ProvideMetadata();
                string code = GetCode(metadata);
                ObjectCodeValidator validator = new ObjectCodeValidator();
                validator.AssertCodeIsValid(code, metadata);
                Console.WriteLine($"Code [{code}] is valid");
            }
            for (int i = 1; i <= iterations; i++)
            {
                LegacyObjectMetadataProvider.V5 metadataProviderVersion = new LegacyObjectMetadataProvider.V5();
                string metadata = metadataProviderVersion.ProvideMetadata();
                string code = GetCode(metadata);
                ObjectCodeValidator validator = new ObjectCodeValidator();
                validator.AssertCodeIsValid(code, metadata);
                Console.WriteLine($"Code [{code}] is valid");
            }
            for (int i = 1; i <= iterations; i++)
            {
                LegacyObjectMetadataProvider.V6 metadataProviderVersion = new LegacyObjectMetadataProvider.V6();
                string metadata = metadataProviderVersion.ProvideMetadata();
                string code = GetCode(metadata);
                ObjectCodeValidator validator = new ObjectCodeValidator();
                validator.AssertCodeIsValid(code, metadata);
                Console.WriteLine($"Code [{code}] is valid");
            }
            for (int i = 1; i <= iterations; i++)
            {
                LegacyObjectMetadataProvider.V7 metadataProviderVersion = new LegacyObjectMetadataProvider.V7();
                string metadata = metadataProviderVersion.ProvideMetadata();
                string code = GetCode(metadata);
                ObjectCodeValidator validator = new ObjectCodeValidator();
                validator.AssertCodeIsValid(code, metadata);
                Console.WriteLine($"Code [{code}] is valid");
            }
            Console.ReadKey();
        }

        static string GetCode(string metadata)
        {
            string pattern = @"(((_|~|<Code>)[A-Z0-9]{3,7})(~|<))";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(metadata);
            if (metadata.Contains("<Code>"))
            {
                string almostSureResult = matches[0].ToString().Replace("_", "").Replace("~", "").Replace("<Code>", "").Replace("<", "");

                if (metadata.Contains("<Market>PL") || metadata.Contains("<Market>BG") || metadata.Contains("<Market>EL"))
                {
                    return almostSureResult.Substring(0,almostSureResult.Length-2);
                }
                else
                {
                    return almostSureResult;
                }
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
