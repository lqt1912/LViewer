using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LViewer_Client
{
    public class my_Crypto
    {
        private static int p, q, n, e, d, phi_n;
        public static  string getString(string str)
        {
            int bre = 0;
            string s1 = null;
            string s2 = null;
            string s = null;
            char[] getChar = new char[str.Length];
            getChar = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (getChar[i] == ':')
                {
                    bre = i + 1;
                    break;
                }
            }
            for (int k = 0; k < bre; k++)
            {
                s1 += getChar[k].ToString();
            }
            for (int j = bre; j < str.Length; j++)
            {
                s2 += getChar[j].ToString();
            }
            s2 = getDecipher(s2);
            s = s1 + " " + s2;
            return s;
        }

        public static string getDecipher(string str)
        {
            string rtbChuoiKiTu = str.Trim() + " ";
            int chieuDaiChuoi = rtbChuoiKiTu.Length;
            char[] rtbMangKiTu;
            rtbMangKiTu = new char[chieuDaiChuoi];
            int[] rtbMangSo;
            rtbMangSo = new int[chieuDaiChuoi];
            rtbMangKiTu = rtbChuoiKiTu.ToCharArray();
            string s = "";
            int count = 0;
            int i = 0;
            for (i = 0; i < chieuDaiChuoi; i++)
            {
                if (rtbMangKiTu[i] != ' ')
                {
                    s += rtbMangKiTu[i];
                }
                else
                {
                    rtbMangSo[count] = int.Parse(s);
                    count++;
                    s = "";
                }
            }
            char[] rtbMang;
            rtbMang = new char[chieuDaiChuoi];
            int dd = rtbMangSo[0];
            int ee = rtbMangSo[1];
            int nn = rtbMangSo[2];
            for (i = 3; i < count; i++)
            {
                rtbMangSo[i] = (rtbMangSo[i] ^ dd) % nn;
                rtbMangSo[i] = (rtbMangSo[i] ^ ee) % nn;
                rtbMangSo[i] = (rtbMangSo[i] ^ dd) % nn;
                rtbMang[i] = (char)rtbMangSo[i];
                s += rtbMang[i];
            }
            return s;
        }

        public static  string getEncrypt(string str)
        {
            createKey();
            int len = str.Length;
            char[] mangKiTu = new char[len];
            mangKiTu = str.ToCharArray();
            int[] mangAscii = new int[len];
            for (int i = 0; i < len; i++)
                mangAscii[i] = (int)mangKiTu[i];
            for (int i = 0; i < len; i++)

                mangAscii[i] = (mangAscii[i] ^ e) % n;			//Mã hóa từng kí tự trong chuỗi

            string str1 = "";					// Gán vào một chuỗi số khác
            for (int i = 0; i < len; i++)
                str1 += (mangAscii[i] + " ");
            return d.ToString() + " " + e.ToString() + " " + n.ToString() + " " + str1;
        }

       public static void  createKey()
        {
            //Tạo hai số nguyên tố ngẫu nhine6 khác nhau
            do
            {
                p = getRandomInt();
                q = getRandomInt();
            }
            while (p == q || !isPrimeNumber(p) || !isPrimeNumber(q));

            //Tinh n=p*q
            n = p * q;

            //Tính Phi(n)=(p-1)*(q-1)
            phi_n = (p - 1) * (q - 1);

            //Tính e là một số ngẫu nhiên có giá trị 0< e <phi(n) và là số nguyên tố cùng nhau với Phi(n)
            do
            {
                Random rd = new Random();
                e = rd.Next(2, phi_n);
            }
            while (!isPrimeTogether(e, phi_n));

            //Tính d
            d = 0;
            int i = 2;
            while (((1 + i * phi_n) % e) != 0 || d <= 0)
            {
                i++;
                d = (1 + i * phi_n) / e;
            }
        }

       public static int getRandomInt()
        {
            Random rd = new Random();
            return rd.Next(11, 101);
        }

       public static bool isPrimeNumber(int i)
        {
            bool kiemtra = true;
            for (int j = 2; j < i; j++)
                if (i % j == 0)
                    kiemtra = false;
            return kiemtra;
        }

      public static  bool isPrimeTogether(int a, int b)
        {
            bool kiemtra = true;
            for (int i = 2; i < a; i++)
                if (a % i == 0 && b % i == 0)
                    kiemtra = false;
            return kiemtra;
        }
    }
}
