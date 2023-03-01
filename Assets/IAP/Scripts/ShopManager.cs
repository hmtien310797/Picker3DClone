using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject Content;

    [SerializeField] IAP_Manager IAP_Manager;

    public string ScenePlay;

    public void Show()
    {
        if (IAP_Manager.CanShowShop())
        {
            Content.SetActive(true);
        }
    }

    public void Hide()
    {
        Content.SetActive(false);

    }

    public void PlayBtn()
    {
        SceneManager.LoadScene(ScenePlay);
    }
}
