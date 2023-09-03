using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseBtn;
    [SerializeField] private GameObject _PauseMenu;
    public void Pause()
    {
        Time.timeScale = 0f;
        _pauseBtn.SetActive(false);
        _PauseMenu.SetActive(true);
    }
    public void Return()
    {
        Time.timeScale = 1f;
        _pauseBtn.SetActive(true);
        _PauseMenu.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
