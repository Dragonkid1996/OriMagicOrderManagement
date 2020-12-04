using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using OrigamiOrdering;
using System.Collections.Generic;
using System.Linq;

namespace OrigamiOrdering_TEST
{
    public class OrderTests
    {
        CRUDManager _crudManager = new CRUDManager();
        [SetUp]
        public void Setup()
        {
            using (var db = new origamiContext())
            {
                var selectedOrder =
                    from o in db.Orders
                    where o.TotalPrice == (decimal)3000.00
                    select o;

                db.Orders.RemoveRange(selectedOrder);

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
                var selectedOrder =
                    from o in db.Orders
                    where o.TotalPrice == (decimal)3000.00
                    select o;

                db.Orders.RemoveRange(selectedOrder);

                var selectedModel =
                    from m in db.Models
                    where m.ModelName == "Test"
                    select m;

                db.Models.RemoveRange(selectedModel);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenAnOrderIsCreatedTheNumberOfOrdersIncreasesBy1()
        {
            using (var db = new origamiContext())
            {
                int numOrdersBefore = db.Orders.Count();
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
                var modelList = new List<Model>()
                {
                    newModel
                };
                _crudManager.CreateOrder(modelList, (decimal)3000.00);
                Assert.AreEqual(numOrdersBefore + 1, db.Orders.Count());
            }
        }

        [Test]
        public void WhenANewOrderIsAdded_DetailsAreCorrect()
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
                var modelList = new List<Model>()
                {
                    newModel
                };
                _crudManager.CreateOrder(modelList, (decimal)3000.00);
                var newOrder = db.Orders.Where(o => o.Model.ModelName == "Test");

                foreach (var item in newOrder)
                {
                    Assert.AreEqual("Test", item.Model.ModelName);
                    Assert.AreEqual((decimal)3000.00, item.TotalPrice);
                }
            }
        }

        [Test]
        public void WhenGetAllOrdersIsCalledAllOrdersAreCalled()
        {
            using (var db = new origamiContext())
            {
                List<Order> orderList = _crudManager.GetAllOrders();
                Assert.AreEqual(orderList.Count(), db.Orders.Count());
            }
        }
    }
}