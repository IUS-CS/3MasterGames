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

        private DataTable dtSpells;

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = GetData();
            listBox1.DisplayMember = "Spell";
        }

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

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataView dvSpells = dtSpells.DefaultView;

            dvSpells.RowFilter = "Spell LIKE '%" + SearchTextBox.Text + "%'";
        }
    }
}
