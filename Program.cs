using AzureCostManager.Classes;
using AzureCostManager.Services;

namespace AzureCostManager
{
    class Program
    {
        static List<User> users = new List<User>();
        static List<Resource> resources = new List<Resource>();

        static void Main(string[] args)
        {
            resources.Add(new Resource("Virtual Machine", "hours", 0.10));
            resources.Add(new Resource("Storage", "GB", 0.02));
            resources.Add(new Resource("Database", "hours", 0.15));
            resources.Add(new Resource("Bandwidth", "GB", 0.07));
            resources.Add(new Resource("Backup", "GB", 0.03));

            users = FileService.LoadUsers();
            if (users.Count == 0)
            {
                users.Add(new Admin("Patrick", "1234"));
                users.Add(new Customer("Peter", "5678"));
                users.Add(new Customer("Pan", "9999"));
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("      AzureCostManager           ");
                Console.WriteLine("=================================");
                Console.WriteLine("Your Username:");
                string username = Console.ReadLine().Trim();

                User user = users.Find(u => u.Username.ToLower() == username.ToLower());

                if (user == null)
                {
                    Console.WriteLine("User not found!");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("Your PIN:");
                string pin = Console.ReadLine().Trim();

                if (!user.Login(pin))
                {
                    Console.WriteLine("Wrong PIN!");
                    Console.ReadKey();
                    continue;
                }

                if (user.Role == "Admin")
                    AdminMenu((Admin)user);
                else
                    CustomerMenu((Customer)user);
            }
        }

        static void AdminMenu(Admin admin)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("          Admin Menu             ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. User Management");
                Console.WriteLine("2. Show All Calculations");
                Console.WriteLine("3. Statistics");
                Console.WriteLine("4. Logout");
                Console.WriteLine("=================================");
                Console.WriteLine("Your choice:");

                bool gültig = int.TryParse(Console.ReadLine(), out int auswahl);

                if (!gültig || auswahl < 1 || auswahl > 4)
                {
                    Console.WriteLine("Invalid input!");
                    Console.ReadKey();
                    continue;
                }

                if (auswahl == 1)
                {
                    Console.Clear();
                    Console.WriteLine("=================================");
                    Console.WriteLine("       User Management           ");
                    Console.WriteLine("=================================");
                    Console.WriteLine("1. Create User");
                    Console.WriteLine("2. Delete User");
                    Console.WriteLine("3. Back");
                    Console.WriteLine("Your choice:");

                    bool gültig2 = int.TryParse(Console.ReadLine(), out int auswahl2);

                    if (auswahl2 == 1)
                    {
                        Console.WriteLine("Username:");
                        string newUsername = Console.ReadLine();
                        Console.WriteLine("PIN:");
                        string newPin = Console.ReadLine();
                        Console.WriteLine("Role (Admin/Customer):");
                        string newRole = Console.ReadLine();
                        admin.CreateUser(users, newUsername, newPin, newRole);
                        FileService.SaveUsers(users);
                        FileService.SaveCalculations(users);
                        Console.ReadKey();
                    }

                    if (auswahl2 == 2)
                    {
                        Console.WriteLine("Username to delete:");
                        string delUsername = Console.ReadLine();
                        admin.DeleteUser(users, delUsername);
                        FileService.SaveUsers(users);
                        FileService.SaveCalculations(users);
                        Console.ReadKey();
                    }
                }

                if (auswahl == 2)
                {
                    Console.Clear();
                    foreach (User u in users)
                        if (u is Customer customer)
                            customer.ShowCalculations();
                    Console.ReadKey();
                }

                if (auswahl == 3)
                {
                    Console.Clear();
                    admin.ShowStatistics(users);
                    Console.ReadKey();
                }

                if (auswahl == 4)
                {
                    FileService.SaveUsers(users);
                    FileService.SaveCalculations(users);
                    break;
                }
            }
        }

        static void CustomerMenu(Customer customer)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("        Customer Menu            ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. New Calculation");
                Console.WriteLine("2. Past Calculations");
                Console.WriteLine("3. My Profile");
                Console.WriteLine("4. Logout");
                Console.WriteLine("=================================");
                Console.WriteLine("Your choice:");

                bool gültig = int.TryParse(Console.ReadLine(), out int auswahl);

                if (!gültig || auswahl < 1 || auswahl > 4)
                {
                    Console.WriteLine("Invalid input!");
                    Console.ReadKey();
                    continue;
                }

                if (auswahl == 1)
                {
                    Console.Clear();
                    Console.WriteLine("=================================");
                    Console.WriteLine("        New Calculation          ");
                    Console.WriteLine("=================================");
                    Console.WriteLine("1. Full Calculation");
                    Console.WriteLine("2. Custom Calculation");
                    Console.WriteLine("3. Edit Existing Calculation");
                    Console.WriteLine("Your choice:");

                    bool gültigSub = int.TryParse(Console.ReadLine(), out int sub);

                    if (sub == 1)
                        customer.FullCalculation(resources);
                    if (sub == 2)
                        customer.IndividualCalculation(resources);
                    if (sub == 3)
                        customer.EditCalculation();
                }

                if (auswahl == 2)
                {
                    Console.Clear();
                    customer.ShowCalculations();
                    Console.ReadKey();
                }

                if (auswahl == 3)
                {
                    Console.Clear();
                    customer.ShowProfile();
                    Console.ReadKey();
                }

                if (auswahl == 4)
                {
                    FileService.SaveUsers(users);
                    FileService.SaveCalculations(users);
                    break;
                }
            }
        }
    }
}