namespace Demo.Finish
{
    public class Person
    {
        public Person(string name) => (FirstName, LastName) = name.ParseName();
        public Person(int id, string name) : this(name) => Id = id;
        
        public int Id { get; } = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{LastName}, {FirstName}";

        public override string ToString() => FullName;
    }
}