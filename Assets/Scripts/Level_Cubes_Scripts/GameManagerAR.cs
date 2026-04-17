using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManagerAR : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI textInstructions;
    public TextMeshProUGUI textLives;
    public GameObject panelGameOver;
    public TextMeshProUGUI textGameOverMessage;

    [Header("Game Setup")]
    public GameObject cubePrefab;
    public Transform spawnCenter;
    public Material[] cubeMaterials; 
    public string[] colorNames = { "RED", "YELLOW", "BLUE", "GREEN" };

    [Header("Spawn Settings")]
    public float minSpawnRadius = 0.5f; // Distància mínima en metres
    public float maxSpawnRadius = 1.2f; // Distància màxima en metres

    private int lives;
    private int currentTargetColorID;
    private int cubesLeftOfTarget;
    private List<int> colorsToAsk; 
    
    // Llista per guardar els cubs i poder-los esborrar al reiniciar
    private List<GameObject> activeCubes = new List<GameObject>();

    // Canviem Start per OnEnable perquè s'executi cada cop que obrim el nivell
    void OnEnable()
    {
        Time.timeScale = 1f;
        lives = 3;
        colorsToAsk = new List<int> { 0, 1, 2, 3 };
        
        panelGameOver.SetActive(false);

        ClearOldCubes(); // Netegem cubs d'una partida anterior si n'hi ha
        SpawnCubes();
        PickNextColor();
        UpdateUI();
    }

    // Quan sortim del nivell, netegem els cubs perquè no molestin al menú
    void OnDisable()
    {
        ClearOldCubes();
    }

    void ClearOldCubes()
    {
        foreach (GameObject cube in activeCubes)
        {
            if (cube != null) Destroy(cube);
        }
        activeCubes.Clear();
    }

    void SpawnCubes()
    {
        List<int> colorPool = new List<int>();
        for (int i = 0; i < 4; i++) { colorPool.Add(i); colorPool.Add(i); colorPool.Add(i); }

        for (int i = 0; i < colorPool.Count; i++)
        {
            int temp = colorPool[i];
            int randomIndex = Random.Range(i, colorPool.Count);
            colorPool[i] = colorPool[randomIndex];
            colorPool[randomIndex] = temp;
        }

        float angleStep = 360f / 12f; 

        for (int i = 0; i < 12; i++)
        {
            float currentAngle = (i * angleStep) + Random.Range(-10f, 10f);
            
            // Aquí apliquem les noves variables de l'Inspector!
            float radius = Random.Range(minSpawnRadius, maxSpawnRadius); 

            float x = Mathf.Sin(currentAngle * Mathf.Deg2Rad) * radius;
            float z = Mathf.Cos(currentAngle * Mathf.Deg2Rad) * radius;

            Vector3 spawnPos = spawnCenter.position + new Vector3(x, 0.1f, z);
            Quaternion randomRot = Quaternion.Euler(0, Random.Range(0, 360), 0);

            GameObject newCube = Instantiate(cubePrefab, spawnPos, randomRot);
            
            int chosenColor = colorPool[i];
            newCube.GetComponent<Renderer>().material = cubeMaterials[chosenColor];
            newCube.GetComponent<CubeData>().colorID = chosenColor;
            
            // Guardem el cub a la nostra llista per tenir-lo controlat
            activeCubes.Add(newCube);
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
            activeCubes.Remove(cube.gameObject); // El traiem de la llista
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
}