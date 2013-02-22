using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Midi;

namespace MidiExample
{
    struct Note
    {
        public Pitch pitch;
        public int attack;
        public int sleep;

        public Note(Pitch p, int a, int s)
        {
            pitch = p;
            attack = a;
            sleep = s;

        }
    }
}
