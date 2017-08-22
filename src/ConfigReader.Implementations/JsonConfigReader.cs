using System.Collections;
using System.Collections.Generic;
using System.IO;
using ConfigReader.Contract;
using Newtonsoft.Json.Linq;

namespace ConfigReader.Implementations
{
    public class JsonConfigReader : IConfigReader
    {
        private readonly JObject _jObject;


        public JsonConfigReader(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Config file not found", path);

            _jObject = JObject.Parse(File.ReadAllText(path));
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            foreach (var valuePair in _jObject)
            {
                yield return new KeyValuePair<string, string>(valuePair.Key, valuePair.Value.ToObject<string>());
            }
        }

        public T GetValue<T>(string key)
        {
            return _jObject[key].ToObject<T>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}