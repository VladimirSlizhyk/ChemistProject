using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistProject.EFData
{
    public class MainRepository
    {
        protected ChemistContext Context { get; set; }

        public MainRepository(ChemistContext context)
        {
            Context = context;
        }
    }
}
