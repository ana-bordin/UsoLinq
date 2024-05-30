using Microsoft.Data.SqlClient;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoAula_B
{
    public class DbManipulation
    {
        static readonly DbContext _connSql = new DbContext();
        static readonly SqlConnection _conexao = new SqlConnection(_connSql.GetConnectSQL());

        static readonly DbContext _connMongo = new DbContext();
        static readonly MongoClient _mongoClient = new MongoClient(_connMongo.GetConnectMongo());
        static readonly IMongoDatabase _mongoDatabase = _mongoClient.GetDatabase("MotoristaHabilitado");

        public static void InsertData(List<PenalidadeAplicada> lista)
        {
            try
            {
                _conexao.Open();
                InsertIntoSqlServer(lista);
                InsertIntoMongoDB(lista);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Dados inseridos com sucesso!");
                _conexao.Close();
            }
        }

        private static void InsertIntoSqlServer(List<PenalidadeAplicada> lista)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Razao_Social", typeof(string));
            dataTable.Columns.Add("CNPJ", typeof(string));
            dataTable.Columns.Add("Nome_Motorista", typeof(string));
            dataTable.Columns.Add("CPF", typeof(string));
            dataTable.Columns.Add("Vigencia_Cadastro", typeof(DateTime));
            int line = 0;
            int totalItems = 0;

            foreach (var penalidade in lista)
            { 
                totalItems++;
                line++;
                dataTable.Rows.Add(penalidade.RazaoSocial, penalidade.CNPJ, penalidade.NomeMotorista, penalidade.CPF, penalidade.VigenciaCadastro);
                
                if (line == 1000 || totalItems == lista.Count)
                {
                    using (var bulkCopy = new SqlBulkCopy(_conexao))
                    {
                        bulkCopy.DestinationTableName = "Penalidade_Aplicada";
                        bulkCopy.WriteToServer(dataTable);
                        InsertIntoControleProcessamento("Inserção de penalidades", dataTable.Rows.Count);
                        dataTable.Clear();
                        line = 0;
                    }
                }
            }
        }

        private static void InsertIntoMongoDB(List<PenalidadeAplicada> lista)
        {
            var collection = _mongoDatabase.GetCollection<BsonDocument>("Penalidade_Aplicada");
            var documents = new List<BsonDocument>();

            foreach (var penalidade in lista)
            {
                var json = JsonConvert.SerializeObject(penalidade);
                var document = BsonDocument.Parse(json);
                documents.Add(document);
            }

            collection.InsertMany(documents);
        }

        private static void InsertIntoControleProcessamento(string description, int numberOfRecords)
        {
            var date_Controle = DateTime.Now;
            var sql = $"INSERT INTO Controle_Processamento (Description_Control, Date_Controle, NumberOfRecords) VALUES (@description_Control, @date_Controle, @numberOfRecords)";
            using (var cmd = new SqlCommand(sql, _conexao))
            {
                cmd.Parameters.AddWithValue("@description_Control", description);
                cmd.Parameters.AddWithValue("@date_Controle", date_Controle);
                cmd.Parameters.AddWithValue("@numberOfRecords", numberOfRecords);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

