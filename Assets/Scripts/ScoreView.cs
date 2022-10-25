using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    TMP_Text _text;

    public void ChangeText(int value)
    {
        _text.text = $"{value}";
    }
}
