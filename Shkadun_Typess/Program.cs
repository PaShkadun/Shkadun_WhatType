using System;

namespace Shkadun_WhatType
{
    class Program
    {
        static void Main(string[] args)
        {
            String str;
            Console.WriteLine("Write object-type");
            for (int i = 0; i < 11; i++)
            {
                //Console.WriteLine(FindTypeOfObject(obj.ToString())); //Первый вариант решения задачи
                object obj;
                obj = Console.ReadLine();
                switch (FindType(obj))
                {
                    case "Bool": str = $"{obj} is bool"; break;
                    case "Byte": str = $"{obj} is byte"; break;
                    case "Short": str = $"{obj} is short"; break;
                    case "Int": str = $"{obj} is int"; break;
                    case "Long": str = $"{obj} is long"; break;
                    case "Float": str = $"{obj} is float"; break;
                    case "Decimal": str = $"{obj} is decimal"; break;
                    case "Double": str = $"{obj} is double"; break;
                    case "Char": str = $"{obj} is char"; break;
                    case "String": str = $"{obj} is string"; break;
                    case "Empty": str = $"{obj} is empty"; break;
                    default: str = $"{obj} is a error"; break;
                }
                Console.WriteLine(str);
            }
        }

        private static string FindType(object obj)
        {
            object newObj = null;
            char[] c;
            try
            {
                newObj = Convert.ToDouble(obj);
                double doubleObj = (double)newObj;
                c = obj.ToString().ToCharArray();
                bool Paint = false;
                int position = -1;
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] == ',')
                    {
                        Paint = true;
                        position = i;
                        break;
                    }
                }
                if (Paint)
                {
                    if (c.Length - (position + 1) == 1 && doubleObj >= (-3.4 * Math.Pow(10, 38)) &&
                       doubleObj <= (3.4 * Math.Pow(10, 38)))
                    {
                        newObj = "Float";
                    }
                    else if (c.Length - (position + 1) >= 16 && doubleObj >= (-1.0 * Math.Pow(10, 28)) &&
                            doubleObj <= (7.9228 * Math.Pow(10, 28)))
                    {
                        newObj = "Decimal";
                    }
                    else
                    {
                        newObj = "Double";
                    }
                }
                else
                {
                    if (doubleObj >= -128 && doubleObj <= 127)
                    {
                        newObj = "Byte";
                    }
                    else if (doubleObj >= -32768 && doubleObj <= 32767)
                    {
                        newObj = "Short";
                    }
                    else if (doubleObj >= -2147483648 && doubleObj <= 2147483647)
                    {
                        newObj = "Int";
                    }
                    else if (doubleObj >= (-1 * Math.Pow(2, 64)) && doubleObj <= Math.Pow(2, 64) - 1)
                    {
                        newObj = "Long";
                    }
                    else if (doubleObj >= (-1 * Math.Pow(10, 28)) && doubleObj <= (7.9228 * Math.Pow(10, 28)))
                    {
                        newObj = "Decimal";
                    }
                    else if (doubleObj >= (-3.4 * Math.Pow(10, 38)) && doubleObj <= (3.4 * Math.Pow(10, 38)))
                    {
                        newObj = "Float";
                    }
                    else
                    {
                        newObj = "Double";
                    }
                }
            }
            catch
            {
                if (obj.ToString() == "true" || obj.ToString() == "false")
                {
                    newObj = "Bool";
                }
                else
                {
                    c = obj.ToString().ToCharArray();
                    if (c.Length > 1)
                    {
                        newObj = "String";
                    }
                    else if (c.Length == 1)
                    {
                        newObj = "Char";
                    }
                    else
                    {
                        newObj = "Empty";
                    }
                }
            }
            return newObj.ToString();
        }

        private static string FindTypeOfObject(string obj)
        {
            double d = 0;
            long l = 0;
            if (obj == "true" || obj == "false")
            {
                return $"{obj} is bool";
            }
            else if (Int64.TryParse(obj, out l))
            {
                if (l >= -128 && l <= 127)
                {
                    return $"{obj} is byte";
                }
                else if (l >= -32768 && l <= 32767)
                {
                    return $"{obj} is short";
                }
                else if (l >= -2147483648 && l <= 2147483647)
                {
                    return $"{obj} is int";
                }
                else
                {
                    return $"{obj} is long";
                }
            }
            else if (Double.TryParse(obj, out d))
            {
                char[] c = obj.ToCharArray();
                int position = -1;
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] == ',')
                    {
                        position = i;
                    }
                }
                if (position != -1)
                {
                    if (c.Length - (position + 1) > 15)
                    {
                        return $"{obj} is decimal";
                    }
                    else if (c.Length - (position + 1) > 1)
                    {
                        return $"{obj} is double";
                    }
                    else
                    {
                        return $"{obj} is float";
                    }
                }
                else
                {
                    if (d >= (-1 * Math.Pow(10, 28)) && d <= (7.9228 * Math.Pow(10, 28)))
                    {
                        return $"{obj} is decimal";
                    }
                    else if (d >= (-3.4 * Math.Pow(10, 38)) && d <= (3.4 * Math.Pow(10, 38)))
                    {
                        return $"{obj} is float";
                    }
                    else
                    {
                        return $"{obj} is double";
                    }
                }
            }
            else
            {
                char[] c = obj.ToCharArray();
                if (c.Length == 1)
                {
                    return $"{obj} is char";
                }
                else
                {
                    return $"{obj} is String";
                }
            }
        }
    }
}
