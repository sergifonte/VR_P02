using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class ManagerTrafficLight : MonoBehaviour
{
    

    public void ReturnTo()
    {
        LoaderUtility.Deinitialize();
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    }
