using Utils;
using Hockey.Data;
using System.Security.AccessControl;

namespace Hockey.Data
{
    // <summary>
    // An instance of this class will hold data about a hockey player
    // </summary>
    
    public class HockeyPlayer
    {
        // Data fields

        private string _birthplace;
        private string _firstName;
        private string _lastName;
        private int _heightInInches;
        private int _weightInPounds;
        private DateOnly _dateOfBirth;
        private int _jerseyNumber;

        //Properties

        public string BirthPlace 
        { 
            get 
            { 
                return _birthplace; 
            }
            
            private set 
            {
                if (Utilities.IsNullEmptyOrWhiteSpace(value))
                {
                    throw new ArgumentException("Birth place cannot be null or empty.");
                }

                _birthplace = value;
                
            }
            
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            private set
            {
                if (Utilities.IsNullEmptyOrWhiteSpace(value))
                {
                    throw new ArgumentException("First Name cannot be null or empty.");
                }

                _firstName = value;

            }

        }

        public string LastName
        {
            get
            {
                return _lastName;
            }

            private set
            {
                if (Utilities.IsNullEmptyOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last Name cannot be null or empty.");
                }

                _lastName = value;

            }

        }

        public int WeightInPounds
        {
            get
            {
                return _weightInPounds;
            }

            private set
            {
                if (!Utilities.IsPositive(value))
                {
                    throw new ArgumentException("Weight must be positive.");
                }

                _weightInPounds = value;


            }

        }

        public int HeightInInches
        {
            get
            {
                return _heightInInches;
            }

            private set
            {
                if (Utilities.IsZeroOrNegative(value))
                {
                    throw new ArgumentException("Height must be positive.");
                }

                _heightInInches = value;

            }

        }

        public DateOnly DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }

            set
            {
                if(Utilities.IsInTheFuture(value))
                {
                    throw new ArgumentException("Date of birth cannot be in the future.");
                }

                _dateOfBirth = value;
            }
        }

        public Position Position { get; set; }

        public Shot Shot { get; set; }

        //Greedy constructor

        public HockeyPlayer(string firstName, string lastName, string birthPlace, DateOnly birthDate, int weightInPounds, int heightInInches, Position position, Shot shot)
        {
            BirthPlace = birthPlace;
            HeightInInches = heightInInches;
            DateOfBirth = birthDate;
            Position = position;
            Shot = shot;
            FirstName = firstName;
            LastName = lastName;
            WeightInPounds = weightInPounds;
        }

        // Override ToString - Displays a formatted version of the object to display comma separated value format for class fields
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public int Age => (DateOnly.FromDateTime(DateTime.Now).DayNumber - DateOfBirth.DayNumber) / 365;

        public int JerseyNumber 
        {
            get 
            {
                return _jerseyNumber;
            }

            set
            {
                _jerseyNumber = value;
            }
        }


    }
}