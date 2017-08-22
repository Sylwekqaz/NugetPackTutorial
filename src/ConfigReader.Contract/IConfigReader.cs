using System.Collections.Generic;

namespace ConfigReader.Contract
{
    public interface IConfigReader : IEnumerable<KeyValuePair<string,string>>
    {
        T GetValue<T>(string key);
    }
}
