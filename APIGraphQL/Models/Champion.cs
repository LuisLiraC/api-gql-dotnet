using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGraphQL.Models
{
    public class Champion
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Role { get; set; }
        public IList<string> Skins { get; set; }
        public string Region { get; set; }
        public string Champion_image { get; set; }
        //public IList<Ability> Abilities { get; set; }
    }
}
