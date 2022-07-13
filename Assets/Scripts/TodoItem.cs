using UnityEngine;
using UnityEngine.UI;

public class TodoItem : MonoBehaviour
{
    [SerializeField] private Text idText;
    [SerializeField] private Toggle completedToggle;
    [SerializeField] private Text titleText;

    public void UpdateTodoItem(int id, string title, bool completed)
    {
        idText.text = id.ToString();
        titleText.text = title;
        completedToggle.isOn = completed;
    }
}
