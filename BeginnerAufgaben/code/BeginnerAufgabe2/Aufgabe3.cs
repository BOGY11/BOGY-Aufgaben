namespace Benutzerverwaltung 
{ 
    class Program 
    { 
        private static readonly List<User> Users = new List<User>(); 

        static void Main(string[] args) 
        { 
            bool running = true; 

            while (running) 
            { 
                Console.Clear(); 
                Console.WriteLine("=== Benutzerverwaltung ==="); 
                Console.WriteLine("1 - Benutzer erstellen"); 
                Console.WriteLine("2 - Benutzer anzeigen"); 
                Console.WriteLine("3 - Programm beenden"); 
                Console.WriteLine(); 
                Console.Write("Auswahl: "); 
                string input = Console.ReadLine(); 
                switch (input) 
                { 
                    case "1": 
                        CreateUser(); 
                        break; 
            
                    case "2": 
                        ShowUsers(); 
                        break; 
                    
                    case "3": 
                        running = false; 
                        break; 
                    
                    default: 
                        Console.WriteLine("Ungültige Eingabe."); 
                        Pause(); 
                        break; 
                } 
            } 
        } 
        static void CreateUser() 
        { 
            Console.Clear(); 
            Console.WriteLine("=== Benutzer erstellen ==="); 
            Console.Write("Name: "); 
            string name = Console.ReadLine(); 
            
            int alter; 
            
            while (true) 
            { 
                Console.Write("Alter: "); 
                if (int.TryParse(Console.ReadLine(), out alter)) 
                { 
                    break; 
                } 
                Console.WriteLine("Bitte eine gültige Zahl eingeben."); 
            } 
            
            Console.Write("Lieblingsfarbe: "); 
            string lieblingsfarbe = Console.ReadLine(); 
            User user = new User 
            { 
                Name = name, 
                Alter = alter, 
                Lieblingsfarbe = lieblingsfarbe 
            }; 

            Users.Add(user); 
            Console.WriteLine(); 
            Console.WriteLine("Benutzer erfolgreich gespeichert."); 
            Pause(); 
        } 

        static void ShowUsers() 
        { 
            Console.Clear(); 
            Console.WriteLine("=== Benutzerliste ==="); 
            Console.WriteLine(); 

            if (Users.Count == 0) 
            { 
                Console.WriteLine("Es wurden noch keine Benutzer angelegt."); 
                Pause(); 
                return; 
            } 

            foreach (User user in Users) 
            { 
                Console.WriteLine($"Name: {user.Name}"); 
                Console.WriteLine($"Alter: {user.Alter}"); 
                Console.WriteLine($"Lieblingsfarbe: {user.Lieblingsfarbe}"); 
                Console.WriteLine(new string('-', 30)); 
            } 

            Pause(); 
        } 

        static void Pause() 
        { 
            Console.WriteLine(); 
            Console.WriteLine("Weiter mit Enter..."); 
            Console.ReadLine(); 
        } 
    } 
}
