internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Är det bra väder idag?");
        string svar = Console.ReadLine();
        if(svar == "Ja" || svar == "ja" || svar == "JA")
        {
            Console.WriteLine("Kulimojs");
        }
        else if(svar == "Nej" || svar == "nej" || svar == "NEJ")
        {
            Console.WriteLine("Inte skojsigt");
        }
        else if(svar == "308 Negra Arroyo Lane")
        {
            Console.WriteLine("I am the one who knocks");
        }
        else
        {
            Console.WriteLine(svar + " du låter som leg");
        }
    }
}