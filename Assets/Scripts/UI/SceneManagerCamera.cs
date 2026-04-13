using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerCamera : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();

        if (canvas != null && canvas.worldCamera == null)
        {
            canvas.worldCamera = Camera.main;
        }
    }

    public void ReturnTo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void ChangeTo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);    }

   
}
