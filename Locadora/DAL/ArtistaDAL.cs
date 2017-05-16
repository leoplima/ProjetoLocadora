using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ArtistaDAL
    {
        string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=LocadoraWeb; User Id=sa ; Password=lima0878";

        public void InserirArtista(Artista a)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "INSERT INTO Artista VALUES (@nome,@dtNasc,@pais,@foto)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", a.Nome);
                cmd.Parameters.AddWithValue("@dtNasc", a.DataNasc);
                cmd.Parameters.AddWithValue("@pais", a.Pais);
                cmd.Parameters.AddWithValue("@foto", a.Foto);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public void AtualizarArtista(Artista a)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = @"UPDATE Artista SET Nome=@nome,DtNasc=@dtNasc,Pais=@pais,Foto1=@foto
                                WHERE Codigo=@codigo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@codigo", a.Codigo);
                cmd.Parameters.AddWithValue("@nome", a.Nome);
                cmd.Parameters.AddWithValue("@dtNasc", a.DataNasc);
                cmd.Parameters.AddWithValue("@pais", a.Pais);
                cmd.Parameters.AddWithValue("@foto", a.Foto);


                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }

        public List<Artista> SelecionarTodosArtistas()
        {
            List<Artista> lista = new List<Artista>();

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = "SELECT * FROM Artista";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Artista a;
                    while (dr.Read())
                    {
                        a = new Artista();
                        a.Codigo = Convert.ToInt32(dr["Codigo"]);
                        a.Nome = dr["Nome"].ToString();
                        a.DataNasc = Convert.ToDateTime(dr["DtNasc"]);
                        a.Pais = dr["Pais"].ToString();
                        a.Foto = dr["Foto1"].ToString();

                        lista.Add(a);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return lista;
        }

        public void ExcluirArtista(int codigo)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "DELETE FROM Artista WHERE Codigo = @codigo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@codigo", codigo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }

        public Artista SelecionarArtistaCodigo(int codigo)
        {
            Artista a = null;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = "SELECT * FROM Artista WHERE Codigo=@cod";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod", codigo);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows && dr.Read())
                {
                    a = new Artista();
                    a.Codigo = codigo;
                    a.Nome = dr["Nome"].ToString();
                    a.DataNasc = Convert.ToDateTime(dr["DtNasc"]);
                    a.Pais = dr["Pais"].ToString();
                    a.Foto = dr["Foto1"].ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return a;
        }
    }
}
