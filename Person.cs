namespace Team
{
    class Person
    {
        private string? _firstName;
        private string? _lastName;
        private DateTime _birthday;

        public DateTime Birthday
        {
            set
            {
                if (value != default && DateTime.Today >= value) _birthday = value;
                else throw new ArgumentException("The provided birthday cannot be later than today.", nameof(value));
            }
            get => _birthday;
        }

        public int BirthYear
        {
            set
            {
                if (value > 0 && value <= DateTime.Today.Year) _birthday = new DateTime(value, _birthday.Month, _birthday.Day);
                else throw new ArgumentException("The provided year cannot be negative or later than the current year.", nameof(value));
            }
            get => _birthday.Year;
        }

        public string FirstName
        {
            set
            {
                if (!string.IsNullOrEmpty(value)) _firstName = value;
                else throw new ArgumentException("The provided first name is either empty or uninitialized.", nameof(value));
            }
            get => _firstName ?? string.Empty;
        }
        public string LastName
        {
            set
            {
                if (!string.IsNullOrEmpty(value)) _lastName = value;
                else throw new ArgumentException("The provided last name is either empty or uninitialized.", nameof(value));
            }
            get => _lastName ?? string.Empty;
        }

        public Person()
        {
            _firstName = "James";
            _lastName = "Smith";
            _birthday = DateTime.Today;
        }

        public Person(string firstName, string lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return ToShortString() + $"Birthday: {_birthday:dd.MM.yyyy)} \n";
        }

        public virtual string ToShortString()
        {
            return $"First name: {_firstName} \n" +
                $"Last name: {_lastName} \n";
        }
    }
}