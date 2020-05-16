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
        string textFromFile = "", ext = "", sizeFile = "", fileNameDeshifr = "", demoR02 = "", demoR03="";
        bool flagDemo = false, flagDemoShifr = false, flagDemoDeshifr = false;
        int flagFurther = 0, schDemo = 0, schDemoKey = -1;
        long demoResult, demoL0, demoR0, demoX0, demoDR0, demoDR1;

        public GOST()
        {
            InitializeComponent();
        }

        private void toolStripShifr_Click(object sender, EventArgs e)
        {
            if (!flagDemo)
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
                    StreamWriter sw = new StreamWriter("GOST-" + sizeFile + "-" + ext + "-.txt", false, Encoding.UTF8);
                    sw.Write(processed);
                    sw.Close();
                    textBoxProcessed.Text = "Обработанные данные сохранены в файл, с названием " + "GOST-" + sizeFile + "-" + ext + "-.txt";
                }
                else
                {
                    labelProcessed.Text = "Обработанные данные";
                    buttonCarryover.Show();

                    textBoxProcessed.Text = processed;
                }
                processed = "";
            }
            else
            {
                textBoxProcessed.Text = "Нажмите далее и демострация начнется";
                buttonFurther.Show();
                flagDemoShifr = true;
            }
        }
        static string Binary(long x)
        {
            long[] mas = new long[16];
            string s = "";
            for(int i = 15; i>=0; i--)
            {
                mas[i] = x % 2;
                x /= 2;
            }
            for(int i = 0; i<16; i++)
            {
                s += mas[i];
            }
            return s;
        }
        public long Conversion(long R0, long X0)
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
            long line2 = line[0] * Convert.ToInt64(Math.Pow(2, 28)) +
                     line[1] * Convert.ToInt64(Math.Pow(2, 24)) +
                     line[2] * Convert.ToInt64(Math.Pow(2, 20)) +
                     line[3] * Convert.ToInt64(Math.Pow(2, 16)) +
                     line[4] * Convert.ToInt64(Math.Pow(2, 12)) +
                     line[5] * Convert.ToInt64(Math.Pow(2, 8)) +
                     line[6] * Convert.ToInt64(Math.Pow(2, 4))
                     + line[7];
            if (flagDemo)
            {
                labelDemoInfo1.Text = "Вычисление суммы R0 и X0 по mod2^32:";
                labelDemoInfo2.Show();
                labelDemoInfo3.Text = "Циклический сдвиг влево на 11 бит:";
                labelDemoInfo3.Show();
                labelR0R0.Hide();
                labelL0R1.Hide();
                labelX0.Hide();
                textBoxL01.Hide();
                textBoxL02.Hide();
                textBoxL03.Hide();
                textBoxL04.Hide();
                textBoxR01.Hide();
                textBoxR02.Hide();
                textBoxR03.Hide();
                textBoxR04.Hide();
                textBoxX01.Text = "";
                textBoxX02.Text = "";
                textBoxX01.Hide();
                textBoxX02.Hide();
                textBoxX03.Hide();
                textBoxX04.Hide();

                textBoxR11.Show();
                textBoxR12.Show();
                textBoxR13.Show();

                textBoxR11.Text = Binary(summ_mod32 / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                  Binary(summ_mod32 % Convert.ToInt64(Math.Pow(2, 16)));
                textBoxR12.Text = Binary(line2 / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                  Binary(line2 % Convert.ToInt64(Math.Pow(2, 16)));
                textBoxR13.Text = Binary((line2 << 11) / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                  Binary((line2 << 11) % Convert.ToInt64(Math.Pow(2, 16)));
            }
            return line2 << 11;
        }

        public long[] Xor(long[] L0Xor, long[] resultXor)
        {
            long[] R1 = new long[32];
            for (int i = 0; i < 32; i++)
            {
                if (L0Xor[i] == resultXor[i])
                    R1[i] = 0;
                else
                    R1[i] = 1;
            }
            if(flagDemo)
            {
                if (flagDemoShifr)
                {
                    labelDemoInfo1.Text = "Складываем данный результат с L0 по mod2";
                    labelL0R1.Text = "R1";
                }
                else
                {
                    labelDemoInfo1.Text = "Складываем данный результат с R1 по mod2";
                    labelL0R1.Text = "L0";
                }
                labelL0R1.Show();
                labelR0.Show();
                string s = "";
                for(int i=0; i<16; i++)
                {
                    s += R1[i];
                }
                s += " ";
                for (int i = 16; i < 32; i++)
                {
                    s += R1[i];
                }
                textBoxR12.Text = s;
                labelDemoInfo2.Hide();
                textBoxR12.Hide();
                if(flagDemoShifr)
                    labelDemoInfo3.Text = "Зашифрованные данные";
                else
                    labelDemoInfo3.Text = "Дешифрованные данные";
                labelR0R0.Text = "R0";
                labelR0R0.Show();
                textBoxR12.Show();
                if (flagDemoShifr)
                {
                    labelR0.Text = "R0";
                    labelR1.Text = "R1";
                }
                else
                {
                    labelR0.Text = "L0";
                    labelR1.Text = "R0";
                }
                labelR0.Show();
                labelR1.Show();
                textBoxR13.Hide();
                textBoxX01.Show();
                textBoxX02.Show();
            }
            return R1;
        }

        public void Processing(long[] R1)
        {
            long kod = 0;
            for (int j = 0; j < 16; j++)
            {
                kod += (R1[j] * Convert.ToInt64(Math.Pow(2, 15 - j)));
            }
            processed += Convert.ToChar(kod);
            if(flagDemoShifr)
                textBoxX02.Text += Convert.ToChar(kod);
            else
                textBoxX01.Text += Convert.ToChar(kod);
            kod = 0;
            for (int j = 16; j < 32; j++)
            {
                kod += (R1[j] * Convert.ToInt64(Math.Pow(2, 15 - (j - 16))));
            }
            processed += Convert.ToChar(kod);
            if (flagDemoShifr)
                textBoxX02.Text += Convert.ToChar(kod);
            else
                textBoxX01.Text += Convert.ToChar(kod);
        }

        private void toolStripCutOut_Click(object sender, EventArgs e)
        {
            labelProcessed.Text = "Информация о процессе";
            if (flagDemo)
            {
                labelKey.Hide();
                textBoxKey.Hide();
                textBoxOriginal.Show();
                pictureBoxDemoShifr0.Hide();
                pictureBoxDemoShifr1.Hide();
                pictureBoxDemoShifr2.Hide();
                pictureBoxDemoDeshifr0.Hide();
                pictureBoxDemoDeshifr1.Hide();
                pictureBoxDemoDeshifr2.Hide();
                flagDemo = false;
                flagDemoShifr = false;
                flagDemoDeshifr = false;
                flagFurther = 0;
                schDemo = 0; 
                schDemoKey = -1;
                labelDemoInfo1.Hide();
                labelDemoInfo2.Hide();
                labelDemoInfo3.Hide();
                textBoxR11.Hide();
                textBoxR12.Hide();
                textBoxR13.Hide();
                labelR0.Hide();
                labelR1.Hide();
                labelR0R0.Hide();
                labelL0R1.Hide();
                labelX0.Hide();
                textBoxProcessed.Show();
                textBoxL01.Hide();
                textBoxL02.Hide();
                textBoxL03.Hide();
                textBoxL04.Hide();
                textBoxR01.Hide();
                textBoxR02.Hide();
                textBoxR03.Hide();
                textBoxR04.Hide();
                textBoxX01.Hide();
                textBoxX02.Hide();
                textBoxX03.Hide();
                textBoxX04.Hide();
                buttonFurther.Hide();
            }

            textBoxOriginal.Text = "";

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
            if (!flagDemo)
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
                    StreamWriter sw = new StreamWriter("GOST-Deshifr" + fnd[fnd.Length - 2], false, Encoding.UTF8);
                    sw.Write(processed);
                    sw.Close();
                    textBoxProcessed.Text = "Обработанные данные сохранены в файл, с названием " + "GOST-Deshifr" + fnd[fnd.Length - 2];
                }
                else
                {
                    textBoxProcessed.Text = processed;
                    buttonCarryover.Show();
                }
                processed = "";
            }
            else
            {
                textBoxProcessed.Text = "Нажмите далее и демострация начнется";
                buttonFurther.Show();
                flagDemoDeshifr = true;
            }
        }
        
        private void buttonFurther_Click(object sender, EventArgs e)
        {
            labelKey.Show();
            textBoxKey.Show();
            if (flagDemoShifr)
            {
                int n;
                textBoxOriginal.Hide();
                if (flagFurther == 0)
                {
                    pictureBoxDemoShifr2.Hide();
                    pictureBoxDemoShifr0.Show();
                    n = textBoxOriginal.Text.Length;
                    if (n % 4 != 0) for (int i = 0; i < 4 - n % 4; i++) textBoxOriginal.Text += " ";
                    schDemoKey = (schDemoKey + 1) % 16;

                    demoL0 = Convert.ToInt64(textBoxOriginal.Text[schDemo]) *
                              Convert.ToInt64(Math.Pow(2, 16)) +
                              Convert.ToInt64(textBoxOriginal.Text[schDemo + 1]);
                    demoR0 = Convert.ToInt64(textBoxOriginal.Text[schDemo + 2]) *
                              Convert.ToInt64(Math.Pow(2, 16)) +
                              Convert.ToInt64(textBoxOriginal.Text[schDemo + 3]);
                    processed += (Convert.ToString(textBoxOriginal.Text[schDemo + 2]) +
                                  Convert.ToString(textBoxOriginal.Text[schDemo + 3]));
                    demoR02 = Convert.ToString(textBoxOriginal.Text[schDemo + 2]) +
                                  Convert.ToString(textBoxOriginal.Text[schDemo + 3]);

                    if (schDemoKey != 15)
                        demoX0 = key[schDemoKey, 0] * Convert.ToInt64(Math.Pow(2, 16)) + key[schDemoKey, 1];
                    else
                        demoX0 = key[schDemoKey, 1] * Convert.ToInt64(Math.Pow(2, 16)) + key[schDemoKey, 0];

                    buttonFurther.Show();
                    textBoxProcessed.Hide();
                    labelR0.Hide();
                    labelR1.Hide();
                    textBoxR11.Hide();
                    textBoxR12.Hide();
                    labelDemoInfo1.Text = "Данные для шифрования:";
                    labelDemoInfo1.Show();
                    labelL0R1.Text = "L0";
                    labelL0R1.Show();
                    labelR0R0.Text = "R0";
                    labelR0R0.Show();
                    labelX0.Show();
                    textBoxL01.Show();
                    textBoxL02.Show();
                    textBoxL03.Show();
                    textBoxL04.Show();
                    textBoxR01.Show();
                    textBoxR02.Show();
                    textBoxR03.Show();
                    textBoxR04.Show();
                    textBoxX01.Show();
                    textBoxX02.Show();
                    textBoxX03.Show();
                    textBoxX04.Show();

                    labelDemoInfo3.Text = "Подключ:";
                    labelDemoInfo3.Show();

                    textBoxL01.Text = Convert.ToString(textBoxOriginal.Text[schDemo]);
                    textBoxL02.Text = Convert.ToString(textBoxOriginal.Text[schDemo + 1]);
                    textBoxL03.Text = Binary(demoL0 / Convert.ToInt64(Math.Pow(2, 16)));
                    textBoxL04.Text = Binary(demoL0 % Convert.ToInt64(Math.Pow(2, 16)));

                    textBoxR01.Text = Convert.ToString(textBoxOriginal.Text[schDemo + 2]);
                    textBoxR02.Text = Convert.ToString(textBoxOriginal.Text[schDemo + 3]);
                    textBoxR03.Text = Binary(demoR0 / Convert.ToInt64(Math.Pow(2, 16)));
                    textBoxR04.Text = Binary(demoR0 % Convert.ToInt64(Math.Pow(2, 16)));

                    demoR03 = textBoxR03.Text + "" + textBoxR04.Text;

                    textBoxX01.Text = Convert.ToString(Convert.ToChar(demoX0 / Convert.ToInt64(Math.Pow(2, 16))));
                    textBoxX02.Text = Convert.ToString(Convert.ToChar(demoX0 % Convert.ToInt64(Math.Pow(2, 16))));
                    textBoxX03.Text = Binary(demoX0 / Convert.ToInt64(Math.Pow(2, 16)));
                    textBoxX04.Text = Binary(demoX0 % Convert.ToInt64(Math.Pow(2, 16)));

                    flagFurther = 1;
                }
                else
                {
                    if (flagFurther == 1)
                    {
                        pictureBoxDemoShifr0.Hide();
                        pictureBoxDemoShifr1.Show();
                        demoResult = Conversion(demoR0, demoX0);
                        flagFurther = 2;
                    }
                    else
                    {
                        if (flagFurther == 2)
                        {
                            pictureBoxDemoShifr1.Hide();
                            pictureBoxDemoShifr2.Show();
                            long[] L0Xor = new long[32];
                            long[] resultXor = new long[32];
                            for (int p = 31; p >= 0; p--)
                            {
                                L0Xor[p] = demoL0 % 2;
                                demoL0 /= 2;
                                resultXor[p] = demoResult % 2;
                                demoResult /= 2;
                            }
                            long[] R1 = Xor(L0Xor, resultXor);

                            long[] R00 = new long[32];
                            string s = Binary(demoR0 / Convert.ToInt64(Math.Pow(2, 16)));
                            for (int i = 0; i < 16; i++)
                            {
                                R00[i] = Convert.ToInt64(s[i]);
                            }
                            s = Binary(demoR0 % Convert.ToInt64(Math.Pow(2, 16)));
                            for (int i = 0; i < 16; i++)
                            {
                                R00[i + 16] = Convert.ToInt64(s[i]);
                            }
                            textBoxX01.Text = demoR02;
                            Processing(R1);
                            if (schDemo != textBoxOriginal.Text.Length - 4)
                            {
                                schDemo += 4;
                                flagFurther = 0;
                            }
                            else
                            {
                                buttonFurther.Text = "Конец";
                                flagFurther = 3;
                            }
                        }
                        else
                        {
                            flagDemoShifr = false;
                            labelKey.Hide();
                            textBoxKey.Hide();
                            textBoxOriginal.Show();
                            pictureBoxDemoShifr0.Hide();
                            pictureBoxDemoShifr1.Hide();
                            pictureBoxDemoShifr2.Hide();
                            flagDemo = false;
                            flagFurther = 0;
                            schDemo = 0;
                            schDemoKey = -1;
                            labelDemoInfo1.Hide();
                            textBoxR11.Hide();
                            labelDemoInfo2.Hide();
                            textBoxR12.Hide();
                            labelDemoInfo3.Hide();
                            textBoxR13.Hide();
                            labelR0.Hide();
                            labelR1.Hide();
                            labelR0R0.Hide();
                            labelL0R1.Hide();
                            textBoxProcessed.Text = "";
                            textBoxProcessed.Show();
                            textBoxL01.Hide();
                            textBoxL02.Hide();
                            textBoxL03.Hide();
                            textBoxL04.Hide();
                            textBoxR01.Hide();
                            textBoxR02.Hide();
                            textBoxR03.Hide();
                            textBoxR04.Hide();
                            textBoxX01.Hide();
                            textBoxX02.Hide();
                            textBoxX03.Hide();
                            textBoxX04.Hide();
                            textBoxOriginal.Text = "";
                            labelProcessed.Text = "Информация о процессе";
                            buttonFurther.Hide();
                            buttonFurther.Text = "Далее";
                        }
                    }
                }
            }
            else
            {
                if (flagDemoDeshifr)
                {
                    int n;
                    textBoxOriginal.Hide();
                    if (flagFurther == 0)
                    {
                        pictureBoxDemoDeshifr2.Hide();
                        pictureBoxDemoDeshifr0.Show();
                        n = textBoxOriginal.Text.Length;
                        if (n % 4 != 0) for (int i = 0; i < 4 - n % 4; i++) textBoxOriginal.Text += " ";
                        schDemoKey = (schDemoKey + 1) % 16;

                        demoDR0 = Convert.ToInt64(textBoxOriginal.Text[schDemo]) *
                                  Convert.ToInt64(Math.Pow(2, 16)) +
                                  Convert.ToInt64(textBoxOriginal.Text[schDemo + 1]);
                        demoDR1 = Convert.ToInt64(textBoxOriginal.Text[schDemo + 2]) *
                                  Convert.ToInt64(Math.Pow(2, 16)) +
                                  Convert.ToInt64(textBoxOriginal.Text[schDemo + 3]);
                        demoR02 = Convert.ToString(textBoxOriginal.Text[schDemo]) +
                                      Convert.ToString(textBoxOriginal.Text[schDemo + 1]);

                        if (schDemoKey != 15)
                            demoX0 = key[schDemoKey, 0] * Convert.ToInt64(Math.Pow(2, 16)) + key[schDemoKey, 1];
                        else
                            demoX0 = key[schDemoKey, 1] * Convert.ToInt64(Math.Pow(2, 16)) + key[schDemoKey, 0];

                        buttonFurther.Show();
                        textBoxProcessed.Hide();
                        labelR0.Hide();
                        labelR1.Hide();
                        textBoxR11.Hide();
                        textBoxR12.Hide();
                        labelDemoInfo1.Text = "Данные для шифрования:";
                        labelDemoInfo1.Show();
                        labelL0R1.Text = "R0";
                        labelL0R1.Show();
                        labelR0R0.Text = "R1";
                        labelR0R0.Show();
                        labelX0.Show();
                        textBoxL01.Show();
                        textBoxL02.Show();
                        textBoxL03.Show();
                        textBoxL04.Show();
                        textBoxR01.Show();
                        textBoxR02.Show();
                        textBoxR03.Show();
                        textBoxR04.Show();
                        textBoxX01.Show();
                        textBoxX02.Show();
                        textBoxX03.Show();
                        textBoxX04.Show();

                        labelDemoInfo3.Text = "Подключ:";
                        labelDemoInfo3.Show();

                        textBoxL01.Text = Convert.ToString(textBoxOriginal.Text[schDemo]);
                        textBoxL02.Text = Convert.ToString(textBoxOriginal.Text[schDemo + 1]);
                        textBoxL03.Text = Binary(demoL0 / Convert.ToInt64(Math.Pow(2, 16)));
                        textBoxL04.Text = Binary(demoL0 % Convert.ToInt64(Math.Pow(2, 16)));

                        textBoxR01.Text = Convert.ToString(textBoxOriginal.Text[schDemo + 2]);
                        textBoxR02.Text = Convert.ToString(textBoxOriginal.Text[schDemo + 3]);
                        textBoxR03.Text = Binary(demoR0 / Convert.ToInt64(Math.Pow(2, 16)));
                        textBoxR04.Text = Binary(demoR0 % Convert.ToInt64(Math.Pow(2, 16)));

                        demoR03 = textBoxR03.Text + "" + textBoxR04.Text;

                        textBoxX01.Text = Convert.ToString(Convert.ToChar(demoX0 / Convert.ToInt64(Math.Pow(2, 16))));
                        textBoxX02.Text = Convert.ToString(Convert.ToChar(demoX0 % Convert.ToInt64(Math.Pow(2, 16))));
                        textBoxX03.Text = Binary(demoX0 / Convert.ToInt64(Math.Pow(2, 16)));
                        textBoxX04.Text = Binary(demoX0 % Convert.ToInt64(Math.Pow(2, 16)));

                        flagFurther = 1;
                    }
                    else
                    {
                        if (flagFurther == 1)
                        {
                            pictureBoxDemoDeshifr0.Hide();
                            pictureBoxDemoDeshifr1.Show();
                            demoResult = Conversion(demoDR0, demoX0);
                            flagFurther = 2;
                        }
                        else
                        {
                            if (flagFurther == 2)
                            {
                                pictureBoxDemoDeshifr1.Hide();
                                pictureBoxDemoDeshifr2.Show();
                                long[] R1Xor = new long[32];
                                long[] resultXor = new long[32];
                                for (int p = 31; p >= 0; p--)
                                {
                                    R1Xor[p] = demoDR1 % 2;
                                    demoDR1 /= 2;
                                    resultXor[p] = demoResult % 2;
                                    demoResult /= 2;
                                }
                                long[] L0 = Xor(R1Xor, resultXor);
                                long[] R00 = new long[32];
                                string s = Binary(demoDR1 / Convert.ToInt64(Math.Pow(2, 16)));
                                for (int i = 0; i < 16; i++)
                                {
                                    R00[i] = Convert.ToInt64(s[i]);
                                }
                                s = Binary(demoDR1 % Convert.ToInt64(Math.Pow(2, 16)));
                                for (int i = 0; i < 16; i++)
                                {
                                    R00[i + 16] = Convert.ToInt64(s[i]);
                                }
                                textBoxX02.Text = demoR02;
                                Processing(L0);
                                processed += demoR02;
                                if (schDemo != textBoxOriginal.Text.Length - 4)
                                {
                                    schDemo += 4;
                                    flagFurther = 0;
                                }
                                else
                                {
                                    buttonFurther.Text = "Конец";
                                    flagFurther = 3;
                                }
                            }
                            else
                            {
                                flagDemoDeshifr = false;
                                labelKey.Hide();
                                textBoxKey.Hide();
                                textBoxOriginal.Show();
                                pictureBoxDemoDeshifr0.Hide();
                                pictureBoxDemoDeshifr1.Hide();
                                pictureBoxDemoDeshifr2.Hide();
                                flagDemo = false;
                                flagFurther = 0;
                                schDemo = 0;
                                schDemoKey = -1;
                                labelDemoInfo1.Hide();
                                textBoxR11.Hide();
                                labelDemoInfo2.Hide();
                                textBoxR12.Hide();
                                labelDemoInfo3.Hide();
                                textBoxR13.Hide();
                                labelR0.Hide();
                                labelR1.Hide();
                                labelR0R0.Hide();
                                labelL0R1.Hide();
                                textBoxProcessed.Text = "";
                                textBoxProcessed.Show();
                                textBoxL01.Hide();
                                textBoxL02.Hide();
                                textBoxL03.Hide();
                                textBoxL04.Hide();
                                textBoxR01.Hide();
                                textBoxR02.Hide();
                                textBoxR03.Hide();
                                textBoxR04.Hide();
                                textBoxX01.Hide();
                                textBoxX02.Hide();
                                textBoxX03.Hide();
                                textBoxX04.Hide();
                                textBoxOriginal.Text = "";
                                labelProcessed.Text = "Информация о процессе";
                                buttonFurther.Hide();
                                buttonFurther.Text = "Далее";
                            }
                        }
                    }
                }
            }
        }

        private void toolStripDemo_Click(object sender, EventArgs e)
        {
            flagDemo = true;
            if (textBoxOriginal.Text != "")
            {
                labelProcessed.Text = "Демонстрационный режим";
                textBoxProcessed.Text = "Выберите режим обработки данных (шифрование/дешифрование)";
            }
            else
            {
                MessageBox.Show("Введите исходные данные и затем повторите попытку");
            }
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
                    sizeFile = "" + fstream.Length;
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
                else
                if (ext == ".jpg" || ext == ".png")
                {
                    pictureBoxOriginal.Image = Image.FromFile(op.FileName);
                    pictureBoxOriginal.Show();
                }
                else
                if (ext == ".mp4" || ext == ".mp3")
                {
                    axWindowsMediaPlayerOriginal.URL = op.FileName;
                    axWindowsMediaPlayerOriginal.Show();
                }
                else
                    MessageBox.Show("Извините, но данный тип файла не поддерживается. " +
                        "Если вы считаете, что тип файла корректен, сообщите нам, и мы исправим ошибку.");
            }
        }
    }
}
