using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Posts
{
    [JsonProperty("userId")] 
    public int uid { get; set; }
    [JsonProperty("id")] 
    public int Id { get; set; }
    [JsonProperty("title")] 
    public string Title { get; set; }
    [JsonProperty("body")] 
    public string Body { get; set; }
    
    public Posts(int userId, int id, string title, string body)
    {
        uid = userId;
        Id = id; 
        Title = title;
        Body = body;
    }


}
