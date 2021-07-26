using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchDelegateEvent
{
    //this is the "holder" for the method. You can user any method here that provides an object and NameChangeEventArgs as params and outputs void.
    public delegate void NameChangeEvent(object sender, NameChangeEventArgs args);

    /// <summary>
    /// The arguments that are sent along with the Event. Basically useful info about the event.
    /// </summary>
    public class NameChangeEventArgs : EventArgs
    {
        public NameChangeEventArgs() { }

        public NameChangeEventArgs(string oldName, string newName)
        {
            OldName = oldName;
            NewName = newName;
        }

        public string OldName { get; set; }
        public string NewName { get; set; }
    }
}
