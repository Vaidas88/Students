using Students;

StudentConsole studentConsole = new StudentConsole();

studentConsole.GenerateFakeStudents();

while (true)
{
    Console.WriteLine("Please enter command: 'Add', 'List', 'Pick {id}', BestInTopic {topic}, BestInClass {topic number}, Best, 'Exit':\n");

    string command = Console.ReadLine() ?? "";

    if (command.ToLower() == "add")
    {
        studentConsole.ExecAdd();
    }
    else if (command.ToLower() == "list")
    {
        studentConsole.ExecList();
    }
    else if (command.ToLower().StartsWith("pick"))
    {
        studentConsole.ExecPick(command);
    }
    else if (command.ToLower().StartsWith("bestintopic"))
    {
        studentConsole.ExecBestInTopic(command);
    }
    else if (command.ToLower() == "best")
    {
        studentConsole.ExecBest();
    }
    else if (command.ToLower().StartsWith("bestinclass"))
    {
        studentConsole.ExecBestInClass(command);
    }
    else if (command.ToLower() == "exit")
    {
        return;
    }
    else
    {
        studentConsole.CommandNotFound();
    }
}