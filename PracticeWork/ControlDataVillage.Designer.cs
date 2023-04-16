namespace PracticeWork
{
    partial class ControlDataVillage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDataVillage));
            this.label5 = new System.Windows.Forms.Label();
            this.idAreaTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.idCountryTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.idVillageTextBox = new System.Windows.Forms.TextBox();
            this.idRegionTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.villageTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Ід району";
            // 
            // idAreaTextBox
            // 
            this.idAreaTextBox.Location = new System.Drawing.Point(88, 103);
            this.idAreaTextBox.Name = "idAreaTextBox";
            this.idAreaTextBox.Size = new System.Drawing.Size(100, 20);
            this.idAreaTextBox.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Ід області";
            // 
            // idCountryTextBox
            // 
            this.idCountryTextBox.Location = new System.Drawing.Point(88, 51);
            this.idCountryTextBox.Name = "idCountryTextBox";
            this.idCountryTextBox.Size = new System.Drawing.Size(100, 20);
            this.idCountryTextBox.TabIndex = 34;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(92, 159);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 28;
            this.addButton.Text = "Додати";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(92, 159);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 33;
            this.editButton.Text = "Редагувати";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "ід нас. пункта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Ід країни";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "label1";
            // 
            // idVillageTextBox
            // 
            this.idVillageTextBox.Location = new System.Drawing.Point(88, 25);
            this.idVillageTextBox.Name = "idVillageTextBox";
            this.idVillageTextBox.Size = new System.Drawing.Size(100, 20);
            this.idVillageTextBox.TabIndex = 29;
            // 
            // idRegionTextBox
            // 
            this.idRegionTextBox.Location = new System.Drawing.Point(88, 77);
            this.idRegionTextBox.Name = "idRegionTextBox";
            this.idRegionTextBox.Size = new System.Drawing.Size(100, 20);
            this.idRegionTextBox.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Нас. пункт";
            // 
            // villageTextBox
            // 
            this.villageTextBox.Location = new System.Drawing.Point(88, 129);
            this.villageTextBox.Name = "villageTextBox";
            this.villageTextBox.Size = new System.Drawing.Size(100, 20);
            this.villageTextBox.TabIndex = 38;
            // 
            // ControlDataVillage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 194);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.villageTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.idAreaTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.idCountryTextBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idVillageTextBox);
            this.Controls.Add(this.idRegionTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlDataVillage";
            this.ShowInTaskbar = false;
            this.Text = "ControlDataVillage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox idAreaTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox idCountryTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idVillageTextBox;
        private System.Windows.Forms.TextBox idRegionTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox villageTextBox;
    }
}