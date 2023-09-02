using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI bestScore;
    public TMP_InputField playerNameInput;

    public void StartGame()
    {
        GlobalDataManager.Instance.playerName = playerNameInput.text;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //public void ResetBestScore()
    //{
    //    GlobalDataManager.Instance.bestScore = 0;
    //}
    public void LeaderboardGame()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Debug.Log("salir del juego");
        Application.Quit();
    }
}
