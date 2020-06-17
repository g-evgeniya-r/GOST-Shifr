using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOST
{
    class GOST28147
    {
        private int[,] Key; //ключ для шифрования/дешифрования
        private string Text; //данные для шифрования/дешифрования
        private int[,] Block = { { 4, 14, 5, 7, 6, 4, 13, 1 },
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
                                { 3, 9, 11, 3, 2, 14, 12, 12 } }; //блок подстановки
        public GOST28147(int[,] key, string text)
        {
            Key = key;
            Text = text;
        }
        public string Encrypt() //метод для шифрования
        {
            int j = -1; //счетчик для смены подключа
            string Processed = ""; //переменная для результата шифрования
            for (int i = 0; i <= Text.Length - 4; i += 4)
            {
                j = (j + 1) % 16;

                long L0 = Convert.ToInt64(Text[i]) *
                          Convert.ToInt64(Math.Pow(2, 16)) +
                          Convert.ToInt64(Text[i + 1]); //левая половина шифруемого блока
                long R0 = Convert.ToInt64(Text[i + 2]) *
                          Convert.ToInt64(Math.Pow(2, 16)) +
                          Convert.ToInt64(Text[i + 3]); //правая половина шифруемого блока
                Processed += (Convert.ToString(Text[i + 2]) +
                              Convert.ToString(Text[i + 3])); 
                long X0; //подключ
                if (j != 15)
                    X0 = Key[j, 0] * Convert.ToInt64(Math.Pow(2, 16)) + Key[j, 1];
                else
                    X0 = Key[j, 1] * Convert.ToInt64(Math.Pow(2, 16)) + Key[j, 0];

                long result = Conversion(R0, X0);
                //long[] R1 = Xor(L0, result);
                //Processed = Processing(R1, Processed);
                long R1 = Xor(L0, result);
                Processed = Processing(R1, Processed);
            }
            return Processed;
        }
        public string Decrypt()//метод для дешифрования
        {
            int j = -1; //счетчик для подключа
            string Processed = ""; //переменная для результата дешифрования
            for (int i = 0; i <= Text.Length - 4; i += 4)
            {
                j = (j + 1) % 16;
                long R0 = Convert.ToInt64(Text[i]) *
                          Convert.ToInt64(Math.Pow(2, 16)) +
                          Convert.ToInt64(Text[i + 1]); //левая половина дешифруемого блока
                long R1 = Convert.ToInt64(Text[i + 2]) *
                          Convert.ToInt64(Math.Pow(2, 16)) +
                          Convert.ToInt64(Text[i + 3]); //правая половина дешифруемого блока
                long X0; //подключ
                if (j != 15)
                    X0 = Key[j, 0] * Convert.ToInt64(Math.Pow(2, 16)) + Key[j, 1];
                else
                    X0 = Key[j, 1] * Convert.ToInt64(Math.Pow(2, 16)) + Key[j, 0];
                long result = Conversion(R0, X0);
                //long[] L0 = Xor(R1, result);
                //Processed = Processing(L0, Processed);
                long L0 = Xor(R1, result);
                Processed = Processing(L0, Processed);
                Processed += Convert.ToChar(R0 / Convert.ToInt64(Math.Pow(2, 16)));
                Processed += Convert.ToChar(R0 % Convert.ToInt64(Math.Pow(2, 16)));
            }
            return Processed;
        }
        public long Conversion(long R0, long X0)
        {
            long summ_mod32 = (R0 + X0) % Convert.ToInt64(Math.Pow(2, 32)); //вычисление суммы правой половины шифруемого блока и подключа по mod 2^32
            long[] line = new long[8];
            for (int i = 0; i < 8; i++) //разбиение полученной суммы на блоки по 4 бит
            {
                line[i] = summ_mod32 % 16;
                summ_mod32 /= 16;
            }
            for (int i = 0; i < 8; i++) //преобразование в блоке подстановки
            {
                line[i] = Block[line[i], i];
            }
            long line2 = line[0] * Convert.ToInt64(Math.Pow(2, 28)) +
                         line[1] * Convert.ToInt64(Math.Pow(2, 24)) +
                         line[2] * Convert.ToInt64(Math.Pow(2, 20)) +
                         line[3] * Convert.ToInt64(Math.Pow(2, 16)) +
                         line[4] * Convert.ToInt64(Math.Pow(2, 12)) +
                         line[5] * Convert.ToInt64(Math.Pow(2, 8)) +
                         line[6] * Convert.ToInt64(Math.Pow(2, 4)) +
                         line[7]; //объединение 4-битных блоков
            return line2 << 11;
        }
        public long Xor(long L0, long result)
        {
            long R1 = (L0 ^ result) % Convert.ToInt64(Math.Pow(2, 32));
            return R1;
        }
        public string Processing(long R1, string Processed)
        {
            long kod = R1 / Convert.ToInt64(Math.Pow(2, 16)); //получение кода первого из двух обработанных символов
            Processed += Convert.ToChar(kod);

            kod = R1 % Convert.ToInt64(Math.Pow(2, 16)); //получение кода второго из двух обработанных символов
            Processed += Convert.ToChar(kod);
            return Processed;
        }
    }
}
