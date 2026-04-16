using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class GameNavigationManager : MonoBehaviour
{
    // Funció interna per carregar escenes amb seguretat per a l'AR
    private void SafeLoad(int index)
    {
        // Busquem si hi ha una sessió d'AR activa i la parem manualment.
        // Això és vital per evitar el MissingReferenceException de la càmera.
        ARSession session = Object.FindFirstObjectByType<ARSession>();
        if (session != null)
        {
            session.enabled = false;
        }

        SceneManager.LoadScene(index);
    }

    // --- ESCENA 0: TITLE ---
    public void PlayGame() => SafeLoad(1);
    public void ExitGame()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }

    // --- ESCENA 1: INSTRUCCIONS / CAMERA ---
    public void FromInstructionsToTitle() => SafeLoad(0);
    public void FromInstructionsToMainAR() => SafeLoad(2);

    // --- ESCENA 2: MAIN AR (EXPLORACIÓ) ---
    public void FromMainARToInstructions() => SafeLoad(1);
    public void FromMainARToSelectLevel() => SafeLoad(3);

    // --- ESCENA 3: SELECT LEVEL ---
    public void FromSelectLevelToMainAR() => SafeLoad(2);
    public void FromSelectLevelToCubes() => SafeLoad(4);
    public void FromSelectLevelToTraffic() => SafeLoad(5);

    // --- ESCENA 4: CUBES LEVEL (Panell Game Over) ---
    public void FromCubesToSelectLevel() => SafeLoad(3); // Boto "Back"
    public void ReloadCubes() => SafeLoad(4);           // Boto "Try Again"

    // --- ESCENA 5: TRAFFIC LIGHT LEVEL (Panell Game Over) ---
    public void FromTrafficToSelectLevel() => SafeLoad(3); // Boto "Back"
    public void ReloadTraffic() => SafeLoad(5);           // Boto "Try Again" (El que faltava)
}