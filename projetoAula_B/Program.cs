namespace projetoAula_B
{
    public class Program
    {
        static void Main(string[] args)
        {
            var lista = ReadFile.GetData("C:\\json\\motoristas_habilitados.json");

            Console.WriteLine("Quantidade de linhas:" + TestFilter.GetCountRecords(lista));
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Encontrar registros que tenham o número do CPF iniciando com 237");

            TestFilter.PrintData(TestFilter.GetRecordsByCPF(lista, "237"));
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Listar os registros que têm o ano de vigencia igual a 2021:");
            TestFilter.PrintData(TestFilter.GetRecordsByYear(lista, 2021));
            Console.ReadKey();
            Console.Clear();
            
            Console.WriteLine("Quantas empresas tem no nome da razão social e descrição LTDA:");
            TestFilter.PrintData(TestFilter.GetRecordsByRazaoSocial(lista, "LTDA"));
            Console.ReadKey();
            Console.Clear();
            
            Console.WriteLine("Ordenar a lista de registros pela razão social");
            TestFilter.PrintData(TestFilter.GetRecordsOrderedByRazaoSocial(lista));
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Inserir todos os regitros no SQL Server");
            InsertData.InsertAllData(lista);

            Console.WriteLine("Fim do programa");
        }
    }
}
