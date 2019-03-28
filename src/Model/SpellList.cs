
namespace C246SpellBook_V_2.Model
{
    public class SpellList
    {

        public SpellList() { }

        public SpellList(string id, string name, string level, string school, bool ritual, bool concentration, string time, string range, string components, string materials, string duration, string classes, string description, string higherLevel, string source)
            {
                ID = id;
                Name = name;
                Level = level;
                School = school;
                Ritual = ritual;
                Concentration = concentration;
                Time = time;
                Range = range;
                Components = components;
                Materials = materials;
                Duration = duration;
                Classes = classes;
                Description = description;
                HigherLevel = higherLevel;
                Source = source;
            }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string School { get; set; }
        public bool Ritual { get; set; }
        public bool Concentration { get; set; }
        public string Time { get; set; }
        public string Range { get; set; }
        public string Components { get; set; }
        public string Materials { get; set; }
        public string Duration { get; set; }
        public string Classes { get; set; }
        public string Description { get; set; }
        public string HigherLevel { get; set; }
        public string Source { get; set; }
    }
}
