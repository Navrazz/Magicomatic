using System.IO;
using System.Collections;
using System.Reflection;
using NSubstitute;
using NUnit.Framework;
using Magicomatic.Data.Tools;
using Magicomatic.Data.Readers;
using System.Collections.Generic;
using Magicomatic.Data.Models;

namespace Magicomatic.Data.UnitTests.Readers
{
    [TestFixture]
    class UserInventoryReaderTests : AssertionHelper
    {
        private string filePath;

        private IEnumerable csvFileRows;
        private FileManager fileManager;

        private UserInventoryReader target;

        [SetUp]
        public void Before_Each_Test()
        {
            this.filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Data/UserInventory.csv";
            this.csvFileRows = File.ReadLines(filePath);
            this.fileManager = Substitute.For<FileManager>();

            this.target = new UserInventoryReader(fileManager);
        }

        [Test]
        public void Reads_Csv_File()
        {
            this.fileManager.ReadLines(filePath).Returns(csvFileRows);

            var actual = target.Read(filePath) as List<UserCard>;

            Expect(actual[0].Amount,    Is.EqualTo(1));
            Expect(actual[0].ForTrade,  Is.EqualTo(0));
            Expect(actual[0].Name,      Is.EqualTo("Abandon Reason"));
            Expect(actual[0].Set,       Is.EqualTo("Eldritch Moon"));
            Expect(actual[0].Condition, Is.EqualTo("Near Mint"));
            Expect(actual[0].Language,  Is.EqualTo("English"));
            Expect(actual[0].Foil,      Is.EqualTo(""));
        }
    }
}
