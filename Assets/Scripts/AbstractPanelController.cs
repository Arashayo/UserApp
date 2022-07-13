using System.Threading.Tasks;
using UnityEngine;

public abstract class AbstractPanelController : MonoBehaviour
{
    public GameObject Loading;
    public async void Show()
    {
        gameObject.SetActive(true);
        Loading.SetActive(true);
        await OnShow();
        Loading.SetActive(false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);

        OnHide();
    }

    protected virtual async Task OnShow()
    {
        
    }

    protected virtual void OnHide()
    {
        
    }
}