using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace C246SpellBook_V_2
{
     /*
      * Form1 holds all the methods that effect the whole of the window.
      */
     public partial class Form1 : Form
     {


          /*
           * The three variables will be used to obtain data from the list of spells and
           * be able to view the data that has been placed inside the list. Also List spellType is the
           * list of spells.
           */
          private DataTable dtSpells;
          private DataView dvSpells;
          private List<spellType> spells;

          //For Filters
          private List<spellType> BardList, ClericList, DruidList, PaladinList, RangerList, SorcererList, WarlockList, WizardList;
          private List<spellType> Level_0, Level_1, Level_2, Level_3, Level_4, Level_5, Level_6, Level_7, Level_8, Level_9;
          private DataView BardView, ClericView, DruidView, PaladinView, RangerView, SorcererView, WarlockView, WizardView;
          private DataView Level_0View, Level_1View, Level_2View, Level_3View, Level_4View, Level_5View, Level_6View, Level_7View, Level_8View, Level_9View;
          private DataView temp0, temp1, temp2, temp3;
          /*
           * This method initializes the view of the spells, adds them to a column with its 
           * specific catagory. It also initializes the dataTable named dtSpells and adds that
           * ability to that specific column. In order to display that spell, we need to fill the table 
           * and use dataView on the dataTable and populate it.
           */
          public Form1()
          {
               InitializeComponent();

               //sets the maximize and minimize box to on
               this.MaximizeBox = true;
               this.MinimizeBox = true;

               //ListView Properties
               listView1.View = View.Details;
               listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

               //Add Columns
               listView1.Columns.Add("Name", 150);
               listView1.Columns.Add("Level", 50);
               listView1.Columns.Add("School", 150);
               listView1.Columns.Add("Ritual", 50);
               listView1.Columns.Add("Concentration", 50);
               listView1.Columns.Add("Classes", 350);
               listView1.Columns.Add("Components", 350);


               //Initialize Datatable and add columns
               dtSpells = new DataTable();
               dtSpells.Columns.Add("Name");
               dtSpells.Columns.Add("Level");
               dtSpells.Columns.Add("School");
               dtSpells.Columns.Add("Ritual");
               dtSpells.Columns.Add("Concentation");
               dtSpells.Columns.Add("Classes");
               dtSpells.Columns.Add("Components");


               //Fill datatable
               fillDataTable(generateData());
               dvSpells = new DataView(dtSpells);
               populateListView(dvSpells);

               //For Filters
               BardView = new DataView(dtSpells);
               ClericView = new DataView(dtSpells);
               DruidView = new DataView(dtSpells);
               PaladinView = new DataView(dtSpells);
               RangerView = new DataView(dtSpells);
               SorcererView = new DataView(dtSpells);
               WarlockView = new DataView(dtSpells);
               WizardView = new DataView(dtSpells);
               Level_0View = new DataView(dtSpells);
               Level_1View = new DataView(dtSpells);
               Level_2View = new DataView(dtSpells);
               Level_3View = new DataView(dtSpells);
               Level_4View = new DataView(dtSpells);
               Level_5View = new DataView(dtSpells);
               Level_6View = new DataView(dtSpells);
               Level_7View = new DataView(dtSpells);
               Level_8View = new DataView(dtSpells);
               Level_9View = new DataView(dtSpells);
               temp0 = new DataView(dtSpells);
               temp1 = new DataView(dtSpells);
               temp2 = new DataView(dtSpells);
               temp3 = new DataView(dtSpells);




          }


          /*
           * Update: The generateData method starts with multiple data types to hold all the information in. This method will read in the Xml file
           * with all the spells inside it, and store them into a List spellType. This list is named spells. While the Xml file is open it will read
           * each line and compare whether its the name, level, etc. It will store it into that specific variable and hold onto that data until
           * that spell is competed. Once it is completed it is added to the list spells with all the attributes included inside it. The pnly problem is the 
           * text and roll. For instance, some spells have 2 to 2 text lines in the Xml file but I ended up just placing all of them into the text variable.
           * Same goes for the roll variable. 
           * If you have any questions please let me know, also if I did anything weird or wrong please let me know.
           */
          private List<spellType> generateData()
          {
               string id = " ";
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
               string roll = "";
               int count = 0;

               XmlTextReader doc = new XmlTextReader("SpellBookDB.xml");
               spells = new List<spellType>();
               BardList = new List<spellType>();
               ClericList = new List<spellType>();
               DruidList = new List<spellType>();
               PaladinList = new List<spellType>();
               RangerList = new List<spellType>();
               SorcererList = new List<spellType>();
               WarlockList = new List<spellType>();
               WizardList = new List<spellType>();
               Level_0 = new List<spellType>();
               Level_1 = new List<spellType>();
               Level_2 = new List<spellType>();
               Level_3 = new List<spellType>();
               Level_4 = new List<spellType>();
               Level_5 = new List<spellType>();
               Level_6 = new List<spellType>();
               Level_7 = new List<spellType>();
               Level_8 = new List<spellType>();
               Level_9 = new List<spellType>();
               

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
                         spells.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                         switch (level)
                         {
                              case "0":
                                   Level_0.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                                   break;
                              case "1":
                                   Level_1.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                                   break;
                              case "2":
                                   Level_2.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                                   break;
                              case "3":
                                   Level_3.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                                   break;
                              case "4":
                                   Level_4.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                                   break;
                              case "5":
                                   Level_5.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                                   break;
                              case "6":
                                   Level_6.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                                   break;
                              case "7":
                                   Level_7.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                                   break;
                              case "8":
                                   Level_8.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                                   break;
                              case "9":
                                   Level_9.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                                   break;
                         }
                        if (classes.Contains("Bard")) { 
                              BardList.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                         } // if
                         if (classes.Contains("Cleric")) { 
                              ClericList.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                         } // if
                         if (classes.Contains("Druid")) { 
                              DruidList.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                         }// if
                         if (classes.Contains("Paladin")) { 
                              PaladinList.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                         }
                         if (classes.Contains("Ranger")) { 
                              RangerList.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                         }
                         if (classes.Contains("Sorcerer")) { 
                              SorcererList.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                         }
                         if (classes.Contains("Warlock")) { 
                              WarlockList.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                         }
                         if (classes.Contains("Wizard")) { 
                              WizardList.Add(new spellType(id, name, level, school, ritual, concentration, time, range, components, materials, duration, classes, description, higherLevel, source, roll));
                         }// if
                         classes = "";
                         components = "";
                    }//if = Spell
               }//whileRead

               return spells;

          }//generateData


          /*
           * Transfer the data from list to datatable, by checking each spell and adding it to the 
           * row under that specific column.
           */
          private void fillDataTable(List<spellType> spells)
          {
               foreach (var spell in spells)
               {
                    dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

               }

          }


          //Blank for now.
          private void Form1_Load(object sender, EventArgs e)
          {
          }


          /*
           * The DataTable method is what populates the listBox1 with the spells, another method can be created to create other attributes to the spell.
           * Inside the method, I created a column named "Spell" which holds the attributes spell name. For this column each row that I add will be a spell name.
           * This helps populate the list by examining each spell name in that row and displays the postion
           * in that row. So if we had more attributes I could add row[1].ToString() and that will be the next 
           * attribute like level for instance.
           */
          private void populateListView(DataView dv)
          {
               listView1.Items.Clear();
               foreach (DataRow row in dv.ToTable().Rows)
               {
                    listView1.Items.Add(new ListViewItem(new String[] { row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString() }));
               }
          }

          //this function may be temporary, I'm not sure if I'll use it yet. It's purpose is currently to see if a 
          // box is still checked, and if so it wont repopulate the entire list when a box is unchecked. 
          private int testIfBoxesChecked()
          {
               int count = 0;
               foreach (var checkBox in panel1.Controls.OfType<CheckBox>())
               {
                    if (checkBox.GetType() == typeof(CheckBox))
                    {
                         var checkBoxCtrl = (CheckBox)checkBox;
                         if (checkBoxCtrl.Checked == true)
                         {
                              count++;
                         }
                    }
               }
               return count;
          }
          /*
           * This method effects the Search bar, and how it will be filtered.
           * So, first I used a rowFilter to the DataView dvSpells, which will help display the 
           * searched spell name. To filter the string that you typed in, it must be compared to the
           * Spells that we have. In order to do that, I used rowFilter and our row 0 which holds
           * only the spell names and used the term "LIKE" to compare similar characters and '%. 
           * By doing this I can compare the Spell to the Search bar value with SearchTextBox.Text.
           */
          private void SearchTextBox_TextChanged(object sender, EventArgs e)
          {
               dvSpells.RowFilter = string.Format("Name Like '%{0}%'", SearchTextBox.Text);
               populateListView(dvSpells);
          }
          /*
           So what is supposed to happen with these checkedchange functions is when a checkbox is checked, 
           these functions are invoked. It will drop into the first if statement which will prompt the filter for that respective
           level. It will then drop into the rest of them and see if any other boxes are checked and populate those filters as well
           */
          private void checkBox1_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox1.Checked == true && testIfBoxesChecked() <= 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in Level_0)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(Level_0View);
               }
               
               if (checkBox1.Checked && testIfBoxesChecked() > 1)
               {
                    foreach (var spell in Level_0)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(Level_0View);
               }
               if(checkBox1.Checked == false && testIfBoxesChecked() < 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in spells)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               if (checkBox1.Checked == false && testIfBoxesChecked() >= 1)
               {
                    temp0.RowFilter = $"Level NOT LIKE '%0%'";
                    populateListView(temp0);
                    dtSpells.AcceptChanges();
               }
               
          }
          private void checkBox2_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox2.Checked == true && testIfBoxesChecked() <= 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in Level_1)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(Level_1View);
               }
               
               if (checkBox2.Checked && testIfBoxesChecked() > 1)
               {
                    foreach (var spell in Level_1)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(Level_1View);
               }

               if (checkBox2.Checked == false && testIfBoxesChecked() < 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in spells)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               if (checkBox2.Checked == false && testIfBoxesChecked() >= 1)
               {
                    temp1.RowFilter = $"Level NOT LIKE '%1%'";
                    populateListView(temp1);
               }
          }
          private void checkBox3_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox3.Checked == true && testIfBoxesChecked() <= 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in Level_2)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(Level_2View);
               }

               if (checkBox3.Checked && testIfBoxesChecked() > 1)
               {
                    foreach (var spell in Level_2)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(Level_2View);
               }

               if (checkBox3.Checked == false && testIfBoxesChecked() < 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in spells)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               if (checkBox3.Checked == false && testIfBoxesChecked() >= 1)
               {
                    temp2.RowFilter = $"Level NOT LIKE '%2%'";
                    populateListView(temp2);
               }
          }
          private void checkBox4_CheckedChanged(object sender, EventArgs e)
          {
               
               if (checkBox4.Checked == true && testIfBoxesChecked() <= 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in Level_3)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(Level_3View);
               }

               if (checkBox4.Checked && testIfBoxesChecked() > 1)
               {
                    foreach (var spell in Level_3)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(Level_3View);
               }

               if (checkBox4.Checked == false && testIfBoxesChecked() < 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in spells)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               if (checkBox4.Checked == false && testIfBoxesChecked() >= 1)
               {
                    DataViewManager dvm = new DataViewManager();
                    dvm.DataViewSettings[dtSpells].RowFilter = $"Level NOT LIKE '%3%'";
                    populateListView(Level_3View);
               }
          }
          private void checkBox5_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox5.Checked)
               {
                   
               }
          }
          private void checkBox6_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox6.Checked)
               {
                  
               }
          }
          private void checkBox7_CheckedChanged(object sender, EventArgs e)
          {
               
          }
          private void checkBox8_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox8.Checked)
               {
                    
               }
          }
          private void checkBox9_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox9.Checked)
               {
                   
               }
          }
          private void checkBox10_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox10.Checked)
               {
                   
               }
          }
          private void checkBox11_CheckedChanged(object sender, EventArgs e)
          {

               if (checkBox11.Checked)
               {
                    
               }

          }
          private void checkBox12_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox12.Checked)
               {
                   
               }
          }
          private void checkBox13_CheckedChanged_1(object sender, EventArgs e)
          {
               if (checkBox13.Checked)
               {
               }
          }

          private void checkBox14_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox14.Checked)
               {
                  
               }
          }
          private void checkBox15_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox15.Checked)
               {

               }
          }
          private void checkBox16_CheckedChanged_1(object sender, EventArgs e)
          {

               if (checkBox16.Checked)
               {
                   
               }

          }
          private void checkBox17_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox17.Checked)
               {
                   
               }
          }
          private void checkBox18_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox18.Checked)
               {
                    
               }
          }

          private void duplicateSpellBookToolStripMenuItem_Click(object sender, EventArgs e)
          {

          }
          // This shouldn't do anything but removing it breaks things 
          private void label1_Click(object sender, EventArgs e)
          {

          }

          private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
          {

          }

          private void aboutThisApplicationToolStripMenuItem_Click(object sender, EventArgs e)
          {


          }

          // this method is trigger when the hightlighted spell is changed
          private void listView1_SelectedIndexChanged(object sender, EventArgs e)
          {
               //of type ListView.SelectedListViewItemCollection
               var temp = listView1.SelectedItems;

               //of type StringBuilder
               var displayText = new StringBuilder();
               foreach (ListViewItem item in temp)
               {
                    //only displays what is in the list veiw at the moment
                    for (var i = 0; i < 6; i++)
                    {
                         displayText.AppendLine(item.SubItems[i].Text);
                    }
               }

               //StringBuilder temp = listView1.SelectedItems.ToString();

               ////for(int i = 0; i < listView1.SelectedItems.Count; i++)
               ////{
               //    temp. listView1.SelectedItems.ToString();
               ////}
               Spell_Display.Text = displayText.ToString();
               //Console.WriteLine(listView1.SelectedItems);
          }
          //This is the reset filters button. It checks panel 1 where the checkboxes are located and looks for a control of checkbox type
          // if it finds one, it checks if its checked, and if it is, it unchecks it
          private void button1_Click(object sender, EventArgs e)
          {
               foreach (var checkBox in panel1.Controls.OfType<CheckBox>())
               {
                    if (checkBox.GetType() == typeof(CheckBox))
                    {
                         var checkBoxCtrl = (CheckBox)checkBox;
                         if (checkBoxCtrl.Checked == true)
                         {
                              checkBoxCtrl.Checked = false;
                         }
                    }
               }
          }

          private void editorToolStripMenuItem_Click(object sender, EventArgs e)
          {

          }

          private void fileToolStripMenuItem_Click(object sender, EventArgs e)
          {

          }

          private void changeLogToolStripMenuItem_Click(object sender, EventArgs e)
          {

          }

          private void licensesToolStripMenuItem_Click(object sender, EventArgs e)
          {

          }

          private void DisplayPanel_Paint(object sender, PaintEventArgs e)
          {
               //get spesfic spell from highlighted from data veiw 

               // display in panel
          }

          private void label2_Click(object sender, EventArgs e)
          {
               //
          }

          private void Spell_Display_TextChanged(object sender, EventArgs e)
          {

          }
     }
}


/*
 * This is where we will add attributes to the spellType class, like level, name, discription, etc.
 */
class spellType
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





     public spellType(string id, string name, string level, string school, bool ritual, bool concentration, string time, string range, string components, string materials, string duration, string classes, string description, string higherLevel, string source, string roll)
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