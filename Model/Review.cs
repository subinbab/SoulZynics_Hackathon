using System.Collections;
using System.Collections.Generic;

namespace SoulZynics.Model
{
    public class Review
    {
        public int id { get; set; }
        public string name { get; set; }
        public string? imageLink { get; set; }
        public ICollection<Environments> envs { get; set; }
    }
}
