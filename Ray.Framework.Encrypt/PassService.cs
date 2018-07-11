using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Ray.Framework.Encrypt
{
    /// <summary>
    /// 用于生成Kingdee K3系统用户密码
    /// </summary>
    public sealed class PassService
    {
        //数字
        private static string[] p0 = new string[] { " P ", "#  ", ",  " };
        private static string[] p1 = new string[] { " Q ", "#$ ", ",0 " };
        private static string[] p2 = new string[] { " R ", "#( ", ",@ " };
        private static string[] p3 = new string[] { " S ", "#, ", ",P " };
        private static string[] p4 = new string[] { " T ", "#0 ", "-  " };
        private static string[] p5 = new string[] { " U ", "#4 ", "-0 " };
        private static string[] p6 = new string[] { " V ", "#8 ", "-@ " };
        private static string[] p7 = new string[] { " W ", "#< ", "-P " };
        private static string[] p8 = new string[] { " X ", "#@ ", ".  " };
        private static string[] p9 = new string[] { " Y ", "#D ", ".0 " };
        //小写字母
        private static string[] pa = new string[] { "!A ", "&$ ", "80" };
        private static string[] pb = new string[] { "!B ", "&( ", "8@" };
        private static string[] pc = new string[] { "!C ", "&, ", "8P" };
        private static string[] pd = new string[] { "!D ", "&0 ", "9 " };
        private static string[] pe = new string[] { "!E ", "&4 ", "90" };
        private static string[] pf = new string[] { "!F ", "&8 ", "9@" };
        private static string[] pg = new string[] { "!G ", "&< ", "9P" };
        private static string[] ph = new string[] { "!H ", "&@ ", ": " };
        private static string[] pi = new string[] { "!I ", "&D ", ":0" };
        private static string[] pj = new string[] { "!J ", "&H ", ":@" };
        private static string[] pk = new string[] { "!K ", "&L ", ":P" };
        private static string[] pl = new string[] { "!L ", "&P ", "; " };
        private static string[] pm = new string[] { "!M ", "&T ", ";0" };
        private static string[] pn = new string[] { "!N ", "&X ", ";@" };
        private static string[] po = new string[] { "!O ", "&/ ", ";P" };
        private static string[] pp = new string[] { "!P ", "'  ", "< " };
        private static string[] pq = new string[] { "!Q ", "'$ ", "<0" };
        private static string[] pr = new string[] { "!R ", "'( ", "<@" };
        private static string[] ps = new string[] { "!S ", "', ", "<P" };
        private static string[] pt = new string[] { "!T ", "'0 ", "= " };
        private static string[] pu = new string[] { "!U ", "'4 ", "=0" };
        private static string[] pv = new string[] { "!V ", "'8 ", "=@" };
        private static string[] pw = new string[] { "!W ", "'< ", "=P" };
        private static string[] px = new string[] { "!X ", "'@ ", "> " };
        private static string[] py = new string[] { "!Y ", "'D ", ">0" };
        private static string[] pz = new string[] { "!Z ", "'H ", ">@" };
        //大写字母
        private static string[] pA = new string[] { "!! ", "$$ ", "00" };
        private static string[] pB = new string[] { "!\" ", "$( ", "0@" };
        private static string[] pC = new string[] { "!# ", "$, ", "0P" };
        private static string[] pD = new string[] { "!$ ", "$0 ", "1 " };
        private static string[] pE = new string[] { "!% ", "$4 ", "10" };
        private static string[] pF = new string[] { "!& ", "$8 ", "1@" };
        private static string[] pG = new string[] { "!' ", "$< ", "1P" };
        private static string[] pH = new string[] { "!( ", "$@ ", "2 " };
        private static string[] pI = new string[] { "!) ", "$D ", "20" };
        private static string[] pJ = new string[] { "!* ", "$H ", "2@" };
        private static string[] pK = new string[] { "!+ ", "$L ", "2P" };
        private static string[] pL = new string[] { "!, ", "$P ", "3 " };
        private static string[] pM = new string[] { "!- ", "$T ", "30" };
        private static string[] pN = new string[] { "!. ", "$X ", "3@" };
        private static string[] pO = new string[] { "!/ ", "$/ ", "3P" };
        private static string[] pP = new string[] { "!0 ", "%  ", "4 " };
        private static string[] pQ = new string[] { "!1 ", "%$ ", "40" };
        private static string[] pR = new string[] { "!2 ", "%( ", "4@" };
        private static string[] pS = new string[] { "!3 ", "%, ", "4P" };
        private static string[] pT = new string[] { "!4 ", "%0 ", "5 " };
        private static string[] pU = new string[] { "!5 ", "%4 ", "50" };
        private static string[] pV = new string[] { "!6 ", "%8 ", "5@" };
        private static string[] pW = new string[] { "!7 ", "%< ", "5P" };
        private static string[] pX = new string[] { "!8 ", "%@ ", "6 " };
        private static string[] pY = new string[] { "!9 ", "%D ", "60" };
        private static string[] pZ = new string[] { "!: ", "%H ", "6@" };
        //符号
        //!
        private static string[] p11 = new string[] { " A ", "\"$ ", "(0" };
        //@
        private static string[] p12 = new string[] { " ! ", "$  ", "0 " };
        //#
        private static string[] p13 = new string[] { " C ", "\", ", "(P" };
        //$
        private static string[] p14 = new string[] { " D ", "\"0 ", ") " };
        //%
        private static string[] p15 = new string[] { " E ", "\"4 ", ")0" };
        //^
        private static string[] p16 = new string[] { "!> ", "%X ", "7@" };
        //&
        private static string[] p17 = new string[] { " F ", "\"8 ", ")@" };
        //*
        private static string[] p18 = new string[] { " J ", "\"H ", "*@" };
        //(
        private static string[] p19 = new string[] { " H ", "\"@ ", "* " };
        //)
        private static string[] p20 = new string[] { " I ", "\"D ", "*0" };

        //_
        private static string[] p21 = new string[] { "!? ", "%/ ", "7P" };
        //+
        private static string[] p22 = new string[] { " K ", "\"L ", "*P" };
        //=
        private static string[] p23 = new string[] { " ] ", "#T ", "/0" };
        //-
        private static string[] p24 = new string[] { " M ", "\"T ", "+0" };
        //[
        private static string[] p25 = new string[] { "!; ", "%L ", "6P" };
        //]
        private static string[] p26 = new string[] { "!= ", "%T ", "70" };
        //{
        private static string[] p27 = new string[] { "![ ", "'L ", ">P" };
        //}
        private static string[] p28 = new string[] { "!] ", "'T ", "?0" };
        //;
        private static string[] p29 = new string[] { " [ ", "#L ", ".P" };
        //:
        private static string[] p30 = new string[] { " Z ", "#H ", ".@" };

        //"
        private static string[] p31 = new string[] { " B ", "\"( ", "(@" };
        //'
        private static string[] p32 = new string[] { " G ", "\"< ", ")P" };
        //,
        private static string[] p33 = new string[] { " L ", "\"P ", "+ " };
        //.
        private static string[] p34 = new string[] { " N ", "\"X ", "+@" };
        //?
        private static string[] p35 = new string[] { " _ ", "#/ ", "/P" };
        /// 
        private static string[] p36 = new string[] { "!< ", "%P ", "7 " };
        //|
        private static string[] p37 = new string[] { "!/ ", "'P ", "? " };
        //\
        private static string[] p38 = new string[] { " 0 ", "\"/", "+P" };
        //\
        private static string[] p39 = new string[] { "!@ ", "&  ", "8 " };
        //~
        private static string[] p40 = new string[] { "!^ ", "'X ", "?@" };

        //<
        private static string[] p41 = new string[] { " / ", "#P ", "/ " };
        //>
        private static string[] p42 = new string[] { " ^ ", "#X ", "/@" };

        /// <summary>
        /// 查询密码表，对应生成Kingdee密码
        /// 版本号是用来区别V11以下的K3，前面有一组字符前缀
        /// </summary>
        /// <param name="pass">密码明文</param>
        /// <param name="KingdeeVersion">版本号</param>
        /// <returns></returns>
        public static string EncryptPassword(string pass, int KingdeeVersion)
        {
            string retVal = "";

            for (int i = 0; i < pass.Length; i++)
            {
                //该位是数字
                if (Regex.IsMatch(pass[i].ToString(), @"^[0-9]*$"))
                {
                    if (pass[i].ToString() == "0")
                    {
                        retVal += i % 6 == 3 ? p0[0].Substring(1) : p0[i % 3];
                    }
                    else if (pass[i].ToString() == "1")
                    {
                        retVal += i % 6 == 3 ? p1[0].Substring(1) : p1[i % 3];
                    }
                    else if (pass[i].ToString() == "2")
                    {
                        retVal += i % 6 == 3 ? p2[0].Substring(1) : p2[i % 3];
                    }
                    else if (pass[i].ToString() == "3")
                    {
                        retVal += i % 6 == 3 ? p3[0].Substring(1) : p3[i % 3];
                    }
                    else if (pass[i].ToString() == "4")
                    {
                        retVal += i % 6 == 3 ? p4[0].Substring(1) : p4[i % 3];
                    }
                    else if (pass[i].ToString() == "5")
                    {
                        retVal += i % 6 == 3 ? p5[0].Substring(1) : p5[i % 3];
                    }
                    else if (pass[i].ToString() == "6")
                    {
                        retVal += i % 6 == 3 ? p6[0].Substring(1) : p6[i % 3];
                    }
                    else if (pass[i].ToString() == "7")
                    {
                        retVal += i % 6 == 3 ? p7[0].Substring(1) : p7[i % 3];
                    }
                    else if (pass[i].ToString() == "8")
                    {
                        retVal += i % 6 == 3 ? p8[0].Substring(1) : p8[i % 3];
                    }
                    else if (pass[i].ToString() == "9")
                    {
                        retVal += i % 6 == 3 ? p9[0].Substring(1) : p9[i % 3];
                    }
                    else
                    {
                        retVal += "";
                    }
                }
                else if (Regex.IsMatch(pass[i].ToString(), @"^[a-z]+$"))//是小写字母
                {
                    if (pass[i].ToString() == "a")
                    {
                        retVal += pa[i % 3];
                    }
                    else if (pass[i].ToString() == "b")
                    {
                        retVal += pb[i % 3];
                    }
                    else if (pass[i].ToString() == "c")
                    {
                        retVal += pc[i % 3];
                    }
                    else if (pass[i].ToString() == "d")
                    {
                        retVal += pd[i % 3];
                    }
                    else if (pass[i].ToString() == "e")
                    {
                        retVal += pe[i % 3];
                    }
                    else if (pass[i].ToString() == "f")
                    {
                        retVal += pf[i % 3];
                    }
                    else if (pass[i].ToString() == "g")
                    {
                        retVal += pg[i % 3];
                    }
                    else if (pass[i].ToString() == "h")
                    {
                        retVal += ph[i % 3];
                    }
                    else if (pass[i].ToString() == "i")
                    {
                        retVal += pi[i % 3];
                    }
                    else if (pass[i].ToString() == "j")
                    {
                        retVal += pj[i % 3];
                    }
                    else if (pass[i].ToString() == "k")
                    {
                        retVal += pk[i % 3];
                    }
                    else if (pass[i].ToString() == "l")
                    {
                        retVal += pl[i % 3];
                    }
                    else if (pass[i].ToString() == "m")
                    {
                        retVal += pm[i % 3];
                    }
                    else if (pass[i].ToString() == "n")
                    {
                        retVal += pn[i % 3];
                    }
                    else if (pass[i].ToString() == "o")
                    {
                        retVal += po[i % 3];
                    }
                    else if (pass[i].ToString() == "p")
                    {
                        retVal += pp[i % 3];
                    }
                    else if (pass[i].ToString() == "q")
                    {
                        retVal += pq[i % 3];
                    }
                    else if (pass[i].ToString() == "r")
                    {
                        retVal += pr[i % 3];
                    }
                    else if (pass[i].ToString() == "s")
                    {
                        retVal += ps[i % 3];
                    }
                    else if (pass[i].ToString() == "t")
                    {
                        retVal += pt[i % 3];
                    }
                    else if (pass[i].ToString() == "u")
                    {
                        retVal += pu[i % 3];
                    }
                    else if (pass[i].ToString() == "v")
                    {
                        retVal += pv[i % 3];
                    }
                    else if (pass[i].ToString() == "w")
                    {
                        retVal += pw[i % 3];
                    }
                    else if (pass[i].ToString() == "x")
                    {
                        retVal += px[i % 3];
                    }
                    else if (pass[i].ToString() == "y")
                    {
                        retVal += py[i % 3];
                    }
                    else if (pass[i].ToString() == "z")
                    {
                        retVal += pz[i % 3];
                    }
                }
                else if (Regex.IsMatch(pass[i].ToString(), @"^[A-Z]+$"))//是大写字母
                {
                    if (pass[i].ToString() == "A")
                    {
                        retVal += pA[i % 3];
                    }
                    else if (pass[i].ToString() == "B")
                    {
                        retVal += pB[i % 3];
                    }
                    else if (pass[i].ToString() == "C")
                    {
                        retVal += pC[i % 3];
                    }
                    else if (pass[i].ToString() == "D")
                    {
                        retVal += pD[i % 3];
                    }
                    else if (pass[i].ToString() == "E")
                    {
                        retVal += pE[i % 3];
                    }
                    else if (pass[i].ToString() == "F")
                    {
                        retVal += pF[i % 3];
                    }
                    else if (pass[i].ToString() == "G")
                    {
                        retVal += pG[i % 3];
                    }
                    else if (pass[i].ToString() == "H")
                    {
                        retVal += pH[i % 3];
                    }
                    else if (pass[i].ToString() == "I")
                    {
                        retVal += pI[i % 3];
                    }
                    else if (pass[i].ToString() == "J")
                    {
                        retVal += pJ[i % 3];
                    }
                    else if (pass[i].ToString() == "K")
                    {
                        retVal += pK[i % 3];
                    }
                    else if (pass[i].ToString() == "L")
                    {
                        retVal += pL[i % 3];
                    }
                    else if (pass[i].ToString() == "M")
                    {
                        retVal += pM[i % 3];
                    }
                    else if (pass[i].ToString() == "N")
                    {
                        retVal += pN[i % 3];
                    }
                    else if (pass[i].ToString() == "O")
                    {
                        retVal += pO[i % 3];
                    }
                    else if (pass[i].ToString() == "P")
                    {
                        retVal += pP[i % 3];
                    }
                    else if (pass[i].ToString() == "Q")
                    {
                        retVal += pQ[i % 3];
                    }
                    else if (pass[i].ToString() == "R")
                    {
                        retVal += pR[i % 3];
                    }
                    else if (pass[i].ToString() == "S")
                    {
                        retVal += pS[i % 3];
                    }
                    else if (pass[i].ToString() == "T")
                    {
                        retVal += pT[i % 3];
                    }
                    else if (pass[i].ToString() == "U")
                    {
                        retVal += pU[i % 3];
                    }
                    else if (pass[i].ToString() == "V")
                    {
                        retVal += pV[i % 3];
                    }
                    else if (pass[i].ToString() == "W")
                    {
                        retVal += pW[i % 3];
                    }
                    else if (pass[i].ToString() == "X")
                    {
                        retVal += pX[i % 3];
                    }
                    else if (pass[i].ToString() == "Y")
                    {
                        retVal += pY[i % 3];
                    }
                    else if (pass[i].ToString() == "Z")
                    {
                        retVal += pZ[i % 3];
                    }
                }
                else//是符号
                {
                    if (pass[i].ToString() == "!")
                    {
                        retVal += p11[i % 3];
                    }
                    else if (pass[i].ToString() == "@")
                    {
                        retVal += p12[i % 3];
                    }
                    else if (pass[i].ToString() == "#")
                    {
                        retVal += p13[i % 3];
                    }
                    else if (pass[i].ToString() == "$")
                    {
                        retVal += p14[i % 3];
                    }
                    else if (pass[i].ToString() == "%")
                    {
                        retVal += p15[i % 3];
                    }
                    else if (pass[i].ToString() == "^")
                    {
                        retVal += p16[i % 3];
                    }
                    else if (pass[i].ToString() == "&")
                    {
                        retVal += p17[i % 3];
                    }
                    else if (pass[i].ToString() == "*")
                    {
                        retVal += p18[i % 3];
                    }
                    else if (pass[i].ToString() == "(")
                    {
                        retVal += p19[i % 3];
                    }
                    else if (pass[i].ToString() == ")")
                    {
                        retVal += p20[i % 3];
                    }
                    else if (pass[i].ToString() == "_")
                    {
                        retVal += p21[i % 3];
                    }
                    else if (pass[i].ToString() == "+")
                    {
                        retVal += p22[i % 3];
                    }
                    else if (pass[i].ToString() == "=")
                    {
                        retVal += p23[i % 3];
                    }
                    else if (pass[i].ToString() == "-")
                    {
                        retVal += p24[i % 3];
                    }
                    else if (pass[i].ToString() == "[")
                    {
                        retVal += p25[i % 3];
                    }
                    else if (pass[i].ToString() == "]")
                    {
                        retVal += p26[i % 3];
                    }
                    else if (pass[i].ToString() == "{")
                    {
                        retVal += p27[i % 3];
                    }
                    else if (pass[i].ToString() == "}")
                    {
                        retVal += p28[i % 3];
                    }
                    else if (pass[i].ToString() == ";")
                    {
                        retVal += p29[i % 3];
                    }
                    else if (pass[i].ToString() == ":")
                    {
                        retVal += p30[i % 3];
                    }
                    else if (pass[i].ToString() == "\"")
                    {
                        retVal += p31[i % 3];
                    }
                    else if (pass[i].ToString() == "'")
                    {
                        retVal += p32[i % 3];
                    }
                    else if (pass[i].ToString() == ",")
                    {
                        retVal += p33[i % 3];
                    }
                    else if (pass[i].ToString() == ".")
                    {
                        retVal += p34[i % 3];
                    }
                    else if (pass[i].ToString() == "?")
                    {
                        retVal += p35[i % 3];
                    }
                    else if (pass[i].ToString() == "/")
                    {
                        retVal += p36[i % 3];
                    }
                    else if (pass[i].ToString() == "|")
                    {
                        retVal += p37[i % 3];
                    }
                    else if (pass[i].ToString() == "\\")
                    {
                        retVal += p38[i % 3];
                    }
                    else if (pass[i].ToString() == "`")
                    {
                        retVal += p39[i % 3];
                    }
                    else if (pass[i].ToString() == "~")
                    {
                        retVal += p40[i % 3];
                    }
                    else if (pass[i].ToString() == "<")
                    {
                        retVal += p41[i % 3];
                    }
                    else if (pass[i].ToString() == ">")
                    {
                        retVal += p42[i % 3];
                    }
                    else
                    {
                        retVal += "";
                    }
                }

                //retVal += pass[i].ToString();
            }

            retVal = KingdeeVersion >= 11 ? ")  F \", ,P T #8 *P!D &D 80!N &@ <0 C \'< : !M &4 )0" + retVal : retVal;

            return retVal;
        }
    }
}
