using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerCamera : MonoBehaviour
{
    public void ReturnTo()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeTo()
    {
        SceneManager.LoadScene(2);
    }
}