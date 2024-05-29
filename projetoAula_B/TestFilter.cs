using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoAula_B
{
    public class TestFilter
    {
        //public static List<PenalidadeAplicada> lista = new List<PenalidadeAplicada>();

        //public static void ListOfRegister(List<PenalidadeAplicada> lst)
        //{
        //    lista = lst;
        //}

        public static int GetCountRecords(List<PenalidadeAplicada> lista) => lista.Count;

        public static List<PenalidadeAplicada> GetRecordsByCPF(List<PenalidadeAplicada> lista, string cpf) => lista.Where(x => x.CPF.StartsWith(cpf)).ToList();

        public static List<PenalidadeAplicada> GetRecordsByYear(List<PenalidadeAplicada> lista, int year) => lista.Where(x => x.VigenciaCadastro.Year == year).ToList();

        public static List<PenalidadeAplicada> GetRecordsByRazaoSocial(List<PenalidadeAplicada> lista, string razaoSocial) => lista.Where(x => x.RazaoSocial.Contains(razaoSocial)).ToList();

        public static List<PenalidadeAplicada> GetRecordsOrderedByRazaoSocial(List<PenalidadeAplicada> lista) => lista.OrderBy(x => x.RazaoSocial).ToList();

        public static void PrintData(List<PenalidadeAplicada> listaEspecifica)
        {
            foreach (var item in listaEspecifica)
                Console.WriteLine(item);
        }

    }
}
