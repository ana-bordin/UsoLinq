using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoAula_B
{
    public class DbManipulation
    {
       
        static readonly DbContext _conn = new DbContext();
        static readonly SqlConnection _conexaoSql = new SqlConnection(_conn.GetConnect());

        public void CreateDatabase()
        {
            try
            {
                _conexaoSql.Open();
                var sql = "CREATE DATABASE IF NOT EXISTS PenalidadeAplicada";
                var cmd = new SqlCommand(sql, _conexaoSql);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _conexaoSql.Close();
            }
        }   
        public void InsertData(PenalidadeAplicada penalidade)
        {
            try
            {
                _conexaoSql.Open();
                var sql = $"INSERT INTO PenalidadeAplicada (RazaoSocial, CNPJ, NomeMotorista, CPF, VigenciaCadastro) VALUES ('{penalidade.RazaoSocial}', '{penalidade.CNPJ}', '{penalidade.NomeMotorista}', '{penalidade.CPF}', '{penalidade.VigenciaCadastro}')";
                var cmd = new SqlCommand(sql, _conexaoSql);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _conexaoSql.Close();
            }
        }   

    }

}
