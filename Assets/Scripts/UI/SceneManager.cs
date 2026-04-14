using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;


public class LinkingScene : MonoBehaviour
{

    public void ChangeTo()
    {
        LoaderUtility.Deinitialize();

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);    }

    public void Exit()
    {
        Debug.Log("Exiting the Game...");
        Application.Quit();
    }
}
