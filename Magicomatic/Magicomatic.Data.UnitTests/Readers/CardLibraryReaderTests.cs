using System.Collections;
using System.IO;
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
    class CardLibraryReaderTests : AssertionHelper
    {
        private string filePath;

        private IEnumerable csvFileRows;
        private FileManager fileManager;

        private CardLibraryReader target;

        [SetUp]
        public void Before_Each_Test()
        {
            this.filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Data/EMN.csv";
            this.csvFileRows = File.ReadLines(filePath);
            this.fileManager = Substitute.For<FileManager>();

            this.target = new CardLibraryReader(fileManager);
        }

        [Test]
        public void Reads_Cards_From_Csv()
        {
            this.fileManager.ReadLines(filePath).Returns(csvFileRows);

            var actual = target.Read(filePath) as List<Card>;
            Expect(actual[0].Name,              Is.EqualTo("Abandon Reason"));
            Expect(actual[0].Set,               Is.EqualTo("Eldritch Moon"));
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
            Expect(actual[0].Ability,           Is.EqualTo(@"Up to two target creatures each get +1/+0 and gain first strike until end of turn."+"\n\n"+"Madness {1}{R} (If you discard this card, discard it into exile. When you do, cast it for its madness cost or put it into your graveyard.)"));
        }
    }
}
