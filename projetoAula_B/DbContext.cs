using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoAula_B
{
    public class DbContext
    {
        string ConexaoBDSQL = "Data Source=127.0.0.1; Initial Catalog=MotoristaHabilitado; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=True";
       
        string ConexaoBDMongo = "mongodb://root:Mongo%402024%23@localhost:27017";

        
        public string GetConnectSQL()
        {
            return ConexaoBDSQL;
        }
        public string GetConnectMongo()
        {
            return ConexaoBDMongo;
        }
    }
}
