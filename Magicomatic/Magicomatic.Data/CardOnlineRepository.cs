using System.IO;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using Magicomatic.Data.Tools;
using Magicomatic.Data.Readers;
using Magicomatic.Data.Models;

namespace Magicomatic.Data
{
    public class CardOnlineRepository : ICardRepository
    {
        private string filePath;
        private string url;

        private FileManager fileManager;

        public CardOnlineRepository(string filePath, string url, FileManager fileManager)
        {
            this.filePath    = filePath;
            this.url         = url;
            this.fileManager = fileManager;
        }

        public IEnumerable<Card> Retrieve()
        {
            IEnumerable csv = GetCsvFromWeb();
            SaveToFile(csv);
            IEnumerable<Card> cardLibrary = new CardLibraryReader(fileManager).Read(filePath);
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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.url);
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
