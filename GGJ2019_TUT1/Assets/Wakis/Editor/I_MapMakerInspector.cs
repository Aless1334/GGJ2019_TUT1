using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(I_MapMaker))]
public class I_MapMakerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        I_MapMaker mapMaker = target as I_MapMaker;
        if (GUILayout.Button("マップ生成"))
        {
            mapMaker.Make();
        }
        if (GUILayout.Button("子オブジェクト全削除"))
        {
            mapMaker.DeleteChildren();
        }
    }
}