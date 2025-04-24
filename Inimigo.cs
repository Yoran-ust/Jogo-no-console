using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoNoConsole
{

    public class Inimigo
    { 
        public string Name {  get; set; }
        public int Atack {  get; set; }
        public int Life {  get; set; }
    
        public Inimigo(string name, int atack, int life)
        {
            Name = name;
            Atack = atack;
            Life = life;  
        }
    }
}
