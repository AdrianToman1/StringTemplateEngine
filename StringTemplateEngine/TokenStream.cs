using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTemplateEngine
{
    public class TokenStream
    {
        #region Fields

        private String source;
        private List<Token> tokens;

        #endregion

        #region Constructors

        public TokenStream(String source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            Source = source;
            Tokens = new List<Token>();

            Advance();
        }

        #endregion

        #region Properties

        public String Source
        {
            get
            {
                return source;
            }
            private set
            {
                source = value;
            }
        }

        public List<Token> Tokens
        {
            get
            {
                return tokens;
            }
            private set
            {
                tokens = value;
            }
        }

        #endregion

        #region Methods

        private void Advance()
        {
            Tokens.Clear();


                using (StringReader reader = new StringReader(Source))
                {
                    Int32 i = reader.Read();

                    while (i >= 0)
                    {
                        Char nextChar = (Char)i;

                        if (IsElementStart(nextChar))
                        {
                            // Element

                            String s = nextChar.ToString();
                            s += EatUpTo(reader, '>');

                            if (reader.Peek() >= 0)
                            {
                                nextChar = (Char)reader.Read();
                                s += nextChar.ToString();
                            }

                            AddNewToken(TokenType.Element, s);
                        }
                        else
                        {
                            // Literal string constant

                            String s = nextChar.ToString();
                            s += EatUpTo(reader, '<');

                            AddNewToken(TokenType.StringLiteral, s);
                        }

                        i = reader.Read();
                    }
                }
        }

        private Boolean IsElementStart(Char c)
        {
            return c.Equals('<');
        }

        //private Boolean IsElementEnd(Char c)
        //{
        //    return c.Equals('>');
        //}

        private String EatUpTo(StringReader reader, Char endChar)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            String s = String.Empty;
            Int32 i = reader.Peek();
            Char nextChar = (Char) i;

            while (i >= 0 && !nextChar.Equals(endChar))
            {
                reader.Read();

                s += nextChar.ToString();

                i = reader.Peek();
                nextChar = (Char)i;
            }

            return s;
        }

        private Token AddNewToken(TokenType tokenType, String value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (value[0] == '<' && value[value.Length - 1] == '>')
            {
                value = value.Substring(1, value.Length - 2);
            }

            Token token = new Token(tokenType, value);

            Tokens.Add(token);

            return token;
        }

        #endregion
    }
}
