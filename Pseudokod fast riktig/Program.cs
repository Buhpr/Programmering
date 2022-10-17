internal class Program
{
    private static void Main(string[] args)
    {
        Random rd = new Random();
        int rand = rd.Next(1, 100);
        int tal = 0;
        int försök = 1;

        Console.WriteLine("Skriv ett heltal mellan 1 och 100");

        while(rand != tal)
        {
            tal = int.Parse(Console.ReadLine());
            if(tal == rand)
            {
                Console.WriteLine("Det var rätt tal!");
                Console.WriteLine("Det tog dig " + försök + " försök!");
            }
            if(tal < rand)
            {
                Console.WriteLine("Talet är för litet, prova igen.");
                försök ++;
            }
            if(tal > rand)
            {
                Console.WriteLine("Talet är för stort, prova igen.");
                försök ++;
            }
        }
    }
}