using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class BossCatEditorTool : Editor
{
    [MenuItem("Tools/删除所有数据")]
    private static void ClearAllData()
    {
        string path = Application.persistentDataPath;
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
