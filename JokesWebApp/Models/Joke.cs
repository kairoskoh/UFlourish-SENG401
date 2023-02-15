using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesWebApp.Models
{
    public class Joke
    {
        // PROP TAB TAB - PROPERTY
        public int Id { get; set; }
        public string JokeQuestion { get; set; }
        public string JokeAnswer { get; set; }

        // CTOR TAB TAB - CONSTRUCTOR
        public Joke()
        {

        }
    }
}
