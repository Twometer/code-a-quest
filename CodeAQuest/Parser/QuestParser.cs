using CodeAQuest.Model;
using CodeAQuest.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.RepresentationModel;

namespace CodeAQuest.Parser
{
    public class QuestParser
    {

        public static Quest ReadQuest(YamlStream yamlStream)
        {
            var quest = new Quest();
            var rootNode = (YamlMappingNode)yamlStream.Documents[0].RootNode;
            foreach (var child in rootNode.Children)
            {
                var key = ((YamlScalarNode)child.Key).Value;
                if (key == "title")
                    quest.Title = ((YamlScalarNode)child.Value).Value;
                else if (key == "version")
                    quest.Version = ((YamlScalarNode)child.Value).Value;
                else if (key == "author")
                    quest.Author = ((YamlScalarNode)child.Value).Value;
                else if (key == "start")
                    quest.InitialState = ((YamlScalarNode)child.Value).Value;
                else if (key == "states")
                    ReadStates(quest, (YamlSequenceNode)child.Value);
                else if (key == "scripts")
                    ReadScripts(quest, (YamlSequenceNode)child.Value);
            }
            return quest;
        }

        private static void ReadStates(Quest quest, YamlSequenceNode node)
        {
            var statesIdx = 0;
            var states = new State[node.Children.Count];
            foreach (var child in node.Children)
            {
                var mapNode = child as YamlMappingNode;
                var state = new State();
                foreach (var mapChild in mapNode.Children)
                {
                    var key = ((YamlScalarNode)mapChild.Key).Value;
                    if (key == "name")
                        state.Name = ((YamlScalarNode)mapChild.Value).Value;
                    else if (key == "desc")
                        state.Description = ((YamlScalarNode)mapChild.Value).Value;
                    else if (key == "actions")
                        ReadActions(state, (YamlSequenceNode)mapChild.Value);
                }
                states[statesIdx] = state;
                statesIdx++;
            }
            quest.States = states;
        }

        private static void ReadActions(State state, YamlSequenceNode node)
        {
            var actions = new UserAction[node.Children.Count];
            var actionIdx = 0;
            foreach (var child in node.Children)
            {
                var mapChild = ((YamlMappingNode)child);
                var action = new UserAction();
                foreach (var grandChild in mapChild.Children)
                {
                    action.Key = ((YamlScalarNode)grandChild.Key).Value;
                    action.Handler = ReadInstructions((YamlSequenceNode)grandChild.Value);
                }
                actions[actionIdx] = action;
                actionIdx++;
            }
            state.Actions = actions;
        }

        private static InstructionBlock ReadInstructions(YamlSequenceNode node)
        {
            InstructionBlock block = new InstructionBlock();
            block.Instructions = new Instruction[node.Children.Count];
            var instructionIndex = 0;
            foreach(var child in node.Children)
            {
                if (child is YamlScalarNode scalar)
                {
                    var instruction = InstructionFactory.Build(scalar.Value, null);
                    block.Instructions[instructionIndex] = instruction;
                    instructionIndex++;
                }
                else
                {
                    var mapChild = ((YamlMappingNode)child).Children.Single();
                    var instruction = InstructionFactory.Build(((YamlScalarNode)mapChild.Key).Value, ((YamlScalarNode)mapChild.Value).Value);
                    block.Instructions[instructionIndex] = instruction;
                    instructionIndex++;
                }
            }
            return block;
        }

        private static void ReadScripts(Quest quest, YamlSequenceNode node)
        {
            var scripts = new Script[node.Children.Count];
            var scriptsIndex = 0;
            foreach(var child in node.Children)
            {
                var mapChild = (YamlMappingNode)child;
                foreach(var grandChild in mapChild.Children)
                {
                    var key = ((YamlScalarNode)grandChild.Key).Value;
                    var script = new Script();
                    script.Name = key;
                    script.InstructionBlock = ReadInstructions((YamlSequenceNode)grandChild.Value);
                    scripts[scriptsIndex] = script;
                    scriptsIndex++;
                }
            }
            quest.Scripts = scripts;
        }
    }
}
