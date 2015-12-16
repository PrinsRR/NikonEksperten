using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikonRepo.Models.ViewModels
{
    public class KatListPro
    {
        public List<Kategori> kategori { get; set; }
        public Produkter produkt { get; set; } 
    }
}
