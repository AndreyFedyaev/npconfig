namespace NP_Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SaveAll = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.button_View = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.MainArea = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.metka = new System.Windows.Forms.Button();
            this.buttonNP1 = new System.Windows.Forms.Button();
            this.NPAdd = new System.Windows.Forms.PictureBox();
            this.NPDelete = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NPAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NPDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1272, 575);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.tabPage1.Controls.Add(this.SaveAll);
            this.tabPage1.Controls.Add(this.Open);
            this.tabPage1.Controls.Add(this.Clear);
            this.tabPage1.Controls.Add(this.button_View);
            this.tabPage1.Controls.Add(this.button_Save);
            this.tabPage1.Controls.Add(this.MainArea);
            this.tabPage1.Controls.Add(this.splitter2);
            this.tabPage1.Controls.Add(this.metka);
            this.tabPage1.Controls.Add(this.buttonNP1);
            this.tabPage1.Controls.Add(this.NPAdd);
            this.tabPage1.Controls.Add(this.NPDelete);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1264, 546);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Редактор Config.ini";
            // 
            // SaveAll
            // 
            this.SaveAll.BackColor = System.Drawing.SystemColors.MenuBar;
            this.SaveAll.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveAll.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveAll.ForeColor = System.Drawing.Color.Black;
            this.SaveAll.Location = new System.Drawing.Point(406, 7);
            this.SaveAll.Margin = new System.Windows.Forms.Padding(4);
            this.SaveAll.Name = "SaveAll";
            this.SaveAll.Size = new System.Drawing.Size(133, 31);
            this.SaveAll.TabIndex = 282;
            this.SaveAll.Text = "Сохранить всё";
            this.SaveAll.UseVisualStyleBackColor = false;
            this.SaveAll.Click += new System.EventHandler(this.SaveAll_Click);
            // 
            // Open
            // 
            this.Open.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Open.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Open.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Open.ForeColor = System.Drawing.Color.Black;
            this.Open.Location = new System.Drawing.Point(547, 7);
            this.Open.Margin = new System.Windows.Forms.Padding(4);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(133, 31);
            this.Open.TabIndex = 281;
            this.Open.Text = "Открыть";
            this.Open.UseVisualStyleBackColor = false;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Clear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Clear.ForeColor = System.Drawing.Color.Black;
            this.Clear.Location = new System.Drawing.Point(688, 7);
            this.Clear.Margin = new System.Windows.Forms.Padding(4);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(133, 31);
            this.Clear.TabIndex = 280;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // button_View
            // 
            this.button_View.BackColor = System.Drawing.SystemColors.MenuBar;
            this.button_View.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_View.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_View.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_View.ForeColor = System.Drawing.Color.Black;
            this.button_View.Location = new System.Drawing.Point(124, 7);
            this.button_View.Margin = new System.Windows.Forms.Padding(4);
            this.button_View.Name = "button_View";
            this.button_View.Size = new System.Drawing.Size(133, 31);
            this.button_View.TabIndex = 248;
            this.button_View.Text = "Просмотр";
            this.button_View.UseVisualStyleBackColor = false;
            this.button_View.Click += new System.EventHandler(this.button_View_Click);
            // 
            // button_Save
            // 
            this.button_Save.BackColor = System.Drawing.SystemColors.MenuBar;
            this.button_Save.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Save.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Save.ForeColor = System.Drawing.Color.Black;
            this.button_Save.Location = new System.Drawing.Point(265, 7);
            this.button_Save.Margin = new System.Windows.Forms.Padding(4);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(133, 31);
            this.button_Save.TabIndex = 247;
            this.button_Save.Text = "Сохранить";
            this.button_Save.UseVisualStyleBackColor = false;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // MainArea
            // 
            this.MainArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(110)))));
            this.MainArea.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainArea.Dock = System.Windows.Forms.DockStyle.Right;
            this.MainArea.Location = new System.Drawing.Point(124, 45);
            this.MainArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainArea.Name = "MainArea";
            this.MainArea.Size = new System.Drawing.Size(1136, 497);
            this.MainArea.TabIndex = 29;
            this.MainArea.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.splitter2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(4, 4);
            this.splitter2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1256, 41);
            this.splitter2.TabIndex = 28;
            this.splitter2.TabStop = false;
            // 
            // metka
            // 
            this.metka.BackColor = System.Drawing.Color.Brown;
            this.metka.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.metka.Location = new System.Drawing.Point(9, 47);
            this.metka.Margin = new System.Windows.Forms.Padding(0);
            this.metka.Name = "metka";
            this.metka.Size = new System.Drawing.Size(7, 37);
            this.metka.TabIndex = 27;
            this.metka.Text = "button3";
            this.metka.UseVisualStyleBackColor = false;
            // 
            // buttonNP1
            // 
            this.buttonNP1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.buttonNP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonNP1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonNP1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNP1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNP1.ForeColor = System.Drawing.Color.Black;
            this.buttonNP1.Location = new System.Drawing.Point(9, 47);
            this.buttonNP1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNP1.Name = "buttonNP1";
            this.buttonNP1.Size = new System.Drawing.Size(107, 37);
            this.buttonNP1.TabIndex = 19;
            this.buttonNP1.Text = "NP 1\r\n";
            this.buttonNP1.UseVisualStyleBackColor = false;
            this.buttonNP1.Click += new System.EventHandler(this.buttonNP1_Click);
            // 
            // NPAdd
            // 
            this.NPAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.NPAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.NPAdd.Image = ((System.Drawing.Image)(resources.GetObject("NPAdd.Image")));
            this.NPAdd.Location = new System.Drawing.Point(67, 87);
            this.NPAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NPAdd.Name = "NPAdd";
            this.NPAdd.Size = new System.Drawing.Size(49, 38);
            this.NPAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NPAdd.TabIndex = 23;
            this.NPAdd.TabStop = false;
            this.NPAdd.Click += new System.EventHandler(this.NPAdd_Click);
            // 
            // NPDelete
            // 
            this.NPDelete.Image = ((System.Drawing.Image)(resources.GetObject("NPDelete.Image")));
            this.NPDelete.Location = new System.Drawing.Point(9, 87);
            this.NPDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NPDelete.Name = "NPDelete";
            this.NPDelete.Size = new System.Drawing.Size(49, 38);
            this.NPDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NPDelete.TabIndex = 24;
            this.NPDelete.TabStop = false;
            this.NPDelete.Click += new System.EventHandler(this.NPDelete_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1264, 546);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Сменить направление счета";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 575);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "NP Software";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NPAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NPDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonNP1;
        private System.Windows.Forms.PictureBox NPAdd;
        private System.Windows.Forms.PictureBox NPDelete;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button metka;
        private System.Windows.Forms.Splitter MainArea;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Button button_View;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button SaveAll;
    }
}

