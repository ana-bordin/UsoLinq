using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoAula_B
{
    public class DbContext
    {
        string ConexaoBD = "Data Source=127.0.0.1; Initial Catalog=Campeonato; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=True";

        public string GetConnect()
        {
            return ConexaoBD;
        }
    }
}
