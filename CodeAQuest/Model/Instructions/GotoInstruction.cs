using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAQuest.Model.Instructions
{
    public class GotoInstruction : Instruction
    {
        public GotoInstruction(string parameter) : base(parameter)
        {
        }

        public override void Execute(QuestContext questContext)
        {
            questContext.GotoState(Parameter);   
        }
    }
}
