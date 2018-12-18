using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAQuest.Model.Instructions
{
    public class RunInstruction : Instruction
    {
        public RunInstruction(string parameter) : base(parameter)
        {
        }

        public override void Execute(QuestContext questContext)
        {
            questContext.RunScript(Parameter);
        }
    }
}
