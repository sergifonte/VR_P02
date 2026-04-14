using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorChange : MonoBehaviour
{
    public Material redMat;
    public Material yellowMat;
    public Material greenMat;

    private Renderer rend;

    public enum LightState { Yellow, Red, Green }
    public LightState currentState;

    // To track what player should do
    public enum ExpectedAction { None, Brake, Accelerate }
    public ExpectedAction expectedAction = ExpectedAction.None;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(LightCycle());
    }

    IEnumerator LightCycle()
    {
        while (true)
        {
            //groc per defecte
            SetLight(LightState.Yellow);
            expectedAction = ExpectedAction.None;
            yield return new WaitForSeconds(10f);

            //es tria vermell o verd de manera random abans de tornar a groc
            bool goRed = Random.value > 0.5f;

            if (goRed)
            {
                //groc a vermell
                SetLight(LightState.Red);
                expectedAction = ExpectedAction.Brake;
            }
            else
            {
                //groc a verd
                SetLight(LightState.Green);
                expectedAction = ExpectedAction.Accelerate;
            }

            //temps perque reaccioni el jugador
            yield return new WaitForSeconds(3f);

            //quan s'acaba el temps de reacció i torna a groc es d'eixa d'esperar una acció
            expectedAction = ExpectedAction.None;
        }
    }

    void SetLight(LightState state)
    {
        currentState = state;

        switch (state)
        {
            case LightState.Red:
                rend.material = redMat;
                break;
            case LightState.Yellow:
                rend.material = yellowMat;
                break;
            case LightState.Green:
                rend.material = greenMat;
                break;
        }
    }

    //aixo es crida amb els pedals a la ui
    public void OnBrakePressed()
    {
        if (expectedAction == ExpectedAction.Brake)
        {
            Debug.Log("Correct: Brake!");
        }
        else
        {
            Debug.Log("Wrong action!");
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
            Debug.Log("Wrong action!");
        }
    }
}
