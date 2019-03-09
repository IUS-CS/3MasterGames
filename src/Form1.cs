using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using C246SpellBook_V_2.WindowView;

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

          //this is for sorting 
          private int sortColumn = -1;

          private DataTable dtSpells;
          private DataView dvSpells;
          private DataTable DisplayTable;

        //For Filters
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
               //hidden id column for searching in the DB
               listView1.Columns.Add("ID", 0);
               listView1.Columns.Add("Name", 150);
               listView1.Columns.Add("Level", 50, HorizontalAlignment.Center);
               listView1.Columns.Add("School", 150);
               listView1.Columns.Add("Ritual", 50);
               listView1.Columns.Add("Concentration", 50);
               listView1.Columns.Add("Classes", 350);
               

               //Initialize Datatable and add columns

               //useing a new database with all information
               /*
               dtSpells = new DataTable();
               dtSpells.Columns.Add("Name");
               dtSpells.Columns.Add("Level");
               dtSpells.Columns.Add("School");
               dtSpells.Columns.Add("Ritual");
               dtSpells.Columns.Add("Concentation");
               dtSpells.Columns.Add("Classes");
               dtSpells.Columns.Add("Components");
               */

                //Data table with all info for display
                DisplayTable = new DataTable();
                DisplayTable.Columns.Add("ID");
                //set primary key
                DisplayTable.PrimaryKey = new DataColumn[] { DisplayTable.Columns["ID"] };
                DisplayTable.Columns.Add("Name");
                DisplayTable.Columns.Add("Level");
                DisplayTable.Columns.Add("School");
                DisplayTable.Columns.Add("Ritual");
                DisplayTable.Columns.Add("Concentation");
                DisplayTable.Columns.Add("Classes");
                DisplayTable.Columns.Add("Time");
                DisplayTable.Columns.Add("Range");
                DisplayTable.Columns.Add("Components");
                DisplayTable.Columns.Add("Materials");
                DisplayTable.Columns.Add("Duration");
                DisplayTable.Columns.Add("Description");
                DisplayTable.Columns.Add("Higher Level");
                DisplayTable.Columns.Add("Source");
                
                
                //Fill DisplayTable 
                fillDataTableAll(XmlReader.generateData());

                //Fill dt datatable
                //fillDataTable(XmlReader.generateData());
                //dvSpells = new DataView(dtSpells);
                dvSpells = new DataView(DisplayTable);
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
           * Transfer the data from list to datatable, by checking each spell and adding it to the 
           * row under that specific column.
           */
          private void fillDataTableAll(List<SpellList> spells)
          {
               foreach (var spell in spells)
               {
                   DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, 
                                            spell.Ritual, spell.Concentration, spell.Classes, spell.Time,
                                            spell.Range, spell.Components, spell.Materials,
                                            spell.Duration, spell.Description, spell.HigherLevel, 
                                            spell.Source);

               }

          }

        private void fillDataTable(List<SpellList> spells)
        {
            foreach (var spell in spells)
            {
                dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

            }

        }


        //Blank for now.
        private void Form1_Load(object sender, EventArgs e)
          {
            // may want to do all of the spell loading ane declaration here

            //This is so that it sorts by level by default 
            listView1.Sorting = SortOrder.Ascending;
            listView1.Sort();
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

                //This is so that it sorts by level by default whenever the listview is loaded
                listView1.Sorting = SortOrder.Ascending;
                listView1.Sort();
                // 2 because id is hidden
                listView1.ListViewItemSorter = new ListViewComparer(2, listView1.Sorting);
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
               {    foundRows = DisplayTable.Select(expression);
                    filterTable.Clear();
                    filterTable.AcceptChanges();
                    foreach (DataRow row in foundRows)
                    {
                         filterTable.ImportRow(row);
                    }
                    filterView = new DataView(filterTable);
                    populateListView(filterView);
                    filterUsed = true;
                    DisplayTable.Clear();
                    DisplayTable.AcceptChanges();
                    filterTable.AcceptChanges();
               }
               else
               {
                    foundRows = filterTable.Select(expression);
                    DisplayTable.Clear();
                    DisplayTable.AcceptChanges();
                // The code errors here because the DisplayTable cannot be null for the ID section.
                    //foreach (DataRow row in foundRows)
                    //{
                    //     DisplayTable.ImportRow(row);
                    //}
                    tempView = new DataView(DisplayTable);
                    populateListView(tempView);
                    filterTable.Clear();
                    filterTable.AcceptChanges();
                    DisplayTable.AcceptChanges();
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
               if (DisplayTable.Rows.Count != 0)
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
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_0)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                }
                    populateListView(dvSpells);
               }
               
               if (checkBox1.Checked && count > 1)
               {
                    if (DisplayTable.Rows.Count != 0)
                    {
                    DisplayTable.Clear();
                         foreach (var spell in XmlReader.Level_0)
                         {
                        DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                  , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                    }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in XmlReader.Level_0)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }
               if(checkBox1.Checked == false && count < 1)
               {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.spells)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

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
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_1)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                }
                    populateListView(dvSpells);
               }
               
               if (checkBox2.Checked && count > 1)
               {
                    if (DisplayTable.Rows.Count != 0)
                    {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_1)
                         {
                        DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                  , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                    }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in XmlReader.Level_1)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox2.Checked == false && count < 1)
               {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.spells)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

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
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_2)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                }
                    populateListView(dvSpells);
               }

               if (checkBox3.Checked && count > 1)
               {
                    if (DisplayTable.Rows.Count != 0)
                    {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_2)
                         {
                        DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                  , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                    }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in XmlReader.Level_2)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox3.Checked == false && count < 1)
               {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.spells)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

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
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_3)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                }
                    populateListView(dvSpells);
               }

               if (checkBox4.Checked && count > 1)
               {
                    if (DisplayTable.Rows.Count != 0)
                    {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_3)
                         {
                        DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                  , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                    }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in XmlReader.Level_3)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox4.Checked == false && count < 1)
               {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.spells)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

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
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_4)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                }
                    populateListView(dvSpells);
               }

               if (checkBox5.Checked && count > 1)
               {
                    if (DisplayTable.Rows.Count != 0)
                    {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_4)
                         {
                        DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                  , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                    }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in XmlReader.Level_4)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox5.Checked == false && count < 1)
               {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.spells)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

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
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_5)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                }
                    populateListView(dvSpells);
               }

               if (checkBox6.Checked && count > 1)
               {
                    if (DisplayTable.Rows.Count != 0)
                    {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_5)
                         {
                        DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                  , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                    }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in XmlReader.Level_5)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox6.Checked == false && count < 1)
               {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.spells)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

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
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_6)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                }
                    populateListView(dvSpells);
               }

               if (checkBox7.Checked && count > 1)
               {
                    if (DisplayTable.Rows.Count != 0)
                    {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_6)
                         {
                        DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                  , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                    }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in XmlReader.Level_6)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox7.Checked == false && count < 1)
               {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.spells)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

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
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_7)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                }
                    populateListView(dvSpells);
               }

               if (checkBox8.Checked && count > 1)
               {
                    if (DisplayTable.Rows.Count != 0)
                    {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_7)
                         {
                        DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                  , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                    }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in XmlReader.Level_7)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox8.Checked == false && count < 1)
               {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.spells)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

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
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_8)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                }
                    populateListView(dvSpells);
               }

               if (checkBox9.Checked && count > 1)
               {
                    if (DisplayTable.Rows.Count != 0)
                    {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_8)
                         {
                        DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                  , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                    }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in XmlReader.Level_8)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox9.Checked == false && count < 1)
               {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.spells)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

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
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_9)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                }
                    populateListView(dvSpells);
               }

               if (checkBox10.Checked && count > 1)
               {
                    if (DisplayTable.Rows.Count != 0)
                    {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.Level_9)
                         {
                        DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                  , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

                    }
                         populateListView(dvSpells);
                    }
                    if (filterTable.Rows.Count != 0)
                    {
                         foreach (var spell in XmlReader.Level_9)
                         {
                              filterTable.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Components);

                         }
                         populateListView(filterView);
                    }
               }

               if (checkBox10.Checked == false && count < 1)
               {
                    DisplayTable.Clear();
                    foreach (var spell in XmlReader.spells)
                    {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                   , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

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

          // ColumnClick event handler.
          private void ColumnClick(object o, ColumnClickEventArgs e)
          {
                // Set the ListViewItemSorter property to a new ListViewItemComparer 
                // object. Setting this property immediately sorts the 
                // ListView using the ListViewItemComparer object.
                //listView1.ListViewItemSorter = new ListViewComparer(e.Column);

                // Determine whether the column is the same as the last column clicked.
                if (e.Column != sortColumn)
                {
                    // Set the sort column to the new column.
                    sortColumn = e.Column;
                    // Set the sort order to ascending by default.
                    listView1.Sorting = SortOrder.Ascending;
                }
                else
                {
                    // Determine what the last sort order was and change it.
                    listView1.Sorting = listView1.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                }

                // Call the sort method to manually sort.
                listView1.Sort();
                // Set the ListViewItemSorter property to a new ListViewItemComparer
                // object.
                listView1.ListViewItemSorter = new ListViewComparer(e.Column, listView1.Sorting);
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
                AboutPage about = new AboutPage();
                about.InitializeComponent();
                about.Show();
          }

          // this method is trigger when the hightlighted spell is changed
          private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
          {
            /* // Old pulling from listview
              //of type ListView.SelectedListViewItemCollection
              var temp = listView1.SelectedItems;

              //of type StringBuilder
              var displayText = new StringBuilder();
              foreach (ListViewItem item in temp)
              {
                   //only displays what is in the list veiw at the moment
                   for (var i = 1; i <= 6; i++)
                   {
                        displayText.AppendLine(item.SubItems[i].Text);
                   }
              }

              Spell_Display.Text = displayText.ToString();
              //Console.WriteLine(listView1.SelectedItems);
              */
              // get changed index
            var spellIndex =  listView1.SelectedIndices;

            // error handling for when selected items are being changed
            // the count is checked to see if an actual index is being passed
            if (spellIndex.Count != 0)
            {
                //get index from spellindex
                var index = spellIndex[0];

                //get the key name 
                string key = listView1.Items[index].Text;
               
                //temporary dataRow to allow display of data
                var spellRow = DisplayTable.Rows.Find(key);

                //call the formatter
                Spell_Display.Text = Format(spellRow);

            }
        }


            //format the string to be outputted on the display
          public string Format(DataRow spell)
          {

              //create a text holder
              var displayText = new StringBuilder();

            /* to output all without formating 
            for (int i = 1; i < 14; i++)
            {
                Console.WriteLine(spell[i]);
                displayText.AppendLine(spell[i].ToString());
            }
            */
              //name #1
              displayText.AppendLine(spell[1].ToString());

            //add a space
            displayText.AppendLine();

            switch (spell[2].ToString())
              {
                case "0":  //school #3 & Level #2
                    displayText.AppendLine(spell[3] + " Cantrip");
                    break;
                case "1": //Level #2 & school #3
                    displayText.AppendLine(spell[2]+"st-level "+spell[3]);
                    break;
                case "2"://Level #2 & school #3
                    displayText.AppendLine(spell[2] + "nd-level " + spell[3]);
                    break;
                case "3"://Level #2 & school #3
                    displayText.AppendLine(spell[2] + "rd-level " + spell[3]);
                    break;
                default://Level #2 & school #3
                    displayText.AppendLine(spell[2] + "th-level " + spell[3]);
                    break;
            }

            //add a space
            displayText.AppendLine();

            // time #7
            displayText.AppendLine("Casting Time: "+spell[7]);

            //Range #8
            displayText.AppendLine("Range: " + spell[8]);

            //Componets #9 & Materials #10
            displayText.Append("Components: " + spell[9]);

            var temp = spell[9].ToString();

            var materialChecker = temp.Split(new[] { "," }, StringSplitOptions.None);

            bool hasMat= false;
            for (int i = 0; i < materialChecker.Length; i++)
            {
                if (materialChecker[i] == " Material" || materialChecker[i] == "Material")
                {
                    hasMat = true;
                }
            }

            if (hasMat)
            {
                displayText.AppendLine("(" + spell[10] + ")" );
            }
            else
            {
                displayText.AppendLine();
            }
                 

            // concentration #5 & ritual #4 & Duration #11  
            displayText.Append("Duration: ");

            if (spell[4].Equals("true") && spell[5].Equals("true"))
            {
                displayText.AppendLine("Ritual & Concentration, up to " + spell[11]);
            }
            else if (spell[4].Equals("false") && spell[5].Equals("true"))
            {
                displayText.AppendLine("Concentration, up to " + spell[11]);
            }
            else if (spell[4].Equals("true") && spell[5].Equals("false"))
            {
                displayText.AppendLine("Ritual or " + spell[11]);
            }
            else
            {
                displayText.AppendLine(spell[11].ToString());
            }

            //add a space
            displayText.AppendLine();

            //description #12
            displayText.AppendLine(spell[12].ToString());

            //add a space
            displayText.AppendLine();

            //higher level #13
            displayText.AppendLine("At Higher Levels: " + spell[13]);

            //add a space
            displayText.AppendLine();

            //Source #14
            displayText.AppendLine("Source: " + spell[14]);

            return displayText.ToString();
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
               filterTable.Clear();
               DisplayTable.Clear();
               foreach (var spell in XmlReader.spells)
               {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes, spell.Time
                        , spell.Range, spell.Components, spell.Materials, spell.Duration, spell.Description, spell.HigherLevel, spell.Source);

               }
               populateListView(dvSpells);

          }

          private void editorToolStripMenuItem_Click(object sender, EventArgs e)
          {

          }

          private void fileToolStripMenuItem_Click(object sender, EventArgs e)
          {

          }

          private void changeLogToolStripMenuItem_Click(object sender, EventArgs e)
          {
                ChangeLog log = new ChangeLog();
                log.InitializeComponent();
                log.Show();
          }

          private void licensesToolStripMenuItem_Click(object sender, EventArgs e)
          {
                Licence lic = new Licence();
                lic.InitializeComponent();
                lic.Show();
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

        private void createNewSpellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpellEditor ed = new SpellEditor();
            ed.InitializeComponent();
            ed.Show();
        }

        private void editSelectedSpellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //for other things we will need to have a different initcalizer to load the form before editing
            SpellEditor ed = new SpellEditor();
            ed.InitializeComponent();
            ed.Show();
        }

        private void duplicateSelectedSpellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //for other things we will need to have a different initcalizer to load the form before editing
            SpellEditor ed = new SpellEditor();
            ed.InitializeComponent();
            ed.Show();
        }

        private void editNonSpellDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataEditor DE = new DataEditor();
            DE.InitializeComponent();
            DE.Show();
        }

        private void Spell_Display_TextChanged(object sender, EventArgs e)
          {

          }
     }
}

