using System;
using StringTemplateEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringTemplateEngine.UnitTests
{
    [TestClass]
    public class TokenStreamUnitTests
    {
        private TokenStream target;

        [TestInitialize()]
        public void TestInit()
        {
            target = new TokenStream(String.Empty);
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            target = null;
        }

        [TestMethod]
        public void TokenStreamUnitTestsPreconditions()
        {
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void TokenStreamContructorSourceNullTest()
        {
            try
            {
                target = new TokenStream(null);

                Assert.Fail("No exception thrown");
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("source", exception.ParamName);
            }
            catch
            {
                Assert.Fail("ArgumentNullException not thrown");
            }
        }

        [TestMethod]
        public void TokenStreamContructorTest()
        {
            String expected = "test";

            target = new TokenStream(expected);

            Assert.AreEqual(expected, target.Source);
        }

        [TestMethod]
        public void TokenStreamNoTokensTest()
        {
            target = new TokenStream(String.Empty);

            Assert.AreEqual(0, target.Tokens.Count);
        }

        
        [TestMethod]
        public void TokenStreamOneTokenTest1()
        {
            target = new TokenStream("one two two");

            Assert.AreEqual(1, target.Tokens.Count);
        }

        [TestMethod]
        public void TokenStreamOneTokenTest2()
        {
            target = new TokenStream("<test>");

            Assert.AreEqual(1, target.Tokens.Count);
        }

        [TestMethod]
        public void TokenStreamOneElementStartTest()
        {
            target = new TokenStream("<test> two two");

            Assert.AreEqual(2, target.Tokens.Count);
        }

        [TestMethod]
        public void TokenStreamOneElementMiddleTest()
        {
            target = new TokenStream("one <test> two");

            Assert.AreEqual(3, target.Tokens.Count);
        }

        [TestMethod]
        public void TokenStreamOneElementEndTest()
        {
            target = new TokenStream("one two <test>");

            Assert.AreEqual(2, target.Tokens.Count);
        }

        [TestMethod]
        public void TokenStreamTwoElementsTest()
        {
            target = new TokenStream("<one><two>test");

            Assert.AreEqual(3, target.Tokens.Count);
        }
    }
}
