namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Detta skrivs ut i början av spelet
            Console.WriteLine("Välkommen till spelet! Jag tänker på ett tal, kan du gissa vilket? Du har 5 försök.");

            // Anropar funktionen CheckGuess() för att starta spelet
            CheckGuess();

        }

        static void CheckGuess()
        {
           Random random = new Random(); //Skapar en slumpmässig generator
           int randomNumber = random.Next(1, 11); //Genererar en slumpmässig siffra mellan 1 och 10

           int attempts = 5; //Antal försök användaren har på sig
           bool guessedCorrectly = false; // Kör loopen så länge guessedCorrectly är false

           for (int i = 1; i <= attempts; i++)//En loop som räknar varje gissningsförsök och sparas i variabeln "i"
           {

                Console.WriteLine($"Försök nr {i}: ");

                int userInput;
                try
                {
                    // Läser in användarens gissning och konverterar det till en int
                    userInput = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Felaktig inmatning, du kan endast ange siffror");
                    i--; // Minskar värdet på "i" för att inte räkna detta försök
                    continue; // Hoppar över resten av loopen och gå till nästa försök
                }

                if (userInput == randomNumber)
                {
                    guessedCorrectly = true;
                    Console.WriteLine("Wohoo, du gissade rätt! Bra jobbat");
                    PlayAgain();  // Anropar funktionen PlayAgain() för att fråga om användaren vill spela igen
                    break;

                }
                else if (userInput < randomNumber && i !=attempts)
                {
                    Console.WriteLine("Du gissade för lågt. Försök igen.");
                }
                else if (userInput > randomNumber && i != attempts) // Om användaren gissar högre än det slumpmässiga talet
                {
                    Console.WriteLine("Du gissade för högt. Försök igen.");
                }
                if (!guessedCorrectly && i ==attempts) // Om användaren inte gissade rätt efter 5 försök
                {
                    Console.WriteLine("Tyvärr, du lyckades inte gissa rätt på fem försök.");
                    PlayAgain();
                    break;
                }
                
            }

        }
        static void PlayAgain() 
        {
            while (true)
            {
                Console.WriteLine("Vill du spela igen? Ja/Nej");
                string inmatning = Console.ReadLine();

                if (inmatning == "Ja" || inmatning == "ja")
                {
                    CheckGuess();
                }
                else if (inmatning == "Nej" || inmatning == "nej")
                {
                    Console.WriteLine("Tack för att du spelade!");
                    Environment.Exit(0); // Stänger av programmet om användaren väljer "nej"
                }
                else continue; // Om användaren ger en felaktig inmatning, fortsätt att fråga tills en giltig inmatning ges
            }

        }

    }
}