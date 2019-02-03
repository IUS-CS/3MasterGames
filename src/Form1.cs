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
         * be able to view the data that has been placed inside the list. Also List SpellType is the
         * list of spells.
         */
        private DataTable dtSpells;
        private DataView dvSpells;
        private List<SpellType> spells;


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

            //Initialize Datatable and add columns
            dtSpells = new DataTable();
            dtSpells.Columns.Add("Name");

            //Fill datatable
            FillDataTable(GenerateData());
            dvSpells = new DataView(dtSpells);
            PopulateListView(dvSpells);

        }


        /*
         * Make the dtSpells at the class level so it can be used throughout the program.
         * This creates a new list named spells and generates all the spells manually, late this
         * will need to change in order to hold more attribtes other than name.
         */
        private List<SpellType> GenerateData()
        {
            spells = new List<SpellType>()
            {
                new SpellType("Abi-Dalzim's Horrid Wilting"),
                new SpellType("Absorb Elements"),
                new SpellType("Acid Arrow"),
                new SpellType("Acid Splash"),
                new SpellType("Aganazzar's Scorcher"),
                new SpellType("Aid"),
                new SpellType("Alarm"),
                new SpellType("Alter Self"),
                new SpellType("Animal Friendship"),
                new SpellType("Animal Messenger"),
                new SpellType("Animal Shapes"),
                new SpellType("Animate Dead"),
                new SpellType("Animate Objects"),
                new SpellType("Antilife Shell"),
                new SpellType("Antimagic Field"),
                new SpellType("Antipathy/Sympathy"),
                new SpellType("Arcane Eye"),
                new SpellType("Arcane Gate"),
                new SpellType("Arcane Hand"),
                new SpellType("Arcane Lock"),
                new SpellType("Arcanist's Magic Aura"),
                new SpellType("Armor of Agathys"),
                new SpellType("Arms of Hadar"),
                new SpellType("Astral Projection"),
                new SpellType("Augury"),
                new SpellType("Aura of Life"),
                new SpellType("Aura of Purity"),
                new SpellType("Aura of Vitality"),
                new SpellType("Awaken"),
            };

            return spells;
        }


        /*
         * Transfer the data from list to datatable, by checking each spell and adding it to the 
         * row under that specific column.
         */
        private void FillDataTable(List<SpellType> spells)
        {
            foreach (var spell in spells)
            {
                dtSpells.Rows.Add(spell.Name);
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
        private void PopulateListView(DataView dv)
        {
            listView1.Items.Clear();
            foreach (DataRow row in dvSpells.ToTable().Rows)
            {
                listView1.Items.Add(new ListViewItem(new String[] { row[0].ToString() }));
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
            PopulateListView(dvSpells);
        }

          private void CheckBox1_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void CheckBox2_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void CheckBox3_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void CheckBox4_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void CheckBox5_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void CheckBox6_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void CheckBox7_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void CheckBox8_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void CheckBox9_CheckedChanged(object sender, EventArgs e)
          {

          }
          private void CheckBox10_CheckedChanged(object sender, EventArgs e)
          {

          }

        private void DuplicateSpellBookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AboutThisApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


/*
 * This is where we will add attributes to the SpellType class, like level, dame, discription, etc.
 */
class SpellType
{
#pragma warning disable IDE0044 // Add readonly modifier
    private string name;
#pragma warning restore IDE0044 // Add readonly modifier

    public SpellType(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return name; }
    }
}