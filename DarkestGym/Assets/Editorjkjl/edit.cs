using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ChangeCellToProt))]
public class edit : Editor
{
    public override void OnInspectorGUI()
    {
        ChangeCellToProt prot = target as ChangeCellToProt;
        if(GUILayout.Button("aaa"))
        {
            prot.Change();
        }
    }
}
