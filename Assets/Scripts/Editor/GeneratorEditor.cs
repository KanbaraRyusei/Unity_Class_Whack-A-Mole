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
            Debug.Log("生成完了");
        }

        if(GUILayout.Button("AllDelete"))
        {
            if(_generator.AllDelete())
            {
                Debug.Log("削除完了");
            }
            else
            {
                Debug.Log("オブジェクトが生成されていません");
            }
        }

        if(GUILayout.Button("PropertyUpdate"))
        {
            if(_generator.PropertyUpdate())
            {
                Debug.Log("新しいデータを反映しました");
            }
            else
            {
                Debug.Log("オブジェクトが生成されていません");
            }
        }
    }
}
