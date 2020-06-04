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
        static int[,] key = { { 1044, 1045 },
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
        string processed = "",  textFromFile = "", ext = "", sizeFile = "", fileNameDeshifr = "", demoR02 = "", demoR03="";
        bool flagDemo = false, flagDemoShifr = false, flagDemoDeshifr = false;
        int flagFurther = 0, schDemo = 0, schDemoKey = -1;
        long demoResult, demoL0, demoR0, demoX0, demoDR0, demoDR1;

        private void ToolStripMenuItemInfoHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для того, чтобы зашифровать/дешифровать небольшой текст, введите его в поле " + '"' + "Исходные данные" + '"'
                +  ", если же вам нужно зашифровать/дешифровать текст большого объема, картинку, видео или аудио, то нажмите на кнопку со знаком скрепки для того, чтобы прикрепить нужный файл " + 
                "и нажмите кнопку со знаком замка для шифрования или со знаком ключа для дешифрования." + '\n' + '\n' +
                "Для демонстрационного режима введите текст в поле " + '"' + "Исходные данные" + '"' + ", нажмите кнопку со знаком глаза и лупы, далее кнопку со знаком замка (для шифрования) или ключа(для дешифрования)." + '\n' + '\n' +
                "Чтобы очистить поля и начать работу с программой сначала, нажмите кнопку со знаком пустого листа. Если вы вводили текст от руки, то при нажатии на эту кнопку обработанные данные скопируются в буфер обмена.");
        }

        private void ToolStripMenuItemInfoAboutTheProgramm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа: Стандарт шифрования ГОСТ" + '\n' + '\n' +
                "Изготовлена в рамках проектной работы по окончании первого курса ФМИТ СОГУ" + '\n' + '\n' +
                "Разработчик: Галустьян Евгения" + '\n' + '\n' +
                "Руководитель: Гутнова Алина" + '\n' + '\n' +
                "Версия: 0.3");
        }

        public GOST()
        {
            InitializeComponent();
        }

        private void toolStripShifr_Click(object sender, EventArgs e)
        {
            if (!flagDemo)
            {
                bool flag = false;
                if (textBoxOriginal.Text != "")
                {
                    textFromFile = textBoxOriginal.Text;
                    flag = true;
                }
                textBoxProcessed.Text = "Идет обработка данных...";
                
                int n = textFromFile.Length;
                if (n % 4 != 0) for (int i = 0; i < 4 - n % 4; i++) textFromFile += " ";
                GOST147 shifr = new GOST147(key, textFromFile);
                processed = shifr.Encrypt();
                if (!flag)
                {
                    using (FileStream fstream = new FileStream("GOST-" + sizeFile + "-" + ext + "-.txt", FileMode.OpenOrCreate))
                    {
                        byte[] array = Encoding.Default.GetBytes(processed);
                        fstream.Write(array, 0, array.Length);
                    }
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
        public string Binary(long x)
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

            pictureBoxOriginal.Image = null;
            pictureBoxOriginal.Hide();

            axWindowsMediaPlayerOriginal.URL = null;
            axWindowsMediaPlayerOriginal.Hide();

            buttonCarryover.Hide();

            if (textBoxProcessed.Text == "" && textBoxOriginal.Text == "")
                MessageBox.Show("Поля очищены");

            textBoxOriginal.Text = "";
            textBoxProcessed.Text = "";
        } 

        private void toolStripDeshifr_Click(object sender, EventArgs e)
        {
            if (!flagDemo)
            {
                bool flag = false;
                if (textBoxOriginal.Text != "")
                {
                    textFromFile = textBoxOriginal.Text;
                    flag = true;
                }
                int n = textFromFile.Length;
                textBoxProcessed.Text = "Идет обработка данных...";
                if (n % 4 != 0) for (int i = 0; i < 4 - n % 4; i++) textFromFile += " ";
                GOST147 shifr = new GOST147(key, textFromFile);
                processed = shifr.Decrypt();
                if (!flag)
                {
                    string[] fnd = fileNameDeshifr.Split('-');
                    using (FileStream fstream = new FileStream("GOST-Deshifr" + fnd[fnd.Length - 2], FileMode.OpenOrCreate))
                    {
                        byte[] array = Encoding.Default.GetBytes(processed);
                        fstream.Write(array, 0, Convert.ToInt32(fnd[fnd.Length - 3]));
                    }
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
            GOST147 shifr = new GOST147(key, textBoxOriginal.Text);
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
                        demoResult = shifr.Conversion(demoR0, demoX0);

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
                        long summ_mod32 = (demoR0 + demoX0) % Convert.ToInt64(Math.Pow(2, 32));
                        textBoxR11.Text = Binary(summ_mod32 / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                          Binary(summ_mod32 % Convert.ToInt64(Math.Pow(2, 16)));
                        textBoxR12.Text = Binary((demoResult >> 11) / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                          Binary((demoResult >> 11) % Convert.ToInt64(Math.Pow(2, 16)));
                        textBoxR13.Text = Binary(demoResult / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                          Binary(demoResult % Convert.ToInt64(Math.Pow(2, 16)));
                        flagFurther = 2;
                    }
                    else
                    {
                        if (flagFurther == 2)
                        {
                            pictureBoxDemoShifr1.Hide();
                            pictureBoxDemoShifr2.Show();
                            long[] R1 = shifr.Xor(demoL0, demoResult);
                            labelDemoInfo1.Text = "Складываем данный результат с L0 по mod2";
                            labelL0R1.Text = "R1";
                            labelL0R1.Show();
                            labelR0.Show();
                            string ss = "";
                            for (int i = 0; i < 16; i++)
                            {
                                ss += R1[i];
                            }
                            ss += " ";
                            for (int i = 16; i < 32; i++)
                            {
                                ss += R1[i];
                            }
                            textBoxR12.Text = ss;
                            labelDemoInfo2.Hide();
                            textBoxR12.Hide();
                            labelDemoInfo3.Text = "Зашифрованные данные";
                            labelR0R0.Text = "R0";
                            labelR0R0.Show();
                            textBoxR12.Show();
                            labelR0.Text = "R0";
                            labelR1.Text = "R1";
                            labelR0.Show();
                            labelR1.Show();
                            textBoxR13.Hide();
                            textBoxX01.Show();
                            textBoxX02.Show();
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
                            string str = "";
                            str = shifr.Processing(R1, str);
                            textBoxX02.Text += str;
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
                            demoResult = shifr.Conversion(demoDR0, demoX0);

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
                            long summ_mod32 = (demoDR0 + demoX0) % Convert.ToInt64(Math.Pow(2, 32));
                            textBoxR11.Text = Binary(summ_mod32 / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                              Binary(summ_mod32 % Convert.ToInt64(Math.Pow(2, 16)));
                            textBoxR12.Text = Binary((demoResult >> 11) / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                              Binary((demoResult >> 11) % Convert.ToInt64(Math.Pow(2, 16)));
                            textBoxR13.Text = Binary(demoResult / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                              Binary(demoResult % Convert.ToInt64(Math.Pow(2, 16)));

                            flagFurther = 2;
                        }
                        else
                        {
                            if (flagFurther == 2)
                            {
                                pictureBoxDemoDeshifr1.Hide();
                                pictureBoxDemoDeshifr2.Show();
                                long[] L0 = shifr.Xor(demoDR1, demoResult);
                                labelDemoInfo1.Text = "Складываем данный результат с R1 по mod2";
                                labelL0R1.Text = "L0";
                                labelL0R1.Show();
                                labelR0.Show();
                                string ss = "";
                                for (int i = 0; i < 16; i++)
                                {
                                    ss += L0[i];
                                }
                                ss += " ";
                                for (int i = 16; i < 32; i++)
                                {
                                    ss += L0[i];
                                }
                                textBoxR12.Text = ss;
                                labelDemoInfo2.Hide();
                                textBoxR12.Hide();
                                labelDemoInfo3.Text = "Дешифрованные данные";
                                labelR0R0.Text = "R0";
                                labelR0R0.Show();
                                textBoxR12.Show();
                                labelR0.Text = "L0";
                                labelR1.Text = "R0";
                                labelR0.Show();
                                labelR1.Show();
                                textBoxR13.Hide();
                                textBoxX01.Show();
                                textBoxX02.Show();

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
                                string str = "";
                                str = shifr.Processing(L0, str);
                                textBoxX01.Text += str;
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
                    textBoxProcessed.Text = "Выберете, что хотите сделать с файлом, и обработка начнется";
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
