using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAQuest.Model
{
    public class QuestContext
    {
        private bool running;
        private Quest quest;
        private State currentState;

        private QuestContext(Quest quest)
        {
            this.quest = quest;
        }

        public static QuestContext FromQuest(Quest quest)
        {
            return new QuestContext(quest);
        }

        public string ResolvePlaceholders(string parameter)
        {
            return parameter.Replace("$title", quest.Title).Replace("$version", quest.Version);
        }

        public void StartQuest()
        {
            GotoState(quest.InitialState);
            this.running = true;
            while (running)
                ExecuteAction(Prompt());
        }

        private void ExecuteAction(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
                return;
            foreach (var action in currentState.Actions)
            {
                if (action.Key == prompt)
                {
                    action.Handler.Execute(this);
                    Console.WriteLine();
                    return;
                }
            }
            Console.WriteLine("You cannot " + prompt);
            Console.WriteLine();
        }

        private string Prompt()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }

        public void Exit()
        {
            running = false;
        }

        public void RunScript(string name)
        {
            if (quest.Scripts != null)
                foreach (var script in quest.Scripts)
                    if (script.Name == name)
                    {
                        script.InstructionBlock.Execute(this);
                        return;
                    }
            Console.WriteLine();
            Console.WriteLine("Sorry, but an internal error occurred with this quest:");
            Console.WriteLine($"The script '{name}' could not be found");
            Console.WriteLine();
            Exit();
        }

        public void GotoState(string name)
        {
            foreach (var state in quest.States)
                if (state.Name == name)
                {
                    currentState = state;
                    Console.WriteLine(currentState.Description);
                    Console.WriteLine();
                    Console.WriteLine("Possible actions: ");
                    foreach (var action in state.Actions)
                    {
                        Console.WriteLine(" - " + action.Key);
                    }
                    Console.WriteLine();
                }
        }

    }
}
