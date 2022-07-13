using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Comments
{
    [JsonProperty("postId")] 
    public int cid { get; set; }
    [JsonProperty("id")] 
    public int Id { get; set; }
    [JsonProperty("name")] 
    public string Name { get; set; }
    [JsonProperty("email")]
    public string Email { get; set; }
    [JsonProperty("body")] 
    public string Body { get; set; }

    public Comments(int commentId, int id, string name, string email, string body)
    {
        cid = commentId;
        Id = id; 
        Name = name;
        Email = email;
        Body = body;
    }
    
}
