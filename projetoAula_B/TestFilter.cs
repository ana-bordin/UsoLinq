using System.Xml.Linq;

namespace projetoAula_B
{
    public class TestFilter
    {
        public static int GetCountRecords(List<PenalidadeAplicada> lista) => lista.Count;
        public static void EscapedWords(List<PenalidadeAplicada> lista)
        {
            foreach (var item in lista)
            {
                if (item.RazaoSocial.Contains("'"))
                    item.RazaoSocial = item.RazaoSocial.Replace("'", "''");

                if (item.NomeMotorista.Contains("'"))
                    item.NomeMotorista = item.NomeMotorista.Replace("'", "''");
            }
        }

        public static List<PenalidadeAplicada> GetRecordsByCPF(List<PenalidadeAplicada> lista, string cpf) => lista.Where(x => x.CPF.StartsWith(cpf)).ToList();

        public static List<PenalidadeAplicada> GetRecordsByYear(List<PenalidadeAplicada> lista, int year) => lista.Where(x => x.VigenciaCadastro.Year == year).ToList();

        public static List<PenalidadeAplicada> GetRecordsByRazaoSocial(List<PenalidadeAplicada> lista, string razaoSocial) => lista.Where(x => x.RazaoSocial.Contains(razaoSocial)).ToList();

        public static List<PenalidadeAplicada> GetRecordsOrderedByRazaoSocial(List<PenalidadeAplicada> lista) => lista.OrderBy(x => x.RazaoSocial).ToList();

        public static void PrintData(List<PenalidadeAplicada> lista)
        {
            foreach (var item in lista)
                Console.WriteLine(item);
        }

        public static string GenerateXML(List<PenalidadeAplicada> lista)
        {
            if (lista.Count > 0)
            {
                var penalidadeAplicada = new XElement("Root",
                    from data in lista
                    where data.CPF.StartsWith("670.***.***-20")
                    select new XElement("Motorista",
                    new XElement("RazaoSocial", data.RazaoSocial),
                    new XElement("CNPJ", data.CNPJ),
                    new XElement("NomeMotorista", data.NomeMotorista),
                    new XElement("CPF", data.CPF),
                    new XElement("VigenciaCadastro", data.VigenciaCadastro)
                    )
                   );
                return penalidadeAplicada.ToString();
            }
            else
            {
                return "Não há registros para gerar o XML";
            }
        
        }
    }
}
