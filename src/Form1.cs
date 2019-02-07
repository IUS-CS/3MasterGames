using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            listView1.Columns.Add("School", 100);
            listView1.Columns.Add("Classes", 150);

            //Initialize Datatable and add columns
            dtSpells = new DataTable();
            dtSpells.Columns.Add("Name");
            dtSpells.Columns.Add("School");
            dtSpells.Columns.Add("Classes");


            //Fill datatable
            fillDataTable(generateData());
            dvSpells = new DataView(dtSpells);
            populateListView(dvSpells);

        }


        /*
         * Make the dtSpells at the class level so it can be used throughout the program.
         * This creates a new list named spells and generates all the spells manually, late this
         * will need to change in order to hold more attributes other than name.
         */
        private List<spellType> generateData()
        {
            spells = new List<spellType>()
            {
                new spellType("Abi-Dalzim's Horrid Wilting", "Necromancy", "Sorcerer, Wizard", "8", "1 Action", "150 ft", "Instantaneous", "You draw the moisture from every creature in a 30-foot cube centered on a point you choose within range. Each creature in that area must make a Constitution saving throw. Constructs and undead aren’t affected, and plants and water elementals make this saving throw with disadvantage. A creature takes 12d8 necrotic damage on a failed save, or half as much damage on a successful one. Nonmagical plants in the area that aren’t creatures, such as trees and shrubs, wither and die instantly."),
                new spellType("Abi-Dalzim's Horrid Wilting", "Necromancy", "Bard", "8", "1 Action", "150 ft", "Instantaneous", "You draw the moisture from every creature in a 30-foot cube centered on a point you choose within range. Each creature in that area must make a Constitution saving throw. Constructs and undead aren’t affected, and plants and water elementals make this saving throw with disadvantage. A creature takes 12d8 necrotic damage on a failed save, or half as much damage on a successful one. Nonmagical plants in the area that aren’t creatures, such as trees and shrubs, wither and die instantly."),

                /*
                 
                new spellType("Absorb Elements"),
                new spellType("Acid Arrow"),
                new spellType("Acid Splash"),
                new spellType("Aganazzar's Scorcher"),
                new spellType("Aid"),
                new spellType("Alarm"),
                new spellType("Alter Self"),
                new spellType("Animal Friendship"),
                new spellType("Animal Messenger"),
                new spellType("Animal Shapes"),
                new spellType("Animate Dead"),
                new spellType("Animate Objects"),
                new spellType("Antilife Shell"),
                new spellType("Antimagic Field"),
                new spellType("Antipathy/Sympathy"),
                new spellType("Arcane Eye"),
                new spellType("Arcane Gate"),
                new spellType("Arcane Hand"),
                new spellType("Arcane Lock"),
                new spellType("Arcanist's Magic Aura"),
                new spellType("Armor of Agathys"),
                new spellType("Arms of Hadar"),
                new spellType("Astral Projection"),
                new spellType("Augury"),
                new spellType("Aura of Life"),
                new spellType("Aura of Purity"),
                new spellType("Aura of Vitality"),
                new spellType("Awaken"),
                */
            };

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
                dtSpells.Rows.Add(spell.Name, spell.School, spell.Classes);
                
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
                listView1.Items.Add(new ListViewItem(new String[] { row[0].ToString(), row[1].ToString(), row[2].ToString() }));
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
          private void checkBox11_CheckedChange(object sender, EventArgs e)
          {

          }
          private void checkBox12_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox13_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox14_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox15_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox16_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox17_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void checkBox18_CheckedChanged(object sender, EventArgs e)
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
 * This is where we will add attributes to the spellType class, like level, dame, discription, etc.
 */
class spellType
{
    private string name;
    private string school;
    private string classes;
    private string level;
    private string castingTime;
    private string range;
    private string duration;
    private string description;


    public spellType(string name, string school, string classes, string level, string castingTime, string range, string duration, string description)
    {
        this.name = name;
        this.school = school;
        this.classes = classes;
        this.level = level;
        this.castingTime = castingTime;
        this.range = range;
        this.duration = duration;
        this.description = description;
    }

    public string Name
    {
        get { return name; }
    }
    public string School
    {
        get { return school; }
    }
    public string Classes
    {
        get { return classes; }
    }
    public string Level
    {
        get { return level; }
    }
    public string CastingTime
    {
        get { return castingTime; }
    }
    public string Range
    {
        get { return range; }
    }
    public string Duration
    {
        get { return duration; }
    }
    public string Description
    {
        get { return description; }
    }
}