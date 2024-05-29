namespace projetoAula_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio do processamento;");
            var people = Adm.LoadData();
            Adm.PrintData(people);

            Console.WriteLine("\nListar todas as pessoas que tem mais de 18 anos;");

            List<Person> peopleOlderThan18 = Adm.GetPeopleOlderThan18(people);
            Adm.PrintData(peopleOlderThan18);

            Console.WriteLine("\nListar todas as pessoas que tem mais de 18 anos (Usando LINQ);");
            Adm.PrintData(Adm.GetPeopleOlderThan18UseLinq(people));

            Console.WriteLine("\nListar todas as pessoas que tem o nome que inicia com a letra A;");
            Adm.PrintData(Adm.PeopleNameStartsWithA(people));

            Console.WriteLine("\nListar todas a spessoas ordenadas por nome");
            Adm.PrintData(Adm.peopleOrderedByName(people));

            Console.WriteLine("\nListar todas a spessoas ordenadas por nome decrescente");
            Adm.PrintData(Adm.peopleOrderedByNameDescending(people));

            Console.WriteLine("Listar todas as pessoas que tenham a letra 'A' no nome e que tenham o nome com mais de 3 caracteres");
            Adm.PrintData(Adm.PeopleNameWithAAndMoreThreeLetters(people));

            Console.WriteLine("\nFim do processamento;");
        }
    }
}
