using UnityEngine;
using UnityEngine.UI;

public class ColorFilterController : MonoBehaviour
{
    public RawImage filterImage; // Arrossega la Raw Image aquí

    public void SetBlindnessType(int index)
    {
        // Apliquem un color amb transparència per simular el filtre
        switch(index)
        {
            case 0: // Normal
                filterImage.color = new Color(0, 0, 0, 0); // Transparent
                break;
            case 1: // Protanopia (Filtre groguenc/marró)
                filterImage.color = new Color(0.7f, 0.6f, 0.2f, 0.3f); 
                break;
            case 2: // Deuteranopia (Filtre verdós/gris)
                filterImage.color = new Color(0.5f, 0.5f, 0.3f, 0.3f);
                break;
            case 3: // Tritanopia (Filtre rosat)
                filterImage.color = new Color(0.8f, 0.2f, 0.2f, 0.2f);
                break;
        }
    }
}