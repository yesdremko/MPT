using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ROT13Encryption;

namespace ROT13EncryptionTest
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("hello world", "uryyb jbeyq")]
        [DataRow("", "")]
        [DataRow("abcdefghijklmnopqrstuvwxyz", "nopqrstuvwxyzabcdefghijklm")]
        [DataRow("a z", "n m")]
        public void Encrypt_ValidInput_ReturnsExpected(string input, string expected)
        {
            string result = Rot13.Encrypt(input);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("Hello")]        // uppercase H
        [DataRow("hello_world")]  // underscore
        [DataRow("123")]          // digits
        [DataRow("hello\nworld")] // newline inside
        public void Encrypt_InvalidCharacters_ThrowsArgumentException(string input)
        {
            Assert.ThrowsException<ArgumentException>(() => Rot13.Encrypt(input));
        }

        [TestMethod]
        public void Main_ValidStdIn_WritesToStdOutAndReturnsZero()
        {
            // Arrange
            var originalIn  = Console.In;
            var originalOut = Console.Out;
            var originalErr = Console.Error;

            Console.SetIn(new StringReader("abc xyz\n"));
            var swOut = new StringWriter();
            var swErr = new StringWriter();
            Console.SetOut(swOut);
            Console.SetError(swErr);

            // Act
            int exitCode = Program.Main(Array.Empty<string>());

            // Restore
            Console.SetIn(originalIn);
            Console.SetOut(originalOut);
            Console.SetError(originalErr);

            // Assert
            Assert.AreEqual(0, exitCode);
            Assert.AreEqual("nop klm", swOut.ToString());
            Assert.AreEqual(string.Empty, swErr.ToString());
        }

        [TestMethod]
        public void Main_InvalidStdIn_WritesErrorAndReturnsNonZero()
        {
            // Arrange
            var originalIn  = Console.In;
            var originalOut = Console.Out;
            var originalErr = Console.Error;

            Console.SetIn(new StringReader("bad_input!"));
            var swOut = new StringWriter();
            var swErr = new StringWriter();
            Console.SetOut(swOut);
            Console.SetError(swErr);

            // Act
            int exitCode = Program.Main(Array.Empty<string>());

            // Restore
            Console.SetIn(originalIn);
            Console.SetOut(originalOut);
            Console.SetError(originalErr);

            // Assert
            Assert.AreNotEqual(0, exitCode);
            Assert.AreEqual(string.Empty, swOut.ToString());
            StringAssert.Contains(swErr.ToString(), "Invalid character");
        }
    }
}