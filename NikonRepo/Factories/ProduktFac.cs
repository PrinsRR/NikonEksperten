using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RepoMz2.Models.ViewModels;

namespace NikonRepo
{
	 public class ProduktFac:AutoFac<Produkt>
	 {
        KategoriFac kf = new KategoriFac();
         public ProduktListe GetProduktListe(int KatID)
         {
             ProduktListe pl = new ProduktListe();
             pl.Kategori = kf.Get(KatID);
            pl.Produkter = GetBy("KatID", KatID);

             return pl;
         }

        public List<Produkt> AdvSearch(int ID, int MaxPris, string SoegeOrd)
	     {
	     string SQL = "SELECT * FROM Produkt WHERE (Tekst LIKE @SoegeOrd OR Navn LIKE @SoegeOrd)";
	         if (MaxPris != 0)
	         {
	             SQL += " AND Pris <= @pris";
	         }
             if (ID != 0)
            {
                SQL += " AND KatID=@katid";
            }
            using (var cmd = new SqlCommand(SQL, Conn.CreateConnection()))

            {
                cmd.Parameters.AddWithValue("@pris", MaxPris);
                cmd.Parameters.AddWithValue("@SoegeOrd", "%" + SoegeOrd + "%");
                cmd.Parameters.AddWithValue("@katid", ID);

                var mapper = new Mapper<Produkt>();
                List<Produkt> list = mapper.MapList(cmd.ExecuteReader());
                cmd.Connection.Close();
                return list;
            }

	     }
	 }



}
