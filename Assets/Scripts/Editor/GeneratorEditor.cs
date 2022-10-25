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
            Debug.Log("��������");
        }

        if(GUILayout.Button("AllDelete"))
        {
            if(_generator.AllDelete())
            {
                Debug.Log("�폜����");
            }
            else
            {
                Debug.Log("�I�u�W�F�N�g����������Ă��܂���");
            }
        }

        if(GUILayout.Button("PropertyUpdate"))
        {
            if(_generator.PropertyUpdate())
            {
                Debug.Log("�V�����f�[�^�𔽉f���܂���");
            }
            else
            {
                Debug.Log("�I�u�W�F�N�g����������Ă��܂���");
            }
        }
    }
}
