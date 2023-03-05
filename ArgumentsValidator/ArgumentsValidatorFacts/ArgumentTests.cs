using Xunit;

namespace ArgumentsValidator
{
    public class ArgumentTests
    {
        [Fact]
        public void CheckValidArgumentWithNameShouldReturnTrue()
        {
            Argument argument = new Argument("message", "m");
            string[] commands = { "--message" };

            Assert.True(argument.Match(commands).Success());
        }

        [Fact]
        public void CheckInvalidArgumentWithInvalidName()
        {
            Argument argument = new Argument("message", "m");
            string[] commands = { "--m" };
            
            Assert.False(argument.Match(commands).Success());
        }

        [Fact]
        public void CheckValidArgumentWithValidAlias()
        {
            Argument argument = new Argument("message", "m");
            string[] commands = { "-m" };

            Assert.True(argument.Match(commands).Success());
        }

        [Fact]
        public void CheckValidArgumentWithASingleOptionShouldReturnTrue()
        {
            Argument argument = new Argument("message", "m", new Argument("ammend", "a"));
            string[] commands = { "--message", "--ammend" };

            Assert.True(argument.Match(commands).Success());
        }

        [Fact]
        public void CheckForValidArgumentWithMultipleOptionsShouldReturnTrue()
        {
            Argument argument = new Argument("message", "m", new Argument("ammend", "a"), new Argument("color", "c"));
            string[] commands = { "--message", "-c" };

            Assert.True(argument.Match(commands).Success());
        }

        [Fact]
        public void CheckForInvalidArgumentWithAnOptionShouldReturnFalse()
        {
            Argument argument = new Argument("message", "m", new Argument("ammend", "a"));
            string[] commands = { "--message", "--color" };

            Assert.False(argument.Match(commands).Success());
        }

        [Fact]
        public void CheckForInvalidArgumentWithMultipleOptionsShouldReturnFalse()
        {
            Argument argument = new Argument("message", "m", new Argument("ammend", "a"), new Argument("setcolor", "s"));
            string[] commands = { "--message", "--color" };

            Assert.False(argument.Match(commands).Success());
        }

        [Fact]
        public void CheckForInvalidArgumentWithMultipleOptionsAndAnArgumetInAnOptionShouldReturnFalse()
        {
            Argument argument = new Argument("message", "m", new Argument("ammend", "a"), new Argument("color", "c", new Argument("setcolor", "s")));
            string[] commands = { "--message", "--color", "abc" };
            string[] commands2 = { "--message", "--ammend", "--setcolor" };

            Assert.False(argument.Match(commands).Success());
            Assert.False(argument.Match(commands2).Success());
        }
        
        [Fact]
        public void CheckForValidArgumentWithMultipleOptionsAndAnArgumentInAnOptionShouldReturnTrue()
        {
            Argument argument = new Argument("message", "m", new Argument("ammend", "a"), new Argument("color", "c", new Argument("setcolor", "s")));
            string[] commands = { "--message", "--color", "--setcolor" };

            Assert.True(argument.Match(commands).Success());
        }

        [Fact]
        public void CheckForValidArgumentWithMultipleOptionsAndMultipleArgumentsInAnOptions()
        {
            Argument ammendOptionForArg = new Argument("ammend", "a");

            Argument optionForColor = new Argument("setcolor", "s");
            Argument optionForColor2 = new Argument("disablecolor", "d");
            Argument colorOption = new Argument("color", "c", optionForColor, optionForColor2);

            Argument argument = new Argument("message", "m", ammendOptionForArg, colorOption);

            string[] commandsAmmend = { "--message", "--ammend" };
            string[] commandsColor = { "--message", "--color", "--disablecolor" };

            Assert.True(argument.Match(commandsAmmend).Success());
            Assert.True(argument.Match(commandsColor).Success());

            string[] wrongAmmendCommand = { "--message", "--ammend", "--setcolor" };
            Assert.False(argument.Match(wrongAmmendCommand).Success());

            string[] anotherValidColorCommand = { "--message", "--color", "-s" };
            Assert.True(argument.Match(anotherValidColorCommand).Success());
        }

        [Fact]
        public void CheckForInvalidArgumentWhichDoesNotHaveAnOptionButItStillCommandsShouldReturnFalse()
        {
            Argument argument = new Argument("ammend", "m");
            string[] command = { "--ammend", "--abc" };
            string[] secondCommand = { "--ammend", "abc" };

            Assert.False(argument.Match(command).Success());
            Assert.False(argument.Match(secondCommand).Success());
        }

        [Fact]
        public void CheckForValidArgumentWithValueShouldReturnTrue()
        {
            Argument argument = new Argument("message", "m", new Value());
            string[] command = { "--message", "abc" };

            Assert.True(argument.Match(command).Success());
        }

        [Fact]
        public void CheckForValidNumberWithPredefinedValueShouldReturnTrue()
        {
            Argument argument = new Argument("color", "c", new Value("blue"));
            string[] command = { "--color", "blue" };

            Assert.True(argument.Match(command).Success());
        }

        [Fact]
        public void CheckForValidArgumentWithMultiplePredefinedValues()
        {
            Argument argument = new Argument("color", "c", new Value("red"), new Value("green"), new Value("blue"));
            string[] command = { "--color", "green" };
            string[] secondCommand = { "--color", "lightgreen" };

            Assert.True(argument.Match(command).Success());
            Assert.False(argument.Match(secondCommand).Success());
        }

        [Fact]
        public void CheckMoreComplexArgument()
        {
            Argument argument = new Argument("message", "m", new Value(), new Argument("setcolor", "s", new Value("red"), new Value("green"), new Value("blue")));

            string[] command = { "--message", "abc" };
            Assert.True(argument.Match(command).Success());

            string[] secondCommand = { "--message", "abc", "--setcolor", "green" };
            Assert.True(argument.Match(secondCommand).Success());

            string[] thirdCommand = { "--message", "--setcolor", "white" };
            Assert.False(argument.Match(thirdCommand).Success());
        }
    }
}
