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
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchPanel.SuspendLayout();
            this.DisplayPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
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
            this.SearchPanel.Location = new System.Drawing.Point(22, 18);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(354, 408);
            this.SearchPanel.TabIndex = 3;
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.Controls.Add(this.label2);
            this.DisplayPanel.Location = new System.Drawing.Point(423, 19);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(355, 407);
            this.DisplayPanel.TabIndex = 4;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(15, 78);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(306, 285);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Spell Description";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.SearchPanel);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.Panel DisplayPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
    }
}

