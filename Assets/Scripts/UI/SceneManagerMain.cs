using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMain : MonoBehaviour
{
    public void ReturnTo()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeTo()
    {
        SceneManager.LoadScene(3);
    }
}