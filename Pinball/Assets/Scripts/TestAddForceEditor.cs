using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TestAddForce))]
public class TestAddForceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        TestAddForce myScript = (TestAddForce)target;
        if (GUILayout.Button("AddForce"))
        {
            myScript.AddForce();
        }
    }
}
