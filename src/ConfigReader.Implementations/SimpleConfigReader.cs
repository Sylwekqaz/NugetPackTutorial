using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ConfigReader.Contract;
using ConfigReader.Helper;

namespace ConfigReader.Implementations
{
    public class SimpleConfigReader : IConfigReader
    {
        private readonly Dictionary<string, string> _values;

        public SimpleConfigReader(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Config file not found", path);

            _values = ParseConfig(path);
        }

        public T GetValue<T>(string key)
        {
            return GenericParser.Parse<T>(_values[key]);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private static Dictionary<string, string> ParseConfig(string path)
        {
            var values = new Dictionary<string, string>();
            foreach (var line in File.ReadAllLines(path))
            {
                var separatorIndex = line.IndexOf(":", StringComparison.Ordinal);
                if (separatorIndex <= 0) continue;
                values.Add(line.Substring(0, separatorIndex), line.Substring(separatorIndex + 1));
            }
            return values;
        }
    }
}