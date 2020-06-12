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
                       {1077, 1090 } };//ключ для шифрования/дешифрования данных
        string processed = ""; //переменная для обработанных данных
        string textFromFile = ""; //переменная для входных данных
        string ext = ""; //переменная для хранения расширения прикрепленного файла  
        string sizeFile = ""; //переменная для хранения размера прикрепленного файла
        string fileNameDeshifr = ""; //переменная для хванения названия прикрепленного файла, который нужно дешифровать
        string demoR02 = "";
        bool flagDemo = false; //истино, если включен демонстрационный режим
        bool flagDemoShifr = false; //истино, если если включен демонстрационный режим для шифрования
        bool flagDemoDeshifr = false; //истино, если если включен демонстрационный режим для дешифрования
        int flagFurther = 0; //счетчик для переключения шагов шифрования/дешифрования во время демонстрационного режима
        int schDemo = 0; //счетчик для переключения блоков шифрования во время демонстрационного режима
        int schDemoKey = -1; //счетчик для смены подключа во время демонстрационного режима
        long demoResult, demoL0, demoR0, demoX0, demoDR0, demoDR1;

        private void ToolStripMenuItemInfoHelp_Click(object sender, EventArgs e)//активируется при нажатии на кнопку "Информация\Справка"
        {
            MessageBox.Show("Для того, чтобы зашифровать/дешифровать небольшой текст, введите его в поле " + '"' + "Исходные данные" + '"'
                +  ", если же вам нужно зашифровать/дешифровать текст большого объема, картинку, видео или аудио, то нажмите на кнопку со знаком скрепки для того, чтобы прикрепить нужный файл " + 
                "и нажмите кнопку со знаком замка для шифрования или со знаком ключа для дешифрования." + '\n' + '\n' +
                "Для демонстрационного режима введите текст в поле " + '"' + "Исходные данные" + '"' + ", нажмите кнопку со знаком глаза и лупы, далее кнопку со знаком замка (для шифрования) или ключа(для дешифрования)." + '\n' + '\n' +
                "Чтобы очистить поля и начать работу с программой сначала, нажмите кнопку со знаком пустого листа. Если вы вводили текст от руки, то при нажатии на эту кнопку обработанные данные скопируются в буфер обмена.", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ToolStripMenuItemInfoAboutTheProgramm_Click(object sender, EventArgs e)//активируется при нажатии на кнопку "Информация\О программе"
        {
            MessageBox.Show("Программа: Стандарт шифрования ГОСТ" + '\n' + '\n' +
                "Изготовлена в рамках проектной работы по окончании первого курса ФМИТ СОГУ" + '\n' + '\n' +
                "Разработчик: Галустьян Евгения" + '\n' + '\n' +
                "Руководитель: Гутнова Алина" + '\n' + '\n' +
                "Версия: 0.3", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public GOST()
        {
            InitializeComponent();
        }

        private void toolStripShifr_Click(object sender, EventArgs e)//активируется при нажатии на кнопку “Зашифровать”
        {
            if (!flagDemo)
            {
                bool flag = false; //флаг для проверки того, введены данные вручную (принимает значение true) или же получены через файл (принимает значение false)
                if (textBoxOriginal.Text != "") //если тестовое поле не пусто, то данные введены вручную
                {
                    textFromFile = textBoxOriginal.Text;
                    flag = true;
                }
                textBoxProcessed.Text = "Идет обработка данных...";
                
                int n = textFromFile.Length;
                if (n % 4 != 0) for (int i = 0; i < 4 - n % 4; i++) textFromFile += " "; //дополнение входных данных пробелами в том случае, если они имеют недостаточное количество бит
                GOST28147 shifr = new GOST28147(key, textFromFile);
                processed = shifr.Encrypt();//шифрование входных данных в классе GOST28147
                if (!flag)//если данные были получены из файла, то зашифрованные данные сохраняются в файл с названием GOST-(размер исходного файла)-(расширение исходного файла)-.txt
                {
                    using (FileStream fstream = new FileStream("GOST-" + sizeFile + "-" + ext + "-.txt", FileMode.OpenOrCreate))
                    {
                        byte[] array = Encoding.Default.GetBytes(processed);
                        fstream.Write(array, 0, array.Length);
                    }
                    textBoxProcessed.Text = "Обработанные данные сохранены в файл, с названием " + "GOST-" + sizeFile + "-" + ext + "-.txt";
                }
                else//если данные были введены вручную, то зашифрованные данные появятся в текстовом поле в правой части формы
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
        public string Binary(long x)//функция для перевода входных данных в двоичную с.с.
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

        private void toolStripCutOut_Click(object sender, EventArgs e)//активируется при нажатии на кнопку “Очистить поля”
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

            textBoxOriginal.Text = "";
            textBoxProcessed.Text = "";
        } 

        private void toolStripDeshifr_Click(object sender, EventArgs e)//активируется при нажатии на кнопку “Дешифровать”
        {
            if (!flagDemo)
            {
                bool flag = false; //флаг для проверки того, введены данные вручную (принимает значение true) или же получены через файл (принимает значение false)
                if (textBoxOriginal.Text != "") //если тестовое поле не пусто, то данные введены вручную
                {
                    textFromFile = textBoxOriginal.Text;
                    flag = true;
                }
                int n = textFromFile.Length;
                textBoxProcessed.Text = "Идет обработка данных...";
                if (n % 4 != 0) for (int i = 0; i < 4 - n % 4; i++) textFromFile += " "; //дополнение входных данных пробелами в том случае, если они имеют недостаточное количество бит
                GOST28147 shifr = new GOST28147(key, textFromFile);
                processed = shifr.Decrypt(); //дешифрование входных данных в классе GOST28147
                if (!flag)//если данные были получены из файла, то зашифрованные данные сохраняются в файл с названием GOST-Deshifr.(расширение ранее зашифрованного файла)
                {
                    string[] fnd = fileNameDeshifr.Split('-');
                    using (FileStream fstream = new FileStream("GOST-Deshifr" + fnd[fnd.Length - 2], FileMode.OpenOrCreate))
                    {
                        byte[] array = Encoding.Default.GetBytes(processed);
                        fstream.Write(array, 0, Convert.ToInt32(fnd[fnd.Length - 3]));
                    }
                    textBoxProcessed.Text = "Обработанные данные сохранены в файл, с названием " + "GOST-Deshifr" + fnd[fnd.Length - 2];
                }
                else//если данные были введены вручную, то дешифрованные данные появятся в текстовом поле в правой части формы
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
        
        private void buttonFurther_Click(object sender, EventArgs e)//активируется при нажатии на кнопку "Далее"
        {
            labelKey.Show();
            textBoxKey.Show();
            GOST28147 shifr = new GOST28147(key, textBoxOriginal.Text);
            if (flagDemoShifr) //демонстрационный режим шифрования
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
                              Convert.ToInt64(textBoxOriginal.Text[schDemo + 1]); //левая половина шифруемого блока
                    demoR0 = Convert.ToInt64(textBoxOriginal.Text[schDemo + 2]) *
                              Convert.ToInt64(Math.Pow(2, 16)) +
                              Convert.ToInt64(textBoxOriginal.Text[schDemo + 3]); //правая половина шифруемого блока
                    demoR02 = Convert.ToString(textBoxOriginal.Text[schDemo + 2]) +
                                  Convert.ToString(textBoxOriginal.Text[schDemo + 3]); //сохранение правой половины шифруемого блока для отображения в текстовом поле

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

                    textBoxL01.Text = Convert.ToString(textBoxOriginal.Text[schDemo]); //запись первого символа левой половины шифруемого блока в текстовое поле
                    textBoxL02.Text = Convert.ToString(textBoxOriginal.Text[schDemo + 1]); //запись второго символа левой половины шифруемого блока в текстовое поле
                    textBoxL03.Text = Binary(demoL0 / Convert.ToInt64(Math.Pow(2, 16))); //запись первого символа левой половины шифруемого блока, представленного в двоичном виде, в текстовое поле
                    textBoxL04.Text = Binary(demoL0 % Convert.ToInt64(Math.Pow(2, 16))); //запись второго символа левой половины шифруемого блока, представленного в двоичном виде, в текстовое поле

                    textBoxR01.Text = Convert.ToString(textBoxOriginal.Text[schDemo + 2]); //запись первого символа правой половины шифруемого блока в текстовое поле
                    textBoxR02.Text = Convert.ToString(textBoxOriginal.Text[schDemo + 3]); //запись второго символа правой половины шифруемого блока в текстовое поле
                    textBoxR03.Text = Binary(demoR0 / Convert.ToInt64(Math.Pow(2, 16))); //запись первого символа правой половины шифруемого блока, представленного в двоичном виде, в текстовое поле
                    textBoxR04.Text = Binary(demoR0 % Convert.ToInt64(Math.Pow(2, 16))); //запись второго символа правой половины шифруемого блока, представленного в двоичном виде, в текстовое поле

                    textBoxX01.Text = Convert.ToString(Convert.ToChar(demoX0 / Convert.ToInt64(Math.Pow(2, 16)))); //запись левой части подключа в текстовое поле
                    textBoxX02.Text = Convert.ToString(Convert.ToChar(demoX0 % Convert.ToInt64(Math.Pow(2, 16)))); //запись правой части подключа в текстовое поле
                    textBoxX03.Text = Binary(demoX0 / Convert.ToInt64(Math.Pow(2, 16))); //запись левой части подключа, представленной в двоичном виде, в текстовое поле
                    textBoxX04.Text = Binary(demoX0 % Convert.ToInt64(Math.Pow(2, 16))); //запись правой части подключа, представленной в двоичном виде, в текстовое поле

                    flagFurther = 1;
                }
                else
                {
                    if (flagFurther == 1)
                    {
                        pictureBoxDemoShifr0.Hide();
                        pictureBoxDemoShifr1.Show();
                        demoResult = shifr.Conversion(demoR0, demoX0); //преобразование в классе GOST28147 (вычисление суммы правой половины шифруемого блока и подключа по mod 2^32, преобразование в блоке подстановки и сдвиг результата на 11 бит влево)

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
                        long summ_mod32 = (demoR0 + demoX0) % Convert.ToInt64(Math.Pow(2, 32)); //вычисление суммы правой половины шифруемого блока и подключа по mod 2^32
                        textBoxR11.Text = Binary(summ_mod32 / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                          Binary(summ_mod32 % Convert.ToInt64(Math.Pow(2, 16))); //запись суммы правой половины шифруемого блока и подключа по mod 2^32, представленной в двоичном виде, в текстовое поле
                        textBoxR12.Text = Binary((demoResult >> 11) / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                          Binary((demoResult >> 11) % Convert.ToInt64(Math.Pow(2, 16))); //запись результата преобразования в блоке подстановки, представленного в двоичном виде, в текстовое поле
                        textBoxR13.Text = Binary(demoResult / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                          Binary(demoResult % Convert.ToInt64(Math.Pow(2, 16))); //запись сдвига последнего результата на 11 бит влево, представленного в двоичном виде, в текстовое поле
                        flagFurther = 2;
                    }
                    else
                    {
                        if (flagFurther == 2)
                        {
                            pictureBoxDemoShifr1.Hide();
                            pictureBoxDemoShifr2.Show();
                            long[] R1 = shifr.Xor(demoL0, demoResult); //вычисление суммы левой половины шифруемого блока и результата, полученного из метода Conversion класса GOST28147, по mod 2 в классе GOST28147
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
                            textBoxR12.Text = ss; //запись суммы левой половины шифруемого блока и результата, полученного из метода Conversion класса GOST28147, по mod 2 в текстовое поле
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
                            textBoxX01.Text = demoR02; //запись правой половины шифруемого блока
                            string str = "";
                            str = shifr.Processing(R1, str); //получение зашифрованных символов из класса GOST28147 
                            textBoxX02.Text += str; //запись зашифрованных символов в текстовое поле
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
            else //демонстрационный режим дешифрования
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
                                  Convert.ToInt64(textBoxOriginal.Text[schDemo + 1]); //левая половина шифруемого блока
                        demoDR1 = Convert.ToInt64(textBoxOriginal.Text[schDemo + 2]) *
                                  Convert.ToInt64(Math.Pow(2, 16)) +
                                  Convert.ToInt64(textBoxOriginal.Text[schDemo + 3]); //правая половина шифруемого блока
                        demoR02 = Convert.ToString(textBoxOriginal.Text[schDemo]) +
                                      Convert.ToString(textBoxOriginal.Text[schDemo + 1]); //сохранение левой половины шифруемого блока для отображения в текстовом поле

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

                        textBoxL01.Text = Convert.ToString(textBoxOriginal.Text[schDemo]); //запись первого символа левой половины дешифруемого блока в текстовое поле
                        textBoxL02.Text = Convert.ToString(textBoxOriginal.Text[schDemo + 1]); //запись второго символа левой половины дешифруемого блока в текстовое поле
                        textBoxL03.Text = Binary(demoL0 / Convert.ToInt64(Math.Pow(2, 16))); //запись первого символа левой половины дешифруемого блока, представленного в двоичном виде, в текстовое поле
                        textBoxL04.Text = Binary(demoL0 % Convert.ToInt64(Math.Pow(2, 16))); //запись второго символа левой половины дешифруемого блока, представленного в двоичном виде, в текстовое поле

                        textBoxR01.Text = Convert.ToString(textBoxOriginal.Text[schDemo + 2]); //запись первого символа правой половины дешифруемого блока в текстовое поле
                        textBoxR02.Text = Convert.ToString(textBoxOriginal.Text[schDemo + 3]); //запись второго символа правой половины дешифруемого блока в текстовое поле
                        textBoxR03.Text = Binary(demoR0 / Convert.ToInt64(Math.Pow(2, 16))); //запись первого символа правой половины дешифруемого блока, представленного в двоичном виде, в текстовое поле
                        textBoxR04.Text = Binary(demoR0 % Convert.ToInt64(Math.Pow(2, 16))); //запись второго символа правой половины дешифруемого блока, представленного в двоичном виде, в текстовое поле

                        textBoxX01.Text = Convert.ToString(Convert.ToChar(demoX0 / Convert.ToInt64(Math.Pow(2, 16)))); //запись левой части подключа в текстовое поле
                        textBoxX02.Text = Convert.ToString(Convert.ToChar(demoX0 % Convert.ToInt64(Math.Pow(2, 16)))); //запись правой части подключа в текстовое поле
                        textBoxX03.Text = Binary(demoX0 / Convert.ToInt64(Math.Pow(2, 16))); //запись левой части подключа, представленной в двоичном виде, в текстовое поле
                        textBoxX04.Text = Binary(demoX0 % Convert.ToInt64(Math.Pow(2, 16))); //запись правой части подключа, представленной в двоичном виде, в текстовое поле

                        flagFurther = 1;
                    }
                    else
                    {
                        if (flagFurther == 1)
                        {
                            pictureBoxDemoDeshifr0.Hide();
                            pictureBoxDemoDeshifr1.Show();
                            demoResult = shifr.Conversion(demoDR0, demoX0); //преобразование в классе GOST28147 (вычисление суммы левой половины дешифруемого блока и подключа по mod 2^32, преобразование в блоке подстановки и сдвиг результата на 11 бит влево)

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
                            long summ_mod32 = (demoDR0 + demoX0) % Convert.ToInt64(Math.Pow(2, 32)); //вычисление суммы левой половины дешифруемого блока и подключа по mod 2^32
                            textBoxR11.Text = Binary(summ_mod32 / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                              Binary(summ_mod32 % Convert.ToInt64(Math.Pow(2, 16))); //запись суммы левой половины дешифруемого блока и подключа по mod 2^32, представленной в двоичном виде, в текстовое поле
                            textBoxR12.Text = Binary((demoResult >> 11) / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                              Binary((demoResult >> 11) % Convert.ToInt64(Math.Pow(2, 16))); //запись результата преобразования в блоке подстановки, представленного в двоичном виде, в текстовое поле
                            textBoxR13.Text = Binary(demoResult / Convert.ToInt64(Math.Pow(2, 16))) + "" +
                                              Binary(demoResult % Convert.ToInt64(Math.Pow(2, 16))); //запись сдвига последнего результата на 11 бит влево, представленного в двоичном виде, в текстовое поле

                            flagFurther = 2;
                        }
                        else
                        {
                            if (flagFurther == 2)
                            {
                                pictureBoxDemoDeshifr1.Hide();
                                pictureBoxDemoDeshifr2.Show();
                                long[] L0 = shifr.Xor(demoDR1, demoResult); //вычисление суммы правой половины дешифруемого блока и результата, полученного из метода Conversion класса GOST28147, по mod 2 в классе GOST28147
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
                                textBoxR12.Text = ss; //запись суммы правой половины дешифруемого блока и результата, полученного из метода Conversion класса GOST28147, по mod 2 в текстовое поле
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
                                textBoxX02.Text = demoR02; //запись левой половины дешифруемого блока
                                string str = "";
                                str = shifr.Processing(L0, str); //получение дешифрованных символов из класса GOST28147
                                textBoxX01.Text += str; //запись дешифрованных символов в текстовое поле
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

        private void toolStripDemo_Click(object sender, EventArgs e)//активируется при нажатии на кнопку "Демонстрационный режим"
        {
            flagDemo = true;
            if (textBoxOriginal.Text != "")
            {
                labelProcessed.Text = "Демонстрационный режим";
                textBoxProcessed.Text = "Выберите режим обработки данных (шифрование/дешифрование)";
            }
            else
            {
                MessageBox.Show("Введите исходные данные и затем повторите попытку", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCarryover_Click(object sender, EventArgs e)//активируется при нажатии на кнопку с изображением стрелки влево
        {
            textBoxOriginal.Text = textBoxProcessed.Text; //перенос обработанных данных в поле с исходными данными
            textBoxProcessed.Clear();
        }

        private void toolStripAttach_Click(object sender, EventArgs e)//активируется при нажатии на кнопку "Прикрепить файл"
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fstream = File.OpenRead(op.FileName))//чтение из файла
                {
                    sizeFile = "" + fstream.Length; //запись размера исходного файла
                    fileNameDeshifr = op.FileName; //запись названия исходного файла
                    byte[] array = new byte[fstream.Length]; //массив для преобразования строки в байты
                    fstream.Read(array, 0, array.Length); //считывание данных
                    textFromFile = Encoding.Default.GetString(array); //декодирование байтов в строку
                }
                
                ext = Path.GetExtension(op.FileName); //запись расширения исходного файла
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
                        "Если вы считаете, что тип файла корректен, сообщите нам, и мы исправим ошибку.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
