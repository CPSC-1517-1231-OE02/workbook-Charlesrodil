namespace BMIWebApp.Data
{
    public class BodyMass
    {
        internal const double PoundsToKg = 0.45359237;
        internal const double InchesToMeters = 0.0254;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public double HeightInInches { get; set; }

        public double WeightInPounds { get; set; }

        public double BMI 
        { 
            get
            {
                return (WeightInPounds * PoundsToKg ) / Math.Pow((HeightInInches * InchesToMeters), 2);
            }
        
        }

        public string BMIClass
        {
            get
            {
                string bmiType = "";

                switch (BMI)
                {
                    case < 18.5:
                        bmiType = "Underweight";
                        break;
                    case < 24.9:
                        bmiType = "Normal";
                        break;
                    case < 29.9:
                        bmiType = "Overweight";
                        break;
                    case >= 30:
                        bmiType = "Obese";
                        break;
                }

                return bmiType;
            }
        }

        public BodyMass(string firstName, string lastName, double heightInInches, double weightInPounds) 
        {
            FirstName = firstName;
            LastName = lastName;
            HeightInInches = heightInInches;
            WeightInPounds = weightInPounds;
        }

        public override string ToString()
        {
            return $"{FirstName},{LastName},{HeightInInches},{WeightInPounds}";
        }

        public static BodyMass Parse(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) 
            {
                throw new ArgumentNullException("Line cannot be null empty or whitespace!");
            }

            string[] parts = line.Split(',');

            if (parts.Length != 4)
            {
                throw new ArgumentException("Line must have 4 components: First Name, Last Name, Height in Inches, Weight in pounds");
            }

            BodyMass person;

            try
            {
                person = new BodyMass(parts[0], parts[1], double.Parse(parts[2]), double.Parse(parts[3]));

            }
            catch
            {
                throw new ArgumentException($"Error parsing line: {line}");
            }

            return person;

        }

        public static bool TryParse(string line, out BodyMass person)
        {
            bool isParsed;

            try
            {
                person = BodyMass.Parse(line);
                isParsed = true;
            }
            catch
            {
                person = null;
                isParsed = false;
            }

            return isParsed;
        }


    }
}
