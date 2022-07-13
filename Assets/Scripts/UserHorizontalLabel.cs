using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserHorizontalLabel : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void UpdateHorizontalLabel(string text)
    {
        _text.text = text;
    }
}
