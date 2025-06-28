using System;
using System.IO;

namespace ROT13Encryption
{
    public static class Rot13
    {
        public static string Encrypt(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var output = new System.Text.StringBuilder(input.Length);
            foreach (char c in input)
            {
                if (c == ' ')
                {
                    output.Append(' ');
                }
                else if (c >= 'a' && c <= 'z')
                {
                    // Rotate within 'a'..'z'
                    char shifted = (char)('a' + (c - 'a' + 13) % 26);
                    output.Append(shifted);
                }
                else
                {
                    throw new ArgumentException($"Invalid character: '{c}'");
                }
            }
            return output.ToString();
        }
    }

    public class Program
    {
        public static int Main(string[] args)
        {
            string input;
            try
            {
                input = Console.In.ReadToEnd();
                input = input.TrimEnd('\r', '\n');
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error reading input: {ex.Message}");
                return 1;
            }

            try
            {
                string encrypted = Rot13.Encrypt(input);
                Console.Out.Write(encrypted);
                return 0;
            }
            catch (ArgumentException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 1;
            }
        }
    }
}