using System.CommandLine;
using System.CommandLine.Parsing;
using HashCrackerLibrary;

namespace HashCrackerCLI;

class Program
{
    static int Main(string[] args)
    {
        Option<string> dictionaryOption = new("--dictionary");

        RootCommand rootCommand = new("HashCrackerCLI");
        rootCommand.Options.Add(dictionaryOption);

        ParseResult parseResult = rootCommand.Parse(args);

        if (parseResult.Errors.Count > 0)
        {
            foreach (ParseError parseError in parseResult.Errors)
                Console.Error.WriteLine(parseError.Message);
            return 1;
        }

        if (parseResult.GetValue(dictionaryOption) is string input)
        {
            GetHashType getHashType = new GetHashType();
            HashTyp hashtyp = getHashType.execute(input);

            BruteForceDictionary bruteForceDictionary = new BruteForceDictionary();
            string result = bruteForceDictionary.execute(input, hashtyp);

            Console.WriteLine("Hash: " + hashtyp);
            Console.WriteLine("Result: " + result);
            return 0;
        }

        Console.Error.WriteLine("Please use --dictionary <hash>");
        return 1;
    }
}
