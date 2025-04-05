using System;
using Xunit;
using KeyPadPhone.Processor;

namespace KeyPadPhone.Tests
{
    public class KeyPadPhoneProcessorTests
    {
        [Theory]
        [InlineData("33#", "E")]
        [InlineData("227*#", "B")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("7777*#", "")]
        [InlineData("777777777#", "P")]
        [InlineData("8 88777444666*664#", "TURING")]
        public void Test_SimpleInput(string input, string output)
        {
            var processor = new KeyPadPhoneProcessor();
            Assert.Equal(output, processor.ProcessInput(input));
        }
        
        [Fact]
        public void Test_InvalidInput_ThrowsException()
        {
            var processor = new KeyPadPhoneProcessor();
            Assert.Throws<ArgumentException>(() => processor.ProcessInput("4433555 555666"));
        }
    }
}