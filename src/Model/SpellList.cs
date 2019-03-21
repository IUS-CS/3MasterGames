
namespace C246SpellBook_V_2
{
    public class SpellList
    {

        private SpellList(string id, string name, string level, string school, bool ritual, bool concentration, string time, string range, string components, string materials, string duration, string classes, string description, string higherLevel, string source)
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

        private string ID { get; set; }
        private string Name { get; set; }
        private string Level { get; set; }
        private string School { get; set; }
        private bool Ritual { get; set; }
        private bool Concentration { get; set; }
        private string Time { get; set; }
        private string Range { get; set; }
        private string Components { get; set; }
        private string Materials { get; set; }
        private string Duration { get; set; }
        private string Classes { get; set; }
        private string Description { get; set; }
        private string HigherLevel { get; set; }
        private string Source { get; set; }
    }
}
