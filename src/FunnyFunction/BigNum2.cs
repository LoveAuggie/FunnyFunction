using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyFunction
{
    class BigNum
    {
        public static string Add(string num1, string num2)
        {
            var error = CheckNum(num1);
            if (!string.IsNullOrEmpty(error))
                return error;
            error = CheckNum(num2);
            if (!string.IsNullOrEmpty(error))
                return error;

            Num bn1 = new Num(num1);
            Num bn2 = new Num(num2);

            return bn1.Add(bn2);
        }


        public static string Sub(string num1, string num2)
        {
            var error = CheckNum(num1);
            if (!string.IsNullOrEmpty(error))
                return error;
            error = CheckNum(num2);
            if (!string.IsNullOrEmpty(error))
                return error;

            Num bn1 = new Num(num1);
            Num bn2 = new Num(num2);

            return bn1.Sub(bn2);
        }

        private static string CheckNum(string nums)
        {
            return "";
        }
    }

    public class Num
    {
        public string ZS;

        public string XS;

        public int XSLength => this.XS.Length;

        public string JNum { get; set; }

        public Num(string sNum)
        {
            var pIndex = sNum.IndexOf('.');
            if (pIndex > 0)
            {
                ZS = sNum.Substring(0, pIndex);
                XS = sNum.Substring(pIndex + 1);
            }
            else
            {
                ZS = sNum;
                XS = "";
            }
            this.JNum = ZS + XS;
        }

        public string Sub(Num bn2)
        {
            if (this.BigThen(bn2))
                return RealBig(bn2);
            else
                return "-" + bn2.RealBig(this);
        }

        public string Add(Num bn2)
        {
            Format(bn2);

            int jw = 0;
            string re = "";
            for (int i = this.JNum.Length - 1; i >= 0; i--)
            {
                var n1 = int.Parse(this.JNum[i].ToString());
                var n2 = int.Parse(bn2.JNum[i].ToString());
                var nr = n1 + n2 + jw;

                re = (nr % 10).ToString() + re;
                jw = nr / 10;
            }

            re = jw.ToString() + re;
            re = re.Insert(re.Length - this.XS.Length, ".");
            return re.Trim('0').TrimEnd('.');
        }

        public string Multi(Num bn2)
        {
            return "";
        }

        private void Format(Num bn2)
        {
            if (this.ZS.Length > bn2.ZS.Length)
            {
                bn2.ZS = bn2.ZS.PadLeft(this.ZS.Length, '0');
            }
            else
            {
                this.ZS = this.ZS.PadLeft(bn2.ZS.Length, '0');
            }

            if (this.XS.Length > bn2.XS.Length)
            {
                bn2.XS = bn2.XS.PadRight(this.XS.Length, '0');
            }
            else
            {
                this.XS = this.XS.PadRight(bn2.XS.Length, '0');
            }
            this.JNum = this.ZS + this.XS;
            bn2.JNum = bn2.ZS + bn2.XS;
        }

        // 这里，只能大数减小数
        private string RealBig(Num bn2)
        {
            string re = "";
            var length = this.JNum.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                var n1 = int.Parse(this.JNum[i].ToString());
                var n2 = int.Parse(bn2.JNum[i].ToString());

                if (n1 >= n2)
                {
                    re = (n1 - n2).ToString() + re;
                }
                else
                {
                    JieWei(i);
                    re = (n1 + 10 - n2).ToString() + re;
                }
            }

            re = re.Insert(re.Length - this.XS.Length, ".");
            return re.Trim('0').TrimEnd('.');
        }

        public bool BigThen(Num bn2)
        {
            Format(bn2);
            for (int i = 0; i < this.JNum.Length; i++)
            {
                if (this.JNum[i] == bn2.JNum[i])
                    continue;
                else
                {
                    return this.JNum[i] > bn2.JNum[i];
                }
            }
            return true;
        }

        private void JieWei(int i)
        {
            for (int index = i - 1; index >= 0; index--)
            {
                var num = int.Parse(this.JNum[index].ToString());
                if (num > 0)
                {
                    this.JNum = this.JNum.Remove(index, i - index);
                    this.JNum = this.JNum.Insert(index, (num - 1).ToString());
                    this.JNum = this.JNum.Insert(index + 1, "".PadLeft(i - index-1, '9'));
                    return;
                }
            }
        }
    }
}
