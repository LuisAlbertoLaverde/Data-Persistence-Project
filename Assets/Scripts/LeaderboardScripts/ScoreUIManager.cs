using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUIManager : MonoBehaviour
{
    // Variables privadas para el almacenamiento de datos y administración de puntajes
    private ScoreData scoreData;
    private ScoreManager scoreManager;

    // Asigna las referencias de ScoreData y ScoreManager en el Inspector
    public ScoreData initialScoreData;
    public ScoreManager initialScoreManager;

    // Awake se utiliza para inicializar las referencias
    private void Awake()
    {
        // Asigna las referencias a las variables privadas
        scoreData = initialScoreData;
        scoreManager = initialScoreManager;
    }

    // Método para restablecer los puntajes
    public void ResetScores()
    {
        Debug.Log("ResetScores() llamado");

        // Verifica si el ScoreData no es nulo
        if (scoreData != null)
        {
            // Borra los puntajes y guarda los cambios
            scoreData.scores.Clear();
            scoreManager.SaveScore();
            Debug.Log("Número de puntajes después de borrar: " + scoreData.scores.Count);
        }
    }

    // Método para regresar al menú principal
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
