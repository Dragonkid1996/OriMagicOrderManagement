using System;
using System.Collections.Generic;

#nullable disable

namespace OrigamiOrdering
{
    public partial class Model
    {
        public Model()
        {
            JtModelColours = new HashSet<JtModelColour>();
            Orders = new HashSet<Order>();
        }

        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public decimal ModelPrice { get; set; }
        public int ModelPiecesNumber { get; set; }
        public string ModelComplexity { get; set; }
        public string LinkToTutorial { get; set; }
        public string LinkToPhoto { get; set; }

        public virtual ICollection<JtModelColour> JtModelColours { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
