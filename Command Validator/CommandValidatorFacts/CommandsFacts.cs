using Xunit;
using Newtonsoft.Json;

namespace Command_Validator
{
    public class CommandsFacts
    {
        [Fact]
        public void CheckForSimpleCommandsArrayWithJustOneValueShouldReturnTrue()
        {
            Command[] commands = {
                new Command("--message", "abc")
            };

            Commands commandsRow = new Commands(commands);


            var command = JsonConvert.SerializeObject(new Command("--message", "abc"));
            var firstIndexCommand = JsonConvert.SerializeObject(commandsRow.GetCommands()[0]);
            Assert.Equal(command, firstIndexCommand);
        }
    }
}