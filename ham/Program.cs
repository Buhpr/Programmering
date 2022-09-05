internal class Program
{
    static void Main(string[] args)
    {
        int Tal;
        Console.WriteLine("Skriv ett tal mellan 1 och 100");
        Tal = Convert.ToInt32(Console.ReadLine());

        while(Tal <= 101)
        {
            Console.WriteLine(Tal);
            Tal++;
        }
    }
}