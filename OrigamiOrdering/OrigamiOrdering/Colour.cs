using System;
using System.Collections.Generic;

#nullable disable

namespace OrigamiOrdering
{
    public partial class Colour
    {
        public Colour()
        {
            JtModelColours = new HashSet<JtModelColour>();
        }

        public int ColourId { get; set; }
        public string Colour1 { get; set; }

        public virtual ICollection<JtModelColour> JtModelColours { get; set; }
    }
}
