using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public static class ScoreManager
{
    public static ReactiveProperty<int> Score => _score;

    private static ReactiveProperty<int> _score = new ReactiveProperty<int>();

    public static void AddScore(int point)
    {
        _score.Value += point;
    }

    public static void DecreaseScore(int point)
    {
        _score.Value -= point;
    }

    public static void ResetScore()
    {
        _score.Value = 0;
    }
}
