using System;
using System.Data.SqlClient;

namespace NikonRepo
{


    public class KundeLoginFac : AutoFac<KundeLogin>
    {

        Mapper<Kunde> mapper = new Mapper<Kunde>();
        public Kunde Login(string email, string password)
        {

            using (var CMD = new SqlCommand("SELECT * FROM Kunde INNER JOIN KundeLogin ON Kunde.ID = KundeLogin.KundeID WHERE Kunde.Email=@Email AND KundeLogin.Password=@Adgangskode ", Conn.CreateConnection()))
            {
                CMD.Parameters.AddWithValue("@Email", email.Trim());
                CMD.Parameters.AddWithValue("@Adgangskode", password.Trim());

                var r = CMD.ExecuteReader();
                Kunde per = new Kunde();

                if (r.Read())
                {
                   per = mapper.Map(r); 
                }
                
                r.Close();
                CMD.Connection.Close();

                return per;

            }
        }

        public bool UserExists(string email)
        {
            using (var cmd = new SqlCommand("SELECT Kunde.ID FROM Kunde INNER JOIN KundeLogin ON Kunde.ID = KundeLogin.KundeID WHERE Kunde.email=@Email AND KundeLogin.KundeID = Kunde.ID", Conn.CreateConnection()))
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

        public void UpdateKundePass(KundeLogin kl)
        {
            using (
                var cmd =
                    new SqlCommand(
                        "UPDATE KundeLogin Set Password=@Pass Where KundeID=@ID",
                        Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@ID", kl.KundeID);
                cmd.Parameters.AddWithValue("@Pass", kl.Password);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }


    }

}
