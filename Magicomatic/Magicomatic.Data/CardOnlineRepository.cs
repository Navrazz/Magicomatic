using System;
using System.Collections;
using Magicomatic.Data.Tools;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Magicomatic.Data.Readers;

namespace Magicomatic.Data
{
    public class CardOnlineRepository : ICardRepository
    {
        private FileManager fileManager;
        private string filePath;
        private const string onlineFilePath = "https://www.dropbox.com/s/xjxk5gonurjt1qe/MTGCardDatabase.csv?dl=1";

        public CardOnlineRepository(FileManager fileManager, string filePath)
        {
            this.fileManager = fileManager;
            this.filePath    = filePath;
        }

        public IEnumerable Retrieve()
        {
            IEnumerable csv = GetCsvFromWeb();
            SaveToFile(csv);
            IEnumerable cardLibrary = new CardLibraryReader(fileManager).Read(filePath);
            return cardLibrary;
        }

        private void SaveToFile(IEnumerable csvFile)
        {
            List<string> csv = csvFile as List<string>;
            if (csv.Count != 0)
            {
                File.WriteAllLines(filePath, csv.ToArray());
            }
        }

        private IEnumerable GetCsvFromWeb()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(onlineFilePath);
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
