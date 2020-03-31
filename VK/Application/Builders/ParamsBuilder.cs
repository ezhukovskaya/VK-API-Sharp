using System.Collections;
using System.Text;

namespace VK.Application.Builders
{
    public class ParamsBuilder
    {
        private const string Amp = "&";
        private readonly Hashtable _builder = new Hashtable();

        public void AddParams(string key, string value)
        {
            _builder.Add(key, value);
        }

        public override string ToString()
        {
            StringBuilder builderParams = new StringBuilder();
            foreach (DictionaryEntry item in _builder)
            {
                builderParams.Append(item.Key).Append(item.Value).Append(Amp);
            }

            return builderParams.ToString();
        }
    }
}