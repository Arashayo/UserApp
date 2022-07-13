using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumItem : MonoBehaviour
{
        [SerializeField] private Text idText;
        [SerializeField] private Text _title;

        public void UpdateAlbumItem(int id, string title)
        {
                idText.text = id.ToString();
                _title.text = title;
        }
}
