using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NikonRepo.Models.ViewModels;

namespace NikonRepo.Factories
{
    public class facProdukter:AutoFac<Produkter>
    {facKategori fkat = new facKategori();
        
        public KatListPro KLP(int id)
        {
            KatListPro KL = new KatListPro();
            KL.kategori = fkat.GetAll();
            KL.produkt = Get(id);





            return KL;
        }

    }
}
