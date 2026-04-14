using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class ManagerCubes : MonoBehaviour
{
   

    public void ReturnTo()
    {
        LoaderUtility.Deinitialize();

        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    public void Reload()
    {
        LoaderUtility.Deinitialize();

        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

}
