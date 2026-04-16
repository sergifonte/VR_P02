using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerCubes : MonoBehaviour
{
    public void ReturnTo()
    {
        SceneManager.LoadScene(3);
    }

    public void Reload()
    {
        SceneManager.LoadScene(4);
    }
}