using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

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
    [Header("生成を開始するポジション")]
    private Vector3 _generatePosision;

    public void Generate()
    {
        for(int i = 0; i < _width; i++)
        {
            for(int j = 0; j < _height; j++)
            {
                Instantiate(_prefab, new Vector3(
                    _generatePosision.x + i * _interval,
                    _generatePosision.y + j * _interval,
                    _generatePosision.z + 0), _prefab.transform.rotation);
            }
        }
    }
}
