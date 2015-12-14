using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NikonRepo
{


    public class KategoriFac : AutoFac<Kategori>
    {
        Mapper<Kategori> mapper = new Mapper<Kategori>();

        public List<Kategori> GetAllOrderList()
        {
            using (var cmd = new SqlCommand("SELECT * FROM Kategori ORDER BY Sortering", Conn.CreateConnection()))
            {
                return mapper.MapList(cmd.ExecuteReader());
            }
        }
        public void AddClick(int katid)
        {
            using (var cmd = new SqlCommand("UPDATE Kategori SET clicks=clicks+1 WHERE ID="+katid, Conn.CreateConnection()))
            {
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

    }

}
