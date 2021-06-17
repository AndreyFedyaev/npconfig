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

        Form2 Dialog = new Form2();

        //Form2 Dialog = new Form2();

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
            AddDeleteView();
        }

        void AddDeleteView ()
        {
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
                if (error = pages[i].ErrorChecking()) return;  // проверка заполнения всех адресов датчиков
            }

            for (int i = 0; i < quantityNP; i++)    //для поиска датчиков во внешних NP
            {
                pages[i].AdressDat();
            }
            
            List_alien_NP_clear();
            search_indx();

            if (error == false)
            {
                pages[activeNP - 1].FormingResult();
                pages[activeNP - 1].SaveConfig();
            }
        }

        private void button_View_Click(object sender, EventArgs e)
        {
            error = false;

            for (int i = 0; i < quantityNP; i++)
            {
                if (error = pages[i].ErrorChecking()) return;  // проверка заполнения всех адресов датчиков
            }

            for (int i = 0; i < quantityNP; i++)    //для поиска датчиков во внешних NP
            {
                pages[i].AdressDat();
            }

            List_alien_NP_clear();
            search_indx();

            if (error == false)
            {
                pages[activeNP - 1].FormingResult();
                pages[activeNP - 1].ViewingConfig();
            }
        }

        

        public void search_indx()
        {
            int var1;   // промежуточная переменная
            int NP;
            
            bool repeat;  // true - адрес не повторяется, false - повторяется
            for (int k = 0; k < Convert.ToInt32(pages[activeNP - 1].kUCH); k++)       // k - участки текущего NP
            {
                if (error == false)
                for (int i = 1; i < 11; i++)            // i - адреса датчиков участка
                {
                    repeat = true;  
                    // проверка повторяемости будет здесь
                    var1 = (pages[activeNP - 1].UCH[k, i] != "") ? (Convert.ToInt32(pages[activeNP - 1].UCH[k, i])) : 0;
                    if (var1 != 0) repeat = RepeatAdressDat(var1);

                    if (repeat) // если адрес датчика не повторяется в других NP ищем индекс
                    {
                        for (int m = 1; m < 21; m++)        // m - индексы датчиков текущего NP
                        {
                            //if (pages[activeNP - 1].UCH[k, i] == Convert.ToString(pages[activeNP - 1].IndexDat[m]))  //поиск индекса в текущем NP
                            //{
                            //    pages[activeNP - 1].UCH_Indx_Write(k, i, m);
                            //    break;
                            //}
                            if (search_indx_activ_NP(i, k, m)) break;
                            

                            else // поиск индекса в чужих NP
                            {
                                if ((pages[activeNP - 1].UCH[k, i] != "") & m == 20)
                                {
                                    search_indx_alien_NP(k, i, Convert.ToInt32(pages[activeNP - 1].UCH[k, i]));
                                    break;
                                }
                            }
                        }
                    }
                    else    // иначе спрашиваем к какому NP принадлежит необходимый датчик
                    {
                       NP = DialogRepeatNP(var1, pages[activeNP - 1].UCH[k, 0]);
                        if (Dialog.NPvar != 0)
                        {
                            if (Dialog.NPvar == 1)
                            {
                                for (int m = 1; m < 21; m++)        // m - индексы датчиков текущего NP
                                {
                                    if (search_indx_activ_NP(i, k, m)) break;
                                    if (m == 20)
                                    {
                                        MessageBox.Show("Участок " + pages[activeNP - 1].UCH[k, 0] + "\r\n" + "Датчик с адресом " + var1 + " не найден!", "Ошибка!");
                                        error = true;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                search_indx_alien_NP(k, i, Convert.ToInt32(pages[activeNP - 1].UCH[k, i]), NP);
                            }
                        }
                        else
                        {
                            error = true;
                            break;
                        }
                        Dialog.NPvar = 0;
                        
                    }
                }
            }
        }
        public bool search_indx_activ_NP (int i, int k, int m)
        {
            if (pages[activeNP - 1].UCH[k, i] == Convert.ToString(pages[activeNP - 1].IndexDat[m]))  //поиск индекса в текущем NP
            {
                pages[activeNP - 1].UCH_Indx_Write(k, i, m);
                return true;
            }
            else return false;
        }
        public bool RepeatAdressDat (int var)  // Проверка повторяемости адресов датчиков в разных NP
        {
            int count = 0;
            for (int i = 0; i < quantityNP; i++)
            {
                for (int k1 = 0; k1 < pages[i].AddressDat1.Length; k1++)
                {
                    if (pages[i].AddressDat1[k1] == var)
                    { count++; }
                }
                for (int k2 = 0; k2 < pages[i].AddressDat2.Length; k2++)
                {
                    if (pages[i].AddressDat2[k2] == var)
                    { count++; }
                }
            }
            if (count <= 1) return true;
            else return false;
        }
        public int DialogRepeatNP (int AdressDat, string UCH)
        {
            Dialog.Adress_and_UCH(AdressDat, UCH, quantityNP);
            Dialog.ShowDialog();
            return Dialog.NPvar;
            //MessageBox.Show(Convert.ToString(Dialog.NPvar));
        }

        public void search_indx_alien_NP (int var1, int var2, int var3)     //определение индекса датчика в чужих NP
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

        public void search_indx_alien_NP(int var1, int var2, int var3, int alienNP)
        {
            int status = 0;
            string NP = "";
            string Indx = "";
            string result = "";
            
                for (int k = 1; k < 21; k++)
                {
                    if (pages[alienNP-1].IndexDat[k] == var3)
                    {
                        NP = Convert.ToString(pages[activeNP - 1].search_list_alien_NP(pages[alienNP - 1].textBox16.Text, pages[alienNP - 1].textBox20.Text));
                        NP = Convert.ToString(Convert.ToInt32(NP), 2);
                        NP = Convert.ToString(Convert.ToInt32(NP).ToString("D3"));
                        Indx = Convert.ToString(k, 2);
                        Indx = Convert.ToString(Convert.ToInt32(Indx).ToString("D5"));

                        result = Convert.ToInt32((NP + Indx), 2).ToString("X2");
                        pages[activeNP - 1].Vn_dat(var1, var2, result);
                        status = 1;
                        break;
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

        //Переменные для функции "Открыть"
        string[] str1;
        string[,] AlienNP = new string [10,8]; //список внешних NP (адресов) всех открываемых конфигурационных файлов
        string[,] Index_AdressDat = new string[10,28];
        int[,] hhh = new int[8,2];
        string[] IP = new string[10];
        string IP_NP;
        //

        private void Open_Click(object sender, EventArgs e)
        {
            if (WarningCleanProgramm()) // подтверждение действия
            {
                ClearProgram(); //очистка полей

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
                openFileDialog1.Filter = "Config Files|*.ini";
                openFileDialog1.Multiselect = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string[] result = openFileDialog1.FileNames;

                    //создаем нужное количество NP
                    for (int i = 1; i < result.Length; i++)
                    {
                        ButtonNPChange(1);
                    }
                    //перебираем все открытые файлы по порядку и заполняем поля IP и адресов датчиков
                    for (int i = 0; i < result.Length; i++)
                    {
                        StreamReader sr = new StreamReader(result[i], System.Text.Encoding.Default);
                        char[] delimiterChars = { '.', '\t' };
                        string[] bb = { "'" };

                        string[] tmp = sr.ReadLine().Split('\'');
                        str1 = tmp[0].Split(delimiterChars);
                        pages[i].textBox1.Text = str1[0];
                        pages[i].textBox2.Text = str1[1];
                        pages[i].textBox3.Text = str1[2];
                        pages[i].textBox4.Text = str1[3];
                        pages[i].textBox5.Text = str1[4];
                        pages[i].textBox6.Text = str1[5];

                        tmp = sr.ReadLine().Split('\'');
                        str1 = tmp[0].Split(delimiterChars);
                        pages[i].textBox7.Text = str1[0];
                        pages[i].textBox8.Text = str1[1];
                        pages[i].textBox9.Text = str1[2];
                        pages[i].textBox10.Text = str1[3];
                        pages[i].textBox11.Text = str1[4];
                        pages[i].textBox12.Text = str1[5];

                        tmp = sr.ReadLine().Split(':');
                        str1 = tmp[0].Split(delimiterChars);
                        pages[i].textBox13.Text = str1[0];
                        pages[i].textBox14.Text = str1[1];
                        pages[i].textBox15.Text = str1[2];
                        pages[i].textBox16.Text = str1[3];

                        tmp = sr.ReadLine().Split(':');
                        str1 = tmp[0].Split(delimiterChars);
                        pages[i].textBox17.Text = str1[0];
                        pages[i].textBox18.Text = str1[1];
                        pages[i].textBox19.Text = str1[2];
                        pages[i].textBox20.Text = str1[3];

                        tmp = sr.ReadLine().Split(':');
                        str1 = tmp[0].Split(delimiterChars);
                        pages[i].textBox21.Text = str1[0];
                        pages[i].textBox22.Text = str1[1];
                        pages[i].textBox23.Text = str1[2];
                        pages[i].textBox24.Text = str1[3];

                        tmp = sr.ReadLine().Split(':');
                        str1 = tmp[0].Split(delimiterChars);
                        pages[i].textBox25.Text = str1[0];
                        pages[i].textBox26.Text = str1[1];
                        pages[i].textBox27.Text = str1[2];
                        pages[i].textBox28.Text = str1[3];

                        sr.ReadLine();

                        tmp = sr.ReadLine().Split(':', '\'');
                        AlienNP[i, 0] = tmp[0];

                        tmp = sr.ReadLine().Split(':', '\'');
                        AlienNP[i, 1] = tmp[0];

                        tmp = sr.ReadLine().Split(':', '\'');
                        AlienNP[i, 2] = tmp[0];

                        tmp = sr.ReadLine().Split(':', '\'');
                        AlienNP[i, 3] = tmp[0];

                        tmp = sr.ReadLine().Split(':', '\'');
                        AlienNP[i, 4] = tmp[0];

                        tmp = sr.ReadLine().Split(':', '\'');
                        AlienNP[i, 5] = tmp[0];

                        tmp = sr.ReadLine().Split(':', '\'');
                        AlienNP[i, 6] = tmp[0];

                        tmp = sr.ReadLine().Split(':', '\'');
                        AlienNP[i, 7] = tmp[0];

                        //Конфигурация датчиков нпорта
                        tmp = sr.ReadLine().Split(' ', '\'');
                        pages[i].numericUpDown1.Value = (Convert.ToInt32(tmp[0]));
                        for (int k = 0; k < Convert.ToInt32(tmp[0]); k++)
                        {
                            pages[i].tboxAddressDat1[k].Text = (Int32.Parse(tmp[k + 4], System.Globalization.NumberStyles.HexNumber)).ToString();
                            Index_AdressDat[i, k] = (Int32.Parse(tmp[k + 4], System.Globalization.NumberStyles.HexNumber)).ToString();
                        }

                        pages[i].numericUpDown2.Value = (Convert.ToInt32(tmp[1]));
                        for (int n = 0; n < Convert.ToInt32(tmp[1]); n++)
                        {
                            pages[i].tboxAddressDat2[n].Text = (Int32.Parse(tmp[n + 4 + Convert.ToInt32(tmp[0])], System.Globalization.NumberStyles.HexNumber)).ToString();
                            Index_AdressDat[i, Int32.Parse(tmp[0]) + n] = (Int32.Parse(tmp[n + 4 + Convert.ToInt32(tmp[0])], System.Globalization.NumberStyles.HexNumber)).ToString();
                        }
                    }

                    //Код определения IP адресов в файлах по порядку
                    for (int i = 0; i < result.Length; i++)
                    {
                        StreamReader sr = new StreamReader(result[i], System.Text.Encoding.Default);
                        char[] delimiterChars = { '.', '\t' };
                        string[] bb = { "'" };
                        sr.ReadLine();
                        sr.ReadLine();
                        string[] tmp = sr.ReadLine().Split('.', ':');
                        IP[i] = tmp[3];
                    }

                    // Код определения участков
                    for (int i = 0; i < result.Length; i++)
                    {
                        StreamReader sr = new StreamReader(result[i], System.Text.Encoding.Default);
                        char[] delimiterChars = { '.', '\t' };
                        string[] bb = { "'" };
                        for (int k = 0; k < 16; k++)    //пропускаем ненужное (16 строк)
                        {
                            sr.ReadLine();
                        }

                        
                        //Конфигурация датчиков, не подключенных к нпорту
                        string[] tmp = sr.ReadLine().Split(' ', '\'');

                        //определяем индекс внешнего NP и индекс датчика в этом NP
                        for (int n = 0; n < 8; n++)
                        {
                            hhh[n,0] = Int32.Parse(tmp[n], System.Globalization.NumberStyles.HexNumber) >> 5;   //индекс внешнего NP
                            hhh[n,1] = Int32.Parse(tmp[n], System.Globalization.NumberStyles.HexNumber) & 31;   //индекс датчика во внешнем NP
                        }
                        //Определяем адрес датчика во внешнем NP
                        for (int m = 0; m < 8; m++)
                        {
                            IP_NP = AlienNP[i, hhh[m, 0]];
                            for (int k = 0; k < quantityNP; k++)
                            {
                               if (pages[k].textBox16.Text == IP_NP)
                                {
                                    if (hhh[m, 1] != 0)
                                    Index_AdressDat[i, m + 20] = Index_AdressDat[k, hhh[m, 1] - 1];
                                }
                            }
                        }
                    }
                }
            }
        }
        bool WarningCleanProgramm ()    //Предупреждение очистки формы при открытии файла
        {
            bool result = false;
            DialogResult Dialogresult = MessageBox.Show(
                "Перед открытием все данные будут удалены! \r\n\r\nПродолжить?",
                "Подтвердите действие",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (Dialogresult == DialogResult.Yes) result = true;
            return result;
        }
        void ClearProgram ()    // очистка программы до исходного состояния
        {
            for (int i = 0; i < quantityNP; i++)
            {
                pages[i] = new UserControl1();
                tabPage1.Controls.Remove(ABC[i]);
            }
            OpenUserControl(1);
            quantityNP = 1; 
            AddDeleteView();
        }

        private void SaveAll_Click(object sender, EventArgs e)
        {
            error = false;

            for (int i = 0; i < quantityNP; i++)
            {
                if (error = pages[i].ErrorChecking()) return;  // проверка заполнения всех адресов датчиков
            }

            for (int i = 0; i < quantityNP; i++)    //для поиска датчиков во внешних NP
            {
                pages[i].AdressDat();
            }

            List_alien_NP_clear();
            search_indx();

            if (error == false)
            {
                for (int i = 0; i < quantityNP; i++)
                {
                    pages[i].FormingResult();
                }

                Stream mySaveStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.Filter = "txt files (*.ini)|*.ini";
                saveFileDialog1.FilterIndex = 2;

                for (int i = 0; i < quantityNP; i++)
                {
                    saveFileDialog1.FileName = "NP" + (i+1) + "_Config";

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if ((mySaveStream = saveFileDialog1.OpenFile()) != null)
                        {
                            StreamWriter TEXT = new StreamWriter(mySaveStream);
                            TEXT.Write(pages[i].Result.Text);
                            TEXT.Close();
                        }
                    }
                    else return;
                }
            }
        }

    }
}
