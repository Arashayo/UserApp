using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsPanelControl : MonoBehaviour
{
    [SerializeField] private UserProfilePanelControl userProfilePanelControl;
    [SerializeField] private TodosPanelControl todosPanelControl;
    [SerializeField] private AlbumsPanelControl albumsPanelControl;
    [SerializeField] private PostsPanelControl postsPanelControl;

    [SerializeField] private Button profileButton;
    [SerializeField] private Button todosButton;
    [SerializeField] private Button albumsButton;
    [SerializeField] private Button postsButton;
    [SerializeField] private Text title;

    private void Awake()
    {
        profileButton.onClick.AddListener(UserProfileClicked);
        todosButton.onClick.AddListener(TodosClicked);
        albumsButton.onClick.AddListener(AlbumsClicked);
        postsButton.onClick.AddListener(PostsClicked);
        title.text = "User Profile";
    }

    private void OnDestroy()
    {
        profileButton.onClick.RemoveListener(UserProfileClicked);
        todosButton.onClick.RemoveListener(TodosClicked);
        albumsButton.onClick.RemoveListener(AlbumsClicked);
        postsButton.onClick.RemoveListener(PostsClicked);
    }

    private void UserProfileClicked()
    {
        todosPanelControl.Hide();
        albumsPanelControl.Hide();
        postsPanelControl.Hide();
        userProfilePanelControl.Show();
        title.text = "User Profile";
    }

    private void TodosClicked()
    {
        userProfilePanelControl.Hide();
        albumsPanelControl.Hide();
        postsPanelControl.Hide();
        todosPanelControl.Show();
        title.text = "To Do List";
    }

    private void AlbumsClicked()
    {
        userProfilePanelControl.Hide();
        postsPanelControl.Hide();
        todosPanelControl.Hide();
        albumsPanelControl.Show();
        title.text = "Albums";
    }

    private void PostsClicked()
    {
        userProfilePanelControl.Hide();
        albumsPanelControl.Hide();
        todosPanelControl.Hide();
        postsPanelControl.Show();
        title.text = "Posts";
    }
}