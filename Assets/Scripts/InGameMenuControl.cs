using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuControl : MonoBehaviour
{
    [Header("Add References")]
    [SerializeField] GameObject inGameMenu;
    [SerializeField] Button contniue;
    [SerializeField] Button exitGame;

    private GameObject ball;

    private void Start()
    {
        SubscribeEvents();
        inGameMenu.SetActive(false);
    }

    public void IsActivateMenu(bool isActive)
    {
        inGameMenu.SetActive(isActive);
    }
   
    private void SubscribeEvents()
    {                      
        contniue.onClick.AddListener(delegate
        {
            inGameMenu.SetActive(false);
            GameManager.Instance.ActivateBall();
        });

        exitGame.onClick.AddListener(delegate
        {
            if (Application.isEditor)
            {
                EditorApplication.ExitPlaymode();
            }
            else
            {
                Application.Quit();
            }           
        });
    }
}
