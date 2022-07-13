using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class User
{
    [JsonProperty("id")] public string id { get; set; }
    [JsonProperty("name")] public string name { get; set; }
    [JsonProperty("username")] public string username { get; set; }
    [JsonProperty("email")] public string email { get; set; }
    public address address { get; set; }
    [JsonProperty("phone")] public string phone { get; set; }
    [JsonProperty("website")] public string website { get; set; }
    public company company { get; set; }
}

public class company
{
    [JsonProperty("name")] public string name { get; set; }
    [JsonProperty("catchPhrase")] public string catchPhrase { get; set; }
    [JsonProperty("bs")] public string bs { get; set; }
}

public class address
{
    [JsonProperty("street")] public string street { get; set; }
    [JsonProperty("suite")] public string suite { get; set; }
    [JsonProperty("city")] public string city { get; set; }
    [JsonProperty("zipcode")] public string zipcode { get; set; }
    public geo geo { get; set; }
}

public class geo
{
    [JsonProperty("lat")] public string lat { get; set; }
    [JsonProperty("lng")] public string lng { get; set; }
}


