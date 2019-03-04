using System.Collections.Generic;
using System.Xml;

namespace C246SpellBook_V_2
{
    /*
         * Update: The XmlReader class starts with multiple data types to hold all the information in. This method will read in the Xml file
         * with all the spells inside it, and store them into a List spellType. This list is named spells. While the Xml file is open it will read
         * each line and compare whether its the name, level, etc. It will store it into that specific variable and hold onto that data until
         * that spell is competed. Once it is completed it is added to the list spells with all the attributes included inside it. The pnly problem is the 
         * text and roll. For instance, some spells have 2 to 2 text lines in the Xml file but I ended up just placing all of them into the text variable.
         * Same goes for the roll variable. 
         * If you have any questions please let me know, also if I did anything weird or wrong please let me know.
         */
    class XmlReader
    {
        public static List<SpellList> spells;
        public static List<SpellList> generateData()
        {
            string id = "";
            string name = "";
            string level = "";
            string school = "";
            bool ritual = false;
            string ritualText = "";
            bool concentration = false;
            string hasConcentration = "";
            string time = "";
            string range = "";
            string components = "";
            string materials = "";
            string duration = "";
            string classes = "";
            string description = "";
            string higherLevel = "";
            string source = "";
            

            XmlTextReader doc = new XmlTextReader("SpellBookDB.xml");
            spells = new List<SpellList>();

            while (doc.Read())
            {
                if (doc.NodeType == XmlNodeType.Element && doc.Name == "Spell")
                {
                    while (doc.Read() && doc.Name != "Spell")
                    {
                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "ID")
                        {
                            id = doc.ReadElementString();
                        }

                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "Name")
                        {
                            name = doc.ReadElementString();
                        }

                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "Level")
                        {
                            level = doc.ReadElementString();
                        }

                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "School")
                        {
                            school = doc.ReadElementString();
                        }

                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "IsRitual")
                        {
                            ritualText = doc.ReadElementString();
                            if (ritualText == "true")
                                ritual = true;
                            else
                                ritual = false;
                        }

                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "CastingTime")
                        {
                            time = doc.ReadElementString();
                        }

                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "Range")
                        {
                            range = doc.ReadElementString();
                        }

                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "Component")
                        {
                            components += doc.ReadElementString() + ", ";
                        }

                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "Materials")
                        {
                            materials = doc.ReadElementString();
                        }

                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "Duration")
                        {
                            duration = doc.ReadElementString();
                        }

                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "HasConcentration")
                        {
                            hasConcentration = doc.ReadElementString();
                            if (hasConcentration == "true")
                                concentration = true;
                            else
                                concentration = false;
                        }

                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "Description")
                        {
                            description = doc.ReadElementString();
                        }

                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "HigherLevel")
                        {
                            higherLevel = doc.ReadElementString();
                        }

                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "Source")
                        {
                            source = doc.ReadElementString();
                        }

                        if (doc.NodeType == XmlNodeType.Element && doc.Name == "Class")
                        {
                            classes += doc.ReadElementString() + ", ";
                        }

                    }//whileRead not Spell
                    spells.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                    classes = "";
                    components = "";
                }//if = Spell
            }//whileRead
            return spells;
        }//generateData
    }
}
