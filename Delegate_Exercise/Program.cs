using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise {
 
    
    internal class Delegate_Exercise {
        public static string csvPath = "C:\\Users\\Ryordan\\Desktop\\Dip-Seminar-Delegates-Lambda-Linq_Exercises-master2\\Files\\Files\\proccessed_data.csv";
        public static string filePath = "C:\\Users\\Ryordan\\Desktop\\Dip-Seminar-Delegates-Lambda-Linq_Exercises-master2\\Files\\Files\\data.csv"; 
        public static void Main(string[] args) {
            DataParser dp = new DataParser();
            FileHandler fh = new FileHandler();
            List<string> file = fh.ReadFile(filePath);
            List<List<string>> LoLoS = fh.ParseCsv(file);
            Func<List<List<string>>, List<List<string>>> FileParser = new Func<List<List<string>>, List<List<string>>>(dp.StripWhiteSpace);
            FileParser += dp.StripHashtags;
            FileParser += dp.StripQuotes;

            LoLoS = FileParser(LoLoS);

            fh.WriteFile(csvPath, ',', LoLoS);


        }
        

        
        
    }
}