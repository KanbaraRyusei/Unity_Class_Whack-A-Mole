using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    private GameObject _plane;

    [SerializeField]
    [Header("モグラ")]
    private GameObject _capsule;

    [SerializeField]
    [Header("横の数")]
    private int _width;

    [SerializeField]
    [Header("縦の数")]
    private int _height;

    [SerializeField]
    [Header("間隔")]
    private int _interval;

    [SerializeField]
    [Header("モグラの初期位置")]
    private int _capsulePosition;

    [SerializeField]
    [Header("生成を開始するポジション")]
    private Vector3 _generatePosition;

    public void Generate()
    {
        for(int i = 0; i < _width; i++)
        {
            for(int j = 0; j < _height; j++)
            {
                var x = _generatePosition.x + i * _interval;
                var y = _generatePosition.y + j * _interval;
                var z = _generatePosition.z + 0;
                Instantiate(_plane, new Vector3(x, y, z), _plane.transform.rotation);
                Instantiate(_capsule, new Vector3(x, y, z + _capsulePosition), _capsule.transform.rotation);
            }
        }
    }
}
