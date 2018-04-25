namespace KeelKit.Core
{
    using System;
    using System.Collections;
    using System.Text;

    public class StringUtils
    {
        public static string[] GetTableNameAlias(string nameAndAlias)
        {
            nameAndAlias = nameAndAlias.Trim();
            string[] strArray = new string[2];
            int index = nameAndAlias.IndexOf(" AS ", StringComparison.CurrentCultureIgnoreCase);
            if (index > 0)
            {
                strArray = Split(nameAndAlias, index, 0);
                if ((strArray[1] != null) && strArray[1].StartsWith("AS", StringComparison.CurrentCultureIgnoreCase))
                {
                    strArray[1] = strArray[1].Substring(2);
                }
            }
            else
            {
                bool flag = nameAndAlias.Contains(".");
                int num2 = 0;
                int num3 = 1;
                int mid = num3 + 1;
                string str = "";
                if (flag)
                {
                    mid = nameAndAlias.IndexOf(".");
                    string[] strArray2 = Split(nameAndAlias, mid, 0);
                    str = strArray2[0];
                    nameAndAlias = strArray2[1];
                }
                if (!nameAndAlias.Contains(" "))
                {
                    strArray[0] = nameAndAlias;
                    strArray[1] = nameAndAlias;
                }
                else if (char.IsLetterOrDigit(nameAndAlias, num2))
                {
                    mid = nameAndAlias.IndexOf(" ");
                    strArray = Split(nameAndAlias, mid, 0);
                }
                else
                {
                    char[] chArray;
                    do
                    {
                        chArray = nameAndAlias.ToCharArray();
                        for (int i = mid; i < chArray.Length; i++)
                        {
                            if (!(char.IsLetterOrDigit(chArray[i]) || char.IsWhiteSpace(chArray[i])))
                            {
                                num3 = i;
                                mid = i + 1;
                                break;
                            }
                        }
                        strArray = Split(nameAndAlias, mid, 0);
                    }
                    while ((mid < chArray.Length) && !IsBeginEndWithSymbol(strArray[0]));
                }
                if (flag)
                {
                    strArray[0] = str + "." + strArray[0];
                }
            }
            if (strArray[0] == null)
            {
                strArray[0] = nameAndAlias;
            }
            if (strArray[1] == null)
            {
                strArray[1] = strArray[0];
            }
            strArray[0] = RetrieveString(strArray[0].Trim());
            strArray[1] = RetrieveString(strArray[1].Trim());
            return strArray;
        }

        public static bool IsBeginEndWithSymbol(string str)
        {
            return (!char.IsLetterOrDigit(str, 0) && !char.IsLetterOrDigit(str, str.Length - 1));
        }

        public static bool IsValidObjectName(string name)
        {
            return true;
        }

        public static void Reorder()
        {
        }

        public static string RetrieveString(string str)
        {
            if (str != "")
            {
                str = str.Trim();
            }
            if ((str.Length > 2) && IsBeginEndWithSymbol(str))
            {
                str = str.Substring(1, str.Length - 2);
            }
            return str.Trim();
        }

        public static string[] Split(string str, string spliter)
        {
            ArrayList list = new ArrayList();
            for (int i = str.IndexOf(spliter, 0, StringComparison.CurrentCultureIgnoreCase); i > -1; i = str.IndexOf(spliter, 0, StringComparison.CurrentCultureIgnoreCase))
            {
                list.Add(str.Substring(0, i));
                str = str.Substring(i + spliter.Length);
            }
            if (str.Length > 0)
            {
                list.Add(str);
            }
            return (string[]) list.ToArray(typeof(string));
        }

        public static string[] Split(string str, int mid, int start)
        {
            string[] strArray = new string[2];
            if ((mid > 0) && (mid < str.Length))
            {
                strArray[0] = str.Substring(start, mid - start).Trim();
                strArray[1] = str.Substring(mid + 1, (str.Length - mid) - 1).Trim();
            }
            return strArray;
        }

        public static string ValidateSqlIdentifier(string identifier)
        {
            identifier = identifier.Replace("]", "]]");
            int index = identifier.IndexOf(".");
            if (index == -1)
            {
                if (identifier.IndexOf(" ") > -1)
                {
                    return ("[" + identifier + "]");
                }
                return identifier;
            }
            StringBuilder builder = new StringBuilder();
            while (index > -1)
            {
                string[] strArray = new string[4];
                strArray[0] = "";
                strArray[1] = identifier.Substring(0, index);
                strArray[2] = "";
                if (strArray[1].IndexOf(" ") > -1)
                {
                    strArray[0] = "[";
                    strArray[2] = "]";
                }
                strArray[3] = ".";
                builder.AppendFormat("{0}{1}{2}{3}", (object[]) strArray);
                identifier = identifier.Substring(index + 1, (identifier.Length - index) - 1);
                index = identifier.IndexOf(".");
            }
            if (identifier.IndexOf(" ") > -1)
            {
                return (builder.ToString() + "[" + identifier + "]");
            }
            return (builder.ToString() + identifier);
        }
    }
}

