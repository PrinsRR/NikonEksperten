using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordProtector;

namespace NikonRepo.Factories
{
   public class facBruger:AutoFac<Bruger>
    {
        Mapper<Bruger> mapper = new Mapper<Bruger>();
        public Bruger Login(string Username, string Pass)
        {
            Bruger U = new Bruger();
            //mapper bruges når en type skal over i en variabel
            Mapper<Bruger> mapper = new Mapper<Bruger>();

            using (
                var cmd = new SqlCommand("SELECT * FROM Bruger WHERE Email=@Username",
                    Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@Username", Username.Trim());


                var r = cmd.ExecuteReader();

                if (r.Read())
                {
                    if (PasswordHash.ValidatePassword(Pass.Trim(), r["Password"].ToString()))
                    {
                        U = mapper.Map(r);
                    }
                    //map bruges til enkel type der skal udtrækkes


                }

                //connection skal lukkes ellers kan det næste kald ikke komme igennem
                r.Close();
                cmd.Connection.Close();
            }
            return U;
        }
    }
}
