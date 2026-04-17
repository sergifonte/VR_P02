using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Pantalles de Menú")]
    public GameObject pantallaTitol;
    public GameObject pantallaInstruccions;
    public GameObject pantallaMainAR;
    public GameObject pantallaNivells;

    [Header("Nivells de Joc")]
    public GameObject jocCubs;
    public GameObject jocSemafor;

    void Start()
    {
        ShowTitle();
    }

    private void HideAll()
    {
        pantallaTitol.SetActive(false);
        pantallaInstruccions.SetActive(false);
        pantallaMainAR.SetActive(false);
        pantallaNivells.SetActive(false);
        jocCubs.SetActive(false);
        jocSemafor.SetActive(false);
    }

    // --- NAVEGACIÓ BÀSICA ---
    public void ShowTitle() { HideAll(); pantallaTitol.SetActive(true); }
    public void ShowInstructions() { HideAll(); pantallaInstruccions.SetActive(true); }
    public void ShowMainAR() { HideAll(); pantallaMainAR.SetActive(true); }
    public void ShowLevelSelection() { HideAll(); pantallaNivells.SetActive(true); }

    // --- ENTRAR ALS NIVELLS ---
    public void PlayCubes() { HideAll(); jocCubs.SetActive(true); }
    public void PlayTraffic() { HideAll(); jocSemafor.SetActive(true); }

    // --- BOTONS TRY AGAIN (REINTENTAR) ---

    public void RetryCubes()
    {
        HideAll();
        jocCubs.SetActive(false); 
        jocCubs.SetActive(true);
    }

    public void RetryTraffic()
    {
        HideAll();
        jocSemafor.SetActive(false);
        jocSemafor.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}