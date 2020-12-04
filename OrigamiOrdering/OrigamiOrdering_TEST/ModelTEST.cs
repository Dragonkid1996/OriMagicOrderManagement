using NUnit.Framework;
using OrigamiOrdering;
using System.Collections.Generic;
using System.Linq;

namespace OrigamiOrdering_TEST
{
    public class ModelTests
    {
        CRUDManager _crudManager = new CRUDManager();
        [SetUp]
        public void Setup()
        {
            using (var db = new origamiContext())
            {
                var selectedModel =
                    from m in db.Models
                    where m.ModelName == "Test"
                    select m;

                db.Models.RemoveRange(selectedModel);
                db.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new origamiContext())
            {
                var selectedModel =
                    from m in db.Models
                    where m.ModelName == "Test"
                    select m;

                db.Models.RemoveRange(selectedModel);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenAModelIsCreatedTheNumberOfModelsIncreasesBy1()
        {
            using (var db = new origamiContext())
            {
                int numModelsBefore = db.Models.Count();
                _crudManager.CreateModel("Test", (decimal)3000.00, "H", 1400, "Own Design", "None");
                Assert.AreEqual(numModelsBefore + 1, db.Models.Count());
            }
        }

        [Test]
        public void WhenANewModelIsAdded_DetailsAreCorrect()
        {
            using (var db = new origamiContext())
            {
                _crudManager.CreateModel("Test", (decimal)3000.00, "H", 1400, "Own Design", "None");
                var newModel = db.Models.Where(m => m.ModelName == "Test");

                foreach (var item in newModel)
                {
                    Assert.AreEqual("Test", item.ModelName);
                    Assert.AreEqual((decimal)3000.00, item.ModelPrice);
                    Assert.AreEqual("H", item.ModelComplexity);
                    Assert.AreEqual(1400, item.ModelPiecesNumber);
                    Assert.AreEqual("Own Design", item.LinkToTutorial);
                    Assert.AreEqual("None", item.LinkToPhoto);
                }
            }
        }

        [Test]
        public void WhenAModelIsChanged_TheDatabaseIsUpdated()
        {
            using (var db = new origamiContext())
            {
                var newModel = new Model
                {
                    ModelName = "Test",
                    ModelPrice = (decimal)3000.00,
                    ModelComplexity = "H",
                    ModelPiecesNumber = 1400,
                    LinkToTutorial = "Own Design",
                    LinkToPhoto = "None"
                };
                db.Models.Add(newModel);
                db.SaveChanges();

                _crudManager.UpdateModel(newModel.ModelName, (decimal)3000, "L", 1500, "http://youtube.com", "test.jpg");
                var updatedModel = db.Models.Where(m => m.ModelName == "Test").FirstOrDefault();
                Assert.AreEqual("L", updatedModel.ModelComplexity);
                Assert.AreEqual(1500, updatedModel.ModelPiecesNumber);
                Assert.AreEqual("http://youtube.com", updatedModel.LinkToTutorial);
                Assert.AreEqual("test.jpg", updatedModel.LinkToPhoto);                
                //I don't know what is going on with this. I know the method works as I can modify models in the GUI
                //and they have been updated when looking at the database data
            }
        }

        [Test]
        public void WhenAModelIsDeletedItIsActuallyRemoved()
        {
            using (var db = new origamiContext())
            {
                var newModel = new Model
                {
                    ModelName = "Test",
                    ModelPrice = (decimal)3000.00,
                    ModelComplexity = "H",
                    ModelPiecesNumber = 1400,
                    LinkToTutorial = "Own Design",
                    LinkToPhoto = "None"
                };
                db.Models.Add(newModel);
                db.SaveChanges();

                _crudManager.DeleteModel("Test");
                Assert.AreEqual(null, db.Models.Where(m => m.ModelName == "Test").FirstOrDefault());
            }
        }

        [Test]
        public void WhenGetAllModelsIsCalledAllModelsAreCalled()
        {
            using (var db = new origamiContext())
            {
                List<Model> modelList = _crudManager.GetAllModels();
                Assert.AreEqual(modelList.Count(), db.Models.Count());
            }
        }
    }
}