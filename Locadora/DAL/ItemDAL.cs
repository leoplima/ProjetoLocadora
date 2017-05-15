using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemDAL
    {
        string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=LocadoraWeb; User Id=sa ; Password=lima0878";

        public void InserirItem(Item i)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "INSERT INTO Item VALUES (@cod_b,@cod_cat,@titulo,@cod_gen,@ano,@cod_tipo,@preco,@data,@vr_custo,@cod_sit@,@cod_art,@diretor,@foto)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod_b", i.CodBarras);
                cmd.Parameters.AddWithValue("@cod_cat", i.CodCategoria);
                cmd.Parameters.AddWithValue("@titulo", i.Nome);
                cmd.Parameters.AddWithValue("@cod_gen", i.CodGenero);
                cmd.Parameters.AddWithValue("@ano", i.Ano);
                cmd.Parameters.AddWithValue("@cod_tipo", i.CodTipo);
                cmd.Parameters.AddWithValue("@preco", i.Preco);
                cmd.Parameters.AddWithValue("@data", i.Data);
                cmd.Parameters.AddWithValue("@vr_custo", i.VrCusto);
                cmd.Parameters.AddWithValue("@cod_sit", i.CodSituacao);
                cmd.Parameters.AddWithValue("@cod_art", i.CodArtista);
                cmd.Parameters.AddWithValue("@diretor", i.Diretor);
                cmd.Parameters.AddWithValue("@foto", i.Foto);

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

        public void AtualizarItem(Item i)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = @"UPDATE Item SET Codigo=@codigo, CodBarras=@cod_b,CodCategoria=@cod_cat,Titulo=@titulo,CodGenero=@cod_gen,Ano=@ano,CodTipo=@cod_tipo,Preco=@preco,Data=@data,VrCusto=@vr_custo,CodSituacao=@cod_sit, CodArtita=@cod_art,Diretor=@diretor,Foto=@foto,
                                WHERE Codigo=@codigo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@codigo", i.Codigo);
                cmd.Parameters.AddWithValue("@cod_cat", i.CodCategoria);
                cmd.Parameters.AddWithValue("@titulo", i.Nome);
                cmd.Parameters.AddWithValue("@cod_gen", i.CodGenero);
                cmd.Parameters.AddWithValue("@ano", i.Ano);
                cmd.Parameters.AddWithValue("@cod_tipo", i.CodTipo);
                cmd.Parameters.AddWithValue("@preco", i.Preco);
                cmd.Parameters.AddWithValue("@data", i.Data);
                cmd.Parameters.AddWithValue("@vr_custo", i.VrCusto);
                cmd.Parameters.AddWithValue("@cod_sit", i.CodSituacao);
                cmd.Parameters.AddWithValue("@cod_art", i.CodArtista);
                cmd.Parameters.AddWithValue("@diretor", i.Diretor);
                cmd.Parameters.AddWithValue("@foto", i.Foto);



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

        public List<Item> SelecionarTodasItems()
        {
            List<Item> lista = new List<Item>();

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = "SELECT * FROM Item";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Item i;
                    while (dr.Read())
                    {
                        i = new Item();
                        i.Codigo = Convert.ToInt32(dr["Codigo"]);
                        i.CodBarras = dr["CodBarras"].ToString();
                        i.CodCategoria = Convert.ToInt32(dr["CodCaregoria"]);
                        i.Nome = dr["Titulo"].ToString();
                        i.CodGenero = Convert.ToInt32(dr["CodGenero"]);
                        i.Ano = dr["Ano"].ToString();
                        i.CodTipo = Convert.ToInt32(dr["CodTipo"]);
                        i.Preco = Convert.ToDecimal(dr["Preco"]);
                        i.Data = Convert.ToDateTime(dr["Data"]);
                        i.VrCusto = Convert.ToDecimal(dr["VrCusto"]);
                        i.CodSituacao = Convert.ToInt32(dr["CodSituacao"]);
                        i.CodArtista = Convert.ToInt32(dr["CodArtista"]);
                        i.Diretor = dr["Diretor"].ToString();
                        i.Foto = dr["Foto"].ToString();

                        lista.Add(i);
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

        public void ExcluirItem(int codigo)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "DELETE FROM Item WHERE Codigo = @codigo";
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

        public Item SelecionarItemCodigo(int codigo)
        {
            Item item = null;

            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = "SELECT * FROM Item WHERE Codigo=@cod";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod", codigo);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows && dr.Read())
                {
                    item = new Item();
                    item.Codigo = codigo;
                    item.CodBarras = dr["CodBarras"].ToString();
                    item.CodCategoria = Convert.ToInt32(dr["CodCaregoria"]);
                    item.Nome = dr["Titulo"].ToString();
                    item.CodGenero = Convert.ToInt32(dr["CodGenero"]);
                    item.Ano = dr["Ano"].ToString();
                    item.CodTipo = Convert.ToInt32(dr["CodTipo"]);
                    item.Preco = Convert.ToDecimal(dr["Preco"]);
                    item.Data = Convert.ToDateTime(dr["Data"]);
                    item.VrCusto = Convert.ToDecimal(dr["VrCusto"]);
                    item.CodSituacao = Convert.ToInt32(dr["CodSituacao"]);
                    item.CodArtista = Convert.ToInt32(dr["CodArtista"]);
                    item.Diretor = dr["Diretor"].ToString();
                    item.Foto = dr["Foto"].ToString();

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

            return item;
        }
    }
}
