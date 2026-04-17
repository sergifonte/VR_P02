using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorChange : MonoBehaviour
{
    [Header("Traffic Light Materials")]
    public Material redMat;
    public Material yellowMat;
    public Material greenMat;
    private Renderer rend;

    public enum LightState { Yellow, Red, Green }
    public LightState currentState;

    public enum ExpectedAction { None, Brake, Accelerate }
    public ExpectedAction expectedAction = ExpectedAction.None;

    [Header("UI Elements")]
    public TextMeshProUGUI textTimer;
    public TextMeshProUGUI textInstructions;
    public TextMeshProUGUI textLives;
    public GameObject panelGameOver;
    public TextMeshProUGUI textGameOverMessage;
    
    [Header("Gameplay Buttons")] // <-- NOVES VARIABLES PER ALS BOTONS
    public GameObject btnBrake;
    public GameObject btnAccelerate;

    [Header("Game Setup")]
    private int lives;
    private float timeRemaining;
    private bool gameActive;
    private bool actionTakenThisCycle;

    void OnEnable()
    {
        Time.timeScale = 1f;
        lives = 3;
        timeRemaining = 30f;
        gameActive = true;
        actionTakenThisCycle = false;

        if (rend == null) rend = GetComponent<Renderer>();

        if (panelGameOver != null) panelGameOver.SetActive(false);
        
        // Assegurem que els botons de jugar estan actius al començar
        if (btnBrake != null) btnBrake.SetActive(true);
        if (btnAccelerate != null) btnAccelerate.SetActive(true);

        if (textInstructions != null)
            textInstructions.text = "Press GAS when you see the green light turn on, press BRAKE when you see the red light turn on.";

        UpdateLivesText();
        StartCoroutine(LightCycle());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    void Update()
    {
        if (!gameActive) return;

        timeRemaining -= Time.deltaTime;

        if (textTimer != null)
            textTimer.text = "Time: " + timeRemaining.ToString("F1") + "s";

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            WinGame();
        }
    }

    IEnumerator LightCycle()
    {
        while (gameActive)
        {
            SetLight(LightState.Yellow);
            expectedAction = ExpectedAction.Brake;
            actionTakenThisCycle = false;

            float yellowTime = Random.Range(2f, 4f);
            yield return new WaitForSeconds(yellowTime);

            if (gameActive && !actionTakenThisCycle)
            {
                Debug.Log("Too slow on yellow!");
                LoseLife();
            }

            if (!gameActive) break;

            bool goRed = Random.value > 0.5f;

            if (goRed)
            {
                SetLight(LightState.Red);
                expectedAction = ExpectedAction.Brake;
            }
            else
            {
                SetLight(LightState.Green);
                expectedAction = ExpectedAction.Accelerate;
            }

            actionTakenThisCycle = false;

            yield return new WaitForSeconds(3f);

            if (gameActive && !actionTakenThisCycle)
            {
                Debug.Log("Too slow on red/green!");
                LoseLife();
            }
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

    public void OnBrakePressed()
    {
        if (!gameActive || actionTakenThisCycle) return;

        actionTakenThisCycle = true;

        if (expectedAction == ExpectedAction.Brake)
        {
            Debug.Log("Correct: Brake!");
        }
        else
        {
            Debug.Log("Wrong action!");
            LoseLife();
        }
    }

    public void OnAcceleratePressed()
    {
        if (!gameActive || actionTakenThisCycle) return;

        actionTakenThisCycle = true;

        if (expectedAction == ExpectedAction.Accelerate)
        {
            Debug.Log("Correct: Accelerate!");
        }
        else
        {
            Debug.Log("Wrong action!");
            LoseLife();
        }
    }

    void LoseLife()
    {
        lives--;
        UpdateLivesText();

        if (lives <= 0)
        {
            LoseGame();
        }
    }

    void UpdateLivesText()
    {
        if (textLives != null)
            textLives.text = "Lives: " + lives;
    }

    void LoseGame()
    {
        gameActive = false;
        StopAllCoroutines();

        if (textGameOverMessage != null) textGameOverMessage.text = "GAME OVER";
        if (textInstructions != null) textInstructions.text = "";

        // Amaguem els botons de Gas i Fre
        if (btnBrake != null) btnBrake.SetActive(false);
        if (btnAccelerate != null) btnAccelerate.SetActive(false);

        if (panelGameOver != null) panelGameOver.SetActive(true);
    }

    void WinGame()
    {
        gameActive = false;
        StopAllCoroutines();
        SetLight(LightState.Yellow);

        if (textGameOverMessage != null) textGameOverMessage.text = "YOU WIN!";
        if (textInstructions != null) textInstructions.text = "";

        if (btnBrake != null) btnBrake.SetActive(false);
        if (btnAccelerate != null) btnAccelerate.SetActive(false);

        if (panelGameOver != null) panelGameOver.SetActive(true);
    }
}