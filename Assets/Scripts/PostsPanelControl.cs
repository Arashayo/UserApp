using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using UnityEditor;


public class PostsPanelControl : AbstractPanelController
{

    [SerializeField] private PostItem postPrefab;
    [SerializeField] private Transform root;
    [SerializeField] private LoginPanelControl idk;
    [SerializeField] private CommentItem commentPrefab;


    private List<PostItem> userPosts = new List<PostItem>();
    private List<CommentItem> commentItems = new List<CommentItem>();

    private List<Posts> posts = new List<Posts>
    {
        
    };

    private List<Comments> comments = new List<Comments>()
    {

    };

    protected override async Task OnShow()
    {
        var content = await GetContentFromServer("https://jsonplaceholder.typicode.com/posts");
        var content2 = await GetContentFromServer("https://jsonplaceholder.typicode.com/comments");
        comments = Deserialize<List<Comments>>(content2);
        posts = Deserialize<List<Posts>>(content);
        int temp = Convert.ToInt32(idk.IDuser);
        for (int i = 0; i < posts.Count; i++)
        {
            if (posts[i].uid == temp)
            {
                PostItem postItem = Instantiate(postPrefab, root);
                postItem.UpdatePostItem(posts[i].Id, posts[i].Title, posts[i].Body);
                userPosts.Add(postItem);
                for(int x = 0; x < comments.Count; x++)
                {
                    if(comments[x].cid == posts[i].Id)
                    {
                        CommentItem commentItem = Instantiate(commentPrefab, postItem.transform);
                        commentItem.UpdateCommentItem(comments[x].Id, comments[x].Name, comments[x].Email,
                            comments[x].Body);
                        commentItems.Add(commentItem);
                    }
                } 
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
        for (int i = userPosts.Count -1; i >= 0; i--)
        {
            Destroy(userPosts[i].gameObject);
        }
        
        userPosts.Clear();
    }

    public void Clear()
    {
        for (int i = userPosts.Count -1; i >= 0; i--)
        {
            Destroy(userPosts[i].gameObject);
        }
        
        userPosts.Clear();
    }
    
}
