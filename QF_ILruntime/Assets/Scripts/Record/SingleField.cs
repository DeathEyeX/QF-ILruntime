using UnityEngine;
using System.Collections.Generic;
using System;

//存储的数据类型
public enum FieldType
{
    String,
    Bool,
    Int,
    Float,
    Vector2,
    Vector3,
    Color,

    StringArray,
    IntArray,
    FloatArray,
    BoolArray,
    Vector2Array,
    Vector3Array,
}

[SerializeField]
public class SingleField
{
    public FieldType m_type;//存储类型
    public string m_content;//存储内容

    #region 构造函数
    //无参
    public SingleField()
    {
        m_type = FieldType.String;
        m_content = "";
    }

    public SingleField(FieldType type, string content)
    {
        m_type = type;
        m_content = content;
        if (content == null)
        {
            Reset();
        }
    }

    public SingleField(string contrnt)
    {
        m_type = FieldType.String;
        m_content = contrnt;
    }

    public SingleField(int contrnt)
    {
        m_type = FieldType.Int;
        m_content = contrnt.ToString();
    }

    public SingleField(float content)
    {
        m_type = FieldType.Float;
        m_content = content.ToString();
    }

    public SingleField(bool content)
    {
        m_type = FieldType.Bool;
        m_content = content.ToString();
    }

    public SingleField(Vector2 content)
    {
        m_type = FieldType.Vector2;
        m_content = content.ToSaveString();
    }

    public SingleField(Vector3 content)
    {
        m_type = FieldType.Vector3;
        m_content = content.ToSaveString();
    }

    public SingleField(Color content)
    {
        m_type = FieldType.Color;
        m_content = content.ToSaveString();
    }

    public SingleField(List<string> content)
    {
        m_type = FieldType.StringArray;
        m_content = content.ToSaveString();
    }
    #endregion

    #region ReSet
    /// <summary>
    /// 类型存在，内容为空，赋予默认值
    /// </summary>
    public void Reset()
    {
        switch (m_type)
        {
            case FieldType.Bool:
                m_content = false.ToString();
                break;
            case FieldType.Vector2:
                m_content = Vector2.zero.ToSaveString();
                break;
            case FieldType.Vector3:
                m_content = Vector3.zero.ToSaveString();
                break;
            case FieldType.Color:
                m_content = Color.white.ToSaveString();
                break;
            case FieldType.Float:
                m_content = (0.0f).ToString();
                break;
            case FieldType.Int:
                m_content = (0).ToString();
                break;
        }
    }
    #endregion

    #region 取值封装
    /// <summary>
    /// 显示在编辑器UI上的字符串
    /// </summary>
    /// <returns></returns>
    public string GetShowString()
    {
        switch (m_type)
        {
            case FieldType.Bool:
                return GetBool().ToString();
            case FieldType.Vector2:
                return GetVector2().ToString();
            case FieldType.Vector3:
                return GetVector3().ToString();
            case FieldType.Color:
                return GetColor().ToString();
            case FieldType.Float:
                return GetFloat().ToString();
            case FieldType.Int:
                return GetInt().ToString();
        }

        return m_content;
    }

    public int GetInt()
    {
        return int.Parse(m_content);
    }

    public float GetFloat()
    {
        return float.Parse(m_content);
    }

    public bool GetBool()
    {
        return bool.Parse(m_content);
    }

    public string GetString()
    {
        return m_content;
    }

    public string[] GetStringArray()
    {
        return ExpandMethod.String2StringArray(m_content);
    }

    public Vector2 GetVector2()
    {
        return ExpandMethod.String2Vector2(m_content);
    }

    public Vector3 GetVector3()
    {
        return ExpandMethod.String2Vector3(m_content);
    }

    public Color GetColor()
    {
        return ExpandMethod.String2Color(m_content);
    }

    public List<string> GetStringList()
    {
        return ExpandMethod.String2StringList(m_content);
    }
    #endregion
}


