using CodeAQuest.Model.Instructions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAQuest.Model
{
    public class InstructionFactory
    {

        public static Instruction Build(string name, string param)
        {
            switch (name)
            {
                case "goto":
                    return new GotoInstruction(param);
                case "out":
                    return new OutInstruction(param);
                case "run":
                    return new RunInstruction(param);
                case "shutdown":
                    return new ShutdownInstruction(param);
            }
            throw new ArgumentException("Unknown instruction " + name);
        }

    }
}
