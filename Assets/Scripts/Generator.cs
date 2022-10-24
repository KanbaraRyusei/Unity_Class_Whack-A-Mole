using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    private GameObject _plane;

    [SerializeField]
    [Header("���O��")]
    private GameObject _capsule;

    [SerializeField]
    [Header("���̐�")]
    private int _width;

    [SerializeField]
    [Header("�c�̐�")]
    private int _height;

    [SerializeField]
    [Header("�Ԋu")]
    private int _interval;

    [SerializeField]
    [Header("���O���̏����ʒu")]
    private int _capsulePosition;

    [SerializeField]
    [Header("�������J�n����|�W�V����")]
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
