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
using System.Threading;

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

        string now = "";
        string key56 = "";
        string block = "";
        string ER = "";
        string[] k = new string[17];
        string[] C = new string[17];
        string[] D = new string[17];
        string blockHex = "";

        string systemBin = "01";
        int h = 0;
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

        string Hex(string num)
        {
            resHex = "";
            long value = Convert.ToInt64(num, 2);
            resHex = Convert.ToString(value, 16).ToUpper();

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

            // Чтобы всегда было 8 бит 
            while (resBin.Length < 8)
            {
                resBin = "0" + resBin;
            }

            return resBin;
        }

        string KeyBin(int num)
        {
            resBin = "";
            int count1 = 0;
            int k = 0;
            value = 0;

            while (num > 0)
            {
                int rem = num % 2;
                if (rem == 1 && k!= 0) count1++;
                k++;
                resBin = systemBin[rem] + resBin;
                num /= 2;
            }

            // Чтобы всегда было 8 бит 
            while (resBin.Length < 8)
            {
                resBin = "0" + resBin;
            }


            if (count1 % 2 == 0) resBin = resBin.Substring(0, resBin.Length - 1) + "1"; //Перебираем строку до предпоследнего элемента
            else resBin = resBin.Substring(0, resBin.Length - 1) + "0"; //Перебираем строку до предпоследнего элемента

            for (int i = 0; i < resBin.Length; i++)
            {
                if (resBin[i] == '1')
                {
                    value += (int)Math.Pow(2, (7 - i));
                }
            }

            textBox_Key.Text += Hex(value);
            return resBin;
        }


        string XOR(int num1, int num2)
        {
            char HalfNum;

            if (h % 8 == 0)
            {
                resXOR = "";
            }

            HalfNum = systemBin[num1 ^ num2];
            if (HalfNum == '1')
            {
                value += (int)Math.Pow(2, (7 - h));
            }
            h++;
            if (h == 8)
            {
                resXOR += (char)value;
                h = 0;
                value = 0;
            }
            return resXOR;
        }

        string XORDES(string num1, string num2)
        {
            resXOR = "";
            for (int i = 0; i < num2.Length; i++)
            {
                resXOR += systemBin[num1[i] ^ num2[i]];
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
            key56 = "";
            keyBin = "";
            keyHex = "";
            textBox_Key.Text = "";
            Random rand = new Random();

            int[] CD = {
            57, 49, 41, 33, 25, 17, 9,
            1,  58, 50, 42, 34, 26, 18,
            10, 2,  59, 51, 43, 35, 27,
            19, 11, 3,  60, 52, 44, 36,
            63, 55, 47, 39, 31, 23, 15,
            7,  62, 54, 46, 38, 30, 22,
            14, 6,  61, 53, 45, 37, 29,
            21, 13, 5,  28, 20, 12, 4
                                        };

            int[] key48 = {
             14, 17, 11, 24,  1,  5,
             3,  28, 15,  6, 21, 10,
             23, 19, 12,  4, 26,  8,
             16,  7, 27, 20, 13,  2,
             41, 52, 31, 37, 47, 55,
             30, 40, 51, 45, 33, 48,
             44, 49, 39, 56, 34, 53,
             46, 42, 50, 36, 29, 32
                                    };

            int[] a = { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };


            for (int i = 0; i < 8; i++)
            {
                // Определяем, какой диапазон выбрать
                int randomNumber = rand.Next(0, 255);
                key += (char)randomNumber;
            }

            for (int i = 0; i < key.Length; i++)
            {
                keyBin += KeyBin(key[i]);
            }

            for (int i = 0; i < CD.Length; i++)
            {
                key56 += keyBin[CD[i] - 1];
            }

            C[0] = key56.Substring(0, 28);
            D[0] = key56.Substring(28, 28);

            for (int j = 1; j < 17; j++)
            {

                C[j] = C[j - 1].Substring(a[j - 1]) + C[j - 1].Substring(0, a[j - 1]);
                D[j] = D[j - 1].Substring(a[j - 1]) + D[j - 1].Substring(0, a[j - 1]);

                for (int l = 0; l < key48.Length; l++)
                {
                    k[j] += (C[j] + D[j])[key48[l] - 1];
                }
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

        private void дешифроватьXORToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void зашифроватьDECToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encrHex = "";
            now = "";

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

           

            int blocksCount = (int)Math.Ceiling(dataBin.Length / 64.0); //Кол-во блоков

            for (int i = 0; i < blocksCount; i++)
            {
                string[] R = new string[17];
                string[] L = new string[17];
                block = "";

                if (i * 64 + 64 <= dataBin.Length)
                {
                    block = dataBin.Substring(i * 64, 64);
                }
                else //Дополняем последний блок нулями
                {
                    block = dataBin.Substring(i * 64);
                    while (block.Length < 64)
                    {
                        block += "0";
                    }
                }

                for (int j = 0; j < IP.Length; j++)
                {
                    //Разделим на блоки L0 и R0
                    if (j < 32) L[0] += block[IP[j] - 1];
                    else R[0] += block[IP[j] - 1];
                }
                    
                for (int j = 1; j < 17; j++)
                {
                    L[j] = R[j - 1];
                    R[j] = XORDES(L[j-1],F(XORDES(E(R[j-1]),k[j])));
                }

                block = "";
                // Собираем результат шифрования всех блоков
                for (int j = 0; j < IP_1.Length; j++)
                {
                    block += (L[16] + R[16])[IP_1[j] - 1];
                }

                now += Hex(block);
            }

            // Выводим результат шифрования
            textBox_CloseTextHex.Text = now;

        }
        private string E(string R)
        {
            int[] E = {
            32,  1,  2,  3,  4,  5,
            4,  5,  6,  7,  8,  9,
            8,  9, 10, 11, 12, 13,
            12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21,
            20, 21, 22, 23, 24, 25,
            24, 25, 26, 27, 28, 29,
            28, 29, 30, 31, 32,  1
                                   };

            ER = "";
            for (int i = 0; i < E.Length; i++)
            {
                ER += R[E[i] - 1];
            }

            return ER;
        }

        private string F(string R)
        {
            string A = "";
            string B = "";
            string C = "";

            int[,,] SBox = new int[8, 4, 16]
            {
               {
                 {14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7},
                 {0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8},
                 {4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0},
                 {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13}
               },
               {
                 {15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10},
                 {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5},
                 {0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
                 {13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9}
               },
               {
                 {10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8},
                 {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1},
                 {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7},
                 {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12}
               },
               {
                 {7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15},
                 {13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9},
                 {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4},
                 {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14}
               },
               {
                 {2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9},
                 {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6},
                 {4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14},
                 {11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3}
               },
               {
                 {12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11},
                 {10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8},
                 {9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6},
                 {4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13}
               },
               {
                 {4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1},
                 {13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6},
                 {1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2},
                 {6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12}
               },
               {
                 {13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7},
                 {1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2},
                 {7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8},
                 {2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11}
               }
            };

            int[] P = {
            16, 7, 20, 21,
            29, 12, 28, 17,
            1, 15, 23, 26,
            5, 18, 31, 10,
            2, 8, 24, 14,
            32, 27, 3, 9,
            19, 13, 30, 6,
            22, 11, 4, 25
                           };

            for (int i = 0; i < R.Length; i += 6)
            {
                A = R.Substring(i, 6);
                B += BinS(SBox[i / 6, Dex(A.Substring(0, 2)), Dex(A.Substring(2))]);
            }

            for (int i = 0; i < P.Length; i++)
            {
                C += B[P[i] - 1];
            }
            return C;
        }

        private int Dex(string num)
        {
            value = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] == '1')
                {
                    value += (int)Math.Pow(2, (num.Length - 1 - i));
                }
            }

            return value;
        }

        string BinS(int num)
        {
            resBin = "";

            while (num > 0)
            {
                int rem = num % 2;
                resBin = systemBin[rem] + resBin;
                num /= 2;
            }

            // Чтобы всегда было 4 бита
            while (resBin.Length < 4)
            {
                resBin = "0" + resBin;
            }

            return resBin;
        }

        private void дешифроватьDECToolStripMenuItem_Click(object sender, EventArgs e)
        {
            value = 0;
            h = 0;
            textBox_OpenTextHex.Text = "";
            textBox_OpenText.Text = "";

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

            for (int i = 0; i < +IP_1.Length; i++)
            {
                decrBin += now[IP_1[i] - 1];
            }

            for (int i = 0; i < decrBin.Length; i++)
            {
                if (decrBin[i] == '1')
                {
                    value += (int)Math.Pow(2, (7 - h));
                }

                h++;
                if (h == 8)
                {
                    resXOR += (char)value;
                    h = 0;
                    value = 0;
                }
            }

            MessageBox.Show("Открытый текст очищен");
            textBox_OpenText.Text = resXOR;
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
