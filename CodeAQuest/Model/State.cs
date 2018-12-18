using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAQuest.Model
{
    public class State
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public UserAction[] Actions { get; set; }
    }
}
