using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 通过读取CSV文件来生产对应的数据类脚本
/// </summary>
public class CSVDataTools : Editor
{
    public const string tempPath = "/Editor/Templete/";          //模版路径
    public const string detailPath = "/Scripts@hotfix/Data/";    //生成位置
    public const string loadPath = "GameData/";                  //csv表路径
    public static string[] dataTitle;//存储CSV表格里面的属性名称
    public static string[] dataTitleZH;//存储CSV表格里面属性的中文注释
    public static string[] dataKey;//存储CSV表格里面的Key值

    private string dataPath;
    private static List<string> dataList = new List<string>();    //用来存储相关的CSV文件的名称List

    [MenuItem("Tools/生成CSV数据类 #&D", priority = 503)]
    public static void CreateData()
    {
        //每次都会重新清空一遍  然后依次加载所有的CSV文件并生产相关数据类
        dataList.Clear();

        //TODO: 只需要添加CSV表名到List就OK 如下
        dataList.Add("ConfigCatBuff"); // 妖灵BUFF表
        dataList.Add("ConfigCat"); // 妖灵表
        dataList.Add("ConfigCatPool"); // 妖灵抽奖池
        dataList.Add("ConfigCatSkin"); // 妖灵皮肤

        dataList.Add("ConfigItem"); // 物品表
        dataList.Add("ConfigCatTrain"); // 妖灵培养表

        dataList.Add("ConfigRoom");         // 馆表
        dataList.Add("ConfigRoomUnLock");   // 馆解锁表
        dataList.Add("ConfigRoomStarTask"); // 馆升星任务表
        dataList.Add("ConfigRoomUpdate");   // 馆升级表

        dataList.Add("ConfigExploreMap");
        dataList.Add("ConfigExploreTask");
        dataList.Add("ConfigExploreVehicle");

        dataList.Add("ConfigCatConstellation"); //妖灵星座
        dataList.Add("ConfigCatCharacter"); //妖灵个性

        dataList.Add("ConfigDrinks");
        dataList.Add("ConfigDrinksIngredients");
        dataList.Add("ConfigDrinksMaterial");

        CreateDataManager();
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// 创建相关的数据类
    /// </summary>
    private static void CreateDataManager()
    {
        for (int i = 0; i < dataList.Count; i++)
        {
            //获取替换模板
            string scriptName = "Data" + dataList[i];
            string detailTemplet = GetTemplete("DataSingletonBase");
            //Debug.Log("detail1："+detailTemplet);
            detailTemplet = detailTemplet.Replace("ScriptName1", scriptName);
            detailTemplet = detailTemplet.Replace("ScriptName2", scriptName);
            detailTemplet = detailTemplet.Replace("DataKey", dataList[i] + "Key");
            detailTemplet = detailTemplet.Replace("DataType", dataList[i] + "Type");
            //Debug.Log("detail2：" + detailTemplet);
            Debug.Log(" 创建数据：" + dataList[i]);

            //获取数据的Key并替换到数据类里面
            dataKey = LoadDataKey(dataList[i]);
            string keyContent = "";
            for (int j = 0; j < dataKey.Length; j++)
            {
                if (j == dataKey.Length - 1)
                {
                    keyContent += "         " + dataKey[j];
                }
                else
                {
                    keyContent += "         " + dataKey[j] + ",\n";
                }
            }
            detailTemplet = detailTemplet.Replace("KeyContent", keyContent);
            //Debug.Log("detail3:" + detailTemplet);

            //获取数据的属性Title替换到数据类里面
            dataTitle = LoadDataTitle(dataList[i]);
            if (dataTitle == null)
                return;
            dataTitleZH = LoadDataTitleZH(dataList[i]);
            string typeContent = "";
            for (int j = 0; j < dataTitle.Length - 1; j++)
            {
                if (j == dataTitle.Length - 2)
                {
                    typeContent += "         " + dataTitle[j] + "    //" + dataTitleZH[j];
                }
                else
                {
                    typeContent += "         " + dataTitle[j] + ",    //" + dataTitleZH[j] + "\n";
                }
            }
            detailTemplet = detailTemplet.Replace("TypeContent", typeContent);
            //Debug.Log("detail4:" + detailTemplet);

            //替换一些名称
            detailTemplet = detailTemplet.Replace("TABLENAME", dataList[i]);
            //Debug.Log("detail5:" + detailTemplet);

            //确定输出路径 进行保存
            Debug.Log(Application.dataPath);
            string outPutFile = Application.dataPath + detailPath + scriptName + ".cs";
            
            
            Save(outPutFile, detailTemplet);

        }
    }

    /// <summary>
    /// 获取templete
    /// </summary>
    /// <param name="tempName"></param>
    /// <returns></returns>
    private static string GetTemplete(string tempName)
    {
        TextAsset textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets" + tempPath + tempName + ".txt");
        string temp = textAsset.text;
        return temp;
    }

    /// <summary>
    /// 获取Key
    /// </summary>
    /// <param name="sName"></param>
    /// <returns></returns>
    public static string[] LoadDataKey(string sName)
    {
        TextAsset txtass = (TextAsset)Resources.Load(loadPath + sName, typeof(TextAsset));
        //Debug.Log(" Load  " + loadPath + sName);
        string stringData = txtass.ToString();
        //Debug.Log("stringData"+ stringData);
        //将读取的表 按照每一行分隔开  依次存储到string[]中
        string[] stringResult = stringData.Split(new char[] { '\n' }); 
        //Debug.Log(stringResult.Length);

        string line;     //获得每一行的数据
        int length = 0;  //记录每个表的Key有多少个
        //获取有效数据的key
        for (int iRow = 2; iRow < stringResult.Length; iRow++)
        {
            line = stringResult[iRow];
            if (line == "")
                continue;
            string str = line.Split(',')[0];
            //Debug.Log(str);
            if (str == "")
                continue;
            length++;
        }

        //Debug.Log("length:"+length);

        string[] rowKey = new string[length];
        for (int iRow = 2; iRow < stringResult.Length; iRow++)
        {
            line = stringResult[iRow];
            if (line == "")
                continue;
            string str = line.Split(',')[0];
            if (str == "")
                continue;
            rowKey[iRow - 2] = str;
        }
        return rowKey;
    }

    /// <summary>
    /// 读取表的第二行  也就是属性的名称
    /// </summary>
    /// <param name="sName"></param>
    /// <returns></returns>
    public static string[] LoadDataTitle(string sName)
    {
        //读取表
        TextAsset txtass = (TextAsset)Resources.Load(loadPath + sName, typeof(TextAsset));
        string stringdata = txtass.ToString();
        string[] stringresult = stringdata.Split(new char[] { '\n' });

        string line;
        string[] ColumnName = null;
        //最少需要两行  才能读取到属性名称  也就是说 这个表最开始创建出来 可以没有数据，但是一定得有属性名称
        if (txtass.text.Length < 2)
        {
            Debug.Log(" 没有找到文件  " + loadPath + sName);
            return ColumnName;
        }
        //这是固定的 表的第2行位属性的名称
        line = stringresult[1]; 
        int len = line.Split(',').Length;
        ColumnName = new string[len];
        //遍历这一行 获取每列的title
        for (int iColumn = 0; iColumn < len - 1; iColumn++)
        {
            ColumnName[iColumn] = line.Split(',')[iColumn];
        }
        return ColumnName;
    }

    /// <summary>
    /// 读取表的第一行  也就是属性的中文注释
    /// </summary>
    /// <param name="sName"></param>
    /// <returns></returns>
    public static string[] LoadDataTitleZH(string sName)
    {
        TextAsset txtass = (TextAsset)Resources.Load(loadPath + sName, typeof(TextAsset));
        string stringdata = txtass.ToString();
        string[] stringresult = stringdata.Split(new char[] { '\n' });
        string line;
        String[] ColumnName = null;

        if (txtass.text.Length < 2)
        {
            Debug.Log(" 没有找到文件  " + loadPath + sName);
            return ColumnName;
        }

        line = stringresult[0];
        int len = line.Split(',').Length;
        ColumnName = new string[len];
        for (int iColumn = 0; iColumn < len - 1; iColumn++)
        {
            ColumnName[iColumn] = line.Split(',')[iColumn];
        }
        return ColumnName;
    }

    /// <summary>
    /// 将替换完成的模板文件保存到相关路径下
    /// </summary>
    /// <param name="outPutFile"></param>
    /// <param name="uiScript"></param>
    static void Save(string outPutFile, string uiScript)
    {
        StreamWriter sw = new StreamWriter(outPutFile, false);
        sw.Write(uiScript);
        sw.Close();
        AssetDatabase.SaveAssets();
        //AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);
    }
}
