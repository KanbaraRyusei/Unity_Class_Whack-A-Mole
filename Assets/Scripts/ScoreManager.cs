using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    public static int Score => _score;

    private static int _score;

    public static void AddScore(int point)
    {
        _score += point;
    }

    public static void DecreaseScore(int point)
    {
        _score -= point;
    }

    public static void ResetScore()
    {
        _score = 0;
    }
}
