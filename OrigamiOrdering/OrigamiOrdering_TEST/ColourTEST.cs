using NUnit.Framework;
using OrigamiOrdering;
using System.Collections.Generic;
using System.Linq;

namespace OrigamiOrdering_TEST
{
    public class ColourTests
    {
        CRUDManager _crudManager = new CRUDManager();
        [SetUp]
        public void Setup()
        {
            using (var db = new origamiContext())
            {
                var selectedColour =
                    from c in db.Colours
                    where c.Colour1 == "Test"
                    select c;

                db.Colours.RemoveRange(selectedColour);
                db.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new origamiContext())
            {
                var selectedColour =
                    from c in db.Colours
                    where c.Colour1 == "Test"
                    select c;

                db.Colours.RemoveRange(selectedColour);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenAColourIsCreatedTheNumberOfColoursIncreasesBy1()
        {
            using (var db = new origamiContext())
            {
                int numColoursBefore = db.Colours.Count();
                _crudManager.CreateColour("Test");
                Assert.AreEqual(numColoursBefore + 1, db.Colours.Count());
            }
        }

        [Test]
        public void WhenANewColourIsAdded_DetailsAreCorrect()
        {
            using (var db = new origamiContext())
            {
                _crudManager.CreateColour("Test");
                var newColour = db.Colours.Where(c => c.Colour1 == "Test");

                foreach (var item in newColour)
                {
                    Assert.AreEqual("Test", item.Colour1);
                }
            }
        }

        [Test]
        public void WhenGetAllColourNamesIsCalledAllColourNamesAreCalled()
        {
            using (var db = new origamiContext())
            {
                List<string> colourList = _crudManager.GetAllColourNames();
                Assert.AreEqual(colourList.Count(), db.Colours.Count());
            }
        }
    }
}