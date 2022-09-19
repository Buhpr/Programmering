internal class Program
{
    static void Main(string[] args)
   {
        int[] Leg = new int[5];
        for (int i = 0; i < Leg.Length; i++)
        {
            Console.WriteLine("Ge mig tal nummer " + (i+1) + ": ");
            Leg [i] = int.Parse(Console.ReadLine());
        }
        for(int i = 4; i > -1; i--)
        {
            Console.WriteLine(Leg[i]);
        }
    }
}