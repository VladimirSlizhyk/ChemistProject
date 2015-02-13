using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChemistProject.EFData
{
    public class ChemistDbInitializer : DropCreateDatabaseIfModelChanges<ChemistContext>
    {
        protected override void Seed(ChemistContext context)
        {
            var a = 10;
            base.Seed(context);
        }
    }
}
