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
            listView1.Columns.Add("Level", 100);
            listView1.Columns.Add("School", 150);
            listView1.Columns.Add("Ritual", 150);


            //Initialize Datatable and add columns
            dtSpells = new DataTable();
            dtSpells.Columns.Add("Name");
            dtSpells.Columns.Add("Level");
            dtSpells.Columns.Add("School");
            dtSpells.Columns.Add("Ritual");



            //Fill datatable
            fillDataTable(generateData());
            dvSpells = new DataView(dtSpells);
            populateListView(dvSpells);

        }


        /*
         * Update: The generateData method starts with multiple data types to hold all the information in. This method will read in the Xml file
         * with all the spells inside it, and store them into a List spellType. This list is named spells. While the Xml file is open it will read
         * each line and compare whether its the name, level, etc. It will store it into that specific variable and hold onto that data until
         * that spell is competed. Once it is completed it is added to the list spells with all the attributes included inside it. This method is not
         * completed yet, because the attributes text and roll can have multiple lines inside the Xml file causing duplicates in the spell list.
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
                    spells.Add(new spellType(name, level, school, ritual, concentration, time, range, components, duration, classes, text, roll));

                }
                //if (doc.NodeType == XmlNodeType.Element && doc.Name == "text")
                //{
                //   text = doc.ReadElementString();
                //
                //}
                //if (doc.NodeType == XmlNodeType.Element && doc.Name == "roll")
                //{
                //    roll = doc.ReadElementString();
                //
                //}
            }
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
                dtSpells.Rows.Add(spell.Name, spell.Level, spell.School, spell.Ritual);
                
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
                listView1.Items.Add(new ListViewItem(new String[] { row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString() }));
            }
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

          private void checkBox1_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox2_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox3_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox4_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox5_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox6_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox7_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox8_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox9_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox10_CheckedChanged(object sender, EventArgs e)
          {

          }

        private void duplicateSpellBookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

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