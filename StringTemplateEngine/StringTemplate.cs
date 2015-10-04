using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ElementData = new Dictionary<String, Object>();
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
            String s = Template;

            foreach (KeyValuePair<String, Object> kvp in ElementData)
            {
                s = s.Replace(String.Format("<{0}>", kvp.Key), kvp.Value.ToString());
            }

            return s;
        }

        #endregion
    }
}
