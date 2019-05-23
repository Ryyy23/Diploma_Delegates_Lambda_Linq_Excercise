using System;
using System.Collections.Generic;
using System.Diagnostics;
using FileParserNetStandard;

namespace Delegate_Exercise {
    
    
    public class CsvHandler {
        
        /// <summary>
        /// Takes a list of list of strings applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="dataHandler"></param>
        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> dataHandler) {
            FileHandler fh = new FileHandler();
            var file = fh.ReadFile(readFile);
            var _file = fh.ParseCsv(file);
            var __file = dataHandler(_file);
            fh.WriteFile(writeFile, ',', __file);

        }
        
    }
}