using Utils;
namespace BMIExercise
{
	public class BodyMassIndex
	{
		private double _weight;
		private double _height;
		public string Name { get; private set; }
		public double Weight
		{
			get
			{
				return _weight;
			}
			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("Weight must be a positive non-zero number");

				}
				_weight = value;
			}
		}


		public double Height
		{
			get
			{
				return _height;
			}
			set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("Height must be a positive non-zero number");
				}

				_height = value;
			}
		}


		public BodyMassIndex(string name, double weight, double height)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Name cannot be blank");
			}

			Name = name;
			Weight = weight;
			Height = height;
		}


		/// <summary>
		/// Calculate the body mass index (BMI) using the weight and height of the person.
		/// The BMI of a person is calculated using the formula: BMI = 700 * weight /(height* height)
		/// where weight is in pounds and height is in inches.
		/// </summary>
		/// <returns>the body mass index (BMI) value of the person</returns>
		public double Bmi()
		{
			double bmiValue = 703 * Weight / Math.Pow(Height, 2);
			bmiValue = Math.Round(bmiValue, 1);
			return bmiValue;
		}


		/// <summary>
		/// Determines the BMI Category of the person using their BMI value.
		/// </summary>
		/// <returns>one of following: underweight, normal, overweight, obese.</returns>
		public string BmiCategory()
		{
			string category = "Unknown";
			double bmiValue = Bmi();


			switch (bmiValue)
			{
				case < 18.5:
					category = "underweight";
					break;
				case < 24.9:
					category = "normal";
					break;
				case < 29.9:
					category = "overweight";
					break;
				case >= 30:
					category = "obese";
					break;

			}

			return category;
		}


	}
}
