using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public GOST()
        {
            InitializeComponent();
        }

        private void toolStripShifr_Click(object sender, EventArgs e)
        {
            int j = -1;
            int n = textBoxOriginal.Text.Length;
            if (n >= 4)
            {
                for (int i = 0; i < textBoxOriginal.Text.Length - 4; i += 4)
                {
                    if (j + 1 == 16)
                        j = 0;
                    else
                        j++;
                    long L0 = Convert.ToInt64(textBoxOriginal.Text[i]) *
                              Convert.ToInt64(Math.Pow(2, 16)) +
                              Convert.ToInt64(textBoxOriginal.Text[i + 1]);
                    long R0 = Convert.ToInt64(textBoxOriginal.Text[i + 2]) *
                              Convert.ToInt64(Math.Pow(2, 16)) +
                              Convert.ToInt64(textBoxOriginal.Text[i + 3]);
                    processed += (Convert.ToString(textBoxOriginal.Text[i + 2]) + 
                                  Convert.ToString(textBoxOriginal.Text[i + 3]));
                    long X0;
                    if(j!=15)
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
                    n -= 8;
                }
                if (n == 1)
                {
                    if (j + 1 == 16)
                        j = 0;
                    else
                        j++;
                    long L0 = Convert.ToInt64(Math.Pow(2, 16)) *
                              Convert.ToInt64(textBoxOriginal.Text[textBoxOriginal.Text.Length - 1]);
                    long R0 = 0;
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
                }
                if (n == 2)
                {
                    if (j + 1 == 16)
                        j = 0;
                    else
                        j++;
                    long L0 = Convert.ToInt64(textBoxOriginal.Text[textBoxOriginal.Text.Length - 2]) *
                              Convert.ToInt64(Math.Pow(2, 16)) +
                              Convert.ToInt64(textBoxOriginal.Text[textBoxOriginal.Text.Length - 1]);
                    long R0 = 0;
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
                }
                if (n == 3)
                {
                    if (j + 1 == 16)
                        j = 0;
                    else
                        j++;
                    long L0 = Convert.ToInt64(textBoxOriginal.Text[textBoxOriginal.Text.Length - 3]) *
                              Convert.ToInt64(Math.Pow(2, 16)) +
                              Convert.ToInt64(textBoxOriginal.Text[textBoxOriginal.Text.Length - 2]);
                    long R0 = Convert.ToInt64(Math.Pow(2, 16)) *
                              Convert.ToInt64(textBoxOriginal.Text[textBoxOriginal.Text.Length - 1]);
                    processed += Convert.ToString(textBoxOriginal.Text[textBoxOriginal.Text.Length - 1]);
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
                }
                textBoxProcessed.Text = processed;
                processed = "";
            }
        }
        static long Conversion(long R0, long X0)
        {
            long summ_mod32 = (R0 + X0)%Convert.ToInt64(Math.Pow(2, 32));
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
            for (int i = 31; i >= 15; i -= 16)
            {
                long kod = 0;
                for (int j = 0; j < 16; j++)
                {
                    kod += (R1[i - j] * Convert.ToInt64(Math.Pow(2, j)));
                }
                processed += Convert.ToChar(kod);
            }
        }

        private void toolStripCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxProcessed.Text);
        }

        private void toolStripCutOut_Click(object sender, EventArgs e)
        {
            textBoxOriginal.Clear();
            textBoxProcessed.Clear();
        }

        private void toolStripDeshifr_Click(object sender, EventArgs e)
        {

        }
    }
    
}
