using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
namespace Spotify1.Models
{
    public class HomeRepository:IHomeRepository
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        const string connectionString = "Data Source =.;Initial Catalog = master; integrated security = true";

        public bool AddNewArtist(Home artists)
        {
            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand("NewArtists", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@names", artists.AName);
                cmd.Parameters.AddWithValue("@dob", artists.dob);
                cmd.Parameters.AddWithValue("@bio", artists.bio);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return true;
        }

        public bool AddNewSong(Home songs)
        {
            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand("NewSongs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sname", songs.Sname);
                cmd.Parameters.AddWithValue("@dor", songs.dor);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return true;
        }

        public List<Home> GetArtist()
        {

            con = new SqlConnection(connectionString);
            con.Open();
            List<Home> artistsList = new List<Home>();
            try
            {
                cmd = new SqlCommand("GetAl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    artistsList.Add(new Home
                    {
                        Sname= Convert.ToString(dr["Sname"]),
                        dor= Convert.ToString(dr["dor"]),
                        AName = Convert.ToString(dr["AName"]),
                        dob = Convert.ToString(dr["dob"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return artistsList;
        }
    }
}
