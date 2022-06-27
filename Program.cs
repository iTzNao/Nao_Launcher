using System.Diagnostics;

Console.Title = "Nao_Launcher";

Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("Please view 'README.txt' before using.\n\n");
Console.ResetColor();

while (true)
{
    Console.Write("    (@@@@ @@@@@@@@@@*       @@@@@@@@@@@#@@@@@      @@@@@@@@@@@@@     ");
    Console.Write("    (@@@@@@     @@@@@@    @@@@@@     ,@@@@@@@    @@@@@&     @@@@@@ \n");
    Console.Write("    (@@@@        %@@@@   @@@@@          @@@@@   @@@@%         @@@@@\n");
    Console.Write("    (@@@@         @@@@   @@@@#          @@@@@   @@@@           @@@@\n");
    Console.Write("    (@@@@         @@@@   @@@@@          @@@@@   @@@@@         @@@@@\n");
    Console.Write("    (@@@@         @@@@    @@@@@@@   .@@@@@@@@    @@@@@@#   @@@@@@@ \n");
    Console.Write("    (@@@@         @@@@      (@@@@@@@@@@ @@@@@      %@@@@@@@@@@@    \n");
    Console.Write("      Nao_Launcher - Launch all your games from one launcher!      \n\n");

    Console.Write("Select a game from the list below:\n");

    var currentDirectory = Directory.GetCurrentDirectory();
    DirectoryInfo gameDir = new DirectoryInfo($"{currentDirectory}\\games");
    FileInfo[] gameFiles = gameDir.GetFiles();
    foreach (var gameFile in gameFiles)
    {
        var gameFileName = gameFile.Name.Remove(gameFile.Name.Length - 4);
        Console.Write($"- {gameFileName}\n");
    }

    var selectedGame = Console.ReadLine();
    var selectedGameDir = $"{currentDirectory}\\games\\{selectedGame}";

    if (Array.Exists(gameFiles, x => x.Name == $"{selectedGame}.url"))
    {
        Process.Start(new ProcessStartInfo(selectedGameDir + ".url") { UseShellExecute = true });
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"Launching '{selectedGame}'\n");
        Console.ResetColor();
    }
    else if (Array.Exists(gameFiles, x => x.Name == $"{selectedGame}.lnk"))
    {
        Process.Start(new ProcessStartInfo(selectedGameDir + ".lnk") { UseShellExecute = true });
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"Launching '{selectedGame}'\n");
        Console.ResetColor();
    }
    else if (Array.Exists(gameFiles, x => x.Name == $"{selectedGame}.exe"))
    {
        Process.Start(new ProcessStartInfo(selectedGameDir + ".exe") { UseShellExecute = true });
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"Launching '{selectedGame}'\n");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Game not found.\n");
        Console.ResetColor();
    }

    Thread.Sleep(2000);
    Console.Clear();
}

// keep the console open,
// dont need it due to
// this never being reached

// Console.ForegroundColor = ConsoleColor.Yellow;
// Console.Write("\nPress any key to continue..");
// Console.ResetColor();
// Console.ReadKey(true);