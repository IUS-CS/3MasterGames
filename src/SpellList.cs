
namespace C246SpellBook_V_2
{
    class SpellList
    {
            private string id;
            private string name;
            private string level;
            private string school;
            private bool ritual;
            private bool concentration;
            private string time;
            private string range;
            private string components;
            private string materials;
            private string duration;
            private string classes;
            private string description;
            private string higherLevel;
            private string source;
            private string roll;

            public SpellList(string id, string name, string level, string school, bool ritual, bool concentration, string time, string range, string components, string materials, string duration, string classes, string description, string higherLevel, string source, string roll)
            {
                this.id = id;
                this.name = name;
                this.level = level;
                this.school = school;
                this.ritual = ritual;
                this.concentration = concentration;
                this.time = time;
                this.range = range;
                this.components = components;
                this.materials = materials;
                this.duration = duration;
                this.classes = classes;
                this.description = description;
                this.higherLevel = higherLevel;
                this.source = source;
                this.roll = roll;
            }

            public string ID
            {
                get { return id; }
            }
            public string Name
            {
                get { return name; }
            }
            public string Level
            {
                get { return level; }
            }
            public string School
            {
                get { return school; }
            }
            public bool Ritual
            {
                get { return ritual; }
            }
            public bool Concentration
            {
                get { return concentration; }
            }
            public string Time
            {
                get { return time; }
            }
            public string Range
            {
                get { return range; }
            }
            public string Components
            {
                get { return components; }
            }
            public string Materials
            {
                get { return materials; }
            }
            public string Duration
            {
                get { return duration; }
            }
            public string Classes
            {
                get { return classes; }
            }
            public string Description
            {
                get { return description; }
            }
            public string HigherLevel
            {
                get { return higherLevel; }
            }
            public string Source
            {
                get { return source; }
            }
            public string Roll
            {
                get { return roll; }
            }
    }
}
