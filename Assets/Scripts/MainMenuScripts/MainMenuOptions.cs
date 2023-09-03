using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{
    public TextMeshProUGUI bestScore;
    public TMP_InputField playerNameInput;

    public void StartGame()
    {
        GlobalDataManager.Instance.playerName = playerNameInput.text;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
