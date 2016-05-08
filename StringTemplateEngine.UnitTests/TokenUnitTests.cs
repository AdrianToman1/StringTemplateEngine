using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringTemplateEngine.UnitTests
{
    [TestClass]
    public class TokenUnitTests
    {
        private Token target;

        [TestInitialize()]
        public void TestInit()
        {
            target = new Token(TokenType.StringLiteral, "test");
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            target = null;
        }

        [TestMethod]
        public void TokenUnitTestsPreconditions()
        {
            Assert.IsNotNull(target);
        }

        #region Constructor Tests

        [TestMethod]
        public void TokenConstructorValueNullTest()
        {
            try
            {
                target = new Token(TokenType.StringLiteral, null);

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
        public void TokenConstructorTest()
        {
            TokenType expectedTokenType = TokenType.StringLiteral;
            String expectedValue = "test";

            target = new Token(expectedTokenType, expectedValue);

            Assert.AreEqual(expectedTokenType, target.TokenType);
            Assert.AreEqual(expectedValue, target.Value);
        }

        #endregion

        #region Equals Tests

        [TestMethod()]
        public void TokenEqualsNullTest()
        {
            Assert.IsFalse(target.Equals(null));
        }

        [TestMethod()]
        public void TokenEqualsAnotherClassTest()
        {
            Assert.IsFalse(target.Equals(new Object()));
        }

        [TestMethod()]
        public void TokenNotEqualTest()
        {
            Assert.IsFalse(target.Equals(new Token(TokenType.Element, String.Empty)));
        }

        [TestMethod()]
        public void TokenEqualsTest1()
        {
            Assert.IsFalse(target.Equals(new Token(target.TokenType, String.Empty)));
        }

        [TestMethod()]
        public void TokenEqualsTest2()
        {
            Assert.IsFalse(target.Equals(new Token(TokenType.Element, target.Value)));
        }
        
        [TestMethod()]
        public void TokenSameTest()
        {
            Assert.IsTrue(target.Equals(target));
        }

        [TestMethod()]
        public void TokenEqualsTest()
        {
            Assert.IsTrue(target.Equals(new Token(target.TokenType, target.Value)));
        }

        [TestMethod()]
        public void TokenEqualsCaseInsensitiveTest()
        {
            Assert.IsFalse(target.Equals(new Token(target.TokenType, target.Value.ToUpper())));
        }

        #endregion

        #region GetHashCode Tests

        [TestMethod]
        public void TokenGethashCodeTest()
        {
            String value = "test";

            target = new Token(TokenType.StringLiteral, value);

            Assert.AreEqual(value.GetHashCode(), target.GetHashCode());
        }

        #endregion
    }
}
