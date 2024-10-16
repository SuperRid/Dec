using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace CoDex
{
    public partial class Form1 : Form
    {
        string resHex = "";
        string resBin = "";
        string resXOR = "";

        string data = "";
        string dataBin = "";
        string dataHex = "";

        string key = "";
        string keyBin = "";
        string keyHex = "";

        string encrXOR = "";
        string encrHex = "";

        string decrDex = "";
        string decrBin = "";
        string decrXOR = "";
        string decrHex = "";

        string systemBin = "01";
        int k = 0;
        int value = 0;
        string Hex(int num)
        {
            resHex = "";
            string systemHex = "0123456789ABCDEF";

            while (num > 0)
            {
                int rem = num % 16;
                resHex = systemHex[rem] + resHex;
                num /= 16;
            }

            while (resHex.Length < 2)
            {
                resHex = "0" + resHex;
            }

            return resHex;
        }

        string Bin(int num)
        {
            resBin = "";


            while (num > 0)
            {
                int rem = num % 2;
                resBin = systemBin[rem] + resBin; 
                num /= 2;
            }

            // Чтобы всегда было 11 бит 
            while (resBin.Length < 8)
            {
                resBin = "0" + resBin; 
            }

            return resBin;
        }

      
        string XOR(int num1, int num2)
        {
            char HalfNum;
            
            if (k % 8 == 0)
            {
                resXOR = "";
            }

            HalfNum = systemBin[num1 ^ num2];
            if (HalfNum == '1')
            {
                value += (int)Math.Pow(2, (7 - k));
            }
            k++;
            if (k == 8)
            {
                resXOR += (char)value;
                k = 0;
                value = 0;
            }
            return resXOR;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void загрузитьОткрытыйТекстToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_OpenTextHex.Text = "";
            textBox_OpenText.Text = "";
            textBox_CloseTextHex.Text = "";
            data = "";
            dataBin = "";
            dataHex = "";

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Установка фильтров для файлов

            // Показать диалог открытия файла и проверить, была ли нажата кнопка OK
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;// Получение пути к файлу        
                textBox_OpenText.Text = File.ReadAllText(filePath);// Чтение содержимого файла и установка его в текстовое поле
            }
            data = textBox_OpenText.Text;

            for (int i = 0; i < data.Length; i++)
            {
                dataBin += Bin(data[i]);
            }

            for (int i = 0; i < data.Length; i++)
            {
                dataHex += Hex(data[i]);
            }
            textBox_OpenTextHex.Text = dataHex;
        }

        private void сгенерироватьКлючToolStripMenuItem_Click(object sender, EventArgs e)
        {
            key = "";
            keyBin = "";
            keyHex = "";
            textBox_Key.Text = "";
            Random rand = new Random();

            for (int i = 0; i < 8; i++)
            {
                // Определяем, какой диапазон выбрать
                int randomNumber = rand.Next(0, 255);
                key += (char)randomNumber;
            }

            for (int i = 0; i < key.Length; i++)
            {
                keyHex += Hex(key[i]);
            }
            textBox_Key.Text = keyHex;

            for (int i = 0; i < key.Length; i++)
            {
                keyBin += Bin(key[i]);
            }

        }

        private void зашифроватьXORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encrXOR = "";
            encrHex = "";
            textBox_CloseTextHex.Text = "";

            if (dataHex != "")
            {
                string data1 = "";
                for (int i = 0; i < dataHex.Length; i += 2)  // Шаг 2, потому что каждый байт (2 hex-символа)
                {
                    int hexValue = 0;
                    hexValue = Convert.ToInt32(dataHex.Substring(i, 2), 16);
                    data1 += (char)hexValue;
                }

                data = textBox_OpenText.Text;
                if (data != data1)
                {
                    dataBin = "";
                    dataHex = "";

                    for (int i = 0; i < data.Length; i++)
                    {
                        dataBin += Bin(data[i]);
                    }

                    for (int i = 0; i < data.Length; i++)
                    {
                        dataHex += Hex(data[i]);
                    }
                    textBox_OpenTextHex.Text = dataHex;
                }

            }

            for (int i = 0; i < dataBin.Length; i++)
            {
                encrXOR += XOR(dataBin[i], keyBin[i % keyBin.Length]);
            }

            for (int i = 0; i < encrXOR.Length; i++)
            {
                encrHex += Hex(encrXOR[i]);
            }
            textBox_CloseTextHex.Text = encrHex;
        }

        private void зашифроватьDECToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] IP = {
             58, 50, 42, 34, 26, 18, 10, 2,
             60, 52, 44, 36, 28, 20, 12, 4,
             62, 54, 46, 38, 30, 22, 14, 6,
             64, 56, 48, 40, 32, 24, 16, 8,
             57, 49, 41, 33, 25, 17, 9, 1,
             59, 51, 43, 35, 27, 19, 11, 3,
             61, 53, 45, 37, 29, 21, 13, 5,
             63, 55, 47, 39, 31, 23, 15, 7
                                            };

            int[] IP_1 = {
            40, 8, 48, 16, 56, 24, 64, 32,
            39, 7, 47, 15, 55, 23, 63, 31,
            38, 6, 46, 14, 54, 22, 62, 30,
            37, 5, 45, 13, 53, 21, 61, 29,
            36, 4, 44, 12, 52, 20, 60, 28,
            35, 3, 43, 11, 51, 19, 59, 27,
            34, 2, 42, 10, 50, 18, 58, 26,
            33, 1, 41, 9, 49, 17, 57, 25
                                           };
            int a = 0;
            string now = "";
            for (int i = 0; i <+ IP.Length; i++)
            {
                now+= dataBin[IP[i]-1];
            }


            a = 1;
        }
        private void дешифроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encrHex = "";
            decrDex = "";
            decrBin = "";
            decrXOR = "";
            decrHex = "";

            textBox_OpenTextHex.Text = "";
            textBox_OpenText.Text = "";
            encrHex = textBox_CloseTextHex.Text;

            key = "";
            keyBin = "";
            keyHex = "";
            string key1;
            key1 = textBox_Key.Text;

            for (int i = 0; i < key1.Length; i += 2)  // Шаг 2, потому что каждый байт (2 hex-символа)
            {
                int hexValue = 0;
                hexValue = Convert.ToInt32(key1.Substring(i, 2), 16);
                key += (char)hexValue;
            }

            for (int i = 0; i < key.Length; i++)
            {
                keyBin += Bin(key[i]);
            }

            MessageBox.Show("Открытый текст очищен");

            for (int i = 0; i < encrHex.Length; i += 2)  // Шаг 2, потому что каждый байт (2 hex-символа)
            {
                int hexValue = 0;
                hexValue = Convert.ToInt32(encrHex.Substring(i, 2), 16);
                decrDex += (char)hexValue;
            }

            for (int i = 0; i < decrDex.Length; i++)
            {
                decrBin += Bin(decrDex[i]);
            }

            for (int i = 0; i < decrBin.Length; i++)
            {
                decrXOR += XOR(decrBin[i], keyBin[i % keyBin.Length]);
            }

            textBox_OpenText.Text = decrXOR;

            for (int i = 0; i < decrXOR.Length; i++)
            {
                decrHex += Hex(decrXOR[i]);
            }

            textBox_OpenTextHex.Text = decrHex;
        }

        private void SaveOpenTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Установка фильтров для файлов
            saveFileDialog1.Title = "Сохранить открытый текст";

            // Показать диалог сохранения файла и проверить, была ли нажата кнопка OK
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Получение пути, выбранного пользователем
                string filePath = saveFileDialog1.FileName;

                // Запись содержимого текстового поля в файл
                File.WriteAllText(filePath, textBox_OpenText.Text);
            }
        }
        private void SaveCloseTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Установка фильтров для файлов
            saveFileDialog1.Title = "Сохранить открытый текст";

            // Показать диалог сохранения файла и проверить, была ли нажата кнопка OK
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Получение пути, выбранного пользователем
                string filePath = saveFileDialog1.FileName;

                // Запись содержимого текстового поля в файл
                File.WriteAllText(filePath, textBox_CloseTextHex.Text);
            }
        }

        private void SaveKeyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Установка фильтров для файлов
            saveFileDialog1.Title = "Сохранить открытый текст";

            // Показать диалог сохранения файла и проверить, была ли нажата кнопка OK
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Получение пути, выбранного пользователем
                string filePath = saveFileDialog1.FileName;

                // Запись содержимого текстового поля в файл
                File.WriteAllText(filePath, textBox_Key.Text);
            }
        }

        private void LoadCloseTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Установка фильтров для файлов

            // Показать диалог открытия файла и проверить, была ли нажата кнопка OK
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;// Получение пути к файлу        
                textBox_CloseTextHex.Text = File.ReadAllText(filePath);// Чтение содержимого файла и установка его в текстовое поле
            }
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Установка фильтров для файлов

            // Показать диалог открытия файла и проверить, была ли нажата кнопка OK
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;// Получение пути к файлу        
                textBox_Key.Text = File.ReadAllText(filePath);// Чтение содержимого файла и установка его в текстовое поле
            }
        }

        private void очиститьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_OpenTextHex.Text = "";
            textBox_OpenText.Text = "";
            textBox_CloseTextHex.Text = "";
            textBox_Key.Text = "";
        }

       
    }
}
