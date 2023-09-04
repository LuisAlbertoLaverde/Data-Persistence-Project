using System;
using System.Collections.Generic; // Importa el espacio de nombres para listas gen�ricas.
using System.Linq;                // Importa el espacio de nombres para consultar colecciones.
using UnityEngine;                // Importa el espacio de nombres principal de Unity.

public class ScoreManager : MonoBehaviour // Define la clase ScoreManager que hereda de MonoBehaviour.
{
    private ScoreData scoreData; // Declara una variable privada para almacenar los datos de puntuaci�n.

    private void Awake() // M�todo que se ejecuta cuando el objeto se inicializa.
    {
        var json = PlayerPrefs.GetString("scores", "{}"); // Obtiene una cadena JSON de PlayerPrefs y la almacena en la variable 'json'.
        scoreData = JsonUtility.FromJson<ScoreData>(json); // Convierte la cadena JSON en un objeto ScoreData y lo asigna a 'scoreData'.
    }

    public IEnumerable<Score> GetHighScores() // M�todo para obtener las puntuaciones m�s altas.
    {
        return scoreData.scores.OrderByDescending(keySelector: x => x.score); // Devuelve la lista de puntuaciones ordenada por la puntuaci�n descendente.
    }
    public int GetHighestScore()
    {
        int highestScore = 0; // Un valor predeterminado en caso de que no haya puntuaciones.

        foreach (var score in GetHighScores())
        {
            if (score.score > highestScore)
            {
                highestScore = (int)score.score;
            }
        }

        return highestScore;
    }
    public void AddScore(Score score) // M�todo para agregar una puntuaci�n a la lista de puntuaciones.
    {
        scoreData.scores.Add(score); // Agrega la puntuaci�n 'score' a la lista 'scores' en 'scoreData'.
    }

    public void ClearScores() // M�todo para borrar todas las puntuaciones.
    {
        scoreData.scores.Clear(); // Borra todos los elementos de la lista 'scores' en 'scoreData'.
    }

    private void OnDestroy() // M�todo que se ejecuta cuando el objeto se destruye.
    {
        SaveScore(); // Llama al m�todo SaveScore para guardar los datos de puntuaci�n.
    }

    public void SaveScore() // M�todo para guardar los datos de puntuaci�n.
    {
        var json = JsonUtility.ToJson(scoreData); // Convierte 'scoreData' a una cadena JSON y la almacena en 'json'.
        PlayerPrefs.SetString("scores", json);     // Guarda la cadena JSON en PlayerPrefs bajo la clave "scores".
    }

    internal string GetPlayerNameWithScore(int highestScore)
    {
        throw new NotImplementedException();
    }
}
