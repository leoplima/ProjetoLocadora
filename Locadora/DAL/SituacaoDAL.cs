using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SituacaoDAL
    {
        string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=LocadoraWeb; User Id=sa ; Password=lima0878";

        public void InserirSituacao(Situacao s)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "INSERT INTO Situacao VALUES (@nome)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", s.Nome);

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

        public void AtualizarSituacao(Situacao s)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = @"UPDATE Situacao SET Codigo=@codigo, Nome=@nome
                                WHERE Codigo=@codigo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@codigo", s.Codigo);
                cmd.Parameters.AddWithValue("@nome", s.Nome);


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

        public List<Situacao> SelecionarTodasSituacaos()
        {
            List<Situacao> lista = new List<Situacao>();

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = "SELECT * FROM Situacao";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Situacao s;
                    while (dr.Read())
                    {
                        s = new Situacao();
                        s.Codigo = Convert.ToInt32(dr["Codigo"]);
                        s.Nome = dr["Nome"].ToString();


                        lista.Add(s);
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

        public void ExcluirSituacao(int codigo)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "DELETE FROM Situacao WHERE Codigo = @codigo";
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

        public Situacao SelecionarSituacaoCodigo(int codigo)
        {
            Situacao sit = null;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = "SELECT * FROM Situacao WHERE Codigo=@cod";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod", codigo);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows && dr.Read())
                {
                    sit = new Situacao();
                    sit.Codigo = codigo;
                    sit.Nome = dr["Nome"].ToString();

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

            return sit;
        }
    }
}
