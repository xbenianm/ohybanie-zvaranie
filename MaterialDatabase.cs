using System.Collections.Generic;

namespace Calculations
{
    public static class MaterialDatabase
    {
        public class MaterialProperties
        {
            public double E { get; set; }
            public double Re { get; set; }
            public double Alpha { get; set; }
            public double KFactor { get; set; }
        }

        public static Dictionary<string, MaterialProperties> Materialy = new Dictionary<string, MaterialProperties>
        {
            { "S235", new MaterialProperties { E = 210000, Re = 235, Alpha = 1.2e-5, KFactor = 0.4 } },
            { "AISI 304", new MaterialProperties { E = 193000, Re = 210, Alpha = 1.7e-5, KFactor = 0.45 } },
            { "AlMg3", new MaterialProperties { E = 70000, Re = 215, Alpha = 2.4e-5, KFactor = 0.5 } },
            { "Pozink", new MaterialProperties { E = 210000, Re = 230, Alpha = 1.2e-5, KFactor = 0.42 } }
        };
    }
}
