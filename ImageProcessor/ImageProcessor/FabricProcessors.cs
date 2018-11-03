using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor
{
    static class FabricProcessors
    {
        public static Processor Get(int idProcessor)
        {
            switch (idProcessor)
            {
                case 1: return new RenameByDateProcessor();
                case 2: return new AddDateProcessor();
                case 3: return new SortByDateProcessor();
                case 4: return new SortByGps();

                default:
                    return null;
            }
        }

    }
}
