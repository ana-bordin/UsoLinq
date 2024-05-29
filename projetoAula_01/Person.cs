namespace projetoAula_01
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public int Age { get; set; }

        override public string ToString() => $"Id: {Id}, Name: {Name}, Age: {Age}, Telephone: {Telephone}";
    }
}
