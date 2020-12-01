using System;
using System.Collections.Generic;
using System.Linq;

namespace OrigamiOrdering
{
    class CRUDManager
    {
        static void Main(string[] args) {}

        public void createModel(string modelName, int modelPrice, string modelComplexity, int modelPiecesNumber,
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

        public void coloursForModel(List<Colour> coloursList, string modelName, List<int> piecesOfColour)
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

        public void createColour(string colour)
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

        public void updateModel(string name, string modelNameUpdate, int modelPriceUpdate, string modelComplexityUpdate, 
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

        public void deleteModel(string modelName)
        {
            using (var db = new origamiContext())
            {
                db.Models.Remove(db.Models.Where(m => m.ModelName == modelName).FirstOrDefault());
                db.SaveChanges();
            }
        }

        public void createOrder(List<Model> modelList, int totalPrice)
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
    }
}
