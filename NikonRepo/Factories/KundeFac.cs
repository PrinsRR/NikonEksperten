using System.Data.SqlClient;

namespace NikonRepo
{
    public class KundeFac : AutoFac<Kunde>
    {
        public int AddKunde(Kunde k)
        {
            var ID = 0;
            using (
                var cmd =
                    new SqlCommand(
                        "INSERT INTO Kunde (Navn, Adresse, Postnr, Bynavn, Tlf, Email)VALUES(@Navn, @Adresse, @Postnr, @Bynavn, @Tlf, @Email);SELECT SCOPE_IDENTITY() AS curID",
                        Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@Navn", k.Navn);
                cmd.Parameters.AddWithValue("@Adresse", k.Adresse);

                cmd.Parameters.AddWithValue("@Postnr", k.Postnr);

                cmd.Parameters.AddWithValue("@Bynavn", k.Bynavn);

                cmd.Parameters.AddWithValue("@Tlf", k.Tlf);

                cmd.Parameters.AddWithValue("@Email", k.Email);

                var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    ID = int.Parse(r["curID"].ToString());
                }

                cmd.Connection.Close();
                r.Close();

                return ID;
            }

        }

        public void AddKundeLogin(KundeLogin kl)
        {
            using (
                var cmd =
                    new SqlCommand(
                        "INSERT INTO KundeLogin (KundeID, Password)VALUES(@ID, @Pass)",
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