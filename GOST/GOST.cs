using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOST
{
    public partial class GOST : Form
    {
        int[,] key = { { 1044, 1045 },
                       { 1044, 1051 },
                       { 1040, 1049 },
                       { 1053, 32 },
                       { 1073, 1083 },
                       { 1080, 1078 },
                       { 1077, 32 },
                       { 1089, 1087 },
                       { 1072, 1089 },
                       { 1072, 1081 },
                       { 1089, 1103 },
                       { 32, 1082 },
                       { 1090, 1086 },
                       { 32, 1084 },
                       { 1086, 1078 },
                       {1077, 1090 } };
        static int[,] substitution_block = { { 4, 14, 5, 7, 6, 4, 13, 1 },
                                             { 10, 11, 8, 13, 12, 11, 11, 15 },
                                             { 9, 4, 1, 10, 7, 10, 4, 13 },
                                             { 2, 12, 13, 1, 1, 0, 1, 0 },
                                             { 13, 6, 10, 0, 5, 7, 3, 5 },
                                             { 8, 13, 3, 8, 15, 2, 15, 7 },
                                             { 0, 15, 4, 9, 13, 1, 5, 10 },
                                             { 14, 10, 2, 15, 8, 13, 9, 4 },
                                             { 6, 2, 14, 14, 4, 3, 0, 9 },
                                             { 11, 3, 15, 4, 10, 6, 10, 2 },
                                             { 1, 8, 12, 6, 9, 8, 14, 3 },
                                             { 12, 1, 7, 12, 14, 5, 7, 14 },
                                             { 7, 0, 6, 11, 0, 9, 6, 6 },
                                             { 15, 7, 0, 2, 3, 12, 8, 11 },
                                             { 5, 5, 9, 5, 11, 15, 2, 8 },
                                             { 3, 9, 11, 3, 2, 14, 12, 12 } };
        static string processed = "";
        string textFromFile = "";
        string ext = "", sizeFile = "", fileNameDeshifr = "";
        public GOST()
        {
            InitializeComponent();
        }

        private void toolStripShifr_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (textBoxOriginal.Text != "" && textBoxOriginal.Text != "Выберете, что хотите сделать с файлом, и обработка начнется")
            {
                textFromFile = textBoxOriginal.Text;
                flag = true;
            }
            textBoxProcessed.Text = "Идет обработка данных...";
            int j = -1;
            int n = textFromFile.Length;
            if (n % 4 != 0) for (int i = 0; i < 4 - n % 4; i++) textFromFile += " ";
            for (int i = 0; i <= textFromFile.Length - 4; i += 4)
            {
                j = (j + 1) % 16;
                long L0 = Convert.ToInt64(textFromFile[i]) *
                          Convert.ToInt64(Math.Pow(2, 16)) +
                          Convert.ToInt64(textFromFile[i + 1]);
                long R0 = Convert.ToInt64(textFromFile[i + 2]) *
                          Convert.ToInt64(Math.Pow(2, 16)) +
                          Convert.ToInt64(textFromFile[i + 3]);
                processed += (Convert.ToString(textFromFile[i + 2]) +
                              Convert.ToString(textFromFile[i + 3]));
                long X0;
                if (j != 15)
                    X0 = key[j, 0] * Convert.ToInt64(Math.Pow(2, 16)) + key[j, 1];
                else
                    X0 = key[j, 1] * Convert.ToInt64(Math.Pow(2, 16)) + key[j, 0];
                long[] L0Xor = new long[32];
                long[] resultXor = new long[32];
                long result = Conversion(R0, X0);
                for (int p = 31; p >= 0; p--)
                {
                    L0Xor[p] = L0 % 2;
                    L0 /= 2;
                    resultXor[p] = result % 2;
                    result /= 2;
                }
                long[] R1 = Xor(L0Xor, resultXor);
                Processing(R1);
                n -= 4;
            }
            if (!flag)
            {
                StreamWriter sw = new StreamWriter("GOST-" + sizeFile + "-" + ext + "-.txt");
                sw.Write(processed);
                sw.Close();
                textBoxProcessed.Text = "Обработанные данные сохранены в файл, с названием " + "GOST-" + sizeFile + "-" + ext + "-.txt";
            }
            else
            {
                textBoxProcessed.Text = processed;
                buttonCarryover.Show();
            }
            processed = "";

        }

        static long Conversion(long R0, long X0)
        {
            long summ_mod32 = (R0 + X0) % Convert.ToInt64(Math.Pow(2, 32));
            long[] line = new long[8];
            for (int i = 0; i < 8; i++)
            {
                line[i] = summ_mod32 % 16;
                summ_mod32 /= 16;
            }
            for (int i = 0; i < 8; i++)
            {
                line[i] = substitution_block[line[i], i];
            }
            return ((line[0] * Convert.ToInt64(Math.Pow(2, 28)) +
                     line[1] * Convert.ToInt64(Math.Pow(2, 24)) +
                     line[2] * Convert.ToInt64(Math.Pow(2, 20)) +
                     line[3] * Convert.ToInt64(Math.Pow(2, 16)) +
                     line[4] * Convert.ToInt64(Math.Pow(2, 12)) +
                     line[5] * Convert.ToInt64(Math.Pow(2, 8)) +
                     line[6] * Convert.ToInt64(Math.Pow(2, 4))
                     + line[7]) << 11);
        }

        static long[] Xor(long[] L0Xor, long[] resultXor)
        {
            long[] R1 = new long[32];
            for (int i = 0; i < 32; i++)
            {
                if (L0Xor[i] == resultXor[i])
                    R1[i] = 0;
                else
                    R1[i] = 1;
            }
            return R1;
        }

        static void Processing(long[] R1)
        {
            long kod = 0;
            for (int j = 0; j < 16; j++)
            {
                kod += (R1[j] * Convert.ToInt64(Math.Pow(2, 15 - j)));
            }
            processed += Convert.ToChar(kod);
            kod = 0;
            for (int j = 16; j < 32; j++)
            {
                kod += (R1[j] * Convert.ToInt64(Math.Pow(2, 15 - (j - 16))));
            }
            processed += Convert.ToChar(kod);
        }

        private void toolStripCutOut_Click(object sender, EventArgs e)
        {

            textBoxOriginal.Text = null;

            pictureBoxOriginal.Image = null;
            pictureBoxOriginal.Hide();

            axWindowsMediaPlayerOriginal.URL = null;
            axWindowsMediaPlayerOriginal.Hide();

            textBoxProcessed.Text = null;

            buttonCarryover.Hide();

            try
            {
                Clipboard.SetText(textBoxProcessed.Text);
            }
            catch
            {
                MessageBox.Show("Поля очищены");
            } 
        } 

        private void toolStripDeshifr_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (textBoxOriginal.Text != "" && textBoxOriginal.Text != "Выберете, что хотите сделать с файлом, и обработка начнется")
            {
                textFromFile = textBoxOriginal.Text;
                flag = true;
            }
            int j = -1;
            int n = textFromFile.Length;
            textBoxProcessed.Text = "Идет обработка данных...";
            if (n % 4 != 0) for (int i = 0; i < 4 - n % 4; i++) textFromFile += " ";
            for (int i = 0; i <= textFromFile.Length - 4; i += 4)
            {
                j = (j + 1) % 16;
                long R0 = Convert.ToInt64(textFromFile[i]) *
                          Convert.ToInt64(Math.Pow(2, 16)) +
                          Convert.ToInt64(textFromFile[i + 1]);
                long R1 = Convert.ToInt64(textFromFile[i + 2]) *
                          Convert.ToInt64(Math.Pow(2, 16)) +
                          Convert.ToInt64(textFromFile[i + 3]);
                long X0;
                if (j != 15)
                    X0 = key[j, 0] * Convert.ToInt64(Math.Pow(2, 16)) + key[j, 1];
                else
                    X0 = key[j, 1] * Convert.ToInt64(Math.Pow(2, 16)) + key[j, 0];
                long[] R1Xor = new long[32];
                long[] resultXor = new long[32];
                long result = Conversion(R0, X0);
                for (int p = 31; p >= 0; p--)
                {
                    R1Xor[p] = R1 % 2;
                    R1 /= 2;
                    resultXor[p] = result % 2;
                    result /= 2;
                }
                long[] L0 = Xor(R1Xor, resultXor);
                Processing(L0);

                processed += Convert.ToChar(R0 / Convert.ToInt64(Math.Pow(2, 16)));
                processed += Convert.ToChar(R0 % Convert.ToInt64(Math.Pow(2, 16)));
                n -= 4;
            }
            if (!flag)
            {
                string[] fnd = fileNameDeshifr.Split('-');
                /*using (FileStream fstream = new FileStream("GOST-Deshifr" + fnd[2], FileMode.OpenOrCreate))
                {
                    byte[] array = Encoding.Default.GetBytes(processed);
                    fstream.Write(array, 0, Convert.ToInt32(fnd[1]) * 1024);
                    fstream.Close();
                }*/
               /* StreamWriter sw = new StreamWriter("GOST-Deshifr" + fnd[2]);
                sw.Write(processed);
                sw.Close();*/
                textBoxProcessed.Text = "Обработанные данные сохранены в файл, с названием " + "GOST-Deshifr" + fnd[2];
            }
            else
            {
                textBoxProcessed.Text = processed;
                buttonCarryover.Show();
            }
            processed = "";
        }

        private void buttonCarryover_Click(object sender, EventArgs e)
        {
            textBoxOriginal.Text = textBoxProcessed.Text;
            textBoxProcessed.Clear();
        }

        private void toolStripAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fstream = File.OpenRead(op.FileName))
                {
                    sizeFile = "" + Convert.ToDouble(fstream.Length / 1024) + "Kб";
                    fileNameDeshifr = op.FileName;
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    textFromFile = Encoding.Default.GetString(array);
                    fstream.Close();
                }
                
                ext = Path.GetExtension(op.FileName);
                if (ext == ".txt")
                {
                    textBoxOriginal.Text = "Выберете, что хотите сделать с файлом, и обработка начнется";
                }
                if (ext == ".jpg" || ext == ".png")
                {
                    pictureBoxOriginal.Image = Image.FromFile(op.FileName);
                    pictureBoxOriginal.Show();
                }
                if (ext == ".mp4" || ext == ".mp3")
                {
                    axWindowsMediaPlayerOriginal.URL = op.FileName;
                    axWindowsMediaPlayerOriginal.Show();
                }
            }
        }
    }
}
