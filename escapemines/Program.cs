using escapemines.Game;
using System;
using System.IO;

namespace escapemines
{
    class Program
    {
        static void Main(string[] args)
        {
            string settingsFilePath = args.Length > 0 ? args[0] : string.Empty;
            
            while (string.IsNullOrEmpty(settingsFilePath))
            {
                Console.WriteLine("Provide path to game settings");
                settingsFilePath = Console.ReadLine();
            }

            var settingsTxt = File.ReadAllLines(settingsFilePath);

            var settings = GameSettingsReader.LoadSettings(settingsTxt);

            if (settings != null && settings.Valid())
            {
                foreach (var actionList in settings.ActionsLists)
                {
                    var board = new Board(settings.BoardWidth, settings.BoardHeight, settings.Mines, settings.ExitPoint);
                    var turtle = new Turtle(settings.StartingPoint, settings.StartingDirection);
                    var minefield = new Minefield(board, turtle);
                    Console.WriteLine($"Result: {minefield.TryEscape(actionList)}");
                }
            }
            else
            {
                Console.WriteLine("Invalid settings provided!");
            }
        }
    }
}
