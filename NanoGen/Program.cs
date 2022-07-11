using System.Security.Cryptography;
using System.Text;

Console.WriteLine("The goal of this project is to reproduce a low level creation of a Nano address.");
Console.WriteLine("The following code only verifies that the extracted code matches the functionality of the libraries they were extracted from.");

// Create private key
Span<byte> private_key = new Span<byte>(Encoding.ASCII.GetBytes("0123456789ABCDEF0123456789ABCDEF"));
var expected_address = "nano_3wfzc94m7k7kxf9uhnif41nyf64gnxmaudqfzapku6w714s41qekkimoxksm";

Console.WriteLine("Control: " + expected_address);
var nano_net_account = new Nano.Net.Account(private_key.ToArray());
Console.WriteLine("Nano.NET: " + nano_net_account.Address);
var nano_gen_account_address = NanoGen.NanoGenAccount.GetAddressFast(private_key);
Console.WriteLine("NanoGen: " + nano_gen_account_address);

if (nano_gen_account_address == nano_net_account.Address) {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Match SUCCESS.");
}
else {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Match FAILURE.");
}

if (nano_net_account.Address == expected_address && nano_gen_account_address == expected_address) {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Validation SUCCESS.");
}
else {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Validation FAILURE.");
}

Console.ForegroundColor = ConsoleColor.White;
