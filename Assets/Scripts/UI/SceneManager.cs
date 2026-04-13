using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkingScene : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();

        if (canvas != null && canvas.worldCamera == null)
        {
            canvas.worldCamera = Camera.main;
        }
    }

    public void ChangeTo()
    {
UnityEngine.SceneManagement.SceneManager.LoadScene(1);    }

    public void Exit()
    {
        Debug.Log("Exiting the Game...");
        Application.Quit();
    }
}
