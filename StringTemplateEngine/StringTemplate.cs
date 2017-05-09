using System;
using System.Collections.Generic;
using System.Text;

namespace StringTemplateEngine
{
    public class StringTemplate
    {
        #region Fields

        private String template;
        private Dictionary<String, Object> elementData;

        #endregion

        #region Constructors

        public StringTemplate(String template)
        {
            if (template == null)
            {
                throw new ArgumentNullException("template");
            }

            Template = template;
            ElementData = new Dictionary<String, Object>(StringComparer.InvariantCultureIgnoreCase);
        }

        #endregion

        #region Properties

        public String Template
        {
            get
            {
                return template;
            }
            private set
            {
                template = value;
            }
        }

        public Dictionary<String, Object> ElementData
        {
            get
            {
                return elementData;
            }
            private set
            {
                elementData = value;
            }
        }

        #endregion

        #region Methods

        public void Add(String element, Object value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (String.IsNullOrWhiteSpace(element))
            {
                throw new ArgumentException("The parameter 'element' cannot be an empty string.", "element");
            }

            if (element[0] == '<' && element[element.Length - 1] == '>')
            {
                element = element.Substring(1, element.Length - 2);
            }

            if (ElementData.ContainsKey(element))
            {
                throw new ArgumentException("Element has already been added.", "element");
            }
            else
            {
                ElementData.Add(element, value);
            }
        }

        public String Render()
        {
            TokenStream tokenStream = new TokenStream(template);

            StringBuilder sb = new StringBuilder();

            foreach (Token token in tokenStream.Tokens)
            {
                if (token.TokenType == TokenType.Element)
                {
                    if (ElementData.ContainsKey(token.Value))
                    {
                        sb.Append(ElementData[token.Value].ToString());
                    }
                    else
                    {
                        sb.Append("<" + token.Value + ">");
                    }
                }
                else if (token.TokenType == TokenType.StringLiteral)
                {
                    sb.Append(token.Value);
                }
                else
                {
                    throw new ArgumentException(String.Format("Unknonw TokenType {0}", token.TokenType.ToString()));
                }
            }

            return sb.ToString();
        }

        #endregion
    }
}
