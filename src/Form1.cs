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
          private DataView filterSpells; 
        private List<spellType> spells;
          private CheckBox[] boxes = new CheckBox[18];


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
            

            //Initialize Datatable and add columns
            dtSpells = new DataTable();
            dtSpells.Columns.Add("Name");
            dtSpells.Columns.Add("Level");
            dtSpells.Columns.Add("School");
            dtSpells.Columns.Add("Ritual");
            dtSpells.Columns.Add("Concentation");
            dtSpells.Columns.Add("Classes");


            //Fill datatable
            fillDataTable(generateData());
            dvSpells = new DataView(dtSpells);
            populateListView(dvSpells);
            filterSpells = new DataView(dtSpells);

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
            string name = "";
            string level = "";
            string school = "";
            bool ritual = false;
            string ritualText = "";
            bool concentration = false;
            string time = "";
            string range = "";
            string components = "";
            string duration = "";
            string classes = "";
            string text = "";
            string roll = "";
            int count = 0;

            XmlTextReader doc = new XmlTextReader("PHB Spells 3.4.6.xml");
            spells = new List<spellType>();

            while (doc.Read())
            {
                if (doc.NodeType == XmlNodeType.Element && doc.Name == "name")
                {
                    name = doc.ReadElementString();
                }
                if (doc.NodeType == XmlNodeType.Element && doc.Name == "level")
                {
                    level = doc.ReadElementString();
                }
                if (doc.NodeType == XmlNodeType.Element && doc.Name == "school")
                {
                    school = doc.ReadElementString();
                    if (school == "A")
                        school = "Abjuration";
                    if (school == "C")
                        school = "Conjuration";
                    if (school == "D")
                        school = "Divination";
                    if (school == "EN")
                        school = "Enchantment";
                    if (school == "EV")
                        school = "Evocation";
                    if (school == "I")
                        school = "Illusion";
                    if (school == "N")
                        school = "Necromancy";
                    if (school == "T")
                        school = "Transmutation";
                }
                if (doc.NodeType == XmlNodeType.Element && doc.Name == "ritual")
                {
                    ritualText = doc.ReadElementString();
                    if (ritualText == "YES")
                        ritual = true;
                    else
                        ritual = false;
                }
                if (doc.NodeType == XmlNodeType.Element && doc.Name == "time")
                {
                    time = doc.ReadElementString();
                }
                if (doc.NodeType == XmlNodeType.Element && doc.Name == "time")
                {
                    time = doc.ReadElementString();
                }
                if (doc.NodeType == XmlNodeType.Element && doc.Name == "range")
                {
                    range = doc.ReadElementString();
                }
                if (doc.NodeType == XmlNodeType.Element && doc.Name == "componenets")
                {
                    components = doc.ReadElementString();
                }
                if (doc.NodeType == XmlNodeType.Element && doc.Name == "duration")
                {
                    duration = doc.ReadElementString();
                }
                if (doc.NodeType == XmlNodeType.Element && doc.Name == "classes")
                {
                    classes = doc.ReadElementString();
                }
                if (doc.NodeType == XmlNodeType.Element && doc.Name == "text")
                {
                   text += doc.ReadElementString() + " ";
                }
                if (doc.NodeType == XmlNodeType.Element && doc.Name == "roll")
                {
                    roll += doc.ReadElementString() + ", ";
                }
                if (doc.NodeType == XmlNodeType.Element && doc.Name == "spell")
                {
                    if (count == 0)
                        count++;
                    else
                        spells.Add(new spellType(name, level, school, ritual, concentration, time, range, components, duration, classes, text, roll));
                    text = "";
                    roll = "";

                }
            }
            spells.Add(new spellType(name, level, school, ritual, concentration, time, range, components, duration, classes, text, roll));
            return spells;
        }


        /*
         * Transfer the data from list to datatable, by checking each spell and adding it to the 
         * row under that specific column.
         */
        private void fillDataTable(List<spellType> spells)
        {
            foreach (var spell in spells)
            {
                dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual, spell.Concentration, spell.Classes);
                
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
            foreach (DataRow row in dvSpells.ToTable().Rows)
            {
                listView1.Items.Add(new ListViewItem(new String[] { row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString() }));
            }
        }
          /*
           These functions are supposed to be similar to the search text box, function, using a rowfilter to the dv spells
           and comparing the parameter (either level or class) to the checked box. These are still a work in progress
                */
          private void SetCheckBoxArray()
          {
             
               boxes[0] = checkBox1;
               boxes[1] = checkBox2;
               boxes[2] = checkBox3;
               boxes[3] = checkBox4;
               boxes[4] = checkBox5;
               boxes[5] = checkBox6;
               boxes[6] = checkBox7;
               boxes[7] = checkBox8;
               boxes[8] = checkBox9;
               boxes[9] = checkBox10;
               boxes[10] = checkBox11;
               boxes[11] = checkBox12;
               boxes[12] = checkBox13;
               boxes[13] = checkBox14;
               boxes[14] = checkBox15;
               boxes[15] = checkBox16;
               boxes[16] = checkBox17;
               boxes[17] = checkBox18;
          }
          private void getClasses(DataTable tbl, String Class)
          {
               
               filterSpells.RowFilter = $"Classes LIKE '%{Class}%'";
               
               foreach (DataRow row in filterSpells.ToTable().Rows)
               {
                    listView1.Items.Add(new ListViewItem(new String[] { row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString() }));
               }
             
        }
          private void GetLevels()
          {
               SetCheckBoxArray();
               int index = 0;
               foreach (var checkBox in panel1.Controls.OfType<CheckBox>())
               {
                    if (checkBox.GetType() == typeof(CheckBox))
                    {
                         for(int i = 0; i < boxes.Length; i++)
                         {
                              if (boxes[i].Checked)
                              {
                                   filterSpells.RowFilter = $"Level LIKE '%{boxes[i].Text}%'";
                              }
                         }
                    }
               }
               /*
               if (checkBox1.Checked)
               {
                    dvSpells.RowFilter = "Level LIKE '%0%'";
                    populateListView(dvSpells);
               }
               if(checkBox1.Checked && checkBox2.Checked)
               {
                    dvSpells.RowFilter = "Level LIKE '%0%' OR Level LIKE '%1%'";
                    populateListView(dvSpells);
               }
               */
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
               if (checkBox1.Checked)
                    GetLevels();

               if (checkBox1.Checked == false)
               {
                    dvSpells = new DataView(dtSpells);
                    populateListView(dvSpells);
               }
          }
          private void checkBox2_CheckedChanged(object sender, EventArgs e)
          {

               if(checkBox2.Checked)
                     GetLevels();

                    if (checkBox2.Checked == false)
                    {
                         dvSpells = new DataView(dtSpells);
                         populateListView(dvSpells);
                    }
               
          } 
          private void checkBox3_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox3.Checked)
                         GetLevels();

               if (checkBox3.Checked == false)
               {
                    dvSpells = new DataView(dtSpells);
                    populateListView(dvSpells);
               }
          }
          private void checkBox4_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox4.Checked)
                    GetLevels();

               if (checkBox4.Checked == false)
               {
                    dvSpells = new DataView(dtSpells);
                    populateListView(dvSpells);
               }
          }
          private void checkBox5_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox5.Checked)
                    GetLevels();
               if (checkBox5.Checked == false)
               {
                    dvSpells = new DataView(dtSpells);
                    populateListView(dvSpells);
               }
          }
          private void checkBox6_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox6.Checked)
                    GetLevels();
               if (checkBox6.Checked == false)
               {
                    dvSpells = new DataView(dtSpells);
                    populateListView(dvSpells);
               }
          }
          private void checkBox7_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox7.Checked)
                    GetLevels();
               if (checkBox7.Checked == false)
               {
                    dvSpells = new DataView(dtSpells);
                    populateListView(dvSpells);
               }
          }
          private void checkBox8_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox8.Checked)
                    GetLevels();
               if (checkBox8.Checked == false)
               {
                    dvSpells = new DataView(dtSpells);
                    populateListView(dvSpells);
               }
          }
           private void checkBox9_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox9.Checked)
                    GetLevels();
               if (checkBox9.Checked == false)
               {
                    dvSpells = new DataView(dtSpells);
                    populateListView(dvSpells);
               }
          }
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox10.Checked)
                    GetLevels();
               if (checkBox10.Checked == false)
               {
                    dvSpells = new DataView(dtSpells);
                    populateListView(dvSpells);
               }
          }
          private void checkBox11_CheckedChanged(object sender, EventArgs e)
          {

               if (checkBox11.Checked)
               {
                    getClasses(dtSpells,"Bard");
                    if (checkBox12.Checked)
                    {
                         getClasses(dtSpells, "Cleric");
                    }

                    if (checkBox13.Checked)
                    {
                         getClasses(dtSpells, "Druid");

                    }
                    if (checkBox14.Checked)
                    {
                         getClasses(dtSpells, "Paladin");

                    }
                    if (checkBox15.Checked)
                    {
                         getClasses(dtSpells, "Ranger");

                    }
                    if (checkBox16.Checked)
                    {
                         getClasses(dtSpells,"Sorcerer");

                    }
                    if (checkBox17.Checked)
                    {
                         getClasses(dtSpells, "Warlock");

                    }
                    if (checkBox18.Checked)
                    {
                         getClasses(dtSpells, "Wizard");

                    }

               }

               if (checkBox11.Checked == false)
               {
                    
                    populateListView(dvSpells);
               }

          }
          private void checkBox12_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox12.Checked)
               {
                    getClasses(dtSpells, "Cleric");

                    if (checkBox13.Checked)
                    {
                         getClasses(dtSpells, "Druid");

                    }
                    if (checkBox14.Checked)
                    {
                         getClasses(dtSpells, "Paladin");

                    }
                    if (checkBox15.Checked)
                    {
                         getClasses(dtSpells, "Ranger");

                    }
                    if (checkBox16.Checked)
                    {
                         getClasses(dtSpells, "Sorcerer");

                    }
                    if (checkBox17.Checked)
                    {
                         getClasses(dtSpells, "Warlock");

                    }
                    if (checkBox18.Checked)
                    {
                         getClasses(dtSpells, "Wizard");

                    }


               }
               if (checkBox12.Checked == false)
               {
                 
                    populateListView(dvSpells);
               }
          }
           private void checkBox13_CheckedChanged_1(object sender, EventArgs e)
          {
               if (checkBox13.Checked)
               {
                    getClasses(dtSpells, "Druid");
                    if (checkBox12.Checked)
                    {
                         getClasses(dtSpells, "Cleric");

                    }
                    if (checkBox14.Checked)
                    {
                         getClasses(dtSpells, "Paladin");

                    }
                    if (checkBox15.Checked)
                    {
                         getClasses(dtSpells, "Ranger");

                    }
                    if (checkBox16.Checked)
                    {
                         getClasses(dtSpells, "Sorcerer");

                    }
                    if (checkBox17.Checked)
                    {
                         getClasses(dtSpells, "Warlock");

                    }
                    if (checkBox18.Checked)
                    {
                         getClasses(dtSpells, "Wizard");

                    }

               }
               if (checkBox13.Checked == false)
               {
                  
                    populateListView(dvSpells);
               }
          }

          private void checkBox14_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox14.Checked)
               {
                    getClasses(dtSpells, "Paladin");
                    if (checkBox13.Checked)
                    {
                         getClasses(dtSpells, "Druid");

                    }
                    if (checkBox12.Checked)
                    {
                         getClasses(dtSpells, "Cleric");

                    }
                    if (checkBox15.Checked)
                    {
                         getClasses(dtSpells, "Ranger");

                    }
                    if (checkBox16.Checked)
                    {
                         getClasses(dtSpells, "Sorcerer");

                    }
                    if (checkBox17.Checked)
                    {
                         getClasses(dtSpells, "Warlock");

                    }
                    if (checkBox18.Checked)
                    {
                         getClasses(dtSpells, "Wizard");

                    }

               }
               if (checkBox14.Checked == false)
               {
                    dvSpells = new DataView(dtSpells);
                    populateListView(dvSpells);
               }
          }
          private void checkBox15_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox15.Checked)
               {
                    getClasses(dtSpells, "Ranger");
                    if (checkBox13.Checked)
                    {
                         getClasses(dtSpells, "Druid");

                    }
                    if (checkBox14.Checked)
                    {
                         getClasses(dtSpells, "Paladin");

                    }
                    if (checkBox12.Checked)
                    {
                         getClasses(dtSpells, "Cleric");

                    }
                    if (checkBox16.Checked)
                    {
                         getClasses(dtSpells, "Sorcerer");

                    }
                    if (checkBox17.Checked)
                    {
                         getClasses(dtSpells, "Warlock");

                    }
                    if (checkBox18.Checked)
                    {
                         getClasses(dtSpells, "Wizard");

                    }

               }
               if (checkBox15.Checked == false)
               {
                    dvSpells = new DataView(dtSpells);
                    populateListView(dvSpells);
               }
          }
          private void checkBox16_CheckedChanged_1(object sender, EventArgs e)
          {

               if (checkBox16.Checked)
               {
                    getClasses(dtSpells, "Sorcerer");
                    if (checkBox13.Checked)
                    {
                         getClasses(dtSpells, "Druid");

                    }
                    if (checkBox14.Checked)
                    {
                         getClasses(dtSpells, "Paladin");

                    }
                    if (checkBox15.Checked)
                    {
                         getClasses(dtSpells,"Ranger");

                    }
                    if (checkBox12.Checked)
                    {
                         getClasses(dtSpells, "Cleric");

                    }
                    if (checkBox17.Checked)
                    {
                         getClasses(dtSpells, "Warlock");

                    }
                    if (checkBox18.Checked)
                    {
                         getClasses(dtSpells, "Wizard");

                    }

               }
               if (checkBox16.Checked == false)
               {
                    dvSpells = new DataView(dtSpells);
                    populateListView(dvSpells);
               }

          }
          private void checkBox17_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox17.Checked)
               {
                    getClasses(dtSpells, "Warlock");
                    if (checkBox13.Checked)
                    {
                         getClasses(dtSpells, "Druid");

                    }
                    if (checkBox14.Checked)
                    {
                         getClasses(dtSpells, "Paladin");

                    }
                    if (checkBox15.Checked)
                    {
                         getClasses(dtSpells, "Ranger");

                    }
                    if (checkBox16.Checked)
                    {
                         getClasses(dtSpells, "Sorcerer");

                    }
                    if (checkBox12.Checked)
                    {
                         getClasses(dtSpells, "Cleric");

                    }
                    if (checkBox18.Checked)
                    {
                         getClasses(dtSpells, "Wizard");

                    }

               }
               if (checkBox17.Checked == false)
               {
                    dvSpells = new DataView(dtSpells);
                    populateListView(dvSpells);
               }
          }
          private void checkBox18_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBox18.Checked)
               {
                    getClasses(dtSpells, "Wizard");
                    if (checkBox13.Checked)
                    {
                         getClasses(dtSpells, "Druid");

                    }
                    if (checkBox14.Checked)
                    {
                         getClasses(dtSpells, "Paladin");

                    }
                    if (checkBox15.Checked)
                    {
                         getClasses(dtSpells, "Ranger");

                    }
                    if (checkBox16.Checked)
                    {
                         getClasses(dtSpells, "Sorcerer");

                    }
                    if (checkBox17.Checked)
                    {
                         getClasses(dtSpells, "Warlock");

                    }
                    if (checkBox12.Checked)
                    {
                         getClasses(dtSpells, "Cleric");

                    }

               }
               if (checkBox18.Checked == false)
               {
                    dvSpells = new DataView(dtSpells);
                    populateListView(dvSpells);
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
          //This is the reset filters button. It sets the checked state for each individual checkbox to false (unchecked) if the box is checked
          private void button1_Click(object sender, EventArgs e)
          {
               foreach(var checkBox in panel1.Controls.OfType<CheckBox>())
               {
                    if(checkBox.GetType() == typeof(CheckBox))
                    {
                         var checkBoxCtrl = (CheckBox)checkBox;
                         if(checkBoxCtrl.Checked == true)
                         {
                              checkBoxCtrl.Checked = false;
                         }
                    }
               }
          }
     }
}


/*
 * This is where we will add attributes to the spellType class, like level, name, discription, etc.
 */
class spellType
{
    private string name;
    private string level;
    private string school;
    private bool ritual;
    private bool concentration;
    private string time;
    private string range;
    private string components;
    private string duration;
    private string classes;
    private string text;
    private string roll;
    
    
    


    public spellType(string name, string level, string school, bool ritual, bool concentration, string time, string range, string components, string duration, string classes, string text, string roll)
    {
        this.name = name;
        this.level = level;
        this.school = school;
        this.ritual = ritual;
        this.concentration = concentration;
        this.time = time;
        this.range = range;
        this.components = components;
        this.duration = duration;
        this.classes = classes;
        this.text = text;
        this.roll = roll;
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
    public string Duration
    {
        get { return duration; }
    }
    public string Classes
    {
        get { return classes; }
    }
    public string Text
    {
        get { return text; }
    }
    public string Roll
    {
        get { return roll; }
    }
}