namespace C246SpellBook_V_2
{
     partial class Form1
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;


          /// <summary>
          /// Clean up any resources being used.
          /// </summary>
          /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }



          #region Windows Form Designer generated code

          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
            this.label1 = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.Spell_Display = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSpellbookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSpellbookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spellbookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSpellToSpellbookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSpellFromSpellbookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewSpellbookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateSpellBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSpellbookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedSpellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewSpellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateSelectedSpellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedSpellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editNonSpellDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutThisApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchPanel.SuspendLayout();
            this.DisplayPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(85, 32);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(223, 20);
            this.SearchTextBox.TabIndex = 1;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // SearchPanel
            // 
            this.SearchPanel.Controls.Add(this.listView1);
            this.SearchPanel.Controls.Add(this.SearchTextBox);
            this.SearchPanel.Controls.Add(this.label1);
            this.SearchPanel.Location = new System.Drawing.Point(273, 45);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(464, 382);
            this.SearchPanel.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(15, 76);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(433, 296);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.BackColor = System.Drawing.SystemColors.MenuBar;
            this.DisplayPanel.Controls.Add(this.Spell_Display);
            this.DisplayPanel.Controls.Add(this.label2);
            this.DisplayPanel.Location = new System.Drawing.Point(752, 45);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(251, 381);
            this.DisplayPanel.TabIndex = 4;
            this.DisplayPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayPanel_Paint);
            // 
            // Spell_Display
            // 
            this.Spell_Display.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Spell_Display.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Spell_Display.Enabled = false;
            this.Spell_Display.Location = new System.Drawing.Point(2, 32);
            this.Spell_Display.Margin = new System.Windows.Forms.Padding(2);
            this.Spell_Display.Name = "Spell_Display";
            this.Spell_Display.Size = new System.Drawing.Size(233, 347);
            this.Spell_Display.TabIndex = 1;
            this.Spell_Display.Text = "this is example ";
            this.Spell_Display.TextChanged += new System.EventHandler(this.Spell_Display_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Spell Description";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.checkBox18);
            this.panel1.Controls.Add(this.checkBox17);
            this.panel1.Controls.Add(this.checkBox16);
            this.panel1.Controls.Add(this.checkBox15);
            this.panel1.Controls.Add(this.checkBox14);
            this.panel1.Controls.Add(this.checkBox13);
            this.panel1.Controls.Add(this.checkBox12);
            this.panel1.Controls.Add(this.checkBox11);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.checkBox10);
            this.panel1.Controls.Add(this.checkBox9);
            this.panel1.Controls.Add(this.checkBox8);
            this.panel1.Controls.Add(this.checkBox7);
            this.panel1.Controls.Add(this.checkBox6);
            this.panel1.Controls.Add(this.checkBox5);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 562);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(20, 516);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Reset Filters";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox18
            // 
            this.checkBox18.AutoSize = true;
            this.checkBox18.Location = new System.Drawing.Point(33, 493);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(59, 17);
            this.checkBox18.TabIndex = 20;
            this.checkBox18.Text = "Wizard";
            this.checkBox18.UseVisualStyleBackColor = true;
            this.checkBox18.CheckedChanged += new System.EventHandler(this.checkBox18_CheckedChanged);
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.Location = new System.Drawing.Point(33, 469);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(66, 17);
            this.checkBox17.TabIndex = 19;
            this.checkBox17.Text = "Warlock";
            this.checkBox17.UseVisualStyleBackColor = true;
            this.checkBox17.CheckedChanged += new System.EventHandler(this.checkBox17_CheckedChanged);
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(33, 446);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(66, 17);
            this.checkBox16.TabIndex = 18;
            this.checkBox16.Text = "Sorcerer";
            this.checkBox16.UseVisualStyleBackColor = true;
            this.checkBox16.CheckedChanged += new System.EventHandler(this.checkBox16_CheckedChanged_1);
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(33, 423);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(61, 17);
            this.checkBox15.TabIndex = 17;
            this.checkBox15.Text = "Ranger";
            this.checkBox15.UseVisualStyleBackColor = true;
            this.checkBox15.CheckedChanged += new System.EventHandler(this.checkBox15_CheckedChanged);
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(33, 403);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(61, 17);
            this.checkBox14.TabIndex = 16;
            this.checkBox14.Text = "Paladin";
            this.checkBox14.UseVisualStyleBackColor = true;
            this.checkBox14.CheckedChanged += new System.EventHandler(this.checkBox14_CheckedChanged);
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(33, 380);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(51, 17);
            this.checkBox13.TabIndex = 15;
            this.checkBox13.Text = "Druid";
            this.checkBox13.UseVisualStyleBackColor = true;
            this.checkBox13.CheckedChanged += new System.EventHandler(this.checkBox13_CheckedChanged_1);
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(33, 357);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(52, 17);
            this.checkBox12.TabIndex = 14;
            this.checkBox12.Text = "Cleric";
            this.checkBox12.UseVisualStyleBackColor = true;
            this.checkBox12.CheckedChanged += new System.EventHandler(this.checkBox12_CheckedChanged);
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(33, 334);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(48, 17);
            this.checkBox11.TabIndex = 13;
            this.checkBox11.Text = "Bard";
            this.checkBox11.UseVisualStyleBackColor = true;
            this.checkBox11.CheckedChanged += new System.EventHandler(this.checkBox11_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Class";
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(33, 274);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(61, 17);
            this.checkBox10.TabIndex = 12;
            this.checkBox10.Text = "Level 9";
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.checkBox10_CheckedChanged);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(33, 251);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(61, 17);
            this.checkBox9.TabIndex = 11;
            this.checkBox9.Text = "Level 8";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(33, 228);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(61, 17);
            this.checkBox8.TabIndex = 10;
            this.checkBox8.Text = "Level 7";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(33, 205);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(61, 17);
            this.checkBox7.TabIndex = 9;
            this.checkBox7.Text = "Level 6";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(33, 182);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(61, 17);
            this.checkBox6.TabIndex = 8;
            this.checkBox6.Text = "Level 5";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(33, 159);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(61, 17);
            this.checkBox5.TabIndex = 7;
            this.checkBox5.Text = "Level 4";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(33, 136);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(61, 17);
            this.checkBox4.TabIndex = 6;
            this.checkBox4.Text = "Level 3";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(33, 113);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(61, 17);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "Level 2";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(33, 90);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(61, 17);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Level 1";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(33, 67);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Level 0";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Filters";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.spellbookToolStripMenuItem,
            this.editorToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1100, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportSpellbookToolStripMenuItem,
            this.loadSpellbookToolStripMenuItem,
            this.exportDataToolStripMenuItem,
            this.importDataToolStripMenuItem,
            this.resetAllDataToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // exportSpellbookToolStripMenuItem
            // 
            this.exportSpellbookToolStripMenuItem.Name = "exportSpellbookToolStripMenuItem";
            this.exportSpellbookToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exportSpellbookToolStripMenuItem.Text = "Export Spellbook";
            // 
            // loadSpellbookToolStripMenuItem
            // 
            this.loadSpellbookToolStripMenuItem.Name = "loadSpellbookToolStripMenuItem";
            this.loadSpellbookToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.loadSpellbookToolStripMenuItem.Text = "Load Spellbook";
            // 
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exportDataToolStripMenuItem.Text = "Export Data";
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.importDataToolStripMenuItem.Text = "Import Data";
            // 
            // resetAllDataToolStripMenuItem
            // 
            this.resetAllDataToolStripMenuItem.Name = "resetAllDataToolStripMenuItem";
            this.resetAllDataToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.resetAllDataToolStripMenuItem.Text = "Reset all Data";
            // 
            // spellbookToolStripMenuItem
            // 
            this.spellbookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSpellToSpellbookToolStripMenuItem,
            this.removeSpellFromSpellbookToolStripMenuItem,
            this.createNewSpellbookToolStripMenuItem,
            this.duplicateSpellBookToolStripMenuItem,
            this.deleteSpellbookToolStripMenuItem});
            this.spellbookToolStripMenuItem.Name = "spellbookToolStripMenuItem";
            this.spellbookToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.spellbookToolStripMenuItem.Text = "Spellbook";
            // 
            // addSpellToSpellbookToolStripMenuItem
            // 
            this.addSpellToSpellbookToolStripMenuItem.Name = "addSpellToSpellbookToolStripMenuItem";
            this.addSpellToSpellbookToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.addSpellToSpellbookToolStripMenuItem.Text = "Add Spell to Spellbook";
            // 
            // removeSpellFromSpellbookToolStripMenuItem
            // 
            this.removeSpellFromSpellbookToolStripMenuItem.Name = "removeSpellFromSpellbookToolStripMenuItem";
            this.removeSpellFromSpellbookToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.removeSpellFromSpellbookToolStripMenuItem.Text = "Remove Spell from Spellbook";
            // 
            // createNewSpellbookToolStripMenuItem
            // 
            this.createNewSpellbookToolStripMenuItem.Name = "createNewSpellbookToolStripMenuItem";
            this.createNewSpellbookToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.createNewSpellbookToolStripMenuItem.Text = "Create New Spellbook";
            // 
            // duplicateSpellBookToolStripMenuItem
            // 
            this.duplicateSpellBookToolStripMenuItem.Name = "duplicateSpellBookToolStripMenuItem";
            this.duplicateSpellBookToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.duplicateSpellBookToolStripMenuItem.Text = "Duplicate Spellbook";
            this.duplicateSpellBookToolStripMenuItem.Click += new System.EventHandler(this.duplicateSpellBookToolStripMenuItem_Click);
            // 
            // deleteSpellbookToolStripMenuItem
            // 
            this.deleteSpellbookToolStripMenuItem.Name = "deleteSpellbookToolStripMenuItem";
            this.deleteSpellbookToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.deleteSpellbookToolStripMenuItem.Text = "Delete Spellbook";
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSelectedSpellToolStripMenuItem,
            this.createNewSpellToolStripMenuItem,
            this.duplicateSelectedSpellToolStripMenuItem,
            this.deleteSelectedSpellToolStripMenuItem,
            this.editNonSpellDataToolStripMenuItem});
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(50, 22);
            this.editorToolStripMenuItem.Text = "Editor";
            this.editorToolStripMenuItem.Click += new System.EventHandler(this.editorToolStripMenuItem_Click);
            // 
            // editSelectedSpellToolStripMenuItem
            // 
            this.editSelectedSpellToolStripMenuItem.Name = "editSelectedSpellToolStripMenuItem";
            this.editSelectedSpellToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.editSelectedSpellToolStripMenuItem.Text = "Edit Selected Spell";
            this.editSelectedSpellToolStripMenuItem.Click += new System.EventHandler(this.editSelectedSpellToolStripMenuItem_Click);
            // 
            // createNewSpellToolStripMenuItem
            // 
            this.createNewSpellToolStripMenuItem.Name = "createNewSpellToolStripMenuItem";
            this.createNewSpellToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.createNewSpellToolStripMenuItem.Text = "Create New Spell";
            this.createNewSpellToolStripMenuItem.Click += new System.EventHandler(this.createNewSpellToolStripMenuItem_Click);
            // 
            // duplicateSelectedSpellToolStripMenuItem
            // 
            this.duplicateSelectedSpellToolStripMenuItem.Name = "duplicateSelectedSpellToolStripMenuItem";
            this.duplicateSelectedSpellToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.duplicateSelectedSpellToolStripMenuItem.Text = "Duplicate Selected Spell";
            this.duplicateSelectedSpellToolStripMenuItem.Click += new System.EventHandler(this.duplicateSelectedSpellToolStripMenuItem_Click);
            // 
            // deleteSelectedSpellToolStripMenuItem
            // 
            this.deleteSelectedSpellToolStripMenuItem.Name = "deleteSelectedSpellToolStripMenuItem";
            this.deleteSelectedSpellToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.deleteSelectedSpellToolStripMenuItem.Text = "Delete Selected Spell";
            // 
            // editNonSpellDataToolStripMenuItem
            // 
            this.editNonSpellDataToolStripMenuItem.Name = "editNonSpellDataToolStripMenuItem";
            this.editNonSpellDataToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.editNonSpellDataToolStripMenuItem.Text = "Edit Non-Spell Data";
            this.editNonSpellDataToolStripMenuItem.Click += new System.EventHandler(this.editNonSpellDataToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutThisApplicationToolStripMenuItem,
            this.changeLogToolStripMenuItem,
            this.licensesToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // aboutThisApplicationToolStripMenuItem
            // 
            this.aboutThisApplicationToolStripMenuItem.Name = "aboutThisApplicationToolStripMenuItem";
            this.aboutThisApplicationToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.aboutThisApplicationToolStripMenuItem.Text = "About This Application";
            this.aboutThisApplicationToolStripMenuItem.Click += new System.EventHandler(this.aboutThisApplicationToolStripMenuItem_Click);
            // 
            // changeLogToolStripMenuItem
            // 
            this.changeLogToolStripMenuItem.Name = "changeLogToolStripMenuItem";
            this.changeLogToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.changeLogToolStripMenuItem.Text = "Change Log";
            this.changeLogToolStripMenuItem.Click += new System.EventHandler(this.changeLogToolStripMenuItem_Click);
            // 
            // licensesToolStripMenuItem
            // 
            this.licensesToolStripMenuItem.Name = "licensesToolStripMenuItem";
            this.licensesToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.licensesToolStripMenuItem.Text = "Licenses";
            this.licensesToolStripMenuItem.Click += new System.EventHandler(this.licensesToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 643);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.SearchPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpellBook_V_1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.DisplayPanel.ResumeLayout(false);
            this.DisplayPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

          }

          #endregion
          public bool MaximizeBox { get; set; }
          public bool MinimizeBox { get; set; }
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.TextBox SearchTextBox;
          private System.Windows.Forms.Panel SearchPanel;
          private System.Windows.Forms.Panel DisplayPanel;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.ListView listView1;
          private System.Windows.Forms.Panel panel1;
          private System.Windows.Forms.CheckBox checkBox10;
          private System.Windows.Forms.CheckBox checkBox9;
          private System.Windows.Forms.CheckBox checkBox8;
          private System.Windows.Forms.CheckBox checkBox7;
          private System.Windows.Forms.CheckBox checkBox6;
          private System.Windows.Forms.CheckBox checkBox5;
          private System.Windows.Forms.CheckBox checkBox4;
          private System.Windows.Forms.CheckBox checkBox3;
          private System.Windows.Forms.CheckBox checkBox2;
          private System.Windows.Forms.CheckBox checkBox1;
          private System.Windows.Forms.Label label3;
          private System.Windows.Forms.MenuStrip menuStrip1;
          private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem exportSpellbookToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem loadSpellbookToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem exportDataToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem resetAllDataToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem spellbookToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem addSpellToSpellbookToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem removeSpellFromSpellbookToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem createNewSpellbookToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem duplicateSpellBookToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem deleteSpellbookToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem aboutThisApplicationToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem changeLogToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem licensesToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem editSelectedSpellToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem createNewSpellToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem duplicateSelectedSpellToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem deleteSelectedSpellToolStripMenuItem;
          private System.Windows.Forms.ToolStripMenuItem editNonSpellDataToolStripMenuItem;
          private System.Windows.Forms.CheckBox checkBox18;
          private System.Windows.Forms.CheckBox checkBox17;
          private System.Windows.Forms.CheckBox checkBox16;
          private System.Windows.Forms.CheckBox checkBox15;
          private System.Windows.Forms.CheckBox checkBox14;
          private System.Windows.Forms.CheckBox checkBox13;
          private System.Windows.Forms.CheckBox checkBox12;
          private System.Windows.Forms.CheckBox checkBox11;
          private System.Windows.Forms.Label label4;
          private System.Windows.Forms.Button button1;
          private System.Windows.Forms.RichTextBox Spell_Display;
     }
}

