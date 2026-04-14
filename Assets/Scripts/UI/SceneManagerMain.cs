using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;


public class ManagerMain : MonoBehaviour
{
    

    public void ReturnTo()
    {
        LoaderUtility.Deinitialize();

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void ChangeTo()
    {
        LoaderUtility.Deinitialize();

        UnityEngine.SceneManagement.SceneManager.LoadScene(3);    }

   
}
