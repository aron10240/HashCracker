using System.CommandLine;
using System.CommandLine.Parsing;
using HashCrackerLibrary;

namespace HashCrackerCLI;

class Program
{
    static int Main(string[] args)
    {
        Option<string> dictionaryOption = new("--dictionary");
        Option<string> simpleOption = new("--simple");

        RootCommand rootCommand = new("HashCrackerCLI");
        rootCommand.Options.Add(dictionaryOption);
        rootCommand.Options.Add(simpleOption);

        ParseResult parseResult = rootCommand.Parse(args);

        if (parseResult.Errors.Count > 0)
        {
            foreach (ParseError parseError in parseResult.Errors)
                Console.Error.WriteLine(parseError.Message);
            return 1;
        }

        if (parseResult.GetValue(dictionaryOption) is string inputDictionary)
        {
            GetHashType getHashType = new GetHashType();
            HashTyp hashtyp = getHashType.execute(inputDictionary);

            BruteForceDictionary bruteForceDictionary = new BruteForceDictionary();
            string result = bruteForceDictionary.execute(inputDictionary , hashtyp);

            Console.WriteLine("Hash: " + hashtyp);
            Console.WriteLine("Result: " + result);
            return 0;
        }

        else if (parseResult.GetValue(simpleOption) is string inputSimple)
        {
            GetHashType getHashType = new GetHashType();
            HashTyp hashtyp = getHashType.execute(inputSimple);

            BruteForceSimple bruteForceSimple = new BruteForceSimple(inputSimple, hashtyp);
            string result = bruteForceSimple.BruteForce();

            Console.WriteLine("Hash: " + hashtyp);
            Console.WriteLine("Result: " + result);
            return 0;
        }

        Console.Error.WriteLine("Please use --dictionary <hash> or --simple <hash> ");
        return 1;
    }
}
