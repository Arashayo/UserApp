using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PostItem : MonoBehaviour
{
    [SerializeField] private Text idText;
    [SerializeField] private Text _title;
    [SerializeField] private Text _body;
    public void UpdatePostItem(int id, string title, string body)
    {
        idText.text = id.ToString();
        _title.text = title;
        _body.text = body;

    }
}
