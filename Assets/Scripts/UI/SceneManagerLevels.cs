using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerLevels : MonoBehaviour
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void ChangeToCubes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    public void ChangeToTraffic()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);    }

   


}
