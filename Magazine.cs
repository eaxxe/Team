namespace Team
{
    class Magazine
    {
        private string? _name;
        private DateTime _dateOfPublicationMagazine;
        private int _magazineCirculation;
        Article[] articles;
        Frequency frequency;
        private Article srticle;   

        public string Name
        {
            set
            {
                if (!string.IsNullOrEmpty(_name)) _name = value;
                else throw new ArgumentException("The provided name is either empty or uninitialized.", nameof(value));
            }
            get => _name ?? string.Empty;
        }

        public DateTime DateOfPublicationMagazine
        {
            set
            {
                if (value != default) _dateOfPublicationMagazine = value;
                else throw new ArgumentException("The provided date of publication is invalid.", nameof(value));
            }
            get => _dateOfPublicationMagazine;
        }

        public int MagazineCirculation
        {
            set
            {
                if (value > 0) _magazineCirculation = value;
                else throw new ArgumentException("The provided circulation of magazine cannot be a negative or equals zero", nameof(value));
            }
            get => _magazineCirculation;
        }

        public Magazine(string name, DateTime dateOfPublicationMagazine, int magazineCirculation)
        {
            Name = name;
            DateOfPublicationMagazine = dateOfPublicationMagazine;
            MagazineCirculation = magazineCirculation;
        }

        public Magazine()
        {
            _name = "Model";
            _dateOfPublicationMagazine = DateTime.Today;
            _magazineCirculation = 10000;
        }

        public override string ToString()
        {
            return $"Name of magazine: {_name}\n" +
                $"Date of publication: {_dateOfPublicationMagazine}\n" +
                $"Magazine circulation: {_magazineCirculation}\n" +
                $"List of articles : \n";
        }
    }
}
