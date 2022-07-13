using System;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanelControl : AbstractPanelController
{
    [SerializeField] private Button loginButton;
    [SerializeField] private UserProfilePanelControl userProfilePanelControl;
    [SerializeField] private InputField UserIDInput;
    protected internal int IDuser;

    private void Awake()
    {
        loginButton.onClick.AddListener(LoginButtonClicked);
    }


    private void LoginButtonClicked()
    {
        IDuser = Convert.ToInt32(UserIDInput.text);
        if(IDuser > 0 && IDuser < 11)
        {
        gameObject.SetActive(false);
        userProfilePanelControl.Show();
        }
    }

    private void OnDestroy()
    {
        loginButton.onClick.RemoveListener(LoginButtonClicked);
    }
}
