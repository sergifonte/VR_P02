using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorAdjustmentController : MonoBehaviour
{
    public Volume globalVolume; 
    private ColorAdjustments colorAdjustments;

    void Start()
    {
        // Intentem agafar el perfil del Volume
        if (globalVolume != null && globalVolume.profile.TryGet(out colorAdjustments))
        {
            Debug.Log("Filtre trobat i preparat!");
        }
        else
        {
            Debug.LogError("Error: No s'ha trobat el component Color Adjustments al Global Volume!");
        }
    }

    public void SetFilter(int index)
    {
        Debug.Log("Has seleccionat l'opció número: " + index);

        if (colorAdjustments == null) return;

        colorAdjustments.colorFilter.overrideState = true;

        switch (index)
        {
            case 0: // Normal
                colorAdjustments.colorFilter.value = Color.white;
                colorAdjustments.saturation.value = 0; // Saturació normal
                break;
            case 1: // Protanopia (Molt més groguenc/gris)
                colorAdjustments.colorFilter.value = new Color(0.6f, 0.55f, 0.3f); 
                colorAdjustments.saturation.value = -20; // Baixem la saturació per fer-ho més gris
                break;
            case 2: // Deuteranopia (Molt més gris/verdós apagat)
                colorAdjustments.colorFilter.value = new Color(0.5f, 0.5f, 0.45f);
                colorAdjustments.saturation.value = -30;
                break;
            case 3: // Tritanopia (Molt més cian/rosa)
                colorAdjustments.colorFilter.value = new Color(0.9f, 0.4f, 0.6f);
                colorAdjustments.saturation.value = -10;
                break;
        }
    }
}