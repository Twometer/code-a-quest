using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAQuest.Model.Instructions
{
    public class OutInstruction : Instruction
    {
        public OutInstruction(string parameter) : base(parameter)
        {
        }

        public override void Execute(QuestContext questContext)
        {
            Console.WriteLine(questContext.ResolvePlaceholders(Parameter));
        }
    }
}
