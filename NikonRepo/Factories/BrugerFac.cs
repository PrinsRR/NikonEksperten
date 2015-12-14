using System;
using System.Data.SqlClient;
using PasswordProtector;
namespace NikonRepo
{


    public class BrugerFac : AutoFac<Bruger>
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
                    if (PasswordHash.ValidatePassword(Pass.Trim(), r["Adgangskode"].ToString()))
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
        public bool UserExists(string email)
        {
            using (var cmd = new SqlCommand("SELECT ID FROM Bruger WHERE Email=@Email", Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@Email", email);

                var r = cmd.ExecuteReader();

                if (r.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


    }

}
