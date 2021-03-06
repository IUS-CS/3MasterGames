﻿using System;
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
using C246SpellBook_V_2.Model;
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

          private DataTable tempSpells;
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


            tempSpells = new DataTable();
                tempSpells.Columns.Add("ID");
                //set primary key
                tempSpells.PrimaryKey = new DataColumn[] { tempSpells.Columns["ID"] };
                tempSpells.Columns.Add("Name");
                tempSpells.Columns.Add("Level");
                tempSpells.Columns.Add("School");
                tempSpells.Columns.Add("Ritual");
                tempSpells.Columns.Add("Concentation");
                tempSpells.Columns.Add("Classes");
                tempSpells.Columns.Add("Time");
                tempSpells.Columns.Add("Range");
                tempSpells.Columns.Add("Components");
                tempSpells.Columns.Add("Materials");
                tempSpells.Columns.Add("Duration");
                tempSpells.Columns.Add("Description");
                tempSpells.Columns.Add("Higher Level");
                tempSpells.Columns.Add("Source");

                

                //Fill DisplayTable 
                FillDataTableAll(XmlReader.generateData());

                //Fill dt datatable
                //fillDataTable(XmlReader.generateData());
                //dvSpells = new DataView(dtSpells);
                dvSpells = new DataView(DisplayTable);
                PopulateListView(dvSpells);
               
                //This is almost like a temporary table. Filters will be bouncing between this table and dtSpells
                filterTable = new DataTable();
                filterTable.Columns.Add("ID");
                filterTable.Columns.Add("Name");
                filterTable.Columns.Add("Level");
                filterTable.Columns.Add("School");
                filterTable.Columns.Add("Ritual");
                filterTable.Columns.Add("Concentation");
                filterTable.Columns.Add("Classes");
                filterTable.Columns.Add("Time");
                filterTable.Columns.Add("Range");
                filterTable.Columns.Add("Components");
                filterTable.Columns.Add("Materials");
                filterTable.Columns.Add("Duration");
                filterTable.Columns.Add("Description");
                filterTable.Columns.Add("Higher Level");
                filterTable.Columns.Add("Source");
          }



          /*
           * Transfer the data from list to datatable, by checking each spell and adding it to the 
           * row under that specific column.
           */
          private void FillDataTableAll(List<SpellList> spells)
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
          private void PopulateListView(DataView dv)
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
          private int TestIfBoxesChecked()
          {
               int count = 0;
               foreach (var checkBox in panel1.Controls.OfType<CheckBox>())
               {
                    if (checkBox.GetType() == typeof(CheckBox))
                    {
                         var checkBoxCtrl = checkBox;
                         if (checkBoxCtrl.Checked)
                         {
                              count++;
                         }
                    }
               }
               return count;
          }


        ///<summary>  
        ///  I added a Regex matching system, that way the program can determine whether it is a level (int) or a class (string).
        ///  I added an if statement after to differ between level, and class. Right now we need to figure out the best way to clear out a class, and add its prior classes back in. When multiple
        ///  checkboxes are selected with classes and you remove one, it will remove all references to that class but we need some if bard is selected for instance and we remove wizard, we need all instances of
        ///  bard to stay even if a wizard is able to use it. 
        ///  Again I commented out DisplayTable.clear(); because it causes an error when multiple boxes are selected and then some are deselected. It causes the display to become null. We do not wnat that. 
        ///  A revision is needed. I am also working on trying to make this method shorter and universal with all filters.
        ///</summary>
        ///<param name="filter">
        ///  Referance to which type of filter that is selected.
        ///</param>  
        private void UseFilterTable(string filter)
          {

            if (Regex.IsMatch(filter, @"^\d+$"))
            {

                string expression = $"Level NOT LIKE '%{filter}%'";
                DataRow[] foundRows;
                if (!filterUsed)
                {
                    foundRows = DisplayTable.Select(expression);
                    filterTable.Clear();

                    filterTable.AcceptChanges();
                    foreach (DataRow row in foundRows)
                    {
                        filterTable.ImportRow(row);
                    }
                    filterView = new DataView(filterTable);
                    PopulateListView(filterView);
                    filterUsed = true;
                    //DisplayTable.Clear();
                    DisplayTable.AcceptChanges();
                    filterTable.AcceptChanges();
                }
                else
                {
                    foundRows = filterTable.Select(expression);
                    DisplayTable.Clear();
                    DisplayTable.AcceptChanges();
                    foreach (DataRow row in foundRows)
                    {
                        DisplayTable.ImportRow(row);
                    }
                    tempView = new DataView(DisplayTable);
                    PopulateListView(tempView);
                    filterTable.Clear();
                    filterTable.AcceptChanges();
                    DisplayTable.AcceptChanges();
                    filterUsed = false;

                }
                if (TestIfBoxesChecked() == 0)
                {
                    filterUsed = false;
                }
            }
            else
            {
                string expression = $"Classes NOT LIKE '%{filter}%'";
                DataRow[] foundRows;
                if (!filterUsed)
                {
                    foundRows = DisplayTable.Select(expression);
                    filterTable.Clear();

                    filterTable.AcceptChanges();
                    foreach (DataRow row in foundRows)
                    {
                        filterTable.ImportRow(row);
                    }
                    filterView = new DataView(filterTable);
                    PopulateListView(filterView);
                    filterUsed = true;
                    //DisplayTable.Clear();
                    DisplayTable.AcceptChanges();
                    filterTable.AcceptChanges();
                }
                else
                {
                    foundRows = filterTable.Select(expression);
                    DisplayTable.Clear();
                    DisplayTable.AcceptChanges();
                    foreach (DataRow row in foundRows)
                    {
                        DisplayTable.ImportRow(row);
                    }
                    tempView = new DataView(DisplayTable);
                    PopulateListView(tempView);
                    filterTable.Clear();
                    filterTable.AcceptChanges();
                    DisplayTable.AcceptChanges();
                    filterUsed = false;

                }
                if (TestIfBoxesChecked() == 0)
                {
                    filterUsed = false;
                }
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
                    PopulateListView(dvSpells);
               }
               if(filterTable.Rows.Count != 0)
               {
                    filterView.RowFilter = string.Format("Name Like '%{0}%'", SearchTextBox.Text);
                    PopulateListView(filterView);
               }
          }

        /*
        Checkbox_CheckedChanged are for levels. First, we create a count variable that checks how many boxes are currently checked. This includes the box 
        whose state was just changed, so for example, if box 1 and 3 are checked, this will return 2. First, we check if our checkbox is checked, and if it's the only one checked.
        If it is, we clear the datatable dtSpells and then loop through our list for the respective level. It will add a new row for each item in the list, and then finally
        we populate the list.
        If our box is checked, but there are others checked too, we check which table is currently in use. If it's dtSpells (we check this by measuring the row count), we add
        the levels to the dtSpells table, and populate that. If it's filterTable, then we add the levels to that table and populate that. 
        If our box is unchecked, and no other box is checked, we populate the entire list.
        If our box is unchecked, but there are still others checked, we call useFilterTable. Please see notes for that function.
         */
        private void checkBox_CheckedChanged(object sender, EventArgs e, CheckBox checkBox, List<SpellList> spellLevel, string filterTableNumber)
        {

            int count = TestIfBoxesChecked();
            if (checkBox.Checked && count <= 1)
            {
                DisplayTable.Clear();
                foreach (var spell in spellLevel)
                {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, 
                                                                spell.Ritual, spell.Concentration, spell.Classes, spell.Time,
                                                                spell.Range, spell.Components, spell.Materials, 
                                                                spell.Duration, spell.Description, spell.HigherLevel, 
                                                                spell.Source);

                }
                PopulateListView(dvSpells);
            }

            if (checkBox.Checked && count > 1)
            {
                if (DisplayTable.Rows.Count != 0)
                {

                    foreach (var spell in spellLevel)
                    {
                        bool contains = DisplayTable.AsEnumerable().Any(row => spell.ID == row.Field<string>("ID"));
                        if (!contains)
                            DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, 
                                                                    spell.Ritual, spell.Concentration, spell.Classes, spell.Time,
                                                                    spell.Range, spell.Components, spell.Materials,
                                                                    spell.Duration, spell.Description, spell.HigherLevel, 
                                                                    spell.Source);

                    }
                    PopulateListView(dvSpells);
                }
                if (filterTable.Rows.Count != 0)
                {
                    foreach (var spell in spellLevel)
                    {
                        filterTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School,
                                                                   spell.Ritual, spell.Concentration, spell.Classes, spell.Time,
                                                                   spell.Range, spell.Components, spell.Materials,
                                                                   spell.Duration, spell.Description, spell.HigherLevel,
                                                                   spell.Source);

                    }
                    PopulateListView(filterView);
                }
            }
            if (!checkBox.Checked && count < 1)
            {
                DisplayTable.Clear();
                foreach (var spell in XmlReader.spells)
                {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, 
                                                                spell.Ritual, spell.Concentration, spell.Classes, spell.Time,
                                                                spell.Range, spell.Components, spell.Materials,    
                                                                spell.Duration, spell.Description, spell.HigherLevel, 
                                                                spell.Source);

                }
                PopulateListView(dvSpells);
            }
            if (!checkBox.Checked && count >= 1)
            {
                UseFilterTable(filterTableNumber);
            }
        }


        ///<summary>  
        ///  This method works the same as the level filter above, it handles by how many checkboxes have been selected or deselected. By calling from the Designer class, it can determine which checkbox
        ///  was selected and how many are selected prior by the count variable. Detpending on how many are selected it filters through some if statements and filters accordingly. If only 1 box is selected and
        ///  then deslected then it will clear that list and imprort the original. If multiple boxes are selected and a deselect is triggered it will call the useFilterTable, this is where out issue occurs. 
        ///  We need to revise this, because as of now it clears anything to do with that checkbox that is deselected and other checkboxes selected might need that spell to stay in the list.
        ///</summary>
        ///<param name="sender", "e", "checkbox", "spellClass", "filterTableClass">
        ///  Referances to the values in the desgner class that determines which checkbox is activated.
        ///</param>  
        private void checkBox_CheckedChangedClass(object sender, EventArgs e, CheckBox checkBox, List<SpellList> spellClass, string filterTableClass)
        {

            int count = TestIfBoxesChecked();
            if (checkBox.Checked && count <= 1)
            {
                DisplayTable.Clear();
                foreach (var spell in spellClass)
                {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School,
                                                                spell.Ritual, spell.Concentration, spell.Classes, spell.Time,
                                                                spell.Range, spell.Components, spell.Materials,
                                                                spell.Duration, spell.Description, spell.HigherLevel,
                                                                spell.Source);

                }
                PopulateListView(dvSpells);
            }

            if (checkBox.Checked && count > 1)
            {
                if (DisplayTable.Rows.Count != 0)
                {
                    foreach (var spell in spellClass)
                    {

                        bool contains = DisplayTable.AsEnumerable().Any(row => spell.ID == row.Field<string>("ID"));
                        if (!contains)
                            DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School,
                                                                        spell.Ritual, spell.Concentration, spell.Classes, spell.Time,
                                                                        spell.Range, spell.Components, spell.Materials,
                                                                        spell.Duration, spell.Description, spell.HigherLevel,
                                                                        spell.Source);
                        
                        

                    }
                    PopulateListView(dvSpells);
                }
                if (filterTable.Rows.Count != 0)
                {
                    foreach (var spell in spellClass)
                    {
                        
                            filterTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School,
                                                                   spell.Ritual, spell.Concentration, spell.Classes, spell.Time,
                                                                   spell.Range, spell.Components, spell.Materials,
                                                                   spell.Duration, spell.Description, spell.HigherLevel,
                                                                   spell.Source);

                    }
                    PopulateListView(filterView);
                }
            }
            if (!checkBox.Checked && count < 1)
            {
                DisplayTable.Clear();
                foreach (var spell in XmlReader.spells)
                {
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School,
                                                                spell.Ritual, spell.Concentration, spell.Classes, spell.Time,
                                                                spell.Range, spell.Components, spell.Materials,
                                                                spell.Duration, spell.Description, spell.HigherLevel,
                                                                spell.Source);

                }
                PopulateListView(dvSpells);
            }
            if (!checkBox.Checked && count >= 1)
            {
                UseFilterTable(filterTableClass);
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

        //Not sure what this is?
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
            var format = new displayFormatter();

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

                var spellRow = DisplayTable.Rows.Find(key);

                Spell_Display.Text = format.Format(spellRow);
            }
        }


           
        //This is the reset filters button. It checks panel 1 where the checkboxes are located and looks for a control of checkbox type
        // if it finds one, it checks if its checked, and if it is, it unchecks it. This also resets filterUsed to false.
        private void button1_Click(object sender, EventArgs e)
          {
               foreach (var checkBox in panel1.Controls.OfType<CheckBox>())
               {
                    if (checkBox.GetType() == typeof(CheckBox))
                    {
                         var checkBoxCtrl = checkBox;
                         if (checkBoxCtrl.Checked)
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
                    DisplayTable.Rows.Add(spell.ID, spell.Name, spell.Level, spell.School, 
                                                                spell.Ritual, spell.Concentration, spell.Classes, spell.Time,
                                                                spell.Range, spell.Components, spell.Materials,
                                                                spell.Duration, spell.Description, spell.HigherLevel, 
                                                                spell.Source);
               }
               PopulateListView(dvSpells);

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

