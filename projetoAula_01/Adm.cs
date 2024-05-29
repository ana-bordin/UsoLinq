namespace projetoAula_01
{
    public class Adm
    {
        public static List<Person> LoadData()
        {
            var people = new List<Person>();
            people.Add(new Person() { Id = 1, Name = "André Silva", Age = 37, Telephone = "16 999989898" });
            people.Add(new Person() { Id = 2, Name = "João Silva", Age = 15, Telephone = "16 999981010" });
            people.Add(new Person() { Id = 3, Name = "José Silva", Age = 20, Telephone = "16 999935360" });
            people.Add(new Person() { Id = 4, Name = "Maria Silva", Age = 10, Telephone = "16 991089303" });
            people.Add(new Person() { Id = 5, Name = "Josué Silva", Age = 70, Telephone = "16 993089887" });
            people.Add(new Person() { Id = 6, Name = "Moises Silva", Age = 53, Telephone = "16 991089898" });

            return people;
        }

        public static List<Person> GetPeopleOlderThan18(List<Person> people)
        {
            List<Person> peopleOlderThan18 = new List<Person>();
            foreach (var p in people)
            {
                if (p.Age > 18)
                    peopleOlderThan18.Add(p);
            }
            return peopleOlderThan18;
        }

        public static List<Person> GetPeopleOlderThan18UseLinq(List<Person> people) => people.Where(p => p.Age > 18).ToList();

        public static List<Person> PeopleNameStartsWithA(List<Person> people) => people.Where(p => p.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase)).ToList();

        public static List<Person> peopleOrderedByName(List<Person> people) => people.OrderBy(p => p.Name).ToList();

        public static List<Person> peopleOrderedByNameDescending(List<Person> people) => people.OrderByDescending(p => p.Name).ToList();

        public static List<Person> PeopleNameWithAAndMoreThreeLetters(List<Person> people) => (people.Where(p => p.Name.Contains("a", StringComparison.OrdinalIgnoreCase) && p.Name.Length > 3).ToList());

        public static void PrintData(List<Person> people)
        {
            foreach (var p in people)
                Console.Write(p + "\n");
        }
    }
}
