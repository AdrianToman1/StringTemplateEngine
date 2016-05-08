using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTemplateEngine
{
    public class Token
    {
        #region Fields

        private TokenType tokenType;
        private String value;

        #endregion

        #region Constructor

        public Token(TokenType tokenType, String value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            TokenType = tokenType;
            Value = value;
        }

        #endregion

        #region Properties

        public TokenType TokenType
        {
            get
            {
                return tokenType;
            }
            private set
            {
                tokenType = value;
            }
        }

        public String Value
        {
            get
            {
                return value;
            }
            private set
            {
                this.value = value;
            }
        }

        #endregion

        #region Methods

        public override Boolean Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Token other = obj as Token;

                return TokenType.Equals(other.TokenType) && Value.Equals(other.Value);
            }
        }

        public override Int32 GetHashCode()
        {
            return Value.GetHashCode();
        }

        #endregion

    }
}
