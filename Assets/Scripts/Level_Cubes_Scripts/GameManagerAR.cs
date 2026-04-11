using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerAR : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI textInstructions;
    public TextMeshProUGUI textLives;
    public GameObject panelGameOver;
    public TextMeshProUGUI textGameOverMessage; // Per dir si has guanyat o perdut
    public Button btnRetry;
    public Button btnBack;

    [Header("Game Setup")]
    public GameObject cubePrefab;
    public Transform spawnCenter;
    public Material[] cubeMaterials; 
    public string[] colorNames = { "RED", "YELLOW", "BLUE", "GREEN" };

    private int lives = 3;
    private int currentTargetColorID;
    private int cubesLeftOfTarget;
    private List<int> colorsToAsk = new List<int> { 0, 1, 2, 3 }; 

    void Start()
    {
        Time.timeScale = 1f;

        panelGameOver.SetActive(false);
        btnRetry.onClick.AddListener(RestartGame);
        btnBack.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));

        SpawnCubes();
        PickNextColor();
        UpdateUI();
    }

    void SpawnCubes()
    {
        List<int> colorPool = new List<int>();
        for (int i = 0; i < 4; i++) { colorPool.Add(i); colorPool.Add(i); colorPool.Add(i); }

        // Barregem els colors aleatòriament perquè no surtin tots els verds junts
        for (int i = 0; i < colorPool.Count; i++)
        {
            int temp = colorPool[i];
            int randomIndex = Random.Range(i, colorPool.Count);
            colorPool[i] = colorPool[randomIndex];
            colorPool[randomIndex] = temp;
        }

        // Dividim els 360 graus al voltant del jugador entre els 12 cubs (30 graus per cub)
        float angleStep = 360f / 12f; 

        for (int i = 0; i < 12; i++)
        {
            // Afegim una petita variació aleatòria a l'angle (+- 10 graus) perquè no sigui massa simètric
            float currentAngle = (i * angleStep) + Random.Range(-10f, 10f);
            
            // Distància: entre 1 i 2.5 metres de tu
            float radius = Random.Range(1.0f, 2.5f); 

            // Matemàtiques per convertir l'angle i la distància en posicions X i Z
            float x = Mathf.Sin(currentAngle * Mathf.Deg2Rad) * radius;
            float z = Mathf.Cos(currentAngle * Mathf.Deg2Rad) * radius;

            // La posició final (la Y es queda a 0 per tocar el terra)
            Vector3 spawnPos = spawnCenter.position + new Vector3(x, 0.1f, z);
            
            // Rotem el cub de forma aleatòria perquè quedi més natural
            Quaternion randomRot = Quaternion.Euler(0, Random.Range(0, 360), 0);

            // Creem el cub
            GameObject newCube = Instantiate(cubePrefab, spawnPos, randomRot);
            
            // Li assignem el color correcte
            int chosenColor = colorPool[i];
            newCube.GetComponent<Renderer>().material = cubeMaterials[chosenColor];
            newCube.GetComponent<CubeData>().colorID = chosenColor;
        }
    }

    void PickNextColor()
    {
        if (colorsToAsk.Count == 0)
        {
            WinGame();
            return;
        }

        int randomIndex = Random.Range(0, colorsToAsk.Count);
        currentTargetColorID = colorsToAsk[randomIndex];
        colorsToAsk.RemoveAt(randomIndex);

        cubesLeftOfTarget = 3; 
        UpdateUI();
    }

    void Update()
    {
        if (lives <= 0 || (cubesLeftOfTarget <= 0 && colorsToAsk.Count == 0)) return;

        // Codi per fer clic amb el ratolí (ordinador) o amb el dit (mòbil)
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                CubeData cube = hit.transform.GetComponent<CubeData>();
                if (cube != null) CheckCube(cube);
            }
        }
    }

    void CheckCube(CubeData cube)
    {
        if (cube.colorID == currentTargetColorID)
        {
            Destroy(cube.gameObject);
            cubesLeftOfTarget--;
            
            if (cubesLeftOfTarget == 0) PickNextColor();
            else UpdateUI();
        }
        else
        {
            lives--;
            UpdateUI();
            if (lives <= 0) LoseGame();
        }
    }

    void UpdateUI()
    {
        textLives.text = "Lives: " + lives;
        if (lives > 0)
            textInstructions.text = "Select the " + colorNames[currentTargetColorID] + " cubes (" + cubesLeftOfTarget + " left)";
    }

    void LoseGame()
    {
        textGameOverMessage.text = "GAME OVER";
        textInstructions.text = "";
        panelGameOver.SetActive(true);
    }

    void WinGame()
    {
        textGameOverMessage.text = "YOU WIN!";
        textInstructions.text = "";
        panelGameOver.SetActive(true);
    }

    void RestartGame() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
}