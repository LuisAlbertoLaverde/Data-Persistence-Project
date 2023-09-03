using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick brickPrefab;       // Prefab de los ladrillos
    public int LineCount = 6;       // N�mero de l�neas de ladrillos
    public Rigidbody Ball;          // Rigidbody de la pelota

    // Referencias a elementos de la interfaz de usuario
    public TextMeshProUGUI playerName;
    public Text BestScore;
    public Text ScoreText;
    public GameObject GameOverText;

    // Referencia al administrador de puntajes
    public ScoreManager scoreManager;

    // Estado del juego
    private bool gameStarted = false;
    private int playerScore;
    private bool isGameOver = false;

    void Start()
    {
        // Configura el nombre del jugador en la interfaz de usuario
        AddPlayerName();
        // Configura la mejor puntuaci�n en la interfaz de usuario
        AddBestScore();
        // Configura la disposici�n de los ladrillos
        InitializeBricks();
    }

    private void InitializeBricks()
    {
        // Definimos la distancia horizontal entre cada ladrillo en el juego.
        const float step = 0.6f;

        // Calculamos cu�ntos ladrillos caben en una l�nea horizontal.
        int perLine = Mathf.FloorToInt(4.0f / step);

        // Definimos una matriz que contiene la cantidad de puntos que otorga cada ladrillo en cada l�nea.
        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };

        // Iniciamos un bucle para crear las filas de ladrillos.
        for (int i = 0; i < LineCount; ++i)
        {
            // Dentro de la fila, iniciamos otro bucle para crear cada ladrillo individualmente.
            for (int x = 0; x < perLine; ++x)
            {
                // Calculamos la posici�n de este ladrillo en funci�n de la fila y la posici�n en la fila.
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);

                // Creamos una instancia de ladrillo en la posici�n calculada y sin rotaci�n.
                var brick = Instantiate(brickPrefab, position, Quaternion.identity);

                // Asignamos la cantidad de puntos que otorga este ladrillo seg�n su posici�n en la fila.
                brick.PointValue = pointCountArray[i];

                // A�adimos un listener (escucha) para el evento OnDestroyed del ladrillo,
                // que llamar� al m�todo AddPoint cuando el ladrillo sea destruido.
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }
    void Update()
    {
        // Manejo de inicio del juego
        HandleGameStart();
        // Manejo de fin del juego
        HandleGameOver();
    }

    private void HandleGameOver()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return; // Salimos del m�todo Update
        }
    }

    private void HandleGameStart()
    {
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameStarted = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                const float initialForce = 2.0f;
                Ball.AddForce(forceDir * initialForce, ForceMode.VelocityChange);

                return; // Salimos del m�todo Update
            }
        }
    }

    // Configura el nombre del jugador en la interfaz de usuario
    void AddPlayerName()
    {
        playerName.text = $"Player : {GlobalDataManager.Instance.playerName}";
    }

    // Configura la mejor puntuaci�n en la interfaz de usuario
    void AddBestScore()
    {
        BestScore.text = $"Best Score : {GlobalDataManager.Instance.playerName} : {GlobalDataManager.Instance.bestScore}";
    }

    // Agrega puntos al contador y actualiza la interfaz de usuario
    void AddPoint(int point)
    {
        playerScore += point;
        ScoreText.text = $"Score : {playerScore}";
    }

    // M�todo para manejar el fin del juego
    public void GameOver()
    {
        Debug.Log("El juego ha finalizado");
        isGameOver = true;

        // Guarda la puntuaci�n del jugador y muestra el texto de fin de juego
        string playerName = GlobalDataManager.Instance.playerName;
        float playerScore = this.playerScore;
        scoreManager.AddScore(new Score(playerName, playerScore));
        scoreManager.SaveScore();
        GameOverText.SetActive(true);
    }
}
