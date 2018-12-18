using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAQuest.Model
{
    public class InstructionBlock
    {
        public Instruction[] Instructions { get; set; }

        public void Execute(QuestContext questContext)
        {
            foreach (var instruction in Instructions)
                instruction.Execute(questContext);
        }

    }
}
