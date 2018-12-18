using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAQuest.Model
{
    public abstract class Instruction
    {
        public string Parameter { get; set; }

        protected Instruction(string parameter)
        {
            Parameter = parameter;
        }

        public abstract void Execute(QuestContext questContext);

    }
}
