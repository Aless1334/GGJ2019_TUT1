using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapMaker))]
public class MapMakerInspector : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MapMaker mapMaker = target as MapMaker;
        if (GUILayout.Button("マップ生成"))
        {
            mapMaker.Make();
        }
        if (GUILayout.Button("マップ番号設定"))
        {
            mapMaker.SetNumber();
        }
        if (GUILayout.Button("子オブジェクト全削除"))
        {
            mapMaker.DeleteChildren();
        }
    }
}