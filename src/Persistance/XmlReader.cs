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
         * If you have any questions please let me know, also if I did anything weird or wrong please let me know.
         */
    class XmlReader
    {
          public static List<SpellList> BardList, ClericList, DruidList, PaladinList, RangerList, SorcererList, WarlockList, WizardList;
          public static List<SpellList> Level_0, Level_1, Level_2, Level_3, Level_4, Level_5, Level_6, Level_7, Level_8, Level_9;
          public static List<SpellList> spells;
        public static List<SpellList> generateData()
        {
               string id = " ";//0
               string name = "";//1
               string level = "";//2
               string school = "";//3
               bool ritual = false;//4
               string ritualText = "";
               bool concentration = false;//5
               string hasConcentration = "";
               string time = "";//6
               string range = "";//7
               string components = "";//8
               string materials = "";//9
               string duration = "";//10
               string classes = "";//11
               string description = "";//12
               string higherLevel = "";//13
               string source = "";//14
               
               XmlTextReader doc = new XmlTextReader("..\\..\\Text_XmlFiles\\SpellBookDB.xml");
               spells = new List<SpellList>();
               BardList = new List<SpellList>();
               ClericList = new List<SpellList>();
               DruidList = new List<SpellList>();
               PaladinList = new List<SpellList>();
               RangerList = new List<SpellList>();
               SorcererList = new List<SpellList>();
               WarlockList = new List<SpellList>();
               WizardList = new List<SpellList>();
               Level_0 = new List<SpellList>();
               Level_1 = new List<SpellList>();
               Level_2 = new List<SpellList>();
               Level_3 = new List<SpellList>();
               Level_4 = new List<SpellList>();
               Level_5 = new List<SpellList>();
               Level_6 = new List<SpellList>();
               Level_7 = new List<SpellList>();
               Level_8 = new List<SpellList>();
               Level_9 = new List<SpellList>();


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
                         switch (level)
                         {
                              case "0":
                                   Level_0.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                                   break;
                              case "1":
                                   Level_1.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                                   break;
                              case "2":
                                   Level_2.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                                   break;
                              case "3":
                                   Level_3.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                                   break;
                              case "4":
                                   Level_4.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                                   break;
                              case "5":
                                   Level_5.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                                   break;
                              case "6":
                                   Level_6.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                                   break;
                              case "7":
                                   Level_7.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                                   break;
                              case "8":
                                   Level_8.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                                   break;
                              case "9":
                                   Level_9.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                                   break;
                         }
                         if (classes.Contains("Bard"))
                         {
                              BardList.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                         } // if
                         if (classes.Contains("Cleric"))
                         {
                              ClericList.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                         } // if
                         if (classes.Contains("Druid"))
                         {
                              DruidList.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                         }// if
                         if (classes.Contains("Paladin"))
                         {
                              PaladinList.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                         }
                         if (classes.Contains("Ranger"))
                         {
                              RangerList.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                         }
                         if (classes.Contains("Sorcerer"))
                         {
                              SorcererList.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                         }
                         if (classes.Contains("Warlock"))
                         {
                              WarlockList.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                         }
                         if (classes.Contains("Wizard"))
                         {
                              WizardList.Add(new SpellList(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source));
                         }// if
                         classes = "";
                         components = "";
                    }//if = Spell
               }//whileRead

               return spells;

          }//generateData
     }
}
