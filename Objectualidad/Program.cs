internal class Program
{
    private static void Main(string[] args)
    {
        List<Vehicle> vehiclelist = new List<Vehicle>();

        Vehicle v = new Vehicle("Volvo", "Volvo 142", 2000);
        vehiclelist.Add(v);
        vehiclelist.Add(new Vehicle("US department of defense", "Stor gryta", 9200));
        vehiclelist.Add(new Vehicle("Yo soy", "Mindre gryta", 9199));

        foreach (Vehicle element in vehiclelist)
        {
            Console.WriteLine(element.Tillverkare);
            Console.WriteLine(element.Modell);
            Console.WriteLine(element.Vikt);
        }
    }

    class Vehicle
    {
        private string tillverkare;
        private string modell;
        private int vikt;

        public Vehicle(string t, string m, int v)
        {
            tillverkare = t;
            modell = m;
            vikt = v;
        }

        public string Tillverkare
    {
        get{return tillverkare;}
    }

        public string Modell
    {
        get{return modell;}
    }

        public int Vikt
    {
        get{return vikt;}
    }

    }
}