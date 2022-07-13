using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentItem : MonoBehaviour
{
   [SerializeField] private Text idText;
   [SerializeField] private Text _name;
   [SerializeField] private Text _email;
   [SerializeField] private Text _body;

   public void UpdateCommentItem(int id, string title, string email, string body)
   {
      idText.text = id.ToString();
      _name.text = title;
      _email.text = email;
      _body.text = body;
   }

}
