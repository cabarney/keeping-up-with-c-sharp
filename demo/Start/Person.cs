namespace Demo.Start
{
    public class Person
    {
        private int _id;
        private string _firstName;
        private string _lastName;

        public Person()
        {
            Id = 0;
        }

        public Person(string name)
        {
            ParseName(name);
        }

        public Person(int id, string name) : this(name)
        {
            Id = id;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get 
            { 
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public void ParseName(string name)
        {
            var nameParts = name.Split(' ');
            FirstName = nameParts[0];
            LastName = nameParts[1];
        }

        public override string ToString() 
        {
            return string.Format("{0}, {1}", LastName, FirstName);
        }
    }
}