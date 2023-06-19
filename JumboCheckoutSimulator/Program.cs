namespace JumboDatabaseSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console in green.
            Console.ForegroundColor = ConsoleColor.Green;
            
            //Print menu.
            Menu();

            //Data:
            string command;
            List<string> staff = new List<string>();
            List<string> products = new List<string>();
            List<string> requests = new List<string>();
            List<int> staffCode = new List<int>();

            //all the magic happens in here.
            while ((command = Console.ReadLine()) != "8")
            {
                MenuInLoop();

                switch(command)
                {
                    case "1":
                        string cmd = string.Empty;
                        AddStaff(staff, staffCode, cmd);
                        Console.Clear();
                        break;
                    case "5":
                        cmd = string.Empty;
                        CheckStaff(staff, staffCode, cmd);
                        Console.Clear();
                        break;       
                }

                Menu();
            }
        }

        static void PrintLogo()
        {
            Console.WriteLine("             (((((((*,    ,///*..  ,///*. ........      ........  ............. \r\n            ((((((((((% *///////&*,/////*#////////*    *///////*,,*************,..%%%%%%%%%%(, \r\n            (((((((((((#///////(@.///////%//////////**//////////#/******/********(%%%%%%%%%%%%%#    \r\n            *((((((((((&//////(@..///////(///////////////////////%*****/% .*******&%&@/,%%%%%%%%&   \r\n      /((((((,(((((((((%//////%/ ,///////%///////////////////////(#**************%%%%(.%%%%%%%%%%/  \r\n    /(((((((#&*((((((((#(////////////////@////////////////////////&************&#%%%%%%%%%%%%%%%%/  \r\n    ((((((((@,(((((((((%(///////////////@/////////////////////////&*****#%*******(%%%%%%%%%%%%%%&/  \r\n    (((((((((((((((((((&///////////////@//////////////////////////&*****&* *******&%%%%%%%%%%%%%@   \r\n     #((((((((((((((((@//////////////%#////////(@//////(@,////////%***************&%%%%%%%%%%%@%    \r\n      .((((((((((((#@/  ./////////#@(  *///////@/ ,(/(%%.  //////@/*************/&%%%%%%%%%%@#      \r\n         ./#%%%&%(,         .***,.        /##(,               ,*.   ,#(//****(&&/  ,/(((/,   ");
        }
        static void Menu()
        {
            PrintLogo();
            Console.WriteLine();
            Console.WriteLine("1. Add staff                   5. Check staff");
            Console.WriteLine("2. Add product                 6. Check if product is available");
            Console.WriteLine("3. Add request                 7. Check for requests");
            Console.WriteLine("4. Checkout simulator          8. Exit");
            Console.WriteLine();
            Console.Write("Choose an option(number): ");
        }
        static void MenuInLoop()
        {
            Console.Clear();
            PrintLogo();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
            }
        }
        static void AddStaff(List<string> staffList, List<int> codeList, string commandStr)
        {
            Console.Write("How much workers you would add?: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Type 'cancel' to go back to the menu.:)");

            for (int i = 1; i <= n; i++)
            { 
                Console.Write($"Full name and code: ");

                commandStr = Console.ReadLine();
                char[] splitBy = {'-', ' '};
                string[] getCode = commandStr
                    .Split(splitBy, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                //Checking for out of bounds exception or cancel command.
                if (getCode.Length < 3 || getCode.Length > 3 || getCode[0] == "cancel")
                {
                    if (getCode.Length > 3)
                    {
                        Console.WriteLine("Invalid input.");
                        i--;
                        continue;
                    }
                    else if (getCode[0] == "cancel")
                    {
                        break;
                    }
                    else if (getCode.Length < 3)
                    {
                        Console.WriteLine("Invalid input. Maybe you're missing a name.:)");
                        i--;
                        continue;
                    }
                }
                //Checking if code exist.
                else
                {
                    string firstName = getCode[0];
                    string lastName = getCode[1];
                    int codeOfWorker = int.Parse(getCode[2]);

                    string workerWithCode = $"{firstName} {lastName} [{codeOfWorker}]";

                    if (codeList.Contains(codeOfWorker))
                    {
                        Console.WriteLine("This code already exist. Press [Enter]");
                        Console.ReadKey();
                        i--;
                    }
                    else
                    {
                        staffList.Add(workerWithCode);
                        codeList.Add(codeOfWorker);
                    }
                }
            }
        }
        
        static void CheckStaff(List<string> staff, List<int> code,string commandStr)
        {
            Console.WriteLine("1. Search by a code             3. Back.");
            Console.WriteLine("2. Print all staff");
            Console.Write("Choose an option(number): ");
            while ((commandStr = Console.ReadLine()) != "3")
            {
                if (commandStr == "1")
                {
                    Console.WriteLine("Enter a code: ");
                    string newCommand = Console.ReadLine();

                    if (code.Contains(int.Parse(newCommand)))
                    {
                        int index = code.IndexOf(int.Parse(newCommand));
                        Console.WriteLine(string.Join("", staff[index]));
                    }
                    else
                    {
                        Console.WriteLine("Not found.");
                        continue;
                    }
                }
                else if (commandStr == "2")
                {
                    Console.WriteLine(string.Join(" ", staff));
                }

                Console.Write("Choose an option(number): ");
            }
        }
    }
}