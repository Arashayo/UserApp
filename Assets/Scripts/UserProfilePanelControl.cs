using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TreeEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class UserProfilePanelControl : AbstractPanelController
{
    [SerializeField] private UserHorizontalLabel HorizontalLabel_Id;
    [SerializeField] private UserHorizontalLabel HorizontalLabel_Name;
    [SerializeField] private UserHorizontalLabel HorizontalLabel_Username;
    [SerializeField] private UserHorizontalLabel HorizontalLabel_Email;
    [SerializeField] private UserHorizontalLabel HorizontalLabel_Phone;
    [SerializeField] private UserHorizontalLabel HorizontalLabel_Website;
    [SerializeField] private UserHorizontalLabel HorizontalLabel_Street;
    [SerializeField] private UserHorizontalLabel HorizontalLabel_Suite;
    [SerializeField] private UserHorizontalLabel HorizontalLabel_City;
    [SerializeField] private UserHorizontalLabel HorizontalLabel_ZipCode;
    [SerializeField] private UserHorizontalLabel HorizontalLabel_Geo;
    [SerializeField] private UserHorizontalLabel HorizontalLabel_Name2;
    [SerializeField] private UserHorizontalLabel HorizontalLabel_CatchPhrase;
    [SerializeField] private UserHorizontalLabel HorizontalLabel_Bs;
    [SerializeField] private LoginPanelControl idk;
    
    
    private List<UserHorizontalLabel> userItems = new List<UserHorizontalLabel>();
    
    private List<User> users = new List<User>
    {
        
    };

    protected override async Task OnShow()
    {
        var content = await GetContentFromServer("https://jsonplaceholder.typicode.com/users");
        users = Deserialize<List<User>>(content);
        
        int rnd = Convert.ToInt32(idk.IDuser) - 1;
        
        HorizontalLabel_Id.UpdateHorizontalLabel(users[rnd].id);
        HorizontalLabel_Name.UpdateHorizontalLabel(users[rnd].name);
        HorizontalLabel_Username.UpdateHorizontalLabel(users[rnd].username);
        HorizontalLabel_Email.UpdateHorizontalLabel(users[rnd].email);
        HorizontalLabel_Phone.UpdateHorizontalLabel(users[rnd].phone);
        HorizontalLabel_Website.UpdateHorizontalLabel(users[rnd].website);
        HorizontalLabel_Street.UpdateHorizontalLabel(users[rnd].address.street);
        HorizontalLabel_Suite.UpdateHorizontalLabel(users[rnd].address.suite);
        HorizontalLabel_City.UpdateHorizontalLabel(users[rnd].address.city);
        HorizontalLabel_ZipCode.UpdateHorizontalLabel(users[rnd].address.zipcode);
        HorizontalLabel_Geo.UpdateHorizontalLabel(users[rnd].address.geo.lat);
        HorizontalLabel_Name2.UpdateHorizontalLabel(users[rnd].company.name);
        HorizontalLabel_CatchPhrase.UpdateHorizontalLabel(users[rnd].company.catchPhrase);
        HorizontalLabel_Bs.UpdateHorizontalLabel(users[rnd].company.bs);
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
        for (int i = userItems.Count -1; i >= 0; i--)
        {
            Destroy(userItems[i].gameObject);
        }
        
        userItems.Clear();
    }

    public void clear()
    {
        for (int i = userItems.Count -1; i >= 0; i--)
        {
            Destroy(userItems[i].gameObject);
        }
        
        userItems.Clear();
    }
}
