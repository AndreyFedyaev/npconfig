using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace NP_Config
{
    public partial class UserControl1 : UserControl
    {
        public int kUCH = 0; // количество участков
        // Создаем массив ТекстБоксов для адресов датчиков первого и второго канала.
        public TextBox[] tboxAddressDat1 = new TextBox[10];
        public TextBox[] tboxAddressDat2 = new TextBox[10];
        //Создаем массив ТекстБоксов для адресов датчиков участков
        public TextBox[] UCH_AddressLeftDat = new TextBox[5];
        public TextBox[] UCH_AddressRightDat = new TextBox[5];
        //Массив внешних NP
        public string[,] ListExternalNP = new string[8,2];
        // Массивы адресов датчиков 1 и 2 канала
        public int[] AddressDat1 = new int[10];
        string[] X2AddressDat1 = new string[10];
        public int[] AddressDat2 = new int[10];
        string[] X2AddressDat2 = new string[10];
        // Массив индексов датчиков
        public int[] IndexDat = new int[21];
        public string[,] IndexExternalDat = new string[8, 2]; // индексы внешних датчиков [адреса датчиков в 16-ричной форме, адреса датчика в десятичной]
        //Создаем массивы участков
        public string[,] UCH = new string[20, 11];  // до 20 участков
        public string[,] IndexUCH = new string[20, 11];  // до 20 участков. Адреса меняем на индексы

        int kLeftUCH = 0;
        int kRightUCH = 0;
        public UserControl1()
        {
            InitializeComponent();
            UpdateInterface();
        }
        public void UpdateInterface()
        {
            // Задаем параметры массивов ТекстБоксов для адресов первого и второго канала (до 10 шт. на канал). Делаем их невидимыми
            for (int i = 0; i < 10; i++)
            {
                tboxAddressDat1[i] = new TextBox();
                tboxAddressDat1[i].Left = numericUpDown1.Location.X;
                tboxAddressDat1[i].Top = numericUpDown1.Location.Y + 43 + i * 24;
                tboxAddressDat1[i].Width = 70;
                tboxAddressDat1[i].Visible = false;
                this.Controls.Add(tboxAddressDat1[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                tboxAddressDat2[i] = new TextBox();
                tboxAddressDat2[i].Left = numericUpDown2.Location.X;
                tboxAddressDat2[i].Top = numericUpDown2.Location.Y + 43 + i * 24;
                tboxAddressDat2[i].Width = 70;
                tboxAddressDat2[i].Visible = false;
                this.Controls.Add(tboxAddressDat2[i]);
            }
            //Создаем массив ТекстБоксов для обозначения датчиков участков
            for (int i = 0; i < 5; i++)
            {
                UCH_AddressLeftDat[i] = new TextBox();
                UCH_AddressLeftDat[i].Left = numericUpDown3.Location.X;
                UCH_AddressLeftDat[i].Top = numericUpDown3.Location.Y + 24 + i * 24;
                UCH_AddressLeftDat[i].Width = 70;
                UCH_AddressLeftDat[i].Visible = false;
                this.Controls.Add(UCH_AddressLeftDat[i]);
            }
            for (int i = 0; i < 5; i++)
            {
                UCH_AddressRightDat[i] = new TextBox();
                UCH_AddressRightDat[i].Left = numericUpDown4.Location.X;
                UCH_AddressRightDat[i].Top = numericUpDown4.Location.Y + 24 + i * 24;
                UCH_AddressRightDat[i].Width = 70;
                UCH_AddressRightDat[i].Visible = false;
                this.Controls.Add(UCH_AddressRightDat[i]);
            }
        }
        static string Str1(string a, string b, string c, string d, string e, string f)
        {
            String result = "";
            result = a + "." + b + "." + c + "." + d + "." + e + "." + f + "'";
            result = result.PadRight(50, ' ');
            result += "\tMAC адрес разъема T1 \r\n";
            return result;
        }
        static string Str2(string a, string b, string c, string d, string e, string f)
        {
            String result = "";
            result = a + "." + b + "." + c + "." + d + "." + e + "." + f + "'";
            result = result.PadRight(50, ' ');
            result += "\tMAC адрес разъема T2 \r\n";
            return result;
        }
        static string Str3(string a, string b, string c, string d)
        {
            String result = "";
            result = a + "." + b + "." + c + "." + d + ":" + c + d + ":4001'";
            result = result.PadRight(50, ' ');
            result += "\tIP адрес, UDP порт разъема T1 \r\n";
            return result;
        }
        static string Str4(string a, string b, string c, string d)
        {
            String result = "";
            result = a + "." + b + "." + c + "." + d + ":" + c + d + ":4002'";
            result = result.PadRight(50, ' ');
            result += "\tIP адрес, UDP порт разъема T2 \r\n";
            return result;
        }
        static string Str5(string a, string b, string c, string d, string IP1, string IP2)
        {
            String result = "";
            result = a + "." + b + "." + c + "." + d + ":" + IP1 + IP2 + ":2000'";
            result = result.PadRight(50, ' ');
            result += "\tIP адрес контроллера МПЦ, подключенного к Т1 \r\n";
            return result;
        }
        static string Str6(string a, string b, string c, string d, string IP1, string IP2)
        {
            String result = "";
            result = a + "." + b + "." + c + "." + d + ":" + IP1 + IP2 + ":2000'";
            result = result.PadRight(50, ' ');
            result += "\tIP адрес контроллера МПЦ, подключенного к Т2 \r\n";
            return result;
        }
        public string Str7()
        {
            String result = "0.0'";
            result = result.PadRight(50, ' ');
            result += "\tСкорость обмена данными 1 и 2 канала RS-485 \r\n";
            return result;
        }
        public string Str8_Str15()
        {
            string [] result = new string[8];
            String result_2 = null; 
            for (int i = 0; i < 8; i++)
            {
                if (ListExternalNP[i, 0] != null)
                {
                    result[i] = ListExternalNP[i, 0] + ":2000." + ListExternalNP[i, 1] + ":2000'";
                }
                else
                {
                    result[i] = "0'";
                }
                result[i] = result[i].PadRight(50, ' ');
                result[i] += "\tКонфигурация внешнего нпорта с индексом " + i + "\r\n";

                result_2 += result[i];
            }
            return result_2;
        }
        public string Str16(int var1, int var2)  
        {
            String result = "";
            result = var1.ToString("00") + " " + var2.ToString("00") + " FF" + " 20";
           
            for (int i = 0; i < Convert.ToInt32(var1); i++)
            {
                result += " " + X2AddressDat1[i];                           // добавляем адреса датчиков первого канала
            }
            for (int i = 0; i < Convert.ToInt32(var2); i++)
            {
                result += " " + X2AddressDat2[i];                           // добавляем адреса датчиков второго канала
            }
            result += "'";  
            result = result.PadRight(50, ' ');
            result += "\tКонфигурация датчиков нпорта \r\n";
            return result;
        }
        public string Str17()
        {
            String result = "";
            for (int i = 0; i < 8; i++)
            {
                if (IndexExternalDat [i,0] == null)
                {
                    IndexExternalDat[i, 0] = "00";
                }
            }
            for (int i = 0; i < 7; i++)
            {
                result += IndexExternalDat[i, 0] + " ";
            }
            result += IndexExternalDat[7, 0] + "'";
            result = result.PadRight(50, ' ');
            result += "\tКонфигурация датчиков, не подключенных к нпорту \r\n";
            return result;
        }
        public string Str18()
        {
            String result = "";
            result = kUCH.ToString("X2") + "'";
            result = result.PadRight(50, ' ');
            result += "\tКоличество конфигурируемых участков \r\n";
            return result;
        }
        public string Str19_StrN()
        {
            string[] res = new string[kUCH];
            String result = "";
            for (int k = 0; k < kUCH; k++)
            {
                int kd = 0;
                string d_left = "";
                string d_right = "";

                for (int i = 1; i < 6; i++)
                {
                    if (UCH[k, i] != "" & UCH[k, i] != null)
                    {
                        kd++;
                        d_left += " " + Convert.ToInt32(IndexUCH[k, i]).ToString("X2");
                    }
                }
                for (int i = 6; i < 11; i++)
                {
                    if (UCH[k, i] != "" & UCH[k, i] != null)
                    {
                        kd++;
                        d_right += " " + (Convert.ToInt32(IndexUCH[k, i]) | 128).ToString("X2");
                    }
                }
                res[k] = kd.ToString("00") + " 00" + d_left + d_right + "'";
                res[k] = res[k].PadRight(50, ' ');
                res[k] += "\tКонфигурирование участка " + UCH[k, 0] + "\r\n";
            }
            for (int i = 0; i < kUCH; i++)
            {
                result += res[i];
            }
            return result;
        }
        public void FormingResult ()
        {
            Result.Text = Str1(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            Result.Text += Str2(textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text);
            Result.Text += Str3(textBox13.Text, textBox14.Text, textBox15.Text, textBox16.Text);
            Result.Text += Str4(textBox17.Text, textBox18.Text, textBox19.Text, textBox20.Text);
            Result.Text += Str5(textBox21.Text, textBox22.Text, textBox23.Text, textBox24.Text, textBox15.Text, textBox16.Text);
            Result.Text += Str6(textBox25.Text, textBox26.Text, textBox27.Text, textBox28.Text, textBox19.Text, textBox20.Text);
            Result.Text += Str7();
            Result.Text += Str8_Str15();
            Result.Text += Str16(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));
            Result.Text += Str17();
            Result.Text += Str18();
            Result.Text += Str19_StrN();
        }   //Формирование результата
        public void ViewingConfig ()   // Создаем файл для предварительного просмотра Config.ini
        {
            //Создаем файл++++
            StreamWriter TEXT = new StreamWriter("ViewingConfig.ini", false);
            TEXT.WriteLine(Result.Text);
            TEXT.Close();

            //Открываем файл
            if (File.Exists("ViewingConfig.ini"))       //проверяем существует ли заданный файл
            {
                Process.Start("ViewingConfig.ini");     // если да, то открываем его
            }
        }
        public void SaveConfig()         // создаем и сохраняем файл Config.ini
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "Config";
            saveFileDialog1.Filter = "txt files (*.ini)|*.ini";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter TEXT = new StreamWriter(myStream);
                    TEXT.Write(Result.Text);                              
                    TEXT.Close();
                }
            }
        }
       
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //изменяем видимость полей для ввода адресов датчиков
            for (int i = 0; i < 10; i++)
            {
                if (i < Convert.ToInt32(numericUpDown1.Value))
                {
                    tboxAddressDat1[i].Visible = true;
                }
                else
                {
                    tboxAddressDat1[i].Visible = false;
                    tboxAddressDat1[i].Text = null;
                }
            }
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //изменяем видимость полей для ввода адресов датчиков
            for (int i = 0; i < 10; i++)
            {
                if (i < Convert.ToInt32(numericUpDown2.Value))
                {
                    tboxAddressDat2[i].Visible = true;
                }
                else
                {
                    tboxAddressDat2[i].Visible = false;
                    tboxAddressDat2[i].Text = null;
                }
            }
        }
        public void AdressDat ()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 2; k++)
                {
                    IndexExternalDat[i, k] = null;
                }
            }
            //Записываем адреса датчиков в массивы
            for (int i = 0; i < Convert.ToInt32(numericUpDown1.Value); i++)
            {
                    AddressDat1[i] = (Convert.ToInt32(tboxAddressDat1[i].Text));
                    X2AddressDat1[i] = (Convert.ToInt32(tboxAddressDat1[i].Text)).ToString("X2");
            }    
            for (int i = 0; i < Convert.ToInt32(numericUpDown2.Value); i++)
            {
                    AddressDat2[i] = (Convert.ToInt32(tboxAddressDat2[i].Text));
                    X2AddressDat2[i] = (Convert.ToInt32(tboxAddressDat2[i].Text)).ToString("X2");
            }
            //Добавляем в массив "IndexDat" адреса датчиков в 10 форме. Сначала первый, затем второй канал
            for (int i = 0; i < Convert.ToInt32(numericUpDown1.Value); i++)
            {
                IndexDat[i+1] = AddressDat1[i];
            }
            for (int i = 0; i < Convert.ToInt32(numericUpDown2.Value); i++)
            {
                IndexDat[Convert.ToInt32(numericUpDown1.Value) + i + 1] = AddressDat2[i];
            }
        }
         public bool ErrorChecking ()
        {
                bool var = false;
            for (int i = 0; i < Convert.ToInt32(numericUpDown1.Value); i++)
            {
                if (tboxAddressDat1[i].Text == "")
                {
                    MessageBox.Show("Не все адреса датчиков были указаны!", "Предупреждение");
                    var = true;
                }
            }
            for (int i = 0; i < Convert.ToInt32(numericUpDown2.Value); i++)
            {
                if (tboxAddressDat2[i].Text == "")
                {
                    MessageBox.Show("Не все адреса датчиков были указаны!", "Предупреждение");
                    var = true;
                }
            }
            if (textBox16.Text == "" | textBox20.Text == "" | textBox24.Text == "" | textBox28.Text == "")
            {
                MessageBox.Show("Не все IP адреса были указаны!", "Предупреждение");
                var = true;
            }
            return var;
        }
        private void AddUCH_Click(object sender, EventArgs e)
        {
            //Добавление участка:
            if (UCH_Name.Text != "" & (AddUCH.Text == "Добавить участок"))
            {
                if (kUCH < 20)
                {
                    UCH[kUCH, 0] = UCH_Name.Text;
                    for (int i = 1; i < 6; i++)
                    {
                        UCH[kUCH, i] = UCH_AddressLeftDat[i - 1].Text;
                    }
                    for (int i = 6; i < 11; i++)
                    {
                        UCH[kUCH, i] = UCH_AddressRightDat[i - 6].Text;
                    }
                    kUCH++;
                }
                else
                {
                    MessageBox.Show("Добавлено максимальное количество участков!", "Предупреждение");
                }
            }
            //Изменение участка:
            if (UCH_Name.Text != "" & (AddUCH.Text == "Изменить участок"))
            {
                for (int i = 0; i < kUCH; i++)
                {
                    if (UCH_Name.Text == UCH[i,0])
                    {
                        for (int k = 1; k < 6; k++)
                        {
                            UCH[i, k] = UCH_AddressLeftDat[k - 1].Text;
                        }
                        for (int l = 6; l < 11; l++)
                        {
                            UCH[i, l] = UCH_AddressRightDat[l - 6].Text;
                        }
                    }
                }
            }

            // Обнуляем поле ввода участков
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            UCH_Name.Text = null;

            ListUCH ();  //обновление списка добавленных участков

            for (int i = 0; i < kUCH; i++)
            {
                IndexUCH[i, 0] = UCH[i, 0]; //Переписываем названия участков в массив индексов
            }
        }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            //изменяем видимость полей для ввода датчиков участков
            for (int i = 0; i < 5; i++)
            {
                if (i < Convert.ToInt32(numericUpDown3.Value))
                {
                    UCH_AddressLeftDat[i].Visible = true;
                    kLeftUCH = i + 1;
                }
                else
                {
                    UCH_AddressLeftDat[i].Visible = false;
                    UCH_AddressLeftDat[i].Text = null;
                }
            }
            if (numericUpDown3.Value == 0)
                kLeftUCH = 0;
        }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            //изменяем видимость полей для ввода датчиков участков
            for (int i = 0; i < 5; i++)
            {
                if (i < Convert.ToInt32(numericUpDown4.Value))
                {
                    UCH_AddressRightDat[i].Visible = true;
                    kRightUCH = i + 1;
                }
                else
                {
                    UCH_AddressRightDat[i].Visible = false;
                    UCH_AddressRightDat[i].Text = null;
                }
            }
            if (numericUpDown4.Value == 0)
                kRightUCH = 0;
        }
        private void UCH_Name_TextChanged(object sender, EventArgs e)
        {
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;

            for (int i = 0; i < kUCH; i++)
            {
                if (UCH_Name.Text == UCH[i, 0])
                {
                    AddUCH.Text = "Изменить участок";
                    Delete_UCH.Visible = true;
                    UCH_Changes();
                    break;
                }
                else
                {
                    AddUCH.Text = "Добавить участок";
                    Delete_UCH.Visible = false;
                }
            }
        }
        void UCH_Changes ()     //алгоритм отображения значений ранее добавленного участка
        {
            for (int z = 0; z < kUCH; z++)
            {
                if (UCH_Name.Text == UCH[z, 0])
                {

                    for (int k = 1; k < 6; k++)
                    {
                        if (UCH[z, k] != "")
                        {
                            kLeftUCH++;
                            UCH_AddressLeftDat[k - 1].Visible = true;
                            UCH_AddressLeftDat[k - 1].Text = UCH[z, k];
                        }
                        else
                        {
                            UCH_AddressLeftDat[k - 1].Visible = false;
                        }
                        numericUpDown3.Value = kLeftUCH;
                    }
                    for (int k = 6; k < 11; k++)
                    {
                        if (UCH[z, k] != "")
                        {
                            kRightUCH++;
                            UCH_AddressRightDat[k - 6].Visible = true;
                            UCH_AddressRightDat[k - 6].Text = UCH[z, k];
                        }
                        else
                        {
                            UCH_AddressRightDat[k - 6].Visible = false;
                        }
                        numericUpDown4.Value = kRightUCH;
                    }
                }
            }
        }
        private void Delete_UCH_Click(object sender, EventArgs e)       //удаление выбранного участка
        {
            //Удаляем участок из массива
            for (int i = 0; i < kUCH; i++)
            {
                if (UCH_Name.Text == UCH[i, 0])
                {
                    for (int k = 0; k < 11; k++)
                    {
                        UCH[i, k] = null;
                    }
                }
            }
            UCH_Name.Text = null;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            Mass_Delete_Null();
            kUCH--;
            ListUCH (); //обновление списка участков
        }
        public void Mass_Delete_Null()        //Перебор массива UCH[,] после удаления участков 
        {
            for (int i = 0; i < kUCH; i++)
            {
                if (UCH[i, 0] == null)
                {
                    for (int n = i; n < kUCH; n++)
                    {
                        for (int k = 0; k < 11; k++)
                        {
                            if (n != 19)
                            {
                                UCH[n, k] = UCH[n + 1, k];
                            }
                            else
                            {
                                UCH[n, k] = null;
                            }
                        }
                    }
                }
            }
        }
        public void ListUCH ()        //Отображение списка добавленных участков
        {
            UCH_List.Text = "";
            for (int i = 0; i < kUCH; i++)
            {
                UCH_List.Text += UCH[i, 0] + "\r\n";
            }
            label2.Text = "Добавленные участки (" + kUCH + ")";
        }
        
        public void UCH_Indx_Write (int var1, int var2, int var3)
        {
            IndexUCH[var1, var2] = Convert.ToString(var3);
        }

        public int search_list_alien_NP (string var1, string var2)
        {
           
            int var = 0;
            for (int i = 0; i < 8; i++)
            {
                if (var1 == ListExternalNP[i,0])
                {
                    var = i;
                    break;
                }
                else
                {
                    if (i == 7)
                    {
                       var = Write_list_alien_NP(var1, var2);
                        break;
                    }
                }
            }
            return (var);
        }

        public int Write_list_alien_NP (string var1, string var2)
        {
            int var = 0;
            for (int i = 0; i < 8; i++)
            {
                if (ListExternalNP[i,0] == null)
                {
                    ListExternalNP[i, 0] = var1;
                    ListExternalNP[i, 1] = var2;
                    var = i;
                    break;
                }
            }
            return (var);
        }
        public void Vn_dat (int var1, int var2, string var3)
        {
            for (int i = 0; i < 8; i++)
            {
                if (IndexExternalDat[i, 0] == null)
                {
                    IndexExternalDat[i, 0] = var3;
                    IndexExternalDat[i, 1] = UCH[var1, var2];

                    UCH_Indx_Write(var1, var2, (i + 21));
                    
                    break;
                }
            }
        }
    }
}
