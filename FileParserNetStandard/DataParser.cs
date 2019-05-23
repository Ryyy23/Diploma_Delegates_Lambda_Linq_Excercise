using System.Collections.Generic;
using System.Linq;

namespace FileParserNetStandard {
    public class DataParser {
        public DataParser() { }

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data) {
            List<List<string>> ListOfListStrings = new List<List<string>>();
            foreach (var line in data)
            {
                List<string> ListOfStrings = new List<string>();
                foreach (var _string in line)
                {
                    ListOfStrings.Add(_string.Replace(" ", string.Empty));
                }
                ListOfListStrings.Add(ListOfStrings);
            }
            data.Clear();
            data.AddRange(ListOfListStrings);
            return data;
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {

            List<List<string>> ListOfListStrings = new List<List<string>>();
            foreach (var line in data)
            {
                List<string> ListOfStrings = new List<string>();
                foreach (var _string in line)
                {
                    ListOfStrings.Add(_string.Replace("\"", string.Empty));
                }
                ListOfListStrings.Add(ListOfStrings);
            }
            data.Clear();
            data.AddRange(ListOfListStrings);
            return data;
        }
        public List<List<string>> StripHashtags(List<List<string>> data)
        {
            List<List<string>> ListOfListOfStrings = new List<List<string>>();
            foreach (var line in data)
            {
                List<string> ListOfStrings = new List<string>();
                foreach (var _string in line)
                {
                    ListOfStrings.Add(_string.Replace("#", string.Empty));
                }
                ListOfListOfStrings.Add(ListOfStrings);
            }
            data.Clear();
            data.AddRange(ListOfListOfStrings);
            return data;
        }

    }
}