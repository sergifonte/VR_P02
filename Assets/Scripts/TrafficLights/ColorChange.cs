using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorChange : MonoBehaviour
{
    public Material trafficLights;
    //public Material[] colors = { }; 
    public Material red;
    public Material green;

    private Renderer rend;

    private bool isRed;

    public enum ExpectedAction { None, Brake, Accelerate }
    public ExpectedAction expectedAction;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(LightCycle());
    }

    IEnumerator LightCycle()
    {
        while (true)
        {
            isRed = !isRed;

            if (isRed)
            {
                rend.material = red;
                expectedAction = ExpectedAction.Brake;
                Debug.Log("RED --> Press Brake");
            }
            else
            {
                rend.material = green;
                expectedAction = ExpectedAction.Accelerate;
                Debug.Log("GREEN --> Press Accelerator");
            }

            yield return new WaitForSeconds(2f);
        }
    }

    public void OnBrakePressed()
    {
        if (expectedAction == ExpectedAction.Brake)
        {
            Debug.Log("Correct: Brake!");
        }
        else
        {
            Debug.Log("Wrong!");
        }
    }

    public void OnAcceleratePressed()
    {
        if (expectedAction == ExpectedAction.Accelerate)
        {
            Debug.Log("Correct: Accelerate!");
        }
        else
        {
            Debug.Log("Wrong!");
        }
    }
}
