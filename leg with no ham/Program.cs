internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ge mig ett tal mellan 1 och 100");
        
        for (int ham = Convert.ToInt32(Console.ReadLine()); ham <= 101; ham++)
        {
            Console.WriteLine("talet är " + ham);
        }
    }
}