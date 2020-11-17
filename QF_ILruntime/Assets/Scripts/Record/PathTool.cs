using UnityEngine;
using System.Collections;
using System.Text;

/// <summary>
/// 加载的路径
/// </summary>
public enum ResLoadLocation
{
    Resource,  
    Streaming,
    Persistent,
    Catch, 
}

/// <summary>
/// 路径拼接
/// </summary>
public class PathTool
{
    /// <summary>
    /// 根据选择的路径返回正确格式的Path
    /// </summary>
    /// <param name="loadType"></param>
    /// <returns></returns>
    public static string GetPath(ResLoadLocation loadType)
    {
        StringBuilder path = new StringBuilder();
        switch (loadType)
        {
            case ResLoadLocation.Resource:
#if UNITY_EDITOR
                path.Append(Application.dataPath);
                path.Append("/Resources/");
                break;
#endif

            case ResLoadLocation.Streaming:

#if UNITY_ANDROID && !UNITY_EDITOR
                //path.Append("file://");
                path.Append(Application.dataPath );
                path.Append("!assets/");
#else
                path.Append(Application.streamingAssetsPath);
                path.Append("/");
#endif
                break;

            case ResLoadLocation.Persistent:
                path.Append(Application.persistentDataPath);
                path.Append("/");
                break;

            case ResLoadLocation.Catch:
                path.Append(Application.temporaryCachePath);
                path.Append("/");
                break;

            default:
                Debug.LogError("Type Error !" + loadType);
                break;
        }
        return path.ToString();
    }

    /// <summary>
    /// 组合绝对路径
    /// </summary>
    /// <param name="loadType">资源加载类型</param>
    /// <param name="relativelyPath">相对路径</param>
    /// <returns>绝对路径</returns>
    public static string GetAbsolutePath(ResLoadLocation loadType, string relativelyPath)
    {
        return GetPath(loadType) + relativelyPath;
    }

    /// <summary>
    /// 获取相对路径
    /// </summary>
    /// <param name="path"></param>
    /// <param name="fileName"></param>
    /// <param name="expandName"></param>
    /// <returns></returns>
    public static string GetRelativelyPath(string path, string fileName, string expandName)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(path);
        builder.Append("/");
        builder.Append(fileName);
        builder.Append(".");
        builder.Append(expandName);

        return builder.ToString();
    }

}


 

