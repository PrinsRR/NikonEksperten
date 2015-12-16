using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikonRepo.Factories
{
   public class facKategori:AutoFac<Kategori>
    {
        public List<Kategori> GetForsideProdukter()
        {
            var mapper = new Mapper<Kategori>();
            using (var cmd = new SqlCommand("SELECT * FROM Kategori WHERE ForsideProdukt > 0 ORDER BY ForsideProdukt", Conn.CreateConnection()))
            {
                List<Kategori> list = new List<Kategori>();
                list = mapper.MapList(cmd.ExecuteReader());
                cmd.Connection.Close();
                return list;
            }
       }
    }
}
