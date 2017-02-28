using System.IO;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Magicomatic.Data.Tools;
using Magicomatic.Data.Readers;
using Magicomatic.Data.Models;

namespace Magicomatic.Data.UnitTests.Readers
{
    [TestFixture]
    class UserInventoryReaderTests : AssertionHelper
    {
        private string userInventoryFilePath;
        private string cardLibraryFilePath;

        private IEnumerable validUserInventoryCsvFile;
        private IEnumerable invalidUserInventoryCsvFile;

        private IEnumerable cardLibrary;
        private FileManager fileManager;

        private UserInventoryReader target;

        [SetUp]
        public void Before_Each_Test()
        {
            this.userInventoryFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Data/UserInventory.csv";
            this.cardLibraryFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Data/CardLibrary.csv";

            this.validUserInventoryCsvFile = File.ReadLines(userInventoryFilePath);
            this.invalidUserInventoryCsvFile = File.ReadLines(cardLibraryFilePath);

            this.cardLibrary = new CardRepository(cardLibraryFilePath, "DummyUrl.com/dummy").Retrieve();
            this.fileManager = Substitute.For<FileManager>();

            this.target = new UserInventoryReader(fileManager,cardLibrary);
        }

        [Test]
        public void Returns_User_Inventory_List_If_Csv_File_Is_Valid()
        {
            this.fileManager.ReadLines(userInventoryFilePath).Returns(validUserInventoryCsvFile);

            var actual = target.Read(userInventoryFilePath);

            Expect(actual, Is.TypeOf<List<UserCard>>());
        }

        [Test] 
        public void Returns_Null_If_File_Is_Invalid()
        {
            this.fileManager.ReadLines(userInventoryFilePath).Returns(invalidUserInventoryCsvFile);

            var actual = target.Read(userInventoryFilePath);

            Expect(actual, Is.Null);
        }

        [Test]
        public void Reads_Csv_File_Row()
        {
            this.fileManager.ReadLines(userInventoryFilePath).Returns(validUserInventoryCsvFile);

            var actual = target.Read(userInventoryFilePath) as List<UserCard>;

            Expect(actual[0].Amount,    Is.EqualTo(1));
            Expect(actual[0].ForTrade,  Is.EqualTo(0));
            Expect(actual[0].Name,      Is.EqualTo("Abandon Reason"));
            Expect(actual[0].Set,       Is.EqualTo("Eldritch Moon"));
            Expect(actual[0].Condition, Is.EqualTo("Near Mint"));
            Expect(actual[0].Language,  Is.EqualTo("English"));
            Expect(actual[0].Foil,      Is.EqualTo(""));

            Expect(actual[0].SetCode,           Is.EqualTo("EMN"));
            Expect(actual[0].ID,                Is.EqualTo("414412"));
            Expect(actual[0].Type,              Is.EqualTo("Instant"));
            Expect(actual[0].Power,             Is.EqualTo(""));
            Expect(actual[0].Toughness,         Is.EqualTo(""));
            Expect(actual[0].Loyality,          Is.EqualTo(""));
            Expect(actual[0].ManaCost,          Is.EqualTo("{2}{R}"));
            Expect(actual[0].ConvertedManaCost, Is.EqualTo("3"));
            Expect(actual[0].Artist,            Is.EqualTo("Josh Hass"));
            Expect(actual[0].Flavor,            Is.EqualTo(""));
            Expect(actual[0].Color,             Is.EqualTo("R"));
            Expect(actual[0].GeneratedMana,     Is.EqualTo(""));
            Expect(actual[0].Number,            Is.EqualTo("115"));
            Expect(actual[0].Rarity,            Is.EqualTo("U"));
            Expect(actual[0].Ruling,            Is.EqualTo("7/13/2016 : You can’t target the same creature twice to have it get +2/+0."));
            Expect(actual[0].Ability,           Is.EqualTo(@"Up to two target creatures each get +1/+0 and gain first strike until end of turn." + "\n\n" + "Madness {1}{R} (If you discard this card, discard it into exile. When you do, cast it for its madness cost or put it into your graveyard.)"));
        }
    }
}
