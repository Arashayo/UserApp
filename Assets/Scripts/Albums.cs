using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Albums
{
    [JsonProperty("userId")] 
    public int uid { get; set; }
    [JsonProperty("id")] 
    public int Id { get; set; }
    [JsonProperty("title")] 
    public string Title { get; set; }

    public Albums(int userId, int id, string title)
    {
        uid = userId;
        Id = id;
        Title = title;

    }
}
