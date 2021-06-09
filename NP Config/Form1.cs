using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace NP_Config
{

    
    public partial class Form1 : Form
    {
        bool error = false;
        public int activeNP;
        public UserControl1 pages1 = new UserControl1(); 
        public UserControl1 pages2 = new UserControl1();
        private UserControl1 pages3 = new UserControl1();
        private UserControl1 pages4 = new UserControl1();
        private UserControl1 pages5 = new UserControl1();
        private UserControl1 pages6 = new UserControl1();
        private UserControl1 pages7 = new UserControl1();
        private UserControl1 pages8 = new UserControl1();
        private UserControl1 pages9 = new UserControl1();
        private UserControl1 pages10 = new UserControl1();

        public UserControl1[] pages;

        Button[] ABC = new Button[9];

        int quantityNP;
        

        public Form1()
        {
            InitializeComponent();
            UpdateInterface();
            ButtonNP();
        }
        
        public void UpdateInterface()
        {
            pages = new UserControl1[] {pages1, pages2, pages3, pages4, pages5, pages6, pages7, pages8, pages9, pages10};
            MainArea.Controls.Add(pages[0]);
            NPAdd.Top = buttonNP1.Location.Y + 35;
            NPDelete.Visible = false;
            quantityNP = 1;
            activeNP = 1;
            metka.Top = buttonNP1.Top;
        }

        public void ButtonNP()
        {
            for (int i = 0; i < 9; i++)
            {
                ABC[i] = new Button();
                ABC[i].Left = buttonNP1.Location.X;
                ABC[i].Top = buttonNP1.Top + (i + 1) * 33;
                ABC[i].Anchor = buttonNP1.Anchor;
                ABC[i].BackColor = System.Drawing.SystemColors.MenuBar;
                ABC[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                ABC[i].FlatAppearance.BorderColor = System.Drawing.Color.Black;
                ABC[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                ABC[i].Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ABC[i].ForeColor = System.Drawing.Color.Black;
                ABC[i].Margin = new System.Windows.Forms.Padding(0);
                ABC[i].Name = "button" + (i + 2);
                ABC[i].Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
                ABC[i].Size = buttonNP1.Size;
                ABC[i].TabIndex = 28;
                ABC[i].Text = "NP " + (i + 2);
                ABC[i].UseVisualStyleBackColor = false;
            }
            ABC[0].Click += new EventHandler(NP2_Click);
            ABC[1].Click += new EventHandler(NP3_Click);
            ABC[2].Click += new EventHandler(NP4_Click);
            ABC[3].Click += new EventHandler(NP5_Click);
            ABC[4].Click += new EventHandler(NP6_Click);
            ABC[5].Click += new EventHandler(NP7_Click);
            ABC[6].Click += new EventHandler(NP8_Click);
            ABC[7].Click += new EventHandler(NP9_Click);
            ABC[8].Click += new EventHandler(NP10_Click);
        }

        public void ButtonNPChange(int var)
        {
            if (var == 1)  //условие выполняется если добавляем NP
            {
                tabPage1.Controls.Add(ABC[quantityNP-1]);
                quantityNP++;
            }
            if (var == 0) //условие выполняется если удаляем NP
            {
                tabPage1.Controls.Remove(ABC[quantityNP - 2]);
                quantityNP--;
            }
            // Сдвигаем кнопки NPAdd/NPDelete 
            if (quantityNP > 1)
            {
                NPAdd.Top = ABC[quantityNP - 2].Location.Y + 35;
                NPDelete.Top = ABC[quantityNP - 2].Location.Y + 35;
            }
            else NPAdd.Top = buttonNP1.Location.Y + 35;

            // Настраиваем видимость NPAdd/NPDelete
            if (quantityNP > 1) NPDelete.Visible = true; else NPDelete.Visible = false;
            if (quantityNP < 10) NPAdd.Visible = true; else NPAdd.Visible = false;
        }
        
        private void buttonNP1_Click(object sender, EventArgs e)
        {
            OpenUserControl(1);
        }
        private void NP2_Click(object sender, EventArgs e)
        {
            OpenUserControl(2);
        }
        private void NP3_Click(object sender, EventArgs e)
        {
            OpenUserControl(3);
        }
        private void NP4_Click(object sender, EventArgs e)
        {
            OpenUserControl(4);
        }
        private void NP5_Click(object sender, EventArgs e)
        {
            OpenUserControl(5);
        }
        private void NP6_Click(object sender, EventArgs e)
        {
            OpenUserControl(6);
        }
        private void NP7_Click(object sender, EventArgs e)
        {
            OpenUserControl(7);
        }
        private void NP8_Click(object sender, EventArgs e)
        {
            OpenUserControl(8);
        }
        private void NP9_Click(object sender, EventArgs e)
        {
            OpenUserControl(9);
        }
        private void NP10_Click(object sender, EventArgs e)
        {
            OpenUserControl(10);
        }
        
        public void OpenUserControl(int var)  //var - активная кнопка NP
        {
            activeNP = var;
            MainArea.Controls.Clear();
            MainArea.Controls.Add(pages[var-1]);
            MetkaLocation(var);
        }

        void MetkaLocation(int var) //var - активная кнопка NP
        {
            if (var == 1)
                metka.Location = new Point(7, buttonNP1.Location.Y);
            else
                metka.Location = new Point(7, ABC[var - 2].Location.Y);
        }

        public void NPAdd_Click(object sender, EventArgs e)
        {
                ButtonNPChange(1);
        }

        private void NPDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Удалить конфигурацию NP" + (quantityNP)+ "?\r\n\r\nВосстановить ее будет невозможно!", 
                "Подтвердите действие", 
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes) // Проверяем нажатие кнопки ДА в окне предупреждения
            {
                pages[quantityNP-1] = new UserControl1();
                if (quantityNP > 1)
                {
                    ButtonNPChange(0);
                }
                if (quantityNP == (activeNP - 1))      //Условие выполняется если в момент удаления данное окно было активно
                {
                    activeNP--;               //Уменьшаем значение переменной 
                    OpenUserControl(activeNP);    //Обновляем окно
                }
            }
        }
        

        private void button_Save_Click(object sender, EventArgs e)
        {
            error = false;

            for (int i = 0; i < quantityNP; i++)
            {
                pages[i].AdressDat();
            }
            
            List_alien_NP_clear();
            search_indx();

            if (error == false)
            {
                pages[activeNP - 1].FormingResult();
                pages[activeNP - 1].FileConfig();
            }
        }

        private void button_View_Click(object sender, EventArgs e)
        {
            error = false;

            if (error = pages[activeNP - 1].ErrorChecking()) return;  // проверка заполнения всех адресов датчиков

            pages[activeNP - 1].AdressDat();

            List_alien_NP_clear();
            search_indx();

            if (error == false)
            {
                pages[activeNP - 1].FormingResult();
                pages[activeNP - 1].ViewingConfig();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Помочь разработчику программы можно денежным переводом по номеру телефона: 8-912-247-13-80");
        }

        public void search_indx ()
        {
            for (int k = 0; k < Convert.ToInt32(pages[activeNP-1].kUCH); k++)
            {
                for (int i = 1; i < 11; i++)
                {
                    for (int m = 1; m < 21; m++)
                    {
                        if(pages[activeNP - 1].UCH[k, i] == Convert.ToString(pages[activeNP - 1].IndexDat[m]))
                        {
                            pages[activeNP - 1].UCH_Indx_Write(k, i, m);
                            break;
                        }
                        else 
                        {
                            if ((pages[activeNP - 1].UCH[k, i] != "") & m == 20)
                            {
                                search_indx_alien_NP(k, i, Convert.ToInt32(pages[activeNP - 1].UCH[k, i]));
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void search_indx_alien_NP (int var1, int var2, int var3)
        {
            int status = 0;
            string NP = "";
            string Indx = "";
            string result = "";
            
            for (int i = 0; i < quantityNP; i++)
            {
                for (int k = 1; k <21; k++)
                {
                    if(pages[i].IndexDat[k] == var3)               
                    {
                      NP = Convert.ToString(pages[activeNP - 1].search_list_alien_NP(pages[i].textBox16.Text, pages[i].textBox20.Text));
                      NP = Convert.ToString(Convert.ToInt32(NP),2);
                      NP = Convert.ToString(Convert.ToInt32(NP).ToString("D3"));
                      Indx = Convert.ToString(k, 2);
                      Indx = Convert.ToString(Convert.ToInt32(Indx).ToString("D5"));
                      
                      result = Convert.ToInt32((NP + Indx),2).ToString("X2");
                      pages[activeNP - 1].Vn_dat(var1, var2, result);
                      status = 1;
                      break;
                    }
                }
                if (status == 1) break;
            }
            if (status == 0)
            {
                string adress = pages[activeNP - 1].UCH[var1, var2];
                string location = pages[activeNP - 1].UCH[var1, 0];
                MessageBox.Show("Участок " + location + "\r\n" + "Датчик с адресом " + adress + " не найден!", "Ошибка!");
                error = true;
            }
        }

        public void List_alien_NP_clear ()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 2; k++)
                {
                    pages[activeNP - 1].ListExternalNP[i, k] = null;
                }
            }
        }

        private void Clear_Click(object sender, EventArgs e)    //Очистка формы
        {

            DialogResult result = MessageBox.Show(
               "Очистить форму NP" + (activeNP) + "?\r\n\r\nВосстановить ее будет невозможно!",
               "Подтвердите действие",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes) // Проверяем нажатие кнопки ДА в окне предупреждения
            {
                pages[activeNP - 1] = new UserControl1();
                OpenUserControl(activeNP);
            }
        }
    }
}
