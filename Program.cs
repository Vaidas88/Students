using Students;

StudentConsole studentConsole = new StudentConsole();

while (true)
{
    Console.WriteLine("Please enter command: 'Add', 'List', 'Pick {id}', 'Exit':\n");

    string command = Console.ReadLine() ?? "";
    command = command.ToLower();

    if (command == "add")
    {
        studentConsole.ExecAdd();
    }
    else if (command == "list")
    {
        studentConsole.ExecList();
    }
    else if (command.StartsWith("pick"))
    {
        studentConsole.ExecPick(command);
    }
    else if (command == "exit")
    {
        return;
    }
    else
    {
        Console.WriteLine("Command was not recognized. Please try again.");
    }
}