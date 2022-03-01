using System.Text;

namespace CsharpDemo.Common
{
    public class JsonHelper
    {
        public static string Compress(string json)
        {
            StringBuilder sb = new StringBuilder();
            using (StringReader reader = new StringReader(json))
            {
                int ch = -1, lastch = -1;
                bool isQuoteStart = false;
                while ((ch = reader.Read()) > -1)
                {
                    if ((char)lastch != '\\' && (char)ch == '\"')
                    {
                        isQuoteStart = !isQuoteStart;
                    }

                    if (!char.IsWhiteSpace((char)ch) || isQuoteStart)
                    {
                        sb.Append((char)ch);
                    }

                    lastch = ch;
                }
            }

            return sb.ToString();
        }
    }
}
