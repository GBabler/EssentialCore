using EssentialCore.CLASSE;
using EssentialCore.FORMULARIOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.REPOSITORIO
{
    public class SQLITEDAL
    {
        public static string path = Directory.GetCurrentDirectory() + "\\essencialcoreBD.sqlite";
        private static SQLiteConnection sqliteConnection;

        public static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=" + path);
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void CriarBancoSQLite()
        {
            try
            {
                if (File.Exists(path) == false)
                {
                    SQLiteConnection.CreateFile(path);
                }
            }
            catch
            {
                throw;
            }
        }

        public static void CriarTabelasSQLite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS CLIENTE (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, nome VARCHAR(100), endereco VARCHAR(100), numend VARCHAR(20), celular VARCHAR(20))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetClientes()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM CLIENTE";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCliente(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM CLIENTE WHERE id =" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Add(CLIENTE cliente)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    
                    cmd.CommandText = "INSERT INTO CLIENTE (nome, endereco, numend, celular) values (@nome, @endereco, @numend, @celular)";
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
                    cmd.Parameters.AddWithValue("@numend", cliente.NumEnd);
                    cmd.Parameters.AddWithValue("@celular", cliente.Celular);
                    cmd.ExecuteNonQuery();
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update(CLIENTE cliente)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {

                    cmd.CommandText = "UPDATE CLIENTE SET nome=@nome, endereco=@endereco, numend=@numend, celular=@celular WHERE id=@id";
                    cmd.Parameters.AddWithValue("@id", cliente.Id);
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
                    cmd.Parameters.AddWithValue("@numend", cliente.NumEnd);
                    cmd.Parameters.AddWithValue("@celular", cliente.Celular);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete(int id)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {

                    cmd.CommandText = "DELETE FROM CLIENTE WHERE id=@id";
                    cmd.Parameters.AddWithValue("@id",id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
