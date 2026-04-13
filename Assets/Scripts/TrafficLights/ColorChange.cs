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
            // YELLOW (base state)
            SetLight(LightState.Yellow);
            expectedAction = ExpectedAction.None;
            yield return new WaitForSeconds(2f);

            // RANDOM: go to Red or Green
            bool goRed = Random.value > 0.5f;

            if (goRed)
            {
                // YELLOW → RED
                SetLight(LightState.Red);
                expectedAction = ExpectedAction.Brake;
            }
            else
            {
                // YELLOW → GREEN
                SetLight(LightState.Green);
                expectedAction = ExpectedAction.Accelerate;
            }

            // Give player time to react
            yield return new WaitForSeconds(2f);

            // Reset expectation after reaction window
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

    // Called by UI buttons
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
