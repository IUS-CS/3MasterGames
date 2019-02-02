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
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(156, 59);
            this.SearchTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(406, 29);
            this.SearchTextBox.TabIndex = 1;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // SearchPanel
            // 
            this.SearchPanel.Controls.Add(this.listView1);
            this.SearchPanel.Controls.Add(this.SearchTextBox);
            this.SearchPanel.Controls.Add(this.label1);
            this.SearchPanel.Location = new System.Drawing.Point(501, 83);
            this.SearchPanel.Margin = new System.Windows.Forms.Padding(6);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(649, 705);
            this.SearchPanel.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(28, 140);
            this.listView1.Margin = new System.Windows.Forms.Padding(6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(534, 543);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.Controls.Add(this.label2);
            this.DisplayPanel.Location = new System.Drawing.Point(1188, 83);
            this.DisplayPanel.Margin = new System.Windows.Forms.Padding(6);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(651, 703);
            this.DisplayPanel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Spell Description";
            // 
            // panel1
            // 
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
            this.panel1.Location = new System.Drawing.Point(22, 83);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 703);
            this.panel1.TabIndex = 2;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(61, 506);
            this.checkBox10.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(101, 29);
            this.checkBox10.TabIndex = 12;
            this.checkBox10.Text = "Level 9";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(61, 463);
            this.checkBox9.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(101, 29);
            this.checkBox9.TabIndex = 11;
            this.checkBox9.Text = "Level 8";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(61, 421);
            this.checkBox8.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(101, 29);
            this.checkBox8.TabIndex = 10;
            this.checkBox8.Text = "Level 7";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(61, 378);
            this.checkBox7.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(101, 29);
            this.checkBox7.TabIndex = 9;
            this.checkBox7.Text = "Level 6";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(61, 336);
            this.checkBox6.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(101, 29);
            this.checkBox6.TabIndex = 8;
            this.checkBox6.Text = "Level 5";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(61, 294);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(101, 29);
            this.checkBox5.TabIndex = 7;
            this.checkBox5.Text = "Level 4";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(61, 251);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(101, 29);
            this.checkBox4.TabIndex = 6;
            this.checkBox4.Text = "Level 3";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(61, 209);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(101, 29);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "Level 2";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(61, 166);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(101, 29);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Level 1";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(61, 124);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 29);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Level 0";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 39);
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
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1861, 38);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 34);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportSpellbookToolStripMenuItem
            // 
            this.exportSpellbookToolStripMenuItem.Name = "exportSpellbookToolStripMenuItem";
            this.exportSpellbookToolStripMenuItem.Size = new System.Drawing.Size(259, 34);
            this.exportSpellbookToolStripMenuItem.Text = "Export Spellbook";
            // 
            // loadSpellbookToolStripMenuItem
            // 
            this.loadSpellbookToolStripMenuItem.Name = "loadSpellbookToolStripMenuItem";
            this.loadSpellbookToolStripMenuItem.Size = new System.Drawing.Size(259, 34);
            this.loadSpellbookToolStripMenuItem.Text = "Load Spellbook";
            // 
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(259, 34);
            this.exportDataToolStripMenuItem.Text = "Export Data";
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(259, 34);
            this.importDataToolStripMenuItem.Text = "Import Data";
            // 
            // resetAllDataToolStripMenuItem
            // 
            this.resetAllDataToolStripMenuItem.Name = "resetAllDataToolStripMenuItem";
            this.resetAllDataToolStripMenuItem.Size = new System.Drawing.Size(259, 34);
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
            this.spellbookToolStripMenuItem.Size = new System.Drawing.Size(115, 34);
            this.spellbookToolStripMenuItem.Text = "Spellbook";
            // 
            // addSpellToSpellbookToolStripMenuItem
            // 
            this.addSpellToSpellbookToolStripMenuItem.Name = "addSpellToSpellbookToolStripMenuItem";
            this.addSpellToSpellbookToolStripMenuItem.Size = new System.Drawing.Size(374, 34);
            this.addSpellToSpellbookToolStripMenuItem.Text = "Add Spell to Spellbook";
            // 
            // removeSpellFromSpellbookToolStripMenuItem
            // 
            this.removeSpellFromSpellbookToolStripMenuItem.Name = "removeSpellFromSpellbookToolStripMenuItem";
            this.removeSpellFromSpellbookToolStripMenuItem.Size = new System.Drawing.Size(374, 34);
            this.removeSpellFromSpellbookToolStripMenuItem.Text = "Remove Spell from Spellbook";
            // 
            // createNewSpellbookToolStripMenuItem
            // 
            this.createNewSpellbookToolStripMenuItem.Name = "createNewSpellbookToolStripMenuItem";
            this.createNewSpellbookToolStripMenuItem.Size = new System.Drawing.Size(374, 34);
            this.createNewSpellbookToolStripMenuItem.Text = "Create New Spellbook";
            // 
            // duplicateSpellBookToolStripMenuItem
            // 
            this.duplicateSpellBookToolStripMenuItem.Name = "duplicateSpellBookToolStripMenuItem";
            this.duplicateSpellBookToolStripMenuItem.Size = new System.Drawing.Size(374, 34);
            this.duplicateSpellBookToolStripMenuItem.Text = "Duplicate Spellbook";
            this.duplicateSpellBookToolStripMenuItem.Click += new System.EventHandler(this.duplicateSpellBookToolStripMenuItem_Click);
            // 
            // deleteSpellbookToolStripMenuItem
            // 
            this.deleteSpellbookToolStripMenuItem.Name = "deleteSpellbookToolStripMenuItem";
            this.deleteSpellbookToolStripMenuItem.Size = new System.Drawing.Size(374, 34);
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
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(79, 34);
            this.editorToolStripMenuItem.Text = "Editor";
            // 
            // editSelectedSpellToolStripMenuItem
            // 
            this.editSelectedSpellToolStripMenuItem.Name = "editSelectedSpellToolStripMenuItem";
            this.editSelectedSpellToolStripMenuItem.Size = new System.Drawing.Size(326, 34);
            this.editSelectedSpellToolStripMenuItem.Text = "Edit Selected Spell";
            // 
            // createNewSpellToolStripMenuItem
            // 
            this.createNewSpellToolStripMenuItem.Name = "createNewSpellToolStripMenuItem";
            this.createNewSpellToolStripMenuItem.Size = new System.Drawing.Size(326, 34);
            this.createNewSpellToolStripMenuItem.Text = "Create New Spell";
            // 
            // duplicateSelectedSpellToolStripMenuItem
            // 
            this.duplicateSelectedSpellToolStripMenuItem.Name = "duplicateSelectedSpellToolStripMenuItem";
            this.duplicateSelectedSpellToolStripMenuItem.Size = new System.Drawing.Size(326, 34);
            this.duplicateSelectedSpellToolStripMenuItem.Text = "Duplicate Selected Spell";
            // 
            // deleteSelectedSpellToolStripMenuItem
            // 
            this.deleteSelectedSpellToolStripMenuItem.Name = "deleteSelectedSpellToolStripMenuItem";
            this.deleteSelectedSpellToolStripMenuItem.Size = new System.Drawing.Size(326, 34);
            this.deleteSelectedSpellToolStripMenuItem.Text = "Delete Selected Spell";
            // 
            // editNonSpellDataToolStripMenuItem
            // 
            this.editNonSpellDataToolStripMenuItem.Name = "editNonSpellDataToolStripMenuItem";
            this.editNonSpellDataToolStripMenuItem.Size = new System.Drawing.Size(326, 34);
            this.editNonSpellDataToolStripMenuItem.Text = "Edit Non-Spell Data";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutThisApplicationToolStripMenuItem,
            this.changeLogToolStripMenuItem,
            this.licensesToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(82, 34);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // aboutThisApplicationToolStripMenuItem
            // 
            this.aboutThisApplicationToolStripMenuItem.Name = "aboutThisApplicationToolStripMenuItem";
            this.aboutThisApplicationToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.aboutThisApplicationToolStripMenuItem.Text = "About This Application";
            this.aboutThisApplicationToolStripMenuItem.Click += new System.EventHandler(this.aboutThisApplicationToolStripMenuItem_Click);
            // 
            // changeLogToolStripMenuItem
            // 
            this.changeLogToolStripMenuItem.Name = "changeLogToolStripMenuItem";
            this.changeLogToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.changeLogToolStripMenuItem.Text = "Change Log";
            // 
            // licensesToolStripMenuItem
            // 
            this.licensesToolStripMenuItem.Name = "licensesToolStripMenuItem";
            this.licensesToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.licensesToolStripMenuItem.Text = "Licenses";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1861, 831);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.SearchPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
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
    }
}

