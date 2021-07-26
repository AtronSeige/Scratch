using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchDelegateEvent
{
    public class Animal
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                //NB: No use sending out events if no one is listening
                if (this.NameChangeEvent != null && _name != value)
                {
                    var args = new NameChangeEventArgs(this._name, value);
                    this.NameChangeEvent(this, args);
                }
                _name = value;
            }
        }

        public event NameChangeEvent NameChangeEvent;

    }
}
