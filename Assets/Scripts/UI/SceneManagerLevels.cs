using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;


public class ManagerLevels : MonoBehaviour
{
   

    public void ReturnTo()
    {
        LoaderUtility.Deinitialize();

        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void ChangeToCubes()
    {
        LoaderUtility.Deinitialize();

        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    public void ChangeToTraffic()
    {
        LoaderUtility.Deinitialize();

        UnityEngine.SceneManagement.SceneManager.LoadScene(5);    }

   


}
