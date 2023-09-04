using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{
    public TextMeshProUGUI bestScoreTxt;
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI errorMessageText;

    void Start()
    {
        // Configura el nombre del jugador en la interfaz de usuario
        playerNameInput.text = GlobalDataManager.Instance.playerName;

        // Obtiene el nombre y el mejor puntaje desde GlobalDataManager
        string bestPlayerName = GlobalDataManager.Instance.bestPlayerName;
        int bestScore = GlobalDataManager.Instance.bestScore;

        // Configura el objeto de texto en MainMenu con el nombre y el mejor puntaje
        bestScoreTxt.text = $"Best Score : {bestPlayerName} : {bestScore}";
    }
    public void StartGame()
    {
        if (!string.IsNullOrEmpty(playerNameInput.text))
        {
            GlobalDataManager.Instance.playerName = playerNameInput.text;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            // Muestra un mensaje de error al jugador o realiza alguna acción adecuada
            errorMessageText.text = "Por favor, ingresa tu nombre";
            errorMessageText.gameObject.SetActive(true);
        }
    }
    public void LeaderboardGame()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
