namespace Demo.Start
{
    public class Person
    {
        private int _id = 0;
        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get 
            {
                return string.Format("{0}, {1}", LastName, FirstName);
            }
        }

        public Person(string name)
        {
            string firstName, lastName;
            name.ParseName(out firstName, out lastName);
            FirstName = firstName;
            LastName = lastName;
        }

        public Person(int id, string name) : this(name)
        {
            _id = id;
        }

        public override string ToString() 
        {
            return FullName;            
        }
    }
}