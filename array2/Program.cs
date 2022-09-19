internal class Program
{
    static void Main(string[] args)
    {
        double[] temp = {4.5, 3.2, 6.7, 6.1, 2.1, 1.6, 2.9};
        Console.WriteLine("Medelvärde: " + Medel(temp));
    }

    static double Medel(double[] a)
    {
        double summa = 0;
        for(int i = 0; i < a.Length; i++)
        {
            summa += a[i];
        }
        return (Math.Round(summa/ a.Length, 1));
    }
}