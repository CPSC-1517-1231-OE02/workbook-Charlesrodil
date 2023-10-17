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

		public Position Position { get; set; }

        public Shot Shot { get; set; }

        //Greedy constructor

        public HockeyPlayer(string firstName, string lastName,int jerseyNumber, string birthPlace, DateOnly birthDate, int weightInPounds, int heightInInches, Position position, Shot shot)
        {
            BirthPlace = birthPlace;
            HeightInInches = heightInInches;
            DateOfBirth = birthDate;
            Position = position;
            Shot = shot;
            JerseyNumber = jerseyNumber;
            FirstName = firstName;
            LastName = lastName;
            WeightInPounds = weightInPounds;
        }

        // Override ToString - Displays a formatted version of the object to display comma separated value format for class fields
        public override string ToString()
        {
            return $"{FirstName},{LastName},{JerseyNumber},{Position},{Shot},{HeightInInches},{WeightInPounds},{DateOfBirth.ToString("MMM-dd-yyyy")},{BirthPlace}";
        }

        public int Age => (DateOnly.FromDateTime(DateTime.Now).DayNumber - DateOfBirth.DayNumber) / 365;

        public static HockeyPlayer Parse(string line )
        {
			// Connor,Brown,28,RightWing,Right,72,184,Jan-14-1994,Toronto-ON-CAN
			// Split on commas

			string[] fields = line.Split(',');

            HockeyPlayer player;

            player = new HockeyPlayer(fields[0], fields[1], int.Parse(fields[2]), fields[8], DateOnly.ParseExact(fields[7], "MMM-dd-yyyy"), int.Parse(fields[6]), int.Parse(fields[5]), Enum.Parse<Position>(fields[3]), Enum.Parse<Shot>(fields[4]));

            return player;
        }

    }
}