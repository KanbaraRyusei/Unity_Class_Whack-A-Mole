using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

public class MoleController : MonoBehaviour, IPointerClickHandler
{
    public bool WasHit => _wasHit;
    public bool IsAppear => _isAppear;
    public int Point => _point;
    public RangeValue<float> MovePosition => _movePosition;
    public float UpTime => _upTime;
    public float DownTime => _downTime;
    public float WhackDownTime => _whackDownTime;
    public float AppearTime => _appearTime;
    public float IntervalUpperLimit => _intervalUpperLimit;
    public float IntervalLowerLimit => _intervalLowerLimit;

    [SerializeField]
    [Header("得点")]
    private int _point;

    [SerializeField]
    [Header("移動するポジション")]
    private RangeValue<float> _movePosition;

    [SerializeField]
    [Header("上がるのにかかる時間")]
    private float _upTime = 1f;

    [SerializeField]
    [Header("下がるのにかかる時間")]
    private float _downTime = 0.5f;

    [SerializeField]
    [Header("叩かれたときに下がるのにかかる時間")]
    private float _whackDownTime = 0.2f;

    [SerializeField]
    [Header("出ている時間")]
    private float _appearTime = 3f;

    [SerializeField]
    [Header("出てくる間隔の上限")]
    private float _intervalUpperLimit = 6f;

    [SerializeField]
    [Header("出てくる間隔の下限")]
    private float _intervalLowerLimit = 1f;

    private bool _wasHit = false;
    private bool _isAppear = false;
    private bool _stopTimer = true;

    private float _timer = 0f;
    private float _disAppearTimer = 0f;
    private float _randomInterval = 0f;

    Tweener _tweener;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (_stopTimer)
        {
            if(_randomInterval < _disAppearTimer)
            {
                UpMole();
            }
            _disAppearTimer += Time.deltaTime;
            return;
        }
        if (_appearTime < _timer)
        {
            DownMole();
        }
        _timer += Time.deltaTime;
    }

    public void SetData(int point, RangeValue<float> rangeValue,
        float upTime, float downTime, float whackDownTime, float appearTime,
        float intervalUpperLimit, float intervalLowerLimit)
    {
        _point = point;
        _movePosition = rangeValue;
        _upTime = upTime;
        _downTime = downTime;
        _whackDownTime = whackDownTime;
        _appearTime = appearTime;
        _intervalUpperLimit = intervalUpperLimit;
        _intervalLowerLimit = intervalLowerLimit;
        Debug.Log("新しいデータを反映しました。");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_wasHit) return;
        WhackDownMole();
        ScoreManager.AddScore(_point);
    }

    private void Init()
    {
        _randomInterval = UnityEngine.Random.Range(_intervalLowerLimit, _intervalUpperLimit);
    }

    private void UpMole()
    {
        _stopTimer = false;
        _wasHit = false;
        _disAppearTimer = 0f;
        _tweener = transform.DOMoveZ(_movePosition.Start, _upTime)
            .OnComplete(() =>
            transform.position = new Vector3(transform.position.x, transform.position.y, _movePosition.Start));
    }

    private void DownMole()
    {
        _stopTimer = true;
        _wasHit = true;
        _timer = 0f;
        _disAppearTimer = 0f;
        _tweener = transform.DOMoveZ(_movePosition.End, _downTime)
            .OnComplete(() =>
            transform.position = new Vector3(transform.position.x, transform.position.y, _movePosition.End));
    }

    private void WhackDownMole()
    {
        _stopTimer = true;
        _wasHit = true;
        _timer = 0f;
        _disAppearTimer = 0f;
        transform.DOMoveZ(_movePosition.End, _whackDownTime)
            .OnComplete(() =>
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, _movePosition.End);
                _tweener.Kill();
            });
    }
}

[Serializable]
public struct RangeValue<T> where T : struct
{
    public T Start => _start;

    public T End => _end;

    [SerializeField]
    private T _start;

    [SerializeField]
    private T _end;

    public RangeValue(T start, T end)
    {
        _start = start;
        _end = end;
    }
}