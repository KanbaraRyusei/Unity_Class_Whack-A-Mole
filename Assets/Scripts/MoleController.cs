using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoleController : MonoBehaviour, IPointerClickHandler
{
    public bool WasHit => _wasHit;
    public bool IsAppear => _isAppear;

    [SerializeField]
    [Header("“¾“_")]
    private int _point;

    [SerializeField]
    [Header("o‚Ä‚¢‚éŠÔ")]
    private int _appearTime;

    [SerializeField]
    [Header("o‚Ä‚­‚éŠÔŠu")]
    private int _interval;

    private bool _wasHit = false;
    private bool _isAppear = false;
    private float _timer = 0f;
    private bool _stopTimer = true;
    private float _disAppearTimer = 0f;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_stopTimer)
        {
            if(_interval < _disAppearTimer)
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

    public void UpMole()
    {
        _stopTimer = false;
        _anim.Play("Up");
    }

    public void DownMole()
    {
        _stopTimer = true;
        _timer = 0f;
        _disAppearTimer = 0f;
        _anim.Play("Down");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _wasHit = true;
        DownMole();
        ScoreManager.AddScore(_point);
    }
}
