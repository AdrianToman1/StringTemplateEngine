using System;
using StringTemplateEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringTemplateEngine.UnitTests
{
    [TestClass]
    public class StringExtensionsUnitTests
    {
        String target;

        [TestInitialize()]
        public void TestInit()
        {
            //target = new StringTemplate();
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            target = null;
        }

        [TestMethod]
        public void StringReplaceSNullTest()
        {
            try
            {
                target = StringExtensions.Replace(null, "test", "test", StringComparison.InvariantCultureIgnoreCase);

                Assert.Fail("No exception thrown");
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("s", exception.ParamName);
            }
            catch
            {
                Assert.Fail("ArgumentNullException not thrown");
            }
        }

        [TestMethod]
        public void StringReplaceStringEmptyTest()
        {
            target = String.Empty;

            Assert.AreEqual(String.Empty, target.Replace("<test>", "test", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void StringReplaceOldValueNullTest()
        {
            try
            {
                target = StringExtensions.Replace("test", null, "test", StringComparison.InvariantCultureIgnoreCase);

                Assert.Fail("No exception thrown");
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("oldValue", exception.ParamName);
            }
            catch
            {
                Assert.Fail("ArgumentNullException not thrown");
            }
        }

        [TestMethod]
        public void StringReplaceOldValueEmptyTest()
        {
            target = "one two";

            try
            {
                target.Replace("", "test", StringComparison.InvariantCultureIgnoreCase);

                Assert.Fail("No exception thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("oldValue", exception.ParamName);
                StringAssert.StartsWith(exception.Message, "String cannot be of zero length.");
            }
            catch
            {
                Assert.Fail("ArgumentException not thrown");
            }
        }

        [TestMethod]
        public void StringReplaceTest()
        {
            target = "<test> two";

            Assert.AreEqual("one two", target.Replace("<test>", "one", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void StringReplaceMatchAtStartTest()
        {
            target = "<test> two three";

            Assert.AreEqual("one two three", target.Replace("<test>", "one", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void StringReplaceMatchInMiddleTest()
        {
            target = "one <test> three";

            Assert.AreEqual("one two three", target.Replace("<test>", "two", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void StringReplaceMatchAtEndTest()
        {
            target = "one two <test>";

            Assert.AreEqual("one two three", target.Replace("<test>", "three", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void StringReplaceCaseInsensitiveTest1()
        {
            target = "<TEST> two";

            Assert.AreEqual("one two", target.Replace("<test>", "one", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void StringReplaceCaseInsensitiveTest2()
        {
            target = "<test> two";

            Assert.AreEqual("one two", target.Replace("<TEST>", "one", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void StringReplaceNoMatchesTest()
        {
            target = "one two";

            Assert.AreEqual("one two", target.Replace("<test>", "test", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void StringReplaceMultipleMatchesTest()
        {
            target = "one <test> <test>";

            Assert.AreEqual("one two two", target.Replace("<test>", "two", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
