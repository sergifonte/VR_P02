using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadCubesLevel()
    {
        SceneManager.LoadScene("Level_Cubes"); 
    }
}