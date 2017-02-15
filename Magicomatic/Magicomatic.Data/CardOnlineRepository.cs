using System;
using System.Collections;
using Magicomatic.Data.Tools;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace Magicomatic.Data
{
    public class CardOnlineRepository : ICardRepository
    {
        private FileManager fileManager;
        private string filePath;

        public CardOnlineRepository(FileManager fileManager, string filePath)
        {
            this.fileManager = fileManager;
            this.filePath    = filePath;
        }

        public IEnumerable Retrieve()
        {
            List<string> csv = GetCsv() as List<string>;
            SaveToFile(csv);
            return csv;
        }

        private void SaveToFile(List<string> csv)
        {
            if (csv.Count != 0)
            {
                File.WriteAllLines(filePath, csv.ToArray());
            }
        }

        private IEnumerable GetCsv()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(filePath);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            List<string> result = new List<string>();

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {
                string currentLine;
                while((currentLine = streamReader.ReadLine()) != null )
                {
                    result.Add(currentLine);
                }
            }

            return result;
        }
    }
}
