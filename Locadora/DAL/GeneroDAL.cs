using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GeneroDAL
    {
        string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=LocadoraWeb; User Id=sa ; Password=lima0878";

        public void InserirGenero(Genero g)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "INSERT INTO Genero VALUES (@nome)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", g.Nome);

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

        public void AtualizarGenero(Genero g)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = @"UPDATE Genero SET Codigo=@codigo, Nome=@nome,
                                WHERE Codigo=@codigo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@codigo", g.Codigo);
                cmd.Parameters.AddWithValue("@nome", g.Nome);


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

        public List<Genero> SelecionarTodosGeneros()
        {
            List<Genero> lista = new List<Genero>();

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = "SELECT * FROM Genero";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Genero g;
                    while (dr.Read())
                    {
                        g = new Genero();
                        g.Codigo = Convert.ToInt32(dr["Codigo"]);
                        g.Nome = dr["Nome"].ToString();


                        lista.Add(g);
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

        public void ExcluirGenero(int codigo)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "DELETE FROM Genero WHERE Codigo = @codigo";
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

        public Genero SelecionarGeneroCodigo(int codigo)
        {
            Genero gen = null;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = "SELECT * FROM Genero WHERE Codigo=@cod";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod", codigo);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows && dr.Read())
                {
                    gen = new Genero();
                    gen.Codigo = codigo;
                    gen.Nome = dr["Nome"].ToString();

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

            return gen;
        }
    }
}
