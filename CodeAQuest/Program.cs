using CodeAQuest.Model;
using CodeAQuest.Parser;
using System;
using System.IO;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace CodeAQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args[0] == "/?")
            {
                Console.WriteLine("You have to specify the path to the quest file");
                return;
            }
            var yaml = new YamlStream();
            yaml.Load(new StreamReader(args[0]));

            var quest = QuestParser.ReadQuest(yaml);
            Console.WriteLine("=== " + quest.Title + " v" + quest.Version + " by " + quest.Author + " ===");
            Console.WriteLine();

            var context = QuestContext.FromQuest(quest);
            context.StartQuest();

            Console.ReadKey();
        }
    }
}
