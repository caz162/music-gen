using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Midi;
using System.Threading;

namespace MidiExample
{
    public partial class Form1 : Form
    {
        int generation = 0;
        Song[] pop  = new Song[5];
        int idcount = 0;
        int notes = 3;
        int songCount = 5;
        Pitch lastNote;
        List<Pitch> blah = new List<Pitch>() { Pitch.C4, Pitch.D4, Pitch.E4, Pitch.F4, Pitch.G4, Pitch.A4, Pitch.B4, Pitch.C5 };
        

        public Form1()
        {
            InitializeComponent();
        }

        private void clicked(int i)
        {
            OutputDevice outDev = OutputDevice.InstalledDevices[0];
            outDev.Open();
            Song s = pop.ElementAt(i);
                foreach (Note n in s.notes)
                {
                    outDev.SendNoteOn(Channel.Channel1, n.pitch, n.attack);
                    Thread.Sleep(n.sleep);
                }
            
            outDev.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clicked(0);
        }

        private void ga()
        {

        }

        private Note newNote()
        {
            Pitch p = Pitch.A0;
            Random r = new Random();
            int rand = r.Next(0,8);
            while (lastNote == blah.ElementAt(rand))
            {
                rand = r.Next(0,8);

            }
            p = blah.ElementAt(rand);
            int attack = r.Next(80, 100);
            int sleep = r.Next(500, 1000);
            lastNote = p;

            return new Note(p, attack, sleep);
        }


        private void init()
        {
            for (int j = 0; j < songCount; j++)
            {
                Song s = new Song(idcount);
                for (int i = 0; i < notes; i++)
                {
                    Note n = newNote();
                    
                    s.Add(n,i);
                }
                if (generation > 0) 
                 pop[j] = new Song(-1);
                pop[j] = s;
                idcount++;
            }
            generation++;
            
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            clicked(1);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            clicked(2);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            clicked(3);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            clicked(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            init();

            textBox1.Text = "" + pop.ElementAt(0).id + " "
                               + pop.ElementAt(0).notes.ElementAt(0).pitch + " " + pop.ElementAt(0).notes.ElementAt(0).attack + " " + pop.ElementAt(0).notes.ElementAt(0).sleep + " - "
                               + pop.ElementAt(0).notes.ElementAt(1).pitch + " " + pop.ElementAt(0).notes.ElementAt(1).attack + " " + pop.ElementAt(0).notes.ElementAt(1).sleep + " - "
                               + pop.ElementAt(0).notes.ElementAt(2).pitch + " " + pop.ElementAt(0).notes.ElementAt(2).attack + " " + pop.ElementAt(0).notes.ElementAt(2).sleep + " - "           
                               + pop.ElementAt(0).fitness;

            textBox2.Text = "" + pop.ElementAt(1).id + " "
                               + pop.ElementAt(1).notes.ElementAt(0).pitch + " " + pop.ElementAt(1).notes.ElementAt(0).attack + " " + pop.ElementAt(1).notes.ElementAt(0).sleep + " - "
                               + pop.ElementAt(1).notes.ElementAt(1).pitch + " " + pop.ElementAt(1).notes.ElementAt(1).attack + " " + pop.ElementAt(1).notes.ElementAt(1).sleep + " - "
                               + pop.ElementAt(1).notes.ElementAt(2).pitch + " " + pop.ElementAt(1).notes.ElementAt(2).attack + " " + pop.ElementAt(1).notes.ElementAt(2).sleep + " - "
                               + pop.ElementAt(1).fitness;

            textBox3.Text = "" + pop.ElementAt(2).id + " "
                               + pop.ElementAt(2).notes.ElementAt(0).pitch + " " + pop.ElementAt(2).notes.ElementAt(0).attack + " " + pop.ElementAt(2).notes.ElementAt(0).sleep + " - "
                               + pop.ElementAt(2).notes.ElementAt(1).pitch + " " + pop.ElementAt(2).notes.ElementAt(1).attack + " " + pop.ElementAt(2).notes.ElementAt(1).sleep + " - "
                               + pop.ElementAt(2).notes.ElementAt(2).pitch + " " + pop.ElementAt(2).notes.ElementAt(2).attack + " " + pop.ElementAt(2).notes.ElementAt(2).sleep + " - " 
                               + pop.ElementAt(2).fitness;

            textBox4.Text = "" + pop.ElementAt(3).id + " "
                               + pop.ElementAt(3).notes.ElementAt(0).pitch + " " + pop.ElementAt(3).notes.ElementAt(0).attack + " " + pop.ElementAt(3).notes.ElementAt(0).sleep + " - "
                               + pop.ElementAt(3).notes.ElementAt(1).pitch + " " + pop.ElementAt(3).notes.ElementAt(1).attack + " " + pop.ElementAt(3).notes.ElementAt(1).sleep + " - "
                               + pop.ElementAt(3).notes.ElementAt(2).pitch + " " + pop.ElementAt(3).notes.ElementAt(2).attack + " " + pop.ElementAt(3).notes.ElementAt(2).sleep + " - " 
                               + pop.ElementAt(3).fitness;

            textBox5.Text = "" + pop.ElementAt(4).id + " "
                               + pop.ElementAt(4).notes.ElementAt(0).pitch + " " + pop.ElementAt(4).notes.ElementAt(0).attack + " " + pop.ElementAt(4).notes.ElementAt(0).sleep + " - "
                               + pop.ElementAt(4).notes.ElementAt(1).pitch + " " + pop.ElementAt(4).notes.ElementAt(1).attack + " " + pop.ElementAt(4).notes.ElementAt(1).sleep + " - "
                               + pop.ElementAt(4).notes.ElementAt(2).pitch + " " + pop.ElementAt(4).notes.ElementAt(2).attack + " " + pop.ElementAt(4).notes.ElementAt(2).sleep + " - " 
                               + pop.ElementAt(4).fitness;
        }

    }
}
