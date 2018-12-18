using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAQuest.Model.Instructions
{
    public class ShutdownInstruction : Instruction
    {
        public ShutdownInstruction(string parameter) : base(parameter)
        {
        }

        public override void Execute(QuestContext questContext)
        {
            questContext.Exit();
        }
    }
}
