internal class Program
{
    private static void Main(string[] args)
        {
            double uno, dos, tres, radie;
            Console.WriteLine("Skriv ett tal.");
            uno = double.Parse(Console.ReadLine());
            Console.WriteLine("Skriv ett till tal.");
            dos = double.Parse(Console.ReadLine());
            Console.WriteLine("Skriv ett tal fast igen.");
            tres = double.Parse(Console.ReadLine());
            Console.WriteLine("Skriv en radie.");
            radie = double.Parse(Console.ReadLine());
            Console.WriteLine("Cirkelns omkrets är: " + CirkelOmkrets(radie));
            Console.WriteLine("Cirkelns area är: " + CirkelArea(radie));
            Console.WriteLine("Medelvärdet av de tre första talen är: " + Medelvärde(uno,dos,tres));
        }

        static double CirkelOmkrets(double r)
        {
            return 2 * 3.14 * r;
        }

        static double CirkelArea(double r)
        {
            return 3.14 * r * r;
        }

        static double Medelvärde(double a, double b, double c)
        {
            return a + b + c / 3;
        }
}