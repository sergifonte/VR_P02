using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerTrafficLight : MonoBehaviour
{
    public void ReturnTo()
    {
        SceneManager.LoadScene(3);
    }
}