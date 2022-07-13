using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

public class AlbumsPanelControl : AbstractPanelController
{
    [SerializeField] private AlbumItem albumPrefab;
    [SerializeField] private Transform root;
    [SerializeField] private LoginPanelControl idk;

    private List<AlbumItem> userAlbums = new List<AlbumItem>();

    private List<Albums> albums = new List<Albums>()
    {

    };

    protected override async Task OnShow()
    {
        Loading.SetActive(true);
        var content = await GetContentFromServer("https://jsonplaceholder.typicode.com/albums");
        albums = Deserialize<List<Albums>>(content);
        int temp = Convert.ToInt32(idk.IDuser);
        for (int i = 0; i < albums.Count; i++)
        {
            if (albums[i].uid == temp)
            {
                AlbumItem albumItem = Instantiate(albumPrefab, root);
                albumItem.UpdateAlbumItem(albums[i].Id, albums[i].Title);
                userAlbums.Add(albumItem);
            }
        }
        Loading.SetActive(false);
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
        for (int i = userAlbums.Count -1; i >= 0; i--)
        {
            Destroy(userAlbums[i].gameObject);
        }
        
        userAlbums.Clear();
    }

    public void Clear()
    {
        for (int i = userAlbums.Count -1; i >= 0; i--)
        {
            Destroy(userAlbums[i].gameObject);
        }
        
        userAlbums.Clear();
    }
}
