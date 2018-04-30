using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManager.Controller
{
    class FontConvert
    {
        const string unicode_str = "aáàảãạăắằẳẵặâấầẩẫậđeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵ" + "AÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬĐEÉÈẺẼẸÊẾỀỂỄỆIÍÌỈĨỊOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢUÚÙỦŨỤƯỨỪỬỮỰYÝỲỶỸỴ";
        const string tcvn3_str = "a¸µ¶·¹¨¾»¼½Æ©ÊÇÈÉË®eÐÌÎÏÑªÕÒÓÔÖiÝ×ØÜÞoãßáâä«èåæçé¬íêëìîuóïñòô­øõö÷ùyýúûüþ" + "A¸µ¶·¹¡¾»¼½Æ¢ÊÇÈÉË§EÐÌÎÏÑ£ÕÒÓÔÖIÝ×ØÜÞOãßáâä¤èåæçé¥íêëìîUóïñòô¦øõö÷ùYýúûüþ";

        string[] UTF8_CONVERT = new string[146]{"a","Ã¡","Ã ","áº£","Ã£","áº¡",
        		          "Äƒ","áº¯","áº±","áº³","áºµ","áº·",
        		          "Ã¢","áº¥","áº§","áº©","áº«","áº­",
		          "Ä‘",
		          "e","Ã©","Ã¨","áº»","áº½","áº¹",
        		          "Ãª","áº¿","á»","á»ƒ","á»…","á»‡",
        		          "i","Ã­","Ã¬","á»‰","Ä©","á»‹",
        		          "o","Ã³","Ã²","á»","Ãµ","á»",
        		          "Ã´","á»‘","á»“","á»•","á»—","á»™",
        		          "Æ¡","á»›","á»","á»Ÿ","c","á»£",
        		          "u","Ãº","Ã¹","á»§","Å©","á»¥",
        		          "Æ°","á»©","á»«","á»­","á»¯","á»±",
        		          "y","Ã½","á»³","á»·","á»¹","á»µ",
        		          "A","Ã","Ã€","áº¢","Ãƒ","áº ",
        		          "Ä‚","áº®","áº°","áº²","áº´","áº¶",
        		          "Ã‚","áº¤","áº¦","áº¨","áºª","áº¬",
        		          "Ä",
        		          "E","Ã‰","Ãˆ","áºº","áº¼","áº¸",
        		          "ÃŠ","áº¾","á»€","á»‚","á»„","á»†",
        		          "I","Ã","ÃŒ","á»ˆ","Ä¨","á»Š",
        		          "O","Ã“","Ã’","á»Ž","Ã•","á»Œ",
        		          "Ã”","á»","á»’","á»”","á»–","á»˜",
        		          "Æ ","á»š","á»œ","á»ž","á» ","á»¢",
        		          "U","Ãš","Ã™","á»¦","Å¨","á»¤",
        		          "Æ¯","á»¨","á»ª","á»¬","á»®","á»°",
        		          "Y","Ã","á»²","á»¶","á»¸","á»´"};
        public int ReturnLocationUnicode(char Chuoi)//tra ve vi tri unicode trong chuoi
        {
            int Trave = -1;
            for (int i = 0; i < unicode_str.Length; i++)
            {
                if (Chuoi == unicode_str[i])
                {
                    Trave = i;
                    break;
                }

            }
            return Trave;
        }
        public string ReturnUTF8(int index)//tra bang unicode de tim ki tu
        {
            string Trave = "";
            Trave = UTF8_CONVERT[index];
            return Trave;
        }
        
        public char ReturnTcvn3(int index)//tra bang unicode de tim ki tu
        {
            char Trave;
            Trave = tcvn3_str[index];
            return Trave;
        }
        public string UnicodeToUTF8(string Chuoi)
        {
            string Trave = "";
            for (int i = 0; i < Chuoi.Length; i++)
            {
                if (ReturnLocationUnicode(Convert.ToChar(Chuoi[i])) >= 0)
                    Trave = Trave + ReturnUTF8(ReturnLocationUnicode(Convert.ToChar(Chuoi[i])));
                else
                    Trave = Trave + Chuoi[i];

            }
            return Trave;
        }
        public string UnicodeToTvcn3(string Chuoi)
        {
            string Trave = "";
            for (int i = 0; i < Chuoi.Length; i++)
            {
                if (ReturnLocationUnicode(Convert.ToChar(Chuoi[i])) >= 0)
                    Trave = Trave + ReturnTcvn3(ReturnLocationUnicode(Convert.ToChar(Chuoi[i])));
                else
                    Trave = Trave + Chuoi[i];

            }
            return Trave;
        }
        public string convertToUnSign2(string s)// hàm chuyển từ có dấu sang không dấu
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }
        public string CanhGiua(string Chuoi, int number)
        {
            string Trave = Chuoi;
            int Kitu = 0;
            if (number <= Chuoi.Length)
            {
                Trave = Chuoi.Substring(0, number);
            }
            else
            {
                Kitu = number - Chuoi.Length;
                if ((Kitu % 2) == 0)
                {
                    for (int i = 0; i < (Kitu / 2); i++)
                    {
                        Trave = " " + Trave + " ";
                    }
                }
                else
                {
                    for (int i = 0; i < (Kitu / 2); i++)
                    {
                        Trave = " " + Trave + " ";
                    }
                    Trave = Trave + " ";
                }

            }
            return Trave;

        }
        public string CanhPhai(string Chuoi, int number)
        {
            string Trave = Chuoi;
            int Kitu = number - Chuoi.Length;
            for (int i = 0; i < (Kitu); i++)
            {
                Trave = " " + Trave;
            }
            return Trave;
        }
        public string CanhTrai(string Chuoi, int number)
        {
            string Trave = Chuoi;
            int Kitu = number - Chuoi.Length;
            for (int i = 0; i < (Kitu); i++)
            {
                Trave = Trave + " ";
            }
            return Trave;
        }
    }
}
