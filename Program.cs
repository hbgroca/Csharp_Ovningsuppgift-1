namespace ÖVNINGSUPPGIFT___SHOPPINGLISTA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variales
            List<string> shoppingList = new List<string>();
            string input;

            do
            {
                Console.Clear();
                Console.WriteLine($"Lägg till produkt dina produkter i shoppinglistan. Avsluta genom att ange avsluta.");
                Console.WriteLine($"Produkt: ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine($"Du måste ange en produkt.");
                }
                else if(input == "avsluta" || input == "Avsluta")
                {
                    break;
                }
                shoppingList.Add(input);
            }
            while (true);

            Console.Clear() ;
            Console.WriteLine("Produkter tillagt i din shoppinglista");
            shoppingList.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("");
            Console.WriteLine("Tryck på valfri tangent för att avsluta.");
            Console.ReadKey();
        }
    }
}
