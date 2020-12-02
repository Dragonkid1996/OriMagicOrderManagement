using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace OrigamiOrdering
{

    public class CRUDManager
    {
        public List<Colour> ColoursList { get; set; }
        public List<int> PiecesList { get; set; }
        public List<Model> Basket { get; set; }

        public CRUDManager()
        {
            ColoursList = new List<Colour>();
            PiecesList = new List<int>();
            Basket = new List<Model>();
        }

        static void Main(string[] args) { }

        public List<Model> GetAllModels()
        {
            using (var db = new origamiContext())
            {
                return db.Models.ToList();
            }
        }

        public List<Order> GetAllOrders()
        {
            using (var db = new origamiContext())
            {
                return db.Orders.ToList();
            }
        }


        public void CreateModel(string modelName, int modelPrice, string modelComplexity, int modelPiecesNumber,
                                string linkToTutorial, string linkToPhoto)
        {
            using (var db = new origamiContext())
            {
                var newModel = new Model
                {
                    ModelName = modelName,
                    ModelPrice = modelPrice,
                    ModelComplexity = modelComplexity,
                    ModelPiecesNumber = modelPiecesNumber,
                    LinkToTutorial = linkToTutorial,
                    LinkToPhoto = linkToPhoto
                };

                db.Models.Add(newModel);
                db.SaveChanges();
            }
        }

        public void ColoursForModel(List<Colour> coloursList, string modelName, List<int> piecesOfColour)
        {
            using (var db = new origamiContext())
            {
                for (int i = 0; i < coloursList.Count(); i++)
                {
                    var colourPieces = new JtModelColour
                    {
                        ModelId = db.Models.Where(m => m.ModelName == modelName).Select(m => m.ModelId).FirstOrDefault(),
                        ColourId = db.Colours.Where(c => c.ColourId == coloursList[i].ColourId).Select(c => c.ColourId).FirstOrDefault(),
                        PiecesOfColour = piecesOfColour[i]
                    };
                    db.JtModelColours.Add(colourPieces);                    
                }
                db.SaveChanges();
            }
        }

        public void CreateColour(string colour)
        {
            using (var db = new origamiContext())
            {
                var newColour = new Colour
                {
                    Colour1 = colour
                };

                db.Colours.Add(newColour);
                db.SaveChanges();
            }
        }

        public void UpdateModel(string name, string modelNameUpdate, int modelPriceUpdate, string modelComplexityUpdate, 
                                int modelPiecesNumberUpdate, string linkToTutorialUpdate, string linkToPhotoUpdate)
        {
            using (var db = new origamiContext())
            {
                var modelToUpdate = db.Models.Where(m => m.ModelName == name).FirstOrDefault();
                modelToUpdate.ModelName = modelNameUpdate;
                modelToUpdate.ModelPrice = modelPriceUpdate;
                modelToUpdate.ModelComplexity = modelComplexityUpdate;
                modelToUpdate.ModelPiecesNumber = modelPiecesNumberUpdate;
                modelToUpdate.LinkToTutorial = linkToTutorialUpdate;
                modelToUpdate.LinkToPhoto = linkToPhotoUpdate;
                db.SaveChanges();
            }
        }

        public void DeleteModel(string modelName)
        {
            using (var db = new origamiContext())
            {
                db.Models.Remove(db.Models.Where(m => m.ModelName == modelName).FirstOrDefault());
                db.SaveChanges();
            }
        }

        public void CreateOrder(List<Model> modelList, int totalPrice)
        {
            using (var db = new origamiContext())
            {
                foreach (var item in modelList)
                {
                    var newOrder = new Order
                    {
                        ModelId = item.ModelId,
                        TotalPrice = totalPrice
                    };
                    db.Orders.Add(newOrder);
                }
                db.SaveChanges();
            }
        }

        public List<String> GetAllColourNames()
        {
            using (var db = new origamiContext())
            {
                return db.Colours.Select(c => c.Colour1).ToList();
            }
        }

        public Colour GetColourFromName(string colourName)
        {
            using (var db = new origamiContext())
            {
                return db.Colours.Where(c => c.Colour1 == colourName).FirstOrDefault();
            }
        }

        public Model GetModelFromName(string modelName)
        {
            using (var db = new origamiContext())
            {
                return db.Models.Where(m => m.ModelName == modelName).FirstOrDefault();
            }
        }
    }
}
