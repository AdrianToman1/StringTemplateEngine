using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTemplateEngine
{
    public class TokenStream
    {
        #region Fields

        private String source;

        #endregion

        #region Constructors

        public TokenStream(String source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            Source = source;
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

        #endregion
    }
}
