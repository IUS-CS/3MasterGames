﻿using System;
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
          private DataTable filterTable;
          private DataView filterView, tempView;
          private bool filterUsed = false;
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
               //This is almost like a temporary table. Filters will be bouncing between this table and dtSpells
               filterTable = new DataTable();
               filterTable.Columns.Add("Name");
               filterTable.Columns.Add("Level");
               filterTable.Columns.Add("School");
               filterTable.Columns.Add("Ritual");
               filterTable.Columns.Add("Concentation");
               filterTable.Columns.Add("Classes");
               filterTable.Columns.Add("Components");
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

          /*
           This function loops through all of our checkboxes. It loops through and looks for control type of checkbox. 
           If the control it is looking at is a checkbox, it initializes a control variable, and 
                */
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
           This function is how filters are going to work for when boxes are unchecked while others are still checked. First, we create a string that we are going to use
           to filter out whatever was just unchecked. We then create a datarow array to store our results.
           There's a boolean variable called filterUsed. It is by default set to false, since we aren't using a filter by default. If we aren't using a filter, we populate our
           foundRows array with anything not using the current level. So if our parameter is "5", then it will fill the array with any rows that don't have a level of 5. It will first
           clear the table, then put everything thats in the array, into the table. It will then create a new dataview and populate that dataview. It'll change filterUsed to true, then
           clear our old dtSpells table and we accept changes so that way the elements are completely removed.
           If filters are in use, we basically do the same thing, except with filterTable. We populate our dataRow array with everything that's not the parameter, and 
           move everything from that array, into the datatable dtSpells. We then populate that array, clear filterTable, and accept changes on filterTable. filterUsed gets set to
           false, so that way itll go back up to populating filterTable next time this function is called.
           If the user unchecks all boxes without clicking the reset button, it will set filterUsed back to false
                */
          private void useFilterTable(string filter)
          {
               string expression = $"Level NOT LIKE '%{filter}%'";
               DataRow[] foundRows;
               if (filterUsed == false)
               {    foundRows = dtSpells.Select(expression);
                    filterTable.Clear();
                    foreach (DataRow row in foundRows)
                    {
                         filterTable.ImportRow(row);
                    }
                    filterView = new DataView(filterTable);
                    populateListView(filterView);
                    filterUsed = true;
                    dtSpells.Clear();
                    dtSpells.AcceptChanges();
                  
               }
               else
               {
                    foundRows = filterTable.Select(expression);
                    foreach (DataRow row in foundRows)
                    {
                         dtSpells.ImportRow(row);
                    }
                    tempView = new DataView(dtSpells);
                    populateListView(tempView);
                    filterTable.Clear();
                    filterTable.AcceptChanges();
                    filterUsed = false;
                    
               }
               if(testIfBoxesChecked() == 0)
               {
                    filterUsed = false;
               }
          }
          /*
           * This method effects the Search bar, and how it will be filtered.
           * So, first I used a rowFilter to the DataView dvSpells, which will help display the 
           * searched spell name. To filter the string that you typed in, it must be compared to the
           * Spells that we have. In order to do that, I used rowFilter and our row 0 which holds
           * only the spell names and used the term "LIKE" to compare similar characters and '%. 
           * By doing this I can compare the Spell to the Search bar value with SearchTextBox.Text.
           * 
           * 
           * MODIFIED 3/1/19 BY BRANDON BAUGH
           * Changed this so you can filter, and search by filter for levels
           */
          private void SearchTextBox_TextChanged(object sender, EventArgs e)
          {
               if (dtSpells.Rows.Count != 0)
               {
                    dvSpells.RowFilter = string.Format("Name Like '%{0}%'", SearchTextBox.Text);
                    populateListView(dvSpells);
               }
               if(filterTable.Rows.Count != 0)
               {
                    filterView.RowFilter = string.Format("Name Like '%{0}%'", SearchTextBox.Text);
                    populateListView(filterView);
               }
          }
          /*
          Checkbox 1-10 are for levels. First, we create a count variable that checks how many boxes are currently checked. This includes the box 
          whose state was just changed, so for example, if box 1 and 3 are checked, this will return 2. If box 3 is unchecked, it will drop into checkbox3_checkedchanged
          and will call the function again, and it will return 1 since only box 1 is checked now. First, we check if our checkbox is checked, and if it's the only one checked.
          If it is, we clear the datatable dtSpells and then loop through our list for the respective level. It will add a new row for each item in the list, and then finally
          we populate the list.
          If our box is checked, but there are others checked too, we check which table is currently in use. If it's dtSpells (we check this by measuring the row count), we add
          the levels to the dtSpells table, and populate that. If it's filterTable, then we add the levels to that table and populate that. 
          If our box is unchecked, and no other box is checked, we populate the entire list.
          If our box is unchecked, but there are still others checked, we call useFilterTable. Please see notes for that function.
           */
          private void checkBox1_CheckedChanged(object sender, EventArgs e)
          {
               int count = testIfBoxesChecked();
               if (checkBox1.Checked == true && count <= 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in Level_0)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               
               if (checkBox1.Checked && count > 1)
               {
                    if (dtSpells.Rows.Count != 0)
                    {
                         foreach (var spell in Level_0)
                         {
                              dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in Level_0)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }
               if(checkBox1.Checked == false && count < 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in spells)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               if (checkBox1.Checked == false && count >= 1)
               {
                    useFilterTable("0");
               }
               
          }
          private void checkBox2_CheckedChanged(object sender, EventArgs e)
          {
               int count = testIfBoxesChecked();
               if (checkBox2.Checked == true && count <= 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in Level_1)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               
               if (checkBox2.Checked && count > 1)
               {
                    if (dtSpells.Rows.Count != 0)
                    {
                         foreach (var spell in Level_1)
                         {
                              dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in Level_1)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox2.Checked == false && count < 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in spells)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               if (checkBox2.Checked == false && count >= 1)
               {
                    useFilterTable("1");
               }
          }
          private void checkBox3_CheckedChanged(object sender, EventArgs e)
          {
               int count = testIfBoxesChecked();
               if (checkBox3.Checked == true && count <= 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in Level_2)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }

               if (checkBox3.Checked && count > 1)
               {
                    if (dtSpells.Rows.Count != 0)
                    {
                         foreach (var spell in Level_2)
                         {
                              dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in Level_2)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox3.Checked == false && count < 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in spells)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               if (checkBox3.Checked == false && count >= 1)
               {
                    useFilterTable("2");
               }
          }
          private void checkBox4_CheckedChanged(object sender, EventArgs e)
          {
               int count = testIfBoxesChecked();
               if (checkBox4.Checked == true && count <= 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in Level_3)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }

               if (checkBox4.Checked && count > 1)
               {
                    if (dtSpells.Rows.Count != 0)
                    {
                         foreach (var spell in Level_3)
                         {
                              dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in Level_3)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox4.Checked == false && count < 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in spells)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               if (checkBox4.Checked == false && count >= 1)
               {
                    useFilterTable("3");
               }
          }
          private void checkBox5_CheckedChanged(object sender, EventArgs e)
          {
               int count = testIfBoxesChecked();
               if (checkBox5.Checked == true && count <= 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in Level_4)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }

               if (checkBox5.Checked && count > 1)
               {
                    if (dtSpells.Rows.Count != 0)
                    {
                         foreach (var spell in Level_4)
                         {
                              dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in Level_4)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox5.Checked == false && count < 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in spells)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               if (checkBox5.Checked == false && count >= 1)
               {
                    useFilterTable("4");
               }
          }
          private void checkBox6_CheckedChanged(object sender, EventArgs e)
          {
               int count = testIfBoxesChecked();
               if (checkBox6.Checked == true && count <= 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in Level_5)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }

               if (checkBox6.Checked && count > 1)
               {
                    if (dtSpells.Rows.Count != 0)
                    {
                         foreach (var spell in Level_5)
                         {
                              dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in Level_5)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox6.Checked == false && count < 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in spells)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               if (checkBox6.Checked == false && count >= 1)
               {
                    useFilterTable("5");
               }
          }
          private void checkBox7_CheckedChanged(object sender, EventArgs e)
          {
               int count = testIfBoxesChecked();
               if (checkBox7.Checked == true && count <= 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in Level_6)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }

               if (checkBox7.Checked && count > 1)
               {
                    if (dtSpells.Rows.Count != 0)
                    {
                         foreach (var spell in Level_6)
                         {
                              dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in Level_6)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox7.Checked == false && count < 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in spells)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               if (checkBox7.Checked == false && count >= 1)
               {
                    useFilterTable("6");
               }
          }
          private void checkBox8_CheckedChanged(object sender, EventArgs e)
          {
               int count = testIfBoxesChecked();
               if (checkBox8.Checked == true && count <= 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in Level_7)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }

               if (checkBox8.Checked && count > 1)
               {
                    if (dtSpells.Rows.Count != 0)
                    {
                         foreach (var spell in Level_7)
                         {
                              dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in Level_7)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox8.Checked == false && count < 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in spells)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               if (checkBox8.Checked == false && count >= 1)
               {
                    useFilterTable("7");
               }
          }
          private void checkBox9_CheckedChanged(object sender, EventArgs e)
          {
               int count = testIfBoxesChecked();
               if (checkBox9.Checked == true && count <= 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in Level_8)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }

               if (checkBox9.Checked && count > 1)
               {
                    if (dtSpells.Rows.Count != 0)
                    {
                         foreach (var spell in Level_8)
                         {
                              dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in Level_8)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox9.Checked == false && count < 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in spells)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               if (checkBox9.Checked == false && count >= 1)
               {
                    useFilterTable("8");
               }
          }
          private void checkBox10_CheckedChanged(object sender, EventArgs e)
          {
               int count = testIfBoxesChecked();
               if (checkBox10.Checked == true && count <= 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in Level_9)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }

               if (checkBox10.Checked && count > 1)
               {
                    if (dtSpells.Rows.Count != 0)
                    {
                         foreach (var spell in Level_9)
                         {
                              dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in Level_9)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox10.Checked == false && count < 1)
               {
                    dtSpells.Clear();
                    foreach (var spell in spells)
                    {
                         dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                    }
                    populateListView(dvSpells);
               }
               if (checkBox10.Checked == false && count >= 1)
               {
                    useFilterTable("9");
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
          // if it finds one, it checks if its checked, and if it is, it unchecks it. This also resets filterUsed to false.
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
               filterUsed = false;
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