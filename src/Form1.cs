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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Make the dtSpells at the class level so it can be used throughout the program.
         */

        private DataTable dtSpells;

        /* 
         * Generating a form load data table to display the spells.
         * This method is creating a data source for the listBox1, which is the list that will contain our spells.
         * In order to actually display the spell name, I created a Display Member which takes the Data Table variable dtSpells, and looks for the
         * column "Spells" and displays the members in that row.
         */


        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = GetData();
            listBox1.DisplayMember = "Spell";
        }

        /*
         * The DataTable method is what populates the listBox1 with the spells, another method can be created to create other attributes to the spell.
         * Inside the method, I created a column named "Spell" which holds the attributes spell name. For this column each row that I add will be a spell name.
         */

        private DataTable GetData()
        {
            dtSpells = new DataTable();

            dtSpells.Columns.Add("Spell", typeof(string));

            dtSpells.Rows.Add("Abi-Dalzim's Horrid Wilting");
            dtSpells.Rows.Add("Absorb Elements");
            dtSpells.Rows.Add("Acid Arrow");
            dtSpells.Rows.Add("Acid Splash");
            dtSpells.Rows.Add("Aganazzar's Scorcher");
            dtSpells.Rows.Add("Aid");
            dtSpells.Rows.Add("Alarm");
            dtSpells.Rows.Add("Alter Self");
            dtSpells.Rows.Add("Animal Friendship");
            dtSpells.Rows.Add("Animal Messenger");
            dtSpells.Rows.Add("Animal Shapes");
            dtSpells.Rows.Add("Animate Dead");
            dtSpells.Rows.Add("Animate Objects");
            dtSpells.Rows.Add("Antilife Shell");
            dtSpells.Rows.Add("Anitmagic Field");
            dtSpells.Rows.Add("Antipathy/Sympathy");
            dtSpells.Rows.Add("Arcane Eye");
            dtSpells.Rows.Add("Arcane Gate");
            dtSpells.Rows.Add("Arcane Hand");
            dtSpells.Rows.Add("Arcane Lock");
            dtSpells.Rows.Add("Arcanist's Magic Aura");
            dtSpells.Rows.Add("Armor of Agathys");
            dtSpells.Rows.Add("Arms of Hadar");
            dtSpells.Rows.Add("Astral Projection");
            dtSpells.Rows.Add("Augury");
            dtSpells.Rows.Add("Aura of Life");
            dtSpells.Rows.Add("Aura of Purity");
            dtSpells.Rows.Add("Aura of Vitality");
            dtSpells.Rows.Add("Awaken");




            return dtSpells;
        }

        /*
         * This method effects the Search bar, and how it will be filtered.
         * So, first I added the data from the dtSpells to the new DataView dvSpells, which will help display the spell name.
         * To filter the string that you type in it must be comared to the Spells that we have. In order to do that, I used 
         * rowFilter and our column "Spell" and used the term "LIKE" to compare similar characters and '%. By doing this I can 
         * compare the Spell to the Search bar value with SearchTextBox.Text.
         */


        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataView dvSpells = dtSpells.DefaultView;

            dvSpells.RowFilter = "Spell LIKE '%" + SearchTextBox.Text + "%'";
        }
    }
}
