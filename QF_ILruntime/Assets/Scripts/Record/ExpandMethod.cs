using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;
/// <summary>
/// 将常用的 不便于存储的数据  转换格式进行存储
/// </summary>
public static class ExpandMethod
{
    #region ToSaveString 对数据用|分隔开 并存储起来（对这几种类型进行封装转换成string,便于存储）
    public static string ToSaveString(this Vector3 v3)
    {
        StringBuilder sb = new StringBuilder();//线程不安全的string连接
        sb.Append(v3.x.ToString());
        sb.Append("|");
        sb.Append(v3.y.ToString());
        sb.Append("|");
        sb.Append(v3.z.ToString());
        return sb.ToString();
    }

    public static string ToSaveString(this Vector2 v2)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(v2.x.ToString());
        sb.Append("|");
        sb.Append(v2.y.ToString());
        return sb.ToString();
    }

    public static string ToSaveString(this Color color)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(color.r.ToString());
        sb.Append("|");
        sb.Append(color.g.ToString());
        sb.Append("|");
        sb.Append(color.b.ToString());
        sb.Append("|");
        sb.Append(color.a.ToString());
        return sb.ToString();
    }

    public static string ToSaveString(this List<string> list)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < list.Count; i++)
        {
            sb.Append(list[i]);
            if (i != list.Count - 1)
            {
                sb.Append("|");
            }
        }
        return sb.ToString();
    }

    public static string ToSaveString(this string[] list)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < list.Length; i++)
        {
            sb.Append(list[i]);
            if (i != list.Length - 1)
            {
                sb.Append("|");
            }
        }
        return sb.ToString();
    }
    #endregion

    static string[] c_NullStringArray = new string[0];
    static List<string> c_NullStringList = new List<string>();

    #region MyRegion 将x|y|z这样的数据类型 转换成常用的数据类型
    //string转 string[]
    public static string[] String2StringArray(string value)
    {
        if (value != null
            && value != ""
            && value != "null"
            && value != "Null"
            && value != "NULL"
            && value != "None")
        {
            return value.Split('|');
        }
        else
        {
            return c_NullStringArray;
        }
    }

    public static float[] String2FloatArray(string value)
    {
        string[] strArray = String2StringArray(value);
        float[] array = new float[strArray.Length];
        for (int i = 0; i < strArray.Length; i++)
        {
            float tmp = float.Parse(strArray[i]);

            array[i] = tmp;
        }
        return array;
    }

    public static bool[] String2BoolArray(string value)
    {
        string[] strArray = String2StringArray(value);
        bool[] array = new bool[strArray.Length];
        for (int i = 0; i < strArray.Length; i++)
        {
            bool tmp = bool.Parse(strArray[i]);
            array[i] = tmp;
        }
        return array;
    }

    public static Vector2 String2Vector2(string value)
    {
        try
        {
            string[] values = value.Split(',');
            float x = float.Parse(values[0]);
            float y = float.Parse(values[1]);
            return new Vector2(x, y);
        }
        catch (Exception e)
        {
            throw new Exception("ParseVector2: Don't convert value to Vector2 value:" + value + "\n" + e.ToString()); // throw  
        }
    }

    public static Vector3 String2Vector3(string value)
    {
        try
        {
            string[] values = value.Split(',');
            float x = float.Parse(values[0]);
            float y = float.Parse(values[1]);
            float z = float.Parse(values[2]);
            return new Vector3(x, y, z);
        }
        catch (Exception e)
        {
            throw new Exception("ParseVector3: Don't convert value to Vector3 value:" + value + "\n" + e.ToString()); // throw  
        }
    }

    public static Color String2Color(string value)
    {
        try
        {
            string[] values = value.Split(',');
            float r = float.Parse(values[0]);
            float g = float.Parse(values[1]);
            float b = float.Parse(values[2]);
            float a = 1;
            if (values.Length > 3)
            {
                a = float.Parse(values[3]);
            }
            return new Color(r, g, b, a);
        }
        catch (Exception e)
        {
            throw new Exception("ParseColor: Don't convert value to Color value:" + value + "\n" + e.ToString()); // throw  
        }
    }

    public static int[] String2IntArray(string value)
    {
        int[] intArray = null;
        if (!string.IsNullOrEmpty(value))
        {
            string[] strs = value.Split('|');
            intArray = Array.ConvertAll(strs, s => int.Parse(s));
            return intArray;
        }
        else
        {
            return new int[0];
        }
    }

    public static List<string> String2StringList(string value)
    {
        List<string> l = new List<string>();
        if (value != null
            && value != ""
            && value != "null"
            && value != "Null"
            && value != "NULL"
            && value != "None")
        {
            string[] s =  value.Split('|');
            for (int i = 0; i < s.Length; i++)
            {
                l.Add(s[i]);
            }
            return l;
        }
        else
        {
            return c_NullStringList;
        }
    }

    #endregion

    //判断是否是同一天
    public static bool IsOneDay(DateTime t1, DateTime t2)
    {
        return (t1.Year == t2.Year &&
         t1.Month == t2.Month &&
          t1.Day == t2.Day);
    }

}
