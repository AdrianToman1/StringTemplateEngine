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
    }
}
