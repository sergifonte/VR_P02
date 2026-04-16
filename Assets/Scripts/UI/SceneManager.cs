using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkingScene : MonoBehaviour
{
    public void ChangeTo()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Debug.Log("Exiting the Game...");
        Application.Quit();
    }
}