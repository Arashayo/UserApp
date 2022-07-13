using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

public class TodosPanelControl : AbstractPanelController
{
    [SerializeField] private TodoItem todoItemPrefab;
    [SerializeField] private Transform root;
    [SerializeField] private LoginPanelControl idk;

    private List<TodoItem> todoItems = new List<TodoItem>();
    
    private List<Todo> todos = new List<Todo>
    {
        new Todo(1, 1, "Test Title 1", false),
        new Todo(1, 2, "Test Title 2", true),
        new Todo(1, 3, "Test Title 3", false),
        new Todo(1, 4, "Test Title 4", true)
    };

    protected override async Task OnShow()
    {
        var content= await GetContentFromServer("https://jsonplaceholder.typicode.com/todos");
        todos = Deserialize<List<Todo>>(content);
        int temp = Convert.ToInt32(idk.IDuser);
        for (int i = 0; i < todos.Count; i++)
        {
            if (todos[i].UserId == temp)
            {
                TodoItem todoItem = Instantiate(todoItemPrefab, root);
                todoItem.UpdateTodoItem(todos[i].Id, todos[i].Title, todos[i].Completed);
                todoItems.Add(todoItem);
            }
        }
    }
    
    private async Task<string> GetContentFromServer(string path)
    {
        using HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync(path);
            
        return await response.Content.ReadAsStringAsync();
    }
    
    private T Deserialize<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }

    protected override void OnHide()
    {
        for (int i = todoItems.Count -1; i >= 0; i--)
        {
            Destroy(todoItems[i].gameObject);
        }
        
        todoItems.Clear();
    }
    public void clear()
    {
        for (int i = todoItems.Count -1; i >= 0; i--)
        {
            Destroy(todoItems[i].gameObject);
        }
        
        todoItems.Clear();
    }
}
