using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TaskSolution.Class;
using TaskSolution.Interface;

namespace TaskSolution.Tests
{
    [TestClass]
    public class UnitTestTask
    {
        [TestMethod]
        public void TestMethodCheckInputOfLower_ShouldReturnTrue()
        {
            ICustomIO custom = new CustomIOConsole();
            var startApplication = new StartApplication(custom);

            string word = "abc";

            var result = startApplication.CheckString(word);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethodCheckInputOfLower_ShouldReturnFalse()
        {
            ICustomIO custom = new CustomIOConsole();
            string word = "Abc";

            var startApplication = new StartApplication(custom);
            var result = startApplication.CheckString(word);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethodCheckInputOfNumbers_ShouldReturnFalse()
        {
            ICustomIO custom = new CustomIOConsole();
            string word = "Abc1";

            var startApplication = new StartApplication(custom);
            var result = startApplication.CheckString(word);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethodShowAnagramPairs_ShouldReturnEqual()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            ICustomIO custom = new CustomIOConsole();
            Anagram anagram = new Anagram(custom);
            anagram.ShowAnagramPairs("abc");

            string expected = "abc\r\n" + "acb\r\n" + "bac\r\n" + "bca\r\n" + "cab\r\n" + "cba\r\n";

            Assert.AreEqual(string.Format(expected, Environment.NewLine), output.ToString());
        }

        [TestMethod]
        public void TestMethodGetCountOfAnagram_ShouldReturnEqual()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            ICustomIO custom = new CustomIOConsole();
            Anagram anagram = new Anagram(custom);
            anagram.GetCountOfAnagram("abc");

            string expected = "6\r\n";

            Assert.AreEqual(string.Format(expected, Environment.NewLine), output.ToString());
        }
    }
}
