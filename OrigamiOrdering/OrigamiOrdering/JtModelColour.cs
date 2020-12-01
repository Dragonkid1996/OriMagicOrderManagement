using System;
using System.Collections.Generic;

#nullable disable

namespace OrigamiOrdering
{
    public partial class JtModelColour
    {
        public int? ModelId { get; set; }
        public int? ColourId { get; set; }
        public int PiecesOfColour { get; set; }

        public virtual Colour Colour { get; set; }
        public virtual Model Model { get; set; }
    }
}
