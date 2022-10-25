using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField]
    private ScoreView _view;

    private void Start()
    {
        ScoreManager.Score.Subscribe(x => _view.ChangeText(x));
    }
}
