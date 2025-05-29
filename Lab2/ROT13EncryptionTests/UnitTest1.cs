using Microsoft.VisualStudio.TestTools.UnitTesting;
using ROT13Encryption;

namespace ROT13EncryptionTests
{
    [TestClass]
    public class Rot13Tests
    {
        [TestMethod]
        public void TestSimpleText()
        {
            string input = "hello world";
            string expected = "uryyb jbeyq";
            string actual = Rot13Program.Rot13(input);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestWithUpperCaseLetters()
        {
            string input = "Hello World";
            string expected = "Uryyb Jbeyq";
            string actual = Rot13Program.Rot13(input);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestWithNonAlphabetCharacters()
        {
            string input = "1234!@#$";
            string expected = "1234!@#$";
            string actual = Rot13Program.Rot13(input);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestMixedInput()
        {
            string input = "abc XYZ 123";
            string expected = "nop KLM 123";
            string actual = Rot13Program.Rot13(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
