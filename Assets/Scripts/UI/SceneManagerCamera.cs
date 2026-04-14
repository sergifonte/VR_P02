using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;


public class ManagerCamera : MonoBehaviour
{
    

    public void ReturnTo()
    {
        LoaderUtility.Deinitialize();

        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void ChangeTo()
    {
        LoaderUtility.Deinitialize();

        UnityEngine.SceneManagement.SceneManager.LoadScene(2);    }

   
}
