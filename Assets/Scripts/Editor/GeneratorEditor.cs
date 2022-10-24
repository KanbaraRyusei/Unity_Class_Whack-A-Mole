using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Generator))]
public class GeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Generator _generator = target as Generator;

        if (GUILayout.Button("Generate"))
        {
            _generator.Generate();
        }
    }
}
