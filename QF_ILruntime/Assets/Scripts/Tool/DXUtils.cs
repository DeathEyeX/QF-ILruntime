/*
 * When I wrote this, only God and I understood what I was doing
 * Now,God only konws
 */

/*
 * You may think you know what the following code does.
 * But you dont. Trust me.
 * Fiddle with it. and you'll spend many a sleepless
 * night cursing the moment you thought you'd be clever
 * enough to "optimize" the code below.
 * Now close this file and go play with something else.
 */

/*
 * this code sucks ,you know it an I know it.
 */

/* I am not responsible of this code.
 * They made me write it. against my will.
 */

/*
 * no comments for you
 * it was hard to write
 * so it should be hard to read
 */

/* 
 * if this code works. it was written by Paul Dilascia. If not,I don't know Who wrote it
 */

/*
 * Dear maintainer:
 * 
 * Once you are done trying to 'optimize' htis routine,
 * and have realized what a terrible mistake that was,
 * please increment the fllowing counter as a warning
 * to the next guy:
 * 
 * total_hours_wasted_here = 42
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
//using DG.Tweening;
using UnityEngine.UI;
public static class DXUtils
{
    // static DXUtils()
    //{
    //    Debug.Log("DX Launch.....");
    //    Debug.Log("俺はガンダムだ!");
        
    //}
    #region UnityLog ----2019.8.22
    //public static void LogVecor3(this Vector3 ve3,string content = "")
    //{
    //    Debug.Log(content + "  " + "x: " + ve3.x + "  y: " + ve3.y + "  z: " + ve3.z);
    //}
    //public static void LogVecor2(this Vector2 ve3, string content = "")
    //{
    //    Debug.Log(content + "  " + "x: " + ve3.x + "  y: " + ve3.y);
    //}
    //public static void DLog(this object str)
    //{
    //    Debug.Log(str.ToString());
    //}
    //public static void DLog(this System.Exception e)
    //{
    //    Debug.Log(e);
    //}
    //public static void DLog(this List<GameObject> list)
    //{
    //    string a = "";
    //    for(int i = 0; i < list.Count; i++)
    //    {
    //        a += list[i].name;
    //        a += "  ";
    //    }
    //    Debug.Log(a);
    //}
    //public static void DLog<T>(this List<T> list)
    //{
    //    string a = "";
    //    for (int i = 0; i < list.Count; i++)
    //    {
    //        a += list[i];
    //        a += "  ";
    //    }
    //    Debug.Log(a);
    //}
    //public static void DLog(this Dictionary<int, List<int>> dic)
    //{
    //    string key = "";
    //    string value = "";
      
    //    foreach (var b in dic)
    //    {
    //        key += b.Key;
    //        key += " ";
    //        for(int i = 0; i < b.Value.Count; i++)
    //        {
    //        value += b.Value[i];
    //        value += " ";
    //        }
    //    Debug.Log("Key为----" + key+ "Value为----" + value);
    //        key = "";
    //        value = "";
    //    }
       
    //}
    //public static void DLog<T,X>(this Dictionary<T,X> dic)
    //{
    //    string key = "";
    //    string value = "";
    //    string allthing = "";
    //    foreach (var b in dic)
    //    {
    //        key += b.Key;
    //        key += " ";
    //        value += b.Value;
    //        value += " ";
    //        allthing += b.Key;
    //        allthing += "-";
    //        allthing += b.Value;
    //        allthing += " ";
    //    }
    //    Debug.Log("Key为："+key);
    //    Debug.Log("Value为："+value);
    //    Debug.Log("所有值为："+allthing);
    //}
  
    #endregion

    #region  obj
    public static GameObject Hide(this GameObject selfObj)
    {
        if(selfObj.activeSelf) selfObj.SetActive(false);
        return selfObj;
    }
    public static GameObject Show(this GameObject selfObj)
    {
        if (!selfObj.activeSelf); selfObj.SetActive(true);
        return selfObj;
    }
    public static Transform Hide(this Transform selfObj)
    {
        if (selfObj.gameObject.activeSelf) selfObj.gameObject.SetActive(false);
        return selfObj;
    }
    public static Transform Show(this Transform selfObj)
    {
        if (!selfObj.gameObject.activeSelf) selfObj.gameObject.SetActive(true);
        return selfObj;
    }
    #endregion

    #region checkNull //判断有问题 不建议使用
    //public static bool IsNull(this GameObject selfObj)
    //{
    //    return null == selfObj;
    //}
    //public static bool IsNotNull(this GameObject selfObj)
    //{
    //    return null != selfObj;
    //}

    //public static bool IsNull(this Transform selfObj)
    //{
    //    return null == selfObj;
    //}
    //public static bool IsNotNull(this Transform selfObj)
    //{
    //    return null != selfObj;
    //}



    //public static bool IsNull<T>(this T selfObj) where T : class
    //{
    //    return null == selfObj;
    //}

    //public static bool IsNotNull<T>(this T selfObj) where T : class
    //{
    //    return null != selfObj;
    //}
    #endregion

    #region CheckPlatform
    public static bool IsAndroid
    {
        get
        {
            bool retValue = false;
#if UNITY_ANDROID
            retValue = true;
#endif
            return retValue;
        }
    }

    public static bool IsEditor
    {
        get
        {
            bool retValue = false;
#if UNITY_EDITOR
            retValue = true;
#endif
            return retValue;
        }
    }

    public static bool IsiOS
    {
        get
        {
            bool retValue = false;
#if UNITY_IOS
                retValue = true;    
#endif
            return retValue;
        }
    }

    public static bool IsStandaloneWindows
    {
        get
        {
            bool retValue = false;
#if UNITY_STANDALONE_WIN
                retValue = true;    
#endif
            return retValue;
        }
    }
    #endregion

    #region convertDicValue

    public static string DicToString(this IDictionary dic, string key, string defaultValue = "")
    {
        try
        {
            if (!dic.Contains(key))
            {
                return defaultValue;
            }

            if (dic[key] == null)
            {
                return defaultValue;
            }

            return  Convert.ToString(dic[key]);
        }
        catch (Exception e)
        {

            Debug.LogWarning("dictionaryToString:" + e.ToString());
            return defaultValue;

        }
    }

    public static int DicToInt(this IDictionary dic, string key, int defaultValue = 0)
    {
        try
        {
            if (!dic.Contains(key))
            {
                return defaultValue;
            }

            if (dic[key] == null)
            {
                return defaultValue;
            }

            return  Convert.ToInt32(dic[key]);
        }
        catch (Exception e)
        {
            Debug.LogWarning("convert error:" + e.ToString());
            return defaultValue;

        }
    }

    public static float DicToFloat(this IDictionary dic, string key, float defaultValue = 0)
    {
        try
        {
            if (!dic.Contains(key))
            {
                return defaultValue;
            }

            if (dic[key] == null)
            {
                return defaultValue;
            }

            return  dic[key].ToString().StringToFloat();
        }
        catch (Exception e)
        {
            Debug.LogWarning("convert error:" + e.ToString());
            return defaultValue;

        }
    }

    public static long DicToLong(this IDictionary dic, string key, long defaultValue = 0)
    {
        try
        {
            if (!dic.Contains(key))
            {
                return defaultValue;
            }

            if (dic[key] == null)
            {
                return defaultValue;
            }

            return dic[key].ToString().StringTolong();
        }
        catch (Exception e)
        {
            Debug.LogWarning("convert error:" + e.ToString());
            return defaultValue;

        }
    }




    public static bool DicToBool(this IDictionary dic, string key, bool defaultValue = false)
    {
        try
        {
            if (!dic.Contains(key))
            {
                return defaultValue;
            }

            if (dic[key] == null)
            {
                return defaultValue;
            }

            return dic[key].ToString().StringToBool();
        }
        catch (Exception e)
        {
            Debug.LogWarning("convert error:" + e.ToString());
            return defaultValue;

        }
    }

    public static IDictionary DicToDic(this IDictionary dic, string key)
    {
        try
        {
            if (!dic.Contains(key))
            {
                return null;
            }

            if (dic[key] == null)
            {
                return null;
            }

            return dic[key] as IDictionary;
        }
        catch (Exception e)
        {
            Debug.LogWarning("convert error:" + e.ToString());
            return null;

        }
    }

    public static IList DicToList(this IDictionary dic, string key)
    {
        try
        {
            if (!dic.Contains(key))
            {
                return null;
            }

            if (dic[key] == null)
            {
                return null;
            }

            return dic[key] as IList;
        }
        catch (Exception e)
        {
            Debug.LogWarning("convert error:" + e.ToString());
            return null;

        }
    }
    #endregion

    #region convertString
    public static float StringToFloat(this string str)
    {
        try
        {
            if (str == "" || str == null)
            {
                return 0;
            }
            else
            {
                return float.Parse(str);
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning("convert error:" + e.ToString());
            return 0;
        }
    }

    public static double StringToDouble(this string str)
    {
        try
        {
            if (str == "" || str == null)
            {
                return 0;
            }
            else
            {
                return double.Parse(str);
            }
        }
        catch (Exception e)
        {

            Debug.LogWarning("convert error:" + e.ToString());
            return 0;
        }
    }

    public static long StringTolong(this string str)
    {
        try
        {
            if (str == "" || str == null)
            {
                return 0;
            }
            else
            {
                return long.Parse(str);
            }
        }
        catch (Exception e)
        {

            Debug.LogWarning("convert error:" + e.ToString());
            return 0;
        }
    }

    public static int StringToInt(this string str)
    {
        try
        {
            if (str == "" || str == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(str);
            }
        }
        catch (Exception e)
        {

            Debug.LogWarning("convert error:" + e.ToString());
            return 0;
        }
    }

    public static bool StringToBool(this string str)
    {
        try
        {
            if (str.Equals("1") || str.Equals("true") || str.Equals("True"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning("convert error:" + e.ToString());
            return false;
        }
    }

    public static int[] StringToIntArr(this string str, char splitStr)
    {
        try
        {
            string[] strs = str.Split(splitStr);
            int[] arr;
            if (strs[strs.Length - 1].Length > 0)
            {
                arr = new int[strs.Length];
            }
            else
            {
                arr = new int[strs.Length - 1];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(strs[i]);

            }
            return arr;
        }
        catch (Exception e)
        {
            Debug.LogWarning("convert error:" + e.ToString());
            return null;
        }
    }

    public static float[] StringToFloatArr(this string str, char splitStr)
    {

        try
        {
            string[] strs = str.Split(splitStr);
            float[] arr;
            if (strs[strs.Length - 1].Length > 0)
            {
                arr = new float[strs.Length];
            }
            else
            {
                arr = new float[strs.Length - 1];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = float.Parse(strs[i]);
            }
            return arr;
        }
        catch (Exception e)
        {
            Debug.LogWarning("convert error:" + e.ToString());
            return null;
        }
    }

    public static long[] StringToLongArr(this string str, char splitStr)
    {
        try
        {
            string[] strs = str.Split(splitStr);
            long[] arr;
            if (strs[strs.Length - 1].Length > 0)
            {
                arr = new long[strs.Length];
            }
            else
            {
                arr = new long[strs.Length - 1];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = long.Parse(strs[i]);
            }
            return arr;
        }
        catch (Exception e)
        {
            Debug.LogWarning("stringToLongArr:" + e.ToString());
            return null;
        }
    }


    public static string[] StringToStringArr(this string str,string splitStr)
    {
        return Regex.Split(str, splitStr, RegexOptions.IgnoreCase);
    }

    public static int stringToAscII(this string str)
    {
        byte[] array = System.Text.Encoding.ASCII.GetBytes(str);
        return  (int)(array[0]);
    }

 
    #endregion

    #region  convertBool
    public static int BoolToInt(this bool n)
    {
        try
        {
            if (n == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning("convert error:" + e.ToString());
            return 0;
        }
    }

    #endregion

    #region convertInt

    public static bool IntToBool(this int n)
    {
        try
        {
            if (n >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning("convert error:" + e.ToString());
            return false;
        }
    }

    #endregion

    #region convertArr

    public static string ArrToString(this object[] arr, string splitStr)
    {
        try
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str = str + arr[i];
                if (i < arr.Length - 1)
                {
                    str = str + splitStr;
                }
            }
            return str;
        }
        catch (Exception e)
        {
            Debug.LogWarning("convert error:" + e.ToString());
            return null;
        }
    }

    #endregion

    #region convertList

    public static string ListToString(this List<object> arr, string splitStr = "")
    {
        try
        {
            string s = "";
            for (int i = 0; i < arr.Count; i++)
            {
                s = s + arr[i];
                if (i < arr.Count - 1)
                {
                    s = s + splitStr;
                }
            }
            return s;

        }
        catch (Exception e)
        {
            Debug.LogWarning("listToString:" + e.ToString());
            return null;
        }
    }

    public static int[] ListToIntArr(this List<object> arr)
    {
        try
        {
            
            int[] intArr = new int[arr.Count];

            for(int i = 0; i < arr.Count; i++)
            {
                intArr[i] =(int)(arr[i]);
            }
            return intArr;
        }
        catch (Exception e)
        {
            Debug.LogWarning("listToString:" + e.ToString());
            return null;
        }
    }

    public static int[] ListToIntArr(this IList arr)
    {
        try
        {

            int[] intArr = new int[arr.Count];

            for (int i = 0; i < arr.Count; i++)
            {
                intArr[i] = (int)(arr[i]);
            }
            return intArr;
        }
        catch (Exception e)
        {
            Debug.LogWarning("listToString:" + e.ToString());
            return null;
        }
    }

    public static float[] ListToFloatArr(this List<object> arr)
    {
        try
        {

            float[] intArr = new float[arr.Count];

            for (int i = 0; i < arr.Count; i++)
            {
                intArr[i] = (float)arr[i];
            }
            return intArr;
        }
        catch (Exception e)
        {
            Debug.LogWarning("listToString:" + e.ToString());
            return null;
        }
    }

    public static float[] ListToFloatArr(this IList arr)
    {
        try
        {

            float[] intArr = new float[arr.Count];

            for (int i = 0; i < arr.Count; i++)
            {
                intArr[i] = arr[i].ToString().StringToFloat();
            }
            return intArr;
        }
        catch (Exception e)
        {
            Debug.LogWarning("listToString:" + e.ToString());
            return null;
        }
    }
    #endregion

    #region covertObj

    public static int ObjectToInt(this object obj)
    {
        try
        {   
            return (int)(obj);
        }
        catch (Exception e)
        {
            Debug.LogWarning("ObjectToInt:" + e.ToString());
            return 0;
        }
    }
    public static float ObjectToFloat(this object obj)
    {
        try
        {
            return (float)(obj);
        }
        catch (Exception e)
        {
            Debug.LogWarning("ObjectToFloat:" + e.ToString());
            return 0;
        }
    }
    #endregion

    #region converEnum
    
    public static int EnumToInit(this Enum enumObj)
    {

        try
        {
            return enumObj.GetHashCode();
        }
        catch (Exception e)
        {
            Debug.LogWarning("EnumToInit:" + e.ToString());
            return 0;
        }
    }

    #endregion

    #region convert to Chinese

    static string strChnNames = "零一二三四五六七八九";
    static string strDanwei = "个十百千";

    public static string ChineseChange( this string s, int nowP, int allP)
    {

        int n = s.StringToInt();
        if (n == 0)
        {
            return "零";
        }



        string[] shuzhi = new string[s.Length];
        string[] danwei = new string[s.Length];

        int count = 0;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            n = (s[i] + "").StringToInt();
            shuzhi[i] = strChnNames[n] + "";
            if (count > 0 && n != 0)
            {
                danwei[i] = strDanwei[count] + "";
            }
            count++;
        }

        string str = "";
        count = 0;

        bool isZ = false;
        for (int i = 0; i < s.Length; i++)
        {
            if (isZ && shuzhi[i].Equals("零"))
            {

            }
            else
            {
                if (shuzhi[i].Equals("零"))
                {
                    isZ = true;
                    str = str + shuzhi[i];

                }
                else
                {
                    isZ = false;
                    if (shuzhi[i] == "一" && danwei[i] == "十" && ((allP == 1 && nowP == 1) || (allP == 2 && nowP == 2) || (allP == 3 && nowP == 3)) && s.Length == 2)
                    {
                        str = str + "十";
                    }
                    else
                    {
                        str = str + shuzhi[i] + danwei[i];
                    }

                }

            }

        }

        return str;
    }


    public static string Quling(this string s, bool isQ, bool isH, bool isQudanwei = false)
    {
        int q = 0;
        int h = s.Length - 1;
        bool isquanling = true;
        if (isQ)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Equals('零'))
                {
                    q++;
                }
                else
                {
                    isquanling = false;
                    break;
                }
            }

        }



        if (isH)
        {
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i].Equals('零'))
                {
                    h--;
                }
                else
                {
                    isquanling = false;
                    break;
                }
            }

        }

        if (isquanling)
        {
            return "零";
        }

        s = s.Substring(q, h - q + 1);
        if (isQudanwei && s.Length > 2 && !s[s.Length - 3].Equals('零') && (s[s.Length - 1].Equals('十') || s[s.Length - 1].Equals('百') || s[s.Length - 1].Equals('千')))
        {
            s = s.Substring(0, s.Length - 1);
        }
        return s;
    }


    /// <summary>
    /// 数字小写转中文大写 如123转为一百二十三
    /// </summary>
    /// <returns>中文大写</returns>
    /// <param name="s">数字</param>
    public static string ChineseCapital(string s)
    {
        if (s.Length > 12)
        {
            return "--";
        }
        string ss = "";
        string ss1 = "";
        string ss2 = "";
        if (s.Length <= 4)
        {
            ss = ChineseChange(s, 1, 1);
        }
        else if (s.Length <= 8)
        {
            ss1 = ChineseChange(s.Substring(s.Length - 4, 4), 1, 2);
            ss2 = ChineseChange(s.Substring(0, s.Length - 4), 2, 2);

            if (ss2[(ss2.Length - 1)].Equals('零'))
            {
                ss = Quling(ss2, false, true) + "万零" + Quling(ss1, true, false);
            }
            else
            {
                ss = ss2 + "万" + ss1;
            }
        }
        else if (s.Length <= 12)
        {
            ss1 = ChineseChange(s.Substring(s.Length - 4, 4), 1, 3);
            ss2 = ChineseChange(s.Substring(s.Length - 8, 4), 2, 3);

            if (ss2.Equals("零"))
            {
                if (!ss1.Equals("零"))
                {
                    ss1 = "零" + Quling(ss1, true, false);
                }
            }
            else if (ss2[(ss2.Length - 1)].Equals('零'))
            {
                ss1 = Quling(ss2, false, true) + "万零" + Quling(ss1, true, false);
            }
            else
            {
                ss1 = ss2 + "万" + ss1;
            }

            ss2 = ChineseChange(s.Substring(0, s.Length - 8), 3, 3);
            if (ss2[(ss2.Length - 1)].Equals('零'))
            {
                ss = Quling(ss2, false, true) + "亿零" + Quling(ss1, true, false);
            }
            else
            {
                ss = ss2 + "亿" + ss1;
            }
        }
        ss = Quling(ss, true, true, true);
        return ss;
    }

    #endregion

    #region convertHashTabel
    public static string HashtableToString(this Hashtable table, string key, string defaultValue = "")
    {
        try
        {
            if (!table.Contains(key))
            {
                return defaultValue;
            }

            if (table[key] == null)
            {
                return defaultValue;
            }

            return table[key].ToString();
        }
        catch (Exception e)
        {
            Debug.LogWarning("HashtableToString:" + e.ToString());
            return defaultValue;

        }

    }


    public static int HashtableToInt(this Hashtable table, string key, int defaultValue = 0)
    {
        try
        {
            if (!table.Contains(key))
            {
                return defaultValue;
            }

            if (table[key] == null)
            {
                return defaultValue;
            }

            return Convert.ToInt32(table[key]);
        }
        catch (Exception e)
        {
            Debug.LogWarning("hashtableToInt:" + e.ToString());
            return defaultValue;

        }
    }


    public static float HashtableToFloat(this Hashtable table, string key, float defaultValue = 0)
    {
        try
        {
            if (!table.Contains(key))
            {
                return defaultValue;
            }

            if (table[key] == null)
            {
                return defaultValue;
            }

            return  Convert.ToSingle(table[key]);
        }
        catch (Exception e)
        {
            Debug.LogWarning("hashtableToFloat:" + e.ToString());
            return defaultValue;

        }
    }

    /// <summary>
    /// 通过键从Hashtable取值并转成long
    /// </summary>
    /// <returns>The to long.</returns>
    /// <param name="dictionary">Dictionary.</param>
    /// <param name="key">需要的键</param>
    /// <param name="defaultValue">如果Hashtable中没有改键所对应的值,那么值为什么,改值默认为0</param>
    public static long HashtableToLong(this Hashtable table, string key, long defaultValue = 0)
    {
        try
        {
            if (!table.Contains(key))
            {
                return defaultValue;
            }

            if (table[key] == null)
            {
                return defaultValue;
            }

            return (long)(table[key]);
        }
        catch (Exception e)
        {
            Debug.LogWarning("hashtableToLong:" + e.ToString());
            return defaultValue;

        }
    }



    public static bool HashtableToBool(this Hashtable table, string ket, bool defaultValue = false)
    {
        try
        {
            if (!table.Contains(ket))
            {
                return defaultValue;
            }

            if (table[ket] == null)
            {
                return defaultValue;
            }

            return Convert.ToBoolean(table[ket]);
        }
        catch (Exception e)
        {
            Debug.LogWarning("hashtableToBool:" + e.ToString());
            return defaultValue;

        }
    }
    #endregion

    #region labelChange
    public static string LabelChange(this object strobj, string flage)
    {
        string str = strobj.ToString();
        string s = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (i < str.Length - 1 && str[i] == '\\' && str[i + 1] == 'n')
            {
                s = s + "\n";
                i++;
            }
            else
            {
                s = s + flage + str[i];
            }

        }
        return s;
    }
    
    
    
    #endregion

    #region calculate


    public static float returnAngByTowPos(Vector3 v1, Vector3 v2)
    {
        float r = 0;
        if (v2.y == v1.y)
        {
            if (v2.x < v1.x)
            {
                r = 90;
            }
            else
            {
                r = 270;
            }
        }

        else if (v2.x == v1.x)
        {
            if (v2.y < v1.y)
            {
                r = 180;
            }
            else
            {
                r = 0;
            }
        }

        else
        {
            r = Mathf.Atan(Mathf.Abs((v1.x - v2.x) / (v2.y - v1.y))) * Mathf.Rad2Deg;

            if (v2.x < v1.x)
            {
                if (v2.y > v1.y)
                {
                    r = r;
                }
                else
                {
                    r = 180 - r;
                }
            }
            else
            {
                if (v2.y > v1.y)
                {
                    r = 360 - r;
                }
                else
                {
                    r = r + 180;
                }
            }
        }

        return r;
    }

    /// <summary>
    /// 基于某个点选择好多度后的坐标
    /// </summary>
    /// <returns>旋转后的坐标</returns>
    /// <param name="parentPos">旋转中心点</param>
    /// <param name="nowPosition">旋转前该点的坐标</param>
    /// <param name="ang">旋转角度</param>
    public static Vector3 getPosToRotatingForAng(Vector3 parentPos, Vector3 nowPosition, float ang)
    {

        Vector3 v1 = new Vector3(0.0f, 0.0f, 0.0f);
        v1.x = (float)(parentPos.x -
                        (parentPos.x - nowPosition.x) * Mathf.Cos(ang * Mathf.Deg2Rad) -
                        (nowPosition.y - parentPos.y) * Mathf.Sin(ang * Mathf.Deg2Rad));

        v1.y = (float)(-(parentPos.x - nowPosition.x) * Mathf.Sin(ang * Mathf.Deg2Rad)
                        + (nowPosition.y - parentPos.y) * Mathf.Cos(ang * Mathf.Deg2Rad)
                        + parentPos.y);
        v1.z = 0;
        return v1;
    }

    /// <summary>
    /// 两个位置之间的距离——x,y    vector2  vector3 自身有Distance 方法 不要用下面的方法了
    /// </summary>
    /// <returns>长度</returns>
    /// <param name="bv">位置1</param>
    /// <param name="ev">位置2</param>
    public static float getLengthForTwoPosition(Vector3 bv, Vector3 ev)
    {
        return Mathf.Sqrt((bv.x - ev.x) * (bv.x - ev.x) + (bv.y - ev.y) * (bv.y - ev.y));
    }


    public static float getTimeFromTwoPosBaseSpeed(Vector3 bv, Vector3 ev,float speed)
    {
        return getLengthForTwoPosition(bv, ev) / speed;
    }
    #endregion

    #region timeDelayCallBack
    //need DoTween surpport;
    //public static Tweener TimeTween(float duration = 0, TweenCallback onStart = null, TweenCallback onComplete = null)
    //{
    //    float i = 0;
    //    if (duration <= 0.01f) duration = 0.01f;
    //    Tweener tween = DOTween.To(() => i, x => i = x, 1, duration);
    //    if (onStart != null) tween.OnStart(onStart);
    //    if (onComplete != null) tween.OnComplete(onComplete);
    //    return tween;
    //}

    #endregion

    #region getColor
    //透明度变化
    public static Color alpha0Color = new Color(1, 1, 1, 0);
    public static Color alpha1Color = new Color(1, 1, 1, 1);
    public static Color alpha05Color = new Color(0.5f, 0.5f, 0.5f, 1f);
    private static Color alphaSColor = new Color(1, 1, 1, 1);
    
    public static Color GetAlphaColor(float _a)
    {
        alphaSColor.a = Mathf.Clamp01(_a);
        return alphaSColor;
    }

    public static Color GetAlphaColor(this Color _selfColor,float _a)
    {
        _selfColor.a = _a;
        return _selfColor;
    }
    
    #endregion

    #region getTime
    /// <summary>
	/// 得到当前时间（单位毫秒）
	/// </summary>
	/// <returns>The now time.</returns>
	public static long GetNowTimeMilliseconds()
    {
        return (long)(System.DateTime.UtcNow - new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)).TotalMilliseconds;
    }


    public const int timeType_YYMMDD = 0;
    public const int timeType_HHMMSS = 1;

    /// <summary>
    /// 得到当前时间自定义格式"yyyy-MM-dd HH：mm：ss：ffff"
    /// </summary>
    /// <returns>The now time date.</returns>
    /// <param name="type">自定义格式</param>
    public static string GetNowTimeDate(string type)
    {
        return System.DateTime.Now.ToString(type);
    }

    /// <summary>
    /// 得到当前时间
    /// </summary>
    /// <returns>The now time date.</returns>
    /// <param name="type">格式样式</param>
    public static string GetNowTimeDate(int type)
    {
        if (type == timeType_YYMMDD)
        {

            return System.DateTime.Now.ToString("yyyy-MM-dd");
        }

        if (type == timeType_HHMMSS)
        {

            return System.DateTime.Now.ToString("HH：mm：ss");
        }

        return System.DateTime.Now.ToString("yyyy-MM-dd HH：mm：ss：fff");
    }

    //毫秒级时间单位转化
    public static long NormalTimeToMs(int day,int hour,int min,int s,int ms)
    {
        return day * 24 * 3600 * 1000 + hour * 3600 * 1000 + min * 60 * 1000 + s * 1000 + ms;
    }
    public static int MsTimeToNomal(long msValue,string timeUnit)
    {
        int day =(int) (msValue / (24 * 3600 * 1000));
        if (timeUnit.Equals("day"))
        {
            return day;
        }
        int hour = (int)((msValue - day * 24 * 3600 * 1000) / 3600000);
        if (timeUnit.Equals("hour"))
        {
            return hour;
        }
        int min = (int)((msValue - day * 24 * 3600 * 1000 - hour * 3600 * 1000) / 60000);
        if (timeUnit.Equals("min"))
        {
            return min;
        }
        int s = (int)((msValue - day * 24 * 3600 * 1000 - hour * 3600 * 1000 - min * 60 * 1000) / 1000);
        if (timeUnit.Equals("s"))
        {
            return s;
        }
        int ms = (int)((msValue - day * 24 * 3600 * 1000 - hour * 3600 * 1000 - min * 60 * 1000 - s * 1000));
        return ms;
    }

    public static string MsTimeToMin_S_Ms(long msValue)
    {
        int day = (int)(msValue / (24 * 3600 * 1000));
        int hour = (int)((msValue - day * 24 * 3600 * 1000) / 3600000);
        int min = (int)((msValue - day * 24 * 3600 * 1000 - hour * 3600 * 1000) / 60000);
        int s = (int)((msValue - day * 24 * 3600 * 1000 - hour * 3600 * 1000 - min * 60 * 1000) / 1000);
        int ms = (int)((msValue - day * 24 * 3600 * 1000 - hour * 3600 * 1000 - min * 60 * 1000 - s * 1000));
        return string.Format("{0:D2}:{1:D2}:{2:D2}", min,s,ms / 10);

    }
    #endregion

    #region Foo
    public static void Foo(this Exception e)
    {
        Application.OpenURL("https://baidu.com/s?wd=" + e.Message);
        Application.OpenURL("https://google.com/search?q=" + e.Message);
        Application.OpenURL("https://stackoverflow.com/search?q" + e.Message);
    }
    #endregion

    #region Alpha
    public static void SetAlpha(this Image image,float _a)
    {
        image.color = GetAlphaColor(image.color, _a);
    }

    public static void Alpha(this SpriteRenderer sr,float _a)
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, _a);
    }
    #endregion

    #region Vector

    public static Vector3 ToV3(this Vector2 v2, float z)
    {
        return  new Vector3(v2.x,v2.y,z);
    }

    public static Vector2 ToV2(this Vector3 v3)
    {
        return  new Vector2(v3.x,v3.y);
    }

    #endregion

    #region Units

    public static string ConventUnits_K(this int value)
    {
        if (value < 1000)
        {
            return value.ToString();
        }

        return (value * 0.001f).ToString("f1") + "k";

    }
    public static string ConventUnits_W(this int value)
    {
        if (value < 10000)
        {
          return value.ConventUnits_K();
        }
        return (value * 0.0001f).ToString("f1") + "万";
    }

    //60转化为01:00   150-02:30
    public static string ConventUnits_Time(this int value)
    {
        int minite;
        int seconds;
        minite = value / 60;
        seconds = value % 60;
        if (minite < 10)
        {
            if (seconds < 10)
            {
                return "0" + minite + ":0" + seconds;
            }
            return "0" + minite + ":" + seconds;

        }
        if (seconds < 10)
        {
            return minite + ":0" + seconds;
        }
        return minite + ":" + seconds;

    }

    #endregion

    #region fontColor

    public static string AddRichColor(this string str, string color)
    {
        return "<color=\"#" + color + "\">"+str+"</color>";
    }
    

    #endregion

    #region  fromQF
    public static Transform FindChildRecursion(this Transform tfParent, string name,
            StringComparison stringComparison = StringComparison.Ordinal)
    {
        if (tfParent.name.Equals(name, stringComparison))
        {
            //Debug.Log("Hit " + tfParent.name);
            return tfParent;
        }

        foreach (Transform tfChild in tfParent)
        {
            Transform tfFinal = null;
            tfFinal = tfChild.FindChildRecursion(name, stringComparison);
            if (tfFinal)
            {
                return tfFinal;
            }
        }

        return null;
    }

    /// <summary>
        /// 遍历数组
        /// <code>
        /// var testArray = new[] { 1, 2, 3 };
        /// testArray.ForEach(number => number.LogInfo());
        /// </code>
        /// </summary>
        /// <returns>The each.</returns>
        /// <param name="selfArray">Self array.</param>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <returns> 返回自己 </returns>
        public static T[] ForEach<T>(this T[] selfArray, Action<T> action)
        {
            Array.ForEach(selfArray, action);
            return selfArray;
        }

        /// <summary>
        /// 遍历 IEnumerable
        /// <code>
        /// // IEnumerable<T>
        /// IEnumerable<int> testIenumerable = new List<int> { 1, 2, 3 };
        /// testIenumerable.ForEach(number => number.LogInfo());
            
        /// // 支持字典的遍历
        /// new Dictionary<string, string>()
        ///         .ForEach(keyValue => Log.I("key:{0},value:{1}", keyValue.Key, keyValue.Value));
        /// </code>
        /// </summary>
        /// <returns>The each.</returns>
        /// <param name="selfArray">Self array.</param>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> selfArray, Action<T> action)
        {
            if (action == null) throw new ArgumentException();
            foreach (var item in selfArray)
            {
                action(item);
            }

            return selfArray;
        }


        public static string GetPath(this Transform transform)
        {
            var sb = new System.Text.StringBuilder();
            var t = transform;
            while (true)
            {
                sb.Insert(0, t.name);
                t = t.parent;
                if (t)
                {
                    sb.Insert(0, "/");
                }
                else
                {
                    return sb.ToString();
                }
            }
        }
        #region CETR003 LocalPosition
        /// <summary>
        /// 缓存的一些变量,免得每次声明
        /// </summary>
        private static Vector3 mLocalPos;

        private static Vector3 mScale;
        private static Vector3 mPos;
        public static T LocalPosition<T>(this T selfComponent, Vector3 localPos) where T : Component
        {
            selfComponent.transform.localPosition = localPos;
            return selfComponent;
        }

        public static Vector3 GetLocalPosition<T>(this T selfComponent) where T : Component
        {
            return selfComponent.transform.localPosition;
        }



        public static T LocalPosition<T>(this T selfComponent, float x, float y, float z) where T : Component
        {
            selfComponent.transform.localPosition = new Vector3(x, y, z);
            return selfComponent;
        }

        public static T LocalPosition<T>(this T selfComponent, float x, float y) where T : Component
        {
            mLocalPos = selfComponent.transform.localPosition;
            mLocalPos.x = x;
            mLocalPos.y = y;
            selfComponent.transform.localPosition = mLocalPos;
            return selfComponent;
        }

        public static T LocalPositionX<T>(this T selfComponent, float x) where T : Component
        {
            mLocalPos = selfComponent.transform.localPosition;
            mLocalPos.x = x;
            selfComponent.transform.localPosition = mLocalPos;
            return selfComponent;
        }

        public static T LocalPositionY<T>(this T selfComponent, float y) where T : Component
        {
            mLocalPos = selfComponent.transform.localPosition;
            mLocalPos.y = y;
            selfComponent.transform.localPosition = mLocalPos;
            return selfComponent;
        }

        public static T LocalPositionZ<T>(this T selfComponent, float z) where T : Component
        {
            mLocalPos = selfComponent.transform.localPosition;
            mLocalPos.z = z;
            selfComponent.transform.localPosition = mLocalPos;
            return selfComponent;
        }


        public static T LocalPositionIdentity<T>(this T selfComponent) where T : Component
        {
            selfComponent.transform.localPosition = Vector3.zero;
            return selfComponent;
        }

    #endregion

    #endregion

    #region Compare Time
    /// <summary>
    /// 比较任务时间
    /// </summary>
    /// <param name="dateTime">当前时间</param>
    /// <param name="startTime">任务开始时间</param>
    /// <param name="seconds">任务时间</param>
    /// <returns>-1 还未完成  0  完成  1 完成</returns>
    public static int CompareEndTime(this DateTime dateTime,DateTime startTime ,double seconds)
    {
        return DateTime.Compare(dateTime, startTime.AddSeconds(seconds));
    }
    public static float GetRestOfEndTime(this DateTime dateTime, DateTime startTime,double seconds)
    {
        return (float)(startTime.AddSeconds(seconds) - dateTime).TotalSeconds;
    }
    #endregion

    #region ConverTime
    private static int convertBaseSeconds=0;
    private static int convertTime_h = 0;
    private static int convertTime_m = 0;
    private static int convertTime_s = 0;
    private static string convertTimeStr = "";
    public static string ConvertTimeToDateStr(int seconds)
    {
        convertBaseSeconds = seconds;
        convertTimeStr = "";
        convertTime_h = 0;
        convertTime_m = 0;
        convertTime_s = 0;

        convertTime_h = convertBaseSeconds / 3600;
        convertTime_m = (convertBaseSeconds - 3600 * convertTime_h) / 60;
        convertTime_s = convertBaseSeconds - 3600 * convertTime_h - convertTime_m * 60;

        if (convertTime_h > 0) convertTimeStr += convertTime_h + "h ";
        if (convertTime_m > 0) convertTimeStr += convertTime_m + "m ";
        if (convertTime_s > 0) convertTimeStr += convertTime_s + "s ";
        return convertTimeStr;
    }
    public static string ConvertTimeToDateStr(float seconds)
    {
        convertBaseSeconds = (int)seconds;
        convertTimeStr = "";
        convertTime_h = 0;
        convertTime_m = 0;
        convertTime_s = 0;

        convertTime_h = convertBaseSeconds / 3600;
        convertTime_m = (convertBaseSeconds - 3600 * convertTime_h) / 60;
        convertTime_s = convertBaseSeconds - 3600 * convertTime_h - convertTime_m * 60;

        if (convertTime_h > 0) convertTimeStr += convertTime_h + "h ";
        if (convertTime_m > 0) convertTimeStr += convertTime_m + "m ";
        if (convertTime_s > 0) convertTimeStr += convertTime_s + "s ";
        return convertTimeStr;
    }
    #endregion
}
