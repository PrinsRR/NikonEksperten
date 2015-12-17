using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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


        public List<Produkter> AdvSearch(int ID, int MaxPris, string SoegeOrd)
        {
            string SQL = "SELECT * FROM Produkter WHERE (Navn LIKE @SoegeOrd OR Overskrift LIKE @SoegeOrd OR Beskrivelse LIKE @SoegeOrd)";
            if (MaxPris != 0)
            {
                SQL += " AND Pris <= @pris";
            }
            if (ID != 0)
            {
                SQL += " AND KategoriID=@katid";
            }
            using (var cmd = new SqlCommand(SQL, Conn.CreateConnection()))

            {
                cmd.Parameters.AddWithValue("@pris", MaxPris);
                cmd.Parameters.AddWithValue("@SoegeOrd", "%" + SoegeOrd + "%");
                cmd.Parameters.AddWithValue("@katid", ID);
                List<Produkter> list = new List<Produkter>();
                var mapper = new Mapper<Produkter>();
                list = mapper.MapList(cmd.ExecuteReader());
                if (list != null)
               {
                    cmd.Connection.Close();
                }
                cmd.Connection.Close();
                return list;
            }

        }

        public List<Produkter> Getprodukt(int katID)
        {
            var mapper = new Mapper<Produkter>();
            using (var cmd = new SqlCommand("SELECT * FROM Produkter WHERE KategoriID=@katID", Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@katID", katID);

                List<Produkter> list = new List<Produkter>();
                list = mapper.MapList(cmd.ExecuteReader());
                cmd.Connection.Close();
                return list;
            }


        }
    }
    
}
