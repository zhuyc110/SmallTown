using Newtonsoft.Json;
using SmallTown.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Person
{
    public class Personality
    {
        public int Id { get; }

        public string Name { get; }

        public string Description { get; }

        private readonly string[] _highElements;

        public Personality(int id, string name, string description, string[] highElements)
        {
            Id = id;
            Name = name;
            Description = description;
            _highElements = highElements;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
