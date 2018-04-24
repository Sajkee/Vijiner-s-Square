using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vzhik
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var s = "";
            var result = "";
            var key = "";
            var cez_key = "";
            Console.Write("Введите число сдвига:");
            int numKey = (int.Parse(Console.ReadLine()) % 31);
            int cez_num = 0;
            int length = 0;
            var key_on_s = "";
            int x = 0, y = 0;

            char dublicat;


            var pointer = 0;
            var tabula_recta = new char[31, 31];
            var alfabet = "абвгдежзийклмнопрстуфхцчшщьыэюя";
            for (var i = 0; i < 31; i++)
            {
                for (var j = 0; j < 31; j++)
                {
                    pointer = j + i;
                    if (pointer >= 31) pointer = pointer % 31;
                    tabula_recta[i, j] = alfabet[pointer];
                    //Console.Write(tabula_recta[i, j] + "  ");
                }
                //Console.WriteLine();
            }

            Console.Write("Введите ключ:");


            var flag = false;
            while (flag != true)
            {
                flag = true;

                key = Console.ReadLine();

                for (var i = 0; i < key.Length; i++)
                    if (Convert.ToInt32(key[i]) < 1072 || Convert.ToInt32(key[i]) > 1103)
                        flag = false;
                for (int i = 0; i < key.Length; i++)
                {
                    if (Convert.ToInt32(key[i]) + numKey > 1103)
                    {
                        cez_num = 1103 - (Convert.ToInt32(key[i]) + numKey);
                        cez_num = 1072 + Math.Abs(cez_num);
                    }
                    else
                    if (numKey < 0)
                    {
                        cez_num = Convert.ToInt32(key[i]) - numKey;
                    }
                    else
                    {
                        cez_num = Convert.ToInt32(key[i]) + numKey;
                    }
                    cez_key += Convert.ToChar(cez_num);

                }
            }

            if (cez_key.Length > 0)
            {
                Console.Write("Введите строку:");
                s = Console.ReadLine();
                length = s.Length;

                for (var i = 0; i < length; i++) key_on_s += cez_key[i % cez_key.Length];

                for (var i = 0; i < length; i++)
                {
                    var l = 0;
                    flag = false;
                    while (l < 31 && flag == false)
                    {
                        if (key_on_s[i] == tabula_recta[l, 0])
                        {
                            x = l;
                            flag = true;
                        }

                        l++;
                    }


                    dublicat = s[i];

                    l = 0;
                    flag = false;
                    while (l < 31 && flag == false)
                    {
                        if (dublicat == tabula_recta[0, l])
                        {
                            y = l;
                            flag = true;
                        }

                        l++;
                    }

                    result += tabula_recta[x, y];
                }


                Console.WriteLine("Результат:");
                Console.WriteLine(result);
                Console.ReadKey();
            }
        }
    }
}
