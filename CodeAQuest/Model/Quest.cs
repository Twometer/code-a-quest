using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAQuest.Model
{
    public class Quest
    {
        public string Title { get; set; }

        public string Version { get; set; }

        public string Author { get; set; }

        public string InitialState { get; set; }

        public State[] States { get; set; }

        public Script[] Scripts { get; set; }
    }
}
