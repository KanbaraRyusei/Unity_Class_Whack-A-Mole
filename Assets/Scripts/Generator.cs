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

    List<GameObject> _planes = new List<GameObject>();
    List<MoleController> _moles = new List<MoleController>();

    public void Generate()
    {
        for(int i = 0; i < _width; i++)
        {
            for(int j = 0; j < _height; j++)
            {
                var x = _generatePosition.x + i * _interval;
                var y = _generatePosition.y + j * _interval;
                var z = _generatePosition.z + 0;
                var plane = Instantiate(_plane, new Vector3(x, y, z), _plane.transform.rotation);
                var mole = Instantiate(_capsule, new Vector3(x, y, z + _capsulePosition), _capsule.transform.rotation);
                _planes.Add(plane);
                if(mole.TryGetComponent(out MoleController moleController))
                {
                    _moles.Add(moleController);
                }
            }
        }
    }

    public bool AllDelete()
    {
        if(_planes.Count == 0 || _moles.Count == 0)
        {
            return false;
        }
        _planes.ForEach(x => DestroyImmediate(x));
        _moles.ForEach(x => DestroyImmediate(x.gameObject));
        _planes.Clear();
        _moles.Clear();
        return true;
    }

    public bool PropertyUpdate()
    {
        if (_moles.Count == 0) return false;
        var mole = _capsule.GetComponent<MoleController>();
        _moles.ForEach(x => x.SetData(mole.Point, mole.MovePosition,
                mole.UpTime, mole.DownTime, mole.WhackDownTime,
                mole.AppearTime, mole.IntervalUpperLimit, mole.IntervalLowerLimit));
        return true;
    }
}
