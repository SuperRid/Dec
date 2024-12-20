﻿using System;
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
using System.Security.AccessControl;

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

        string encrXOR = "";
        string encrHex = "";

        string decrDes = "";
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
        int value = 0;

        int n = 1;
        int d = 1; 


        public Form1()
        {
            InitializeComponent();
            label5.Enabled = false;
            textBox1.Enabled = false;
            label6.Enabled = false;
            textBox2.Enabled = false;
            label3.Text = "Закрытый текст Hex";
        }
        string Hex(string num)
        {
            resHex = "";
            value = 0;
            for (int i = 0; i < num.Length; i += 8)
            {
                value = Convert.ToInt16(num.Substring(i, 8), 2);
                resHex += Convert.ToString(value, 16).ToUpper().PadLeft(2, '0');
            }

            return resHex;
        }

        string Bin(string num)
        {
            resBin = "";

            for (int i = 0; i < num.Length; i++)
            {
                resBin += Convert.ToString(num[i], 2).PadLeft(8, '0');
            }

            return resBin;
        }

        string KeyBin(int num)
        {
            resBin = "";
            int count = 0;
            resBin = Convert.ToString(num, 2);

            for (int i = 0; i < resBin.Length; i++)
            {
                if (resBin[i] == '1') count++;
            }

            if (count % 2 == 0) resBin += 1;
            else resBin += 0;

            resBin = resBin.PadLeft(8, '0');
            return resBin;
        }


        string XOR(string num1, string num2)
        {
            resXOR = "";

            for (int i = 0; i < num1.Length; i++)
            {
                resXOR += num1[i] ^ num2[i%8];
            }
            return resXOR;
        }
       

        string XORDES(string num1, string num2)
        {
            resXOR = "";
            for (int i = 0; i < num2.Length; i++)
            {
                resXOR += num1[i] ^ num2[i];
            }
            return resXOR;
        }

        private void сгенерироватьКлючToolStripMenuItem_Click(object sender, EventArgs e)
        {
            key = "";
            key56 = "";
            keyBin = "";
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
                int randomNumber = rand.Next(0, 127);
                keyBin += KeyBin(randomNumber);
            }

            textBox_Key.Text = Hex(keyBin);

            for (int i = 0; i < CD.Length; i++)
            {
                key56 += keyBin[CD[i] - 1];
            }

            C[0] = key56.Substring(0, 28);
            D[0] = key56.Substring(28, 28);

            for (int j = 1; j < 17; j++)
            {
                k[j] = "";
                C[j] = C[j-1].Substring(a[j - 1]) + C[0].Substring(0, a[j - 1]);
                D[j] = D[j-1].Substring(a[j - 1]) + D[0].Substring(0, a[j - 1]);

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

            TextProcessing();
            if (dataBin == "") MessageBox.Show("Введите или загрузите текст!");

            encrXOR += XOR(dataBin, keyBin);
            encrHex += Hex(encrXOR);

            textBox_CloseTextHex.Text = encrHex;
        }

        private void дешифроватьXORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encrHex = "";
            decrDes = "";
            decrBin = "";
            decrXOR = "";
            decrHex = "";
            keyBin = "";
            key = "";

            textBox_OpenTextHex.Text = "";
            textBox_OpenText.Text = "";
            decrHex = textBox_CloseTextHex.Text;
            decrBin += HexToBin(decrHex);

            key = textBox_Key.Text;
            keyBin += HexToBin(key);

            MessageBox.Show("Открытый текст очищен");

            decrXOR += XOR(decrBin, keyBin);

            textBox_OpenText.Text = DexToChar(decrXOR);
            textBox_OpenTextHex.Text = Hex(decrXOR);
        }

      
        private void зашифроватьDECToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label5.Enabled = false;
            textBox1.Enabled = false;
            label6.Enabled = false;
            textBox2.Enabled = false;
            label3.Text = "Закрытый текст Hex";

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
            TextProcessing();
            if(dataBin == "") MessageBox.Show("Введите или загрузите текст!");

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
                    block = dataBin.Substring(i * 64).PadLeft(64, '0');
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

                for (int j = 0; j < IP_1.Length; j++)
                {
                    block += (L[16] + R[16])[IP_1[j] - 1];
                }

                now += Hex(block);
            }

                textBox_CloseTextHex.Text = now;

        }

        private void дешифроватьDECToolStripMenuItem_Click(object sender, EventArgs e)
        {
            now = "";
            blockHex = "";
            block = "";
            textBox_OpenTextHex.Text = "";
            textBox_OpenText.Text = "";
            decrDes = "";

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


            now = textBox_CloseTextHex.Text;

            for (int i = 0; i < now.Length; i += 16)
            {
                string[] R = new string[17];
                string[] L = new string[17];

                blockHex = now.Substring(i, 16);
                block = HexToBin(blockHex);

                for (int j = 0; j < IP.Length; j++)
                {
                    //Разделим на блоки L0 и R0
                    if (j < 32) L[16] += block[IP[j] - 1];
                    else R[16] += block[IP[j] - 1];
                }

                for (int j = 16; j > 0; j--)
                {
                    R[j - 1] = L[j];
                    L[j - 1] = XORDES(R[j], F(XORDES(E(L[j]), k[j])));
                }

                block = "";
                // Собираем результат шифрования всех блоков
                for (int j = 0; j < IP_1.Length; j++)
                {
                    block += (L[0] + R[0])[IP_1[j] - 1];
                }

                decrDes += block;
            }
            MessageBox.Show("Открытый текст очищен");
            textBox_OpenText.Text = DexToChar(decrDes);
            textBox_OpenTextHex.Text = Hex(decrDes);
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
                B += BinS(SBox[i / 6, Dex(A.Substring(0,1) + A.Substring(5,1)), Dex(A.Substring(1,4))]);
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

        private string DexToChar(string num)
        {
            resBin = "";
            resXOR = "";
            for (int i = 0; i < num.Length; i+=8)
            {
                resBin = num.Substring(i, 8);
                resXOR += Convert.ToChar(Convert.ToInt32(resBin, 2));
            }
            return resXOR;
        }


        private string HexToBin(string num)
        {
            value = 0;
            resBin = "";
            for (int i = 0; i < num.Length; i += 2)
            {
                value = Convert.ToInt32(num.Substring(i,2), 16);
                resBin += Convert.ToString(value, 2).PadLeft(8,'0');
            }
              
            return resBin;
        }

        string BinS(int num)
        {
            resBin = "";
            resBin += Convert.ToString(num, 2).PadLeft(4, '0');

            return resBin;
        }

        private void TextProcessing()
        {
            dataBin = "";
            dataHex = "";
            data = textBox_OpenText.Text;

            dataBin += Bin(data);
            dataHex += Hex(dataBin);
            textBox_OpenTextHex.Text = dataHex;
        }


        private void зашифроватьRSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label6.Enabled = true;
            textBox1.Enabled = true;
            label5.Enabled = true;
            textBox2.Enabled = true;
            label3.Text = "Закрытый текст Dex";

            Random rand = new Random();
        
            int q = 1;
            int p = 1;
            int fi_n = 1;
            int e1;

            p = FindPQ(rand);
            q = FindPQ(rand);

            n = p * q;
            fi_n = (p - 1) * (q - 1);
            e1 = AlgEuclid(rand, fi_n);
   
            var (gcd, x, y) = AdvAlgEuclid(e1, fi_n);
            if (x < 0) d = x + fi_n;
            else d = x;

            p = 0;
            q = 0;
            fi_n = 0;

            textBox2.Text = e1.ToString();
            textBox1.Text = d.ToString();

            string C = "";
            data = textBox_OpenText.Text;
            for (int i = 0; i < data.Length; i++)
            {
                C += RecursAlg(data[i], e1, n) + " "; 
            }

            textBox_CloseTextHex.Text = C;
        }

        private void дешифроватьRSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data = "";

            data = textBox_CloseTextHex.Text;
            string M = "";
            string value = "";

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != ' ')
                {
                    value += data[i];
                }

                else
                {
                    M += (char)RecursAlg(Convert.ToInt64(value), d, n);
                    value = "";
                }
            }
            textBox_OpenText.Text = "";
            MessageBox.Show("Открытый текст очищен");
            textBox_OpenText.Text = M;
        }


        private long RecursAlg(long a, int b, int r)
        {
            if (b == 0)
                return 1;

            long half = RecursAlg(a, b / 2, r);
            long result = (half * half) % r;


            if (b % 2 != 0) // если степень нечётная
                result = (result * a) % r;

            // Приводим результат к положительному числу
            if (result < 0)
                result += r;

            return result;
        }


        private int FindPQ(Random rand)
        {
            bool good = false;
            int value = 0;
         
            while (!good)
            {
                int r = rand.Next(3, 65536);
                for (int i = 0; i < 6; i++)
                {
                    int b = r - 1;
                    int a = rand.Next(1, b);
                    long res;

                    res = RecursAlg(a, b, r);

                    if (res != 1)
                    {
                        good = false;
                        break;
                    }

                    if (res == 1 && i == 5)
                    {
                        good = true;
                        value = r;
                    }
                }
            }
            return value;
        }

        private int AlgEuclid(Random rand, int fi_n)
        {
            int gcd = 0;
            int value = 0;
            while (gcd != 1)
            {
                int e = rand.Next(1, fi_n);
                int a = e;
                int b = fi_n;
                while (b != 0)
                {
                    int r = a % b;
                    a = b;
                    b = r;
                }
                gcd = a;
                value = e;
            }

            return value;
        }

        private (int gcd, int x, int y) AdvAlgEuclid(int a, int b)
        {
            if (b == 0)
            {
                return (a, 1, 0);
            }

            var (gcd, x1, y1) = AdvAlgEuclid(b, a % b);

            int x = y1;
            int y = x1 - (a / b) * y1;

            return (gcd, x, y);
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
            textBox1.Text = "";
            key = "";
            keyBin = "";
            data = "";
        }
    }
}
