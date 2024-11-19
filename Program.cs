namespace ÖVNINGSUPPGIFT___SHOPPINGLISTA
{
    using Models;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class Program
    {
        // Static variables 
        static List<Product> shoppingList = new List<Product>() 

        // TEST PRODUKTER, KOMMENTERA BORT OM DU INTE VILL HA MED VID START
        {
            new Product(){
                ProductName = "Äggakaga", 
                ProductPrice = 69.90
            },
            new Product(){
                ProductName = "Skånsk senap",
                ProductPrice = 42.90
            },
            new Product(){
                ProductName = "Kagor till kaffet", 
                ProductPrice = 31.90
            },
            new Product(){
                ProductName = "Rägglar", 
                ProductPrice = 49.90
            },
            new Product(){
                ProductName = "Spiddekaga",
                ProductPrice = 99.90
            },
            new Product(){
                ProductName = "Päror / Kartoffler",
                ProductPrice = 44.70
            }
        };

        static void Main(string[] args)
        {
            // Variales (internal)
            double totalPrice = 0;
            bool runProgram = true;

            do
            {
                // Nolla total pris före rendering.
                totalPrice = 0;

                Console.Clear();
                Console.WriteLine("#############################################################");
                Console.WriteLine("#");
                
                // Skriv ut eventuella produkter ifrån shoppinglistan
                if (shoppingList.Count > 0)
                {
                    Console.WriteLine("# Produkter i shoppinglistan");
                    shoppingList.ForEach(x => { Console.WriteLine($"# - {x.ProductName} {x.ProductPrice:F2}kr"); totalPrice += x.ProductPrice; });
                    Console.WriteLine($"# Total kostnad {totalPrice:F2}kr");
                }
                else
                    Console.WriteLine("# Inga produkter i shoppinglistan");

                Console.WriteLine("#");
                Console.WriteLine("# Välj ett alternativ för att fortsätta");
                Console.WriteLine("# 1 - Lägg till vara");
                Console.WriteLine("# 2 - Redigera vara");
                Console.WriteLine("# 3 - Ta bort vara");
                Console.WriteLine("# 4 - Avsluta");
                Console.WriteLine("#");
                Console.WriteLine("#############################################################");

                // Kontrollera val och aggera därefter
                switch (Console.ReadLine())
                {
                    default:
                        {
                            // Ogiltig inmatning
                            break;
                        }
                    case "1":
                        {
                            // Lägg till produkt
                            AddProcuct();
                            break;
                        }
                    case "2":
                        {
                            // Redigera produkt
                            EditProduct();
                            break;
                        }
                    case "3":
                        {
                            // Ta bort produkt
                            RemoveProduct();
                            break;
                        }
                    case "4":
                        {
                            // Stäng program
                            runProgram = false;
                            break;
                        }
                }
            } while (runProgram);
        }

        static void AddProcuct()
        {
            // Variabler (internal)
            string inputPrice;
            string inputName;

            // skapa produkt ifrån Product model
            Product product = new Product();
            
            Console.Clear();
            Console.WriteLine("#############################################################");
            Console.WriteLine("#");
            Console.WriteLine("# Ange produktnamn, etc Mjölk. Skriv X för att avbryta");
            Console.WriteLine("#");

            // Produktnamn input
            inputName = Console.ReadLine()!;
            if (string.IsNullOrEmpty(inputName))
            {
                Console.WriteLine($"# Du måste ange en produkt.");
            }
            else
            {
                // Om skrivit X så återgår vi till huvudmenyn
                if (inputName == "X" || inputName == "x") { return; };

                product.ProductName = inputName;
                Console.WriteLine("# Ange pris (Optional)");
                Console.WriteLine("#");

                // Pris input
                inputPrice = Console.ReadLine()!;
                // Kontrollera så att det endast är siffror i pris variablen
                if (Regex.IsMatch(inputPrice, @"^[0-9.,]+$")) 
                {
                    product.ProductPrice = double.Parse(inputPrice); 
                    shoppingList.Add(product); 
                }
            }  
        }


        static void EditProduct()
        {
            // Variabler (internal)
            string selectedIndex;

            Console.Clear();
            Console.WriteLine("#############################################################");
            Console.WriteLine("#");
            // Om shoppinglistan är tom så skriver vi ut det och återgår till huvudmenyn
            if(shoppingList.Count == 0)
            {
                Console.WriteLine("# Inga produkter i shoppinglistan");
                Console.WriteLine("#");
                Console.WriteLine("# Tryck valfri knapp för att återgå till huvudmenyn.");
                Console.ReadKey();
                return;
            }
            // Skriv ut shoppinglistan, index, produktnamn, produktpris avrundat till 2 decimaler
            shoppingList.ForEach(x => Console.WriteLine($"# {shoppingList.IndexOf(x)+1} - {x.ProductName} {x.ProductPrice:F2}"));
            Console.WriteLine("#");
            Console.WriteLine("# Välj vara att redigera. Skriv X för att avbryta");
            Console.WriteLine("#");

            selectedIndex = Console.ReadLine()!;

            if (string.IsNullOrEmpty(selectedIndex))
            {
                Console.WriteLine($"# Ogiltigt val, återgår till huvudmenyn.");
                Console.ReadKey();
                return;
            }
            else
            {
                // Om skrivit X så återgår vi till huvudmenyn
                if (selectedIndex == "X" || selectedIndex == "x") { return; };

                // Kontrollera så att vi endast har siffror i index variabeln
                if (Regex.IsMatch(selectedIndex, @"^[0-9]"))
                {
                    var x = int.Parse(selectedIndex);
                    if (x < 1) { return; }
                    if (x <= shoppingList.Count && x > 0) 
                    {
                        string input;

                        Console.Clear();
                        Console.WriteLine("#############################################################");
                        Console.WriteLine($"# ");

                        Console.WriteLine($"# Redigera namn (Lämna tomt om du inte vill ändra namnet)");
                        Console.Write($"#  vara: ({shoppingList[x - 1].ProductName}): ");
                        input = Console.ReadLine()!;
                        if (!string.IsNullOrEmpty(input))
                        {
                            shoppingList[x - 1].ProductName = input;
                        }

                        Console.WriteLine($"# ");
                        Console.WriteLine($"# Redigera pris (Lämna tomt om du inte vill ändra priset)");
                        Console.Write($"#  vara: ({shoppingList[x - 1].ProductPrice:F2}): ");
                        input = Console.ReadLine()!;

                        // Kontrollera så att det endast är siffror i pris variablen
                        if (Regex.IsMatch(input, @"^[0-9.,]+$"))
                        {
                            shoppingList[x - 1].ProductPrice = double.Parse(input);
                        }
                    };
                }
                else
                {
                    Console.WriteLine($"# Felaktigt val, återgår till huvudmenyn.");
                    Console.ReadKey();
                    return;
                };
            }
        }


        static void RemoveProduct()
        {
            // Variabler
            string selectedIndex;

            Console.Clear();
            Console.WriteLine("#############################################################");
            Console.WriteLine("#");
            // Om skrivit X så återgår vi till huvudmenyn
            if (shoppingList.Count == 0)
            {
                Console.WriteLine("# Inga produkter i shoppinglistan");
                Console.WriteLine("#");
                Console.WriteLine("# Tryck valfri knapp för att återgå till huvudmenyn.");
                Console.ReadKey();
                return;
            }
            // Skriv ut shoppinglistan, index, produktnamn, produktpris avrundat till 2 decimaler
            shoppingList.ForEach(x => Console.WriteLine($"# {shoppingList.IndexOf(x) + 1} - {x.ProductName} {x.ProductPrice:F2}"));
            Console.WriteLine("#");
            Console.WriteLine("# Välj vara att ta bort. Skriv X för att avbryta");
            Console.WriteLine("#");

            selectedIndex = Console.ReadLine()!;

            // Valt index
            if (string.IsNullOrEmpty(selectedIndex))
            {
                Console.WriteLine($"# Ogiltigt val, återgår till huvudmenyn.");
                Console.ReadKey();
                return;
            }
            else
            {
                // Om skrivit X så återgår vi till huvudmenyn
                if (selectedIndex == "X" || selectedIndex == "x") { return; };

                // Kontrollera så att vi endast har siffror i index variabeln
                if (Regex.IsMatch(selectedIndex, @"^[0-9]"))
                {
                    var x = int.Parse(selectedIndex);
                    if(x < 1) { return; }
                    if (x <= shoppingList.Count && x > 0) shoppingList.RemoveAt(x-1);
                }
                else {
                    Console.WriteLine($"# Felaktigt val, återgår till huvudmenyn.");
                    Console.ReadKey();
                    return;
                };
            }
        }
    }
}
