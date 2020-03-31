using System.Collections;
using System.Text;

namespace VK.Application.Builders
{
    public class ParamsBuilder
    {
        protected const string Amp = "&";
        private Hashtable Builder = new Hashtable();

        public void AddParams(string key, string value)
        {
            Builder.Add(key, value);
        }

        public override string ToString()
        {
            StringBuilder builderParams = new StringBuilder();
            foreach (DictionaryEntry item in Builder)
            {
                builderParams.Append(item.Key).Append(item.Value).Append(Amp);
            }

            return builderParams.ToString();
        }
    }
}