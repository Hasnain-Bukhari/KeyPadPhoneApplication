using KeyPadPhone.Processor;

namespace KeyPadPhone
{
    public class Program
    {
        static void Main(string[] args)
        {
            KeyPadPhoneProcessor processor = new KeyPadPhoneProcessor();

            // Example inputs
            Console.WriteLine(processor.ProcessInput("33#")); // Output: E
            Console.WriteLine(processor.ProcessInput("227*#")); // Output: B
            Console.WriteLine(processor.ProcessInput("4433555 555666#")); // Output: HELLO
            Console.WriteLine(processor.ProcessInput("7777*#")); // Output: S
            Console.WriteLine(processor.ProcessInput("8 88777444666*664#")); // => output: TURING
            
            Console.WriteLine("Please Enter Custom input!");
            var customInput = Console.ReadLine() ?? "";
            Console.WriteLine(processor.ProcessInput((customInput)));
            Console.ReadKey();
        }
    }
}
