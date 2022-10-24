using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoleController : MonoBehaviour, IPointerClickHandler
{
    public bool WasHit => _wasHit;
    public bool IsAppear => _isAppear;

    [SerializeField]
    [Header("���_")]
    private int _point;

    [SerializeField]
    [Header("����オ�鎞��")]
    private int _upTime;

    [SerializeField]
    [Header("�オ��Ԋu")]
    private int _upInterval;

    [SerializeField]
    [Header("�o�Ă��鎞��")]
    private int _appearTime;

    [SerializeField]
    [Header("�o�Ă���Ԋu")]
    private int _interval;

    private bool _wasHit = false;
    private bool _isAppear = false;
    private float _timer = 0f;
    private bool _stopTimer = true;

    private void Update()
    {
        if (_stopTimer) return;
        if (_appearTime < _timer)
        {
            DownMole();
        }
        _timer += Time.deltaTime;
    }

    public void UpMole()
    {
        _stopTimer = false;
        transform.Translate(new Vector3(0, 0, _upInterval));
    }

    public void DownMole()
    {
        _stopTimer = true;
        transform.Translate(new Vector3(0, 0, _upInterval));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _wasHit = true;
        _timer = 0f;
        DownMole();
        ScoreManager.AddScore(_point);
    }
}
