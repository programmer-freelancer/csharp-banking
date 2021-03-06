using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Reporter
{
    class ClassNumbericToLetter
    {
        //
        private string[] yekan = new string[10] { "صفر ", "یک ", "دو", "سه ", "چهار ", "پنج ", "شش ", " هفت ", "هشت ", "نه " };
        private string[] dahgan = new string[10] { "", "", "بیست ", "سی ", "چهل ", "پنجاه ", "شصت ", "هفتاد ", "هشتاد ", "نود " };
        private string[] dahyek = new string[10] { "ده ", "یازده ", "دوازده ", "سیزده ", "چهارده ", "پانزده ", "شانزده ", "هفده ", "هجده ", "نوزده " };
        private string[] sadgan = new string[10] { "", "یکصد ", "دویست ", "سیصد ", "چهارصد ", "پانصد ", "ششصد ", "هفتصد ", "هشتصد ", "نهصد " };
        private string[] basex = new string[5] { "", "هزار ", "میلیون ", "میلیارد ", "تریلیون " };
        //
        private string getnum(int num)
        {
            string s = " ";
            int d3, d12;
            d12 = num % 100;
            d3 = num / 100;
            if (d3 != 0)
                s = sadgan[d3] + " و ";
            if ((d12 >= 10) && (d12 <= 19))
                s = s + dahyek[d12 - 10];
            else
            {
                int d2 = d12 / 10;
                if (d2 != 0)
                    s = s + dahgan[d2] + " و ";
                int d1 = d12 % 10;
                if (d1 != 0)
                    s = s + yekan[d1] + " و ";
                s = s.Substring(0, s.Length - 3);

            }
            return s;
        }
        //
        public string NumbericToLetters(string strNumber)
        {
            string strOutput = "";
            if (strNumber.Length <= 3)
                return getnum(Convert.ToInt32(strNumber));
            else
            {
                string[] result = Spiltter(strNumber);
                int martabe = result.Length;
                int i = 0;
                while (result[i] == "")
                    i++;
                martabe = martabe - i - 1;
                //
                strOutput = getnum(Convert.ToInt32(result[i++])) + basex[martabe--];
                //
                for (int k = i; k < result.Length; k++)
                {
                    if (!CheckZero(result[k]))
                        strOutput += "و " + getnum(Convert.ToInt32(result[k])) + basex[martabe--];
                }
            }
            return strOutput;
        }
        //
        public string AddComma(string strNumber)
        {
            int lenght = strNumber.Length;
            //Insert comma to string
            for (int i = lenght - 3; i >= 0; i -= 3)
                strNumber = strNumber.Insert(i, ",");
            //
            return strNumber;

        }
        //
        private string[] Spiltter(string strNumber)
        {
            string strAddComma = AddComma(strNumber);
            string[] spiltting = strAddComma.Split(',');
            return spiltting;
        }
        //
        private Boolean CheckZero(string str)
        {
            if (Convert.ToInt32(str) == 0)
                return true;
            else
                return false;
        }
    }
}
