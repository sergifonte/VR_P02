using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerLevels : MonoBehaviour
{
    public void ReturnTo()
    {
        SceneManager.LoadScene(2);
    }

    public void ChangeToCubes()
    {
        SceneManager.LoadScene(4);
    }

    public void ChangeToTraffic()
    {
        SceneManager.LoadScene(5);
    }
}