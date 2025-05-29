using System;

namespace ROT13Encryption
{
    public class Rot13Program
    {
        public static string Rot13(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            char[] result = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (ch >= 'a' && ch <= 'z')
                {
                    result[i] = (char)('a' + (ch - 'a' + 13) % 26);
                }
                else if (ch >= 'A' && ch <= 'Z')
                {
                    result[i] = (char)('A' + (ch - 'A' + 13) % 26);
                }
                else
                {
                    result[i] = ch;
                }
            }
            return new string(result);
        }

        public static void Main(string[] args)
        {
            try
            {
                string input = Console.In.ReadToEnd();
                string output = Rot13(input);
                Console.Out.Write(output);
                Environment.ExitCode = 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Помилка: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
