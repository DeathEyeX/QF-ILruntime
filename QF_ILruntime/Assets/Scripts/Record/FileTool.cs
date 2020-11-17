﻿using System.IO;

/// <summary>
/// 文件目录管理
/// </summary>
public class FileTool
{
    /// <summary>
    /// 判断有没有这个文件路径，如果没有则创建它(路径会去掉文件名)
    /// </summary>
    /// <param name="filepath"></param>
    public static void CreatFilePath(string filepath)
    {
        string newPathDir = Path.GetDirectoryName(filepath);

        CreatPath(newPathDir);
    }

    /// <summary>
    /// 判断有没有这个路径，如果没有则创建它
    /// </summary>
    /// <param name="filepath"></param>
    public static void CreatPath(string path)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }

    /// <summary>
    /// 删掉某个目录下的所有子目录和子文件，但是保留这个目录
    /// </summary>
    /// <param name="path"></param>
    public static void DeleteDirectory(string path)
    {
        string[] directorys = Directory.GetDirectories(path);
        //删掉所有子目录
        for (int i = 0; i < directorys.Length; i++)
        {
            string pathTmp = directorys[i];
            if (Directory.Exists(pathTmp))
            {
                Directory.Delete(pathTmp, true);
            }
        }
        //删掉所有子文件
        string[] files = Directory.GetFiles(path);
        for (int i = 0; i < files.Length; i++)
        {
            string pathTmp = files[i];
            if (File.Exists(pathTmp))
            {
                File.Delete(pathTmp);
            }
        }
    }
}
