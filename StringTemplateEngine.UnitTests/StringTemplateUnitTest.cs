﻿using System;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringTemplateEngine.UnitTests
{
    [TestClass]
    public class StringTemplateUnitTest
    {
        StringTemplate target;

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
        public void StringTemplateConstructorTemplateNullTest()
        {
            try
            {
                target = new StringTemplate(null);

                Assert.Fail("No exception thrown");
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("template", exception.ParamName);
            }
            catch
            {
                Assert.Fail("ArgumentNullException not thrown");
            }
        }

        [TestMethod]
        public void StringTemplateConstructorTemplateDefaultsTest()
        {
            target = new StringTemplate("test");

            Assert.IsNotNull(target.ElementData);
            Assert.AreEqual(0, target.ElementData.Count);
        }

        [TestMethod]
        public void StringTemplateRenderEmptyTemplateTest()
        {
            String excepted = String.Empty;

            target = new StringTemplate(excepted);

            Assert.AreEqual(excepted, target.Render());
        }

        [TestMethod]
        public void StringTemplateRenderWhitespaceTemplateTest()
        {
            String excepted = " ";

            target = new StringTemplate(excepted);

            Assert.AreEqual(excepted, target.Render());
        }

        [TestMethod]
        public void StringTemplateRenderNoElementTemplateTest()
        {
            String excepted = "testing";

            target = new StringTemplate(excepted);

            Assert.AreEqual(excepted, target.Render());
        }

        [TestMethod]
        public void StringTemplateRenderOneElementTemplateTest()
        {
            target = new StringTemplate("<test> two two");

            target.Add("test", "one");

            Assert.AreEqual("one two two", target.Render());
        }

        [TestMethod]
        public void StringTemplateRenderOneElementRepeatedTemplateTest()
        {
            target = new StringTemplate("one <test> <test>");

            target.Add("test", "two");

            Assert.AreEqual("one two two", target.Render());
        }

        [TestMethod]
        public void StringTemplateRenderTwoElementTemplateTest()
        {
            target = new StringTemplate("<test1> <test2> two");

            target.Add("test1", "one");
            target.Add("test2", "two");

            Assert.AreEqual("one two two", target.Render());
        }

        [TestMethod]
        public void StringTemplateRenderNoDataForElementTest()
        {
            target = new StringTemplate("<test> two two");

            target.Add("testing", "one");

            Assert.AreEqual("<test> two two", target.Render());
        }

        [TestMethod]
        public void StringTemplateRenderExtraElementDataTest()
        {
            target = new StringTemplate("<test> two two");

            target.Add("test", "one");
            target.Add("testing", "two");

            Assert.AreEqual("one two two", target.Render());
        }

        [TestMethod]
        public void StringTemplateAddElementNullTest()
        {
            target = new StringTemplate("test");

            try
            {
                target.Add(null, new Object());

                Assert.Fail("No exception thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("element", exception.ParamName);
            }
            catch
            {
                Assert.Fail("ArgumentException not thrown");
            }
        }

        [TestMethod]
        public void StringTemplateAddElementEmptyTest()
        {
            target = new StringTemplate("test");

            try
            {
                target.Add(String.Empty, new Object());

                Assert.Fail("No exception thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("element", exception.ParamName);
            }
            catch
            {
                Assert.Fail("ArgumentException not thrown");
            }
        }

        [TestMethod]
        public void StringTemplateAddElementWhitespaceTest()
        {
            target = new StringTemplate("test");

            try
            {
                target.Add(" ", new Object());

                Assert.Fail("No exception thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("The parameter 'element' cannot be an empty string.\r\nParameter name: element", exception.Message);
                Assert.AreEqual("element", exception.ParamName);
            }
            catch
            {
                Assert.Fail("ArgumentException not thrown");
            }
        }

        [TestMethod]
        public void StringTemplateAddValueNullTest()
        {
            target = new StringTemplate("test");

            try
            {
                target.Add("test", null);

                Assert.Fail("No exception thrown");
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("value", exception.ParamName);
            }
            catch
            {
                Assert.Fail("ArgumentNullException not thrown");
            }
        }

        [TestMethod]
        public void StringTemplateAddOneTest()
        {
            target = new StringTemplate(String.Empty);

            target.Add("test", "one");

            Assert.AreEqual(1, target.ElementData.Count);
            Assert.IsTrue(target.ElementData.ContainsKey("test"));
            Assert.AreEqual("one", target.ElementData["test"]);
        }

        [TestMethod]
        public void StringTemplateAddTwoSameValuesTest()
        {
            target = new StringTemplate(String.Empty);

            target.Add("test", "one");
            target.Add("testing", "one");

            Assert.AreEqual(2, target.ElementData.Count);
            Assert.IsTrue(target.ElementData.ContainsKey("test"));
            Assert.AreEqual("one", target.ElementData["test"]);
            Assert.IsTrue(target.ElementData.ContainsKey("testing"));
            Assert.AreEqual("one", target.ElementData["testing"]);
        }

        [TestMethod]
        public void StringTemplateAddTwoDifferentValuesTest()
        {
            target = new StringTemplate(String.Empty);

            target.Add("test", "one");
            target.Add("testing", "two");

            Assert.AreEqual(2, target.ElementData.Count);
            Assert.IsTrue(target.ElementData.ContainsKey("test"));
            Assert.AreEqual("one", target.ElementData["test"]);
            Assert.IsTrue(target.ElementData.ContainsKey("testing"));
            Assert.AreEqual("two", target.ElementData["testing"]);
        }

        [TestMethod]
        public void StringTemplatAddDuplicateSameValuesTest()
        {
            target = new StringTemplate(String.Empty);

            target.Add("test", "one");

            try
            {
                target.Add("test", "one");

                Assert.Fail("No exception thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Element has already been added.\r\nParameter name: element", exception.Message);
                Assert.AreEqual("element", exception.ParamName);
            }
            catch
            {
                Assert.Fail("ArgumentException not thrown");
            }
        }

        [TestMethod]
        public void StringTemplatAddDuplicateDifferentValuesTest()
        {
            target = new StringTemplate(String.Empty);

            target.Add("test", "one");

            try
            {
                target.Add("test", "two");

                Assert.Fail("No exception thrown");
            }
            catch (ArgumentException exception)
            {
                Assert.AreEqual("Element has already been added.\r\nParameter name: element", exception.Message);
                Assert.AreEqual("element", exception.ParamName);
            }
            catch
            {
                Assert.Fail("ArgumentException not thrown");
            }
        }
    }
}