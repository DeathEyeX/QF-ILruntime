using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// 资源读取器
/// </summary>
public class ResourceIOTool : MonoBehaviour
{
    static ResourceIOTool instance;
    public static ResourceIOTool GetInstance()
    {
        if (instance == null)
        {
            GameObject resourceIOTool = new GameObject();
            resourceIOTool.name = "ResourceIO";
            DontDestroyOnLoad(resourceIOTool);
            instance = resourceIOTool.AddComponent<ResourceIOTool>();
        }
        return instance;
    }

    /// <summary>
    /// 根据路径从文件读取数据
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string ReadStringByFile(string path)
    {
        StringBuilder line = new StringBuilder();
        try
        {
            if (!File.Exists(path))
            {
                Debug.Log("path dont exists ! : " + path);
                return "";
            }

            StreamReader sr = File.OpenText(path);
            line.Append(sr.ReadToEnd());

            sr.Close();
            sr.Dispose();
        }
        catch (Exception e)
        {
            Debug.Log("Load text fail ! message:" + e.Message);
        }

        return line.ToString();
    }

    /// <summary>
    /// 写数据到文件
    /// </summary>
    /// <param name="path"></param>
    /// <param name="content"></param>
    public static void WriteStringByFile(string path, string content)
    {
        byte[] dataByte = Encoding.GetEncoding("UTF-8").GetBytes(content);
        CreateFile(path, dataByte);
    }

    public static void CreateFile(string path, byte[] byt)
    {
        try
        {
            FileTool.CreatFilePath(path);
            File.WriteAllBytes(path, byt);
        }
        catch (Exception e)
        {
            Debug.LogError("File Create Fail! \n" + e.Message);
        }
    }
}



