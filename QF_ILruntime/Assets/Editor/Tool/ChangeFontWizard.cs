using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class ChangeFontWizard : ScriptableWizard
{
    public Font uFont;

    [MenuItem("Tools/更改Text字体")]
    private static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<ChangeFontWizard>("更改字体", "ChangeFont");
    }

    private void OnWizardUpdate()
    {
        errorString = "";
        isValid = true;
        if (uFont == null)
        {
            isValid = false;
            errorString = "未选择字体";
        }
        if (Selection.activeTransform == null)
        {
            isValid = false;
            errorString = "未选中Text的父对象";
        }
    }
    private void OnSelectionChange()
    {
        errorString = "";
        isValid = true;
        if (uFont == null)
        {
            isValid = false;
            errorString = "未选择字体";
        }
        if (Selection.activeTransform == null)
        {
            isValid = false;
            errorString = "未选中Text的父对象";
        }
    }
    private void OnWizardCreate()
    {
        ChangeFont();
    }
    void ChangeFont()
    {
        Transform selctionTran = Selection.activeTransform;
        Text[] texts = selctionTran.GetComponentsInChildren<Text>();
        foreach (Text text in texts)
        {
            Debug.Log(1);
            Debug.Log(text.font);
            text.font = uFont;
        }
        Debug.Log("set suc");
    }
}
