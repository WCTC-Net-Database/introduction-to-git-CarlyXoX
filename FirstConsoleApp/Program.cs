using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using System.IO;
using System.Collections;

//Syntax errors and formatting issues solved with ChatGPT
namespace FirstConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            

            void UpdateCSV(string character) {
                StreamWriter sw = new StreamWriter("input.csv", true);
                sw.WriteLine("\n");
                sw.WriteLine(character);
                sw.Close();
            }

            void OutputCSV() {
                StreamReader sr = new StreamReader("input.csv");
                string line;
                while ((line = sr.ReadLine()) != null) {
                    Console.WriteLine(line);
                }
            }
              

            string[] classes = new string[]
            {
                "Barbarian", "Bard", "Cleric", "Druid", "Fighter",
                "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer",
                "Warlock", "Wizard", "Artificer"
            };

            void WriteClasses()
            {
                for (int i = 0; i < classes.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {classes[i]}");
                }
            }

            string ChooseClass(int classChoice)
            {
                if (classChoice >= 1 && classChoice <= classes.Length)
                {
                    return classes[classChoice - 1];
                }
                return "Unknown";
            }

            bool programRunning = true;

            while(programRunning) {
                Console.WriteLine("1. Display Characters");
                Console.WriteLine("2. Add Character");
                Console.WriteLine("3. Level Up Character");
                var input = Console.ReadLine();
                int.TryParse(input, out int opt);

                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Displaying Characters:");
                        OutputCSV();
                        break;
                    case 2:
                        Console.Write("Name: ");
                        var name = Console.ReadLine();
                        WriteClasses();
                        Console.Write("Choose a class: ");
                        int.TryParse(Console.ReadLine(), out int classChoice);
                        string chosenClass = ChooseClass(classChoice);
                        int lvl = 1;
                        int hp = 10;
                        string[] inventory = {};
                            string inventoryLine = String.Join("|", inventory);
                        string character = name + "," + chosenClass + "," + lvl + "," + hp + "," + inventoryLine;

                        UpdateCSV(character);
                        Console.WriteLine("Character added successfully!");
                        break;
                    case 3:
                        Console.Write("Enter Current HP: ");
                        int.TryParse(Console.ReadLine(), out int currentHP);
                        
                        Console.Write("Enter how many HP you wish to add to your stats: ");
                        int.TryParse(Console.ReadLine(), out int increase);
                        
                        currentHP += increase;
                        Console.WriteLine($"Updated HP: {currentHP}");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            
        }
    }
}
