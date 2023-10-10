using FluentAssertions;
using BMIExercise;
namespace BodyMassIndexTest
{
	public class BMITests
	{

		public BodyMassIndex CreatePerson()
		{
			return new BodyMassIndex("Jack Black", 180, 65);
		}


		#region Pass

		[Fact]
		public void BMI_ReturnsGoodValue()
		{
			//arrange
			BodyMassIndex person = CreatePerson();

			//assert
			person.Name.Should().Be("Jack Black");
			person.Bmi().Should().Be(30.0);

		}

		[Fact]
		public void BMICategory_ReturnsGoodValue()
		{
			BodyMassIndex person = CreatePerson();

			person.Name.Should().Be("Jack Black");
			person.BmiCategory().Should().Be("obese");

		}

		[Theory]
		[InlineData("Underweight Person1", 90, 60, 17.6, "underweight")]
		[InlineData("Underweight Person2", 120, 75, 15.0, "underweight")]
		public void BMI_Category_ReturnsUnderweight(string name, int weight, int height, double expectedBMI, string expectedCategory)
		{
			BodyMassIndex person = new BodyMassIndex(name, weight, height);

			person.Bmi().Should().Be(expectedBMI);
			person.BmiCategory().Should().Be(expectedCategory);

		}

		[Theory]
		[InlineData("Normal Person1", 111, 65, 18.5, "normal")]
		[InlineData("Normal Person2", 149, 65, 24.8, "normal")]
		public void BMI_Category_ReturnsNormal(string name, int weight, int height, double expectedBMI, string expectedCategory)
		{
			BodyMassIndex person = new BodyMassIndex(name, weight, height);

			person.Bmi().Should().Be(expectedBMI);
			person.BmiCategory().Should().Be(expectedCategory);

		}

		[Theory]
		[InlineData("Overweight Person1", 150, 65, 25.0, "overweight")]
		[InlineData("Overweight Person2", 179, 65, 29.8, "overweight")]
		public void BMI_Category_ReturnsOverweight(string name, int weight, int height, double expectedBMI, string expectedCategory)
		{
			BodyMassIndex person = new BodyMassIndex(name, weight, height);

			person.Bmi().Should().Be(expectedBMI);
			person.BmiCategory().Should().Be(expectedCategory);

		}

		[Theory]
		[InlineData("Obese Person1", 180, 65, 30.0, "obese")]
		[InlineData("Obese Person2", 210, 65, 34.9, "obese")]
		public void BMI_Category_ReturnsObese(string name, int weight, int height, double expectedBMI, string expectedCategory)
		{
			BodyMassIndex person = new BodyMassIndex(name, weight, height);

			person.Bmi().Should().Be(expectedBMI);
			person.BmiCategory().Should().Be(expectedCategory);

		}

		#endregion

		#region Fail

		[Theory]
		[InlineData("")]
		[InlineData(" ")]
		public void BMI_Constructor_EmptyName_ThrowsError(string value)
		{
			Action action = () => new BodyMassIndex(value, 180, 65);

			action.Should().Throw<ArgumentNullException>().WithParameterName("Name cannot be blank");
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-100)]
		public void BMI_WeightConstructor_BadValues_ThrowsError(int value)
		{
			Action action = () => new BodyMassIndex("Jack Black", value, 65);

			action.Should().Throw<ArgumentOutOfRangeException>().WithParameterName("Weight must be a positive non-zero number");
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-100)]
		public void BMI_HeightConstructor_BadValues_ThrowsError(int value)
		{
			Action action = () => new BodyMassIndex("Jack Black", 180, value);

			action.Should().Throw<ArgumentOutOfRangeException>().WithParameterName("Height must be a positive non-zero number");
		}

		#endregion
	}
}