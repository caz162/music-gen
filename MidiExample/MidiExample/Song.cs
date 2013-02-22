using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MidiExample
{
    struct Song
    {
        public int id;
        public Note[] notes;
        public int fitness;

        public Song(int i)
        {
            id = i;
            notes = new Note[3];
            fitness = 0;
        }

        public void Add(Note n, int num){
            notes[num] = n;
        }

        public void Delete()
        {
            
        }
    }
}
