internal class Program
{
    static void Main(string[] args)
    {
        int antalTal;
        double summa = 0, input, störst = 0, minst = 99999999999999999; //Det finns säkert ett bättre sätt att göra det här men jag är inte smart nog för att lista ut det.
        Console.WriteLine("Antal tal som ska matas in?");
        antalTal = Convert.ToInt32(Console.ReadLine());
        for (int i=1; i <= antalTal; i++)
            {
                Console.WriteLine("Skriv värde " + i + ": ");
                input = Convert.ToDouble(Console.ReadLine());
                summa = summa + input;
                if(input < minst)
                    {
                        minst = input;
                    }
                if(input > störst)
                    {
                        störst = input;
                    }
            }
        Console.WriteLine("Medelvärdet är: " + (summa/antalTal));
        Console.WriteLine("Minsta talet var: " + minst);
        Console.WriteLine("Största talet var: " + störst);
    }
}