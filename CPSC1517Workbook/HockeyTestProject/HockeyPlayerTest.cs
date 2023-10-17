using FluentAssertions;
using Hockey.Data;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Hockey.Test
{
    public class HockeyPlayerTest
    {
        // Constants for a test player
        const string FirstName = "Connor";
        const string LastName = "Brown";
        const string BirthPlace = "Toronto, ON, CAN";
        const int HeightInInches = 72;
        const int WeightInPounds = 188;
        const int JerseyNumber = 28;
        const Position PlayerPosition = Position.Center;
        const Shot PlayerShot = Shot.Left;
        static readonly DateOnly DateOfBirth = new DateOnly(1994, 01, 14);
        string ToStringValue = $"{FirstName},{LastName},{JerseyNumber},{PlayerPosition},{PlayerShot},{HeightInInches},{WeightInPounds},{DateOfBirth.ToString("MMM-dd-yyyy")},{BirthPlace}";
        readonly int Age = (DateOnly.FromDateTime(DateTime.Now).DayNumber - DateOfBirth.DayNumber) / 365;

        //[Fact]
        //public void Age_IsCorrect()
        //{
             //Age.Should().Be(29);
        //}

        public HockeyPlayer CreateTestHockeyPlayer()
        {
            return new HockeyPlayer(FirstName, LastName, JerseyNumber, BirthPlace, DateOfBirth, WeightInPounds, HeightInInches, PlayerPosition, PlayerShot);
        }

        [Fact]
        public void HockeyPlayer_Age_ReturnsCorrectValue()
        {
            HockeyPlayer player = CreateTestHockeyPlayer();
            int actual;

            actual = player.Age;

            actual.Should().Be(Age);
        }

        [Fact]
        public void HockeyPlayer_ToString_ReturnsCorrectValue() 
        {
            HockeyPlayer player = CreateTestHockeyPlayer();
            string actual;
            actual = player.ToString();

            actual.Should().Be(ToStringValue);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(98)]
        public void HockeyPlayer_JerseyNumber_GoodSetAndGet(int value) 
        {
            HockeyPlayer player = CreateTestHockeyPlayer();
            int actual;

            player.JerseyNumber = value;
            actual = player.JerseyNumber;

            actual.Should().Be(value);
            
        }

        [Theory]
        [InlineData(0)]
        [InlineData(99)]
        public void HockeyPlayer_JerseyNumber_BadSetThrows(int value)
        {
            HockeyPlayer player = CreateTestHockeyPlayer();
            int actual;

            player.JerseyNumber = value;
            actual = player.JerseyNumber;

            
        }

        [Fact]
        public void HockeyPlayer_Parse_ParsesCorrectly()
        {
            HockeyPlayer actual;
            string line = $"{FirstName},{LastName},{JerseyNumber},{PlayerPosition},{PlayerShot},{HeightInInches},{WeightInPounds},{DateOfBirth.ToString("MMM-dd-yyyy")},{BirthPlace}";

            actual = HockeyPlayer.Parse(line);

            actual.Should().BeOfType<HockeyPlayer>();

        }



    }
}