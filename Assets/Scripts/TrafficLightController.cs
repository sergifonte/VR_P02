using UnityEngine;
using UnityEngine.UI;

public class TrafficLight : MonoBehaviour
{
    public MeshRenderer llumVermella, llumVerda;
    public Material matVermell, matVerd, matApagat;
    
    // Materials simulats (els haureu de crear vosaltres)
    public Material matVermellSimulat, matVerdSimulat;

    private bool isGreen = false;

    void Start() {
        InvokeRepeating("CanviarLlum", 2f, 4f); // Canvia cada 4 segons
    }

    void CanviarLlum() {
        isGreen = !isGreen;
        ActualitzarVisuals(0); // 0 = Normal per defecte
    }

    public void ActualitzarVisuals(int tipusDaltonisme) {
        // Reset a apagat
        llumVermella.material = matApagat;
        llumVerda.material = matApagat;

        if (isGreen) {
            llumVerda.material = (tipusDaltonisme == 1) ? matVerdSimulat : matVerd;
        } else {
            llumVermella.material = (tipusDaltonisme == 1) ? matVermellSimulat : matVermell;
        }
    }

    public void AccioUsuari(string accio) {
        if (isGreen && accio == "Accelerar") Debug.Log("CORRECTE!");
        else if (!isGreen && accio == "Frenar") Debug.Log("CORRECTE!");
        else Debug.Log("ERROR/ACCIDENT!");
    }
}