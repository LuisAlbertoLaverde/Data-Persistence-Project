using System;
using System.Collections.Generic; // Importa el espacio de nombres para listas genéricas.
using System.Linq;                // Importa el espacio de nombres para consultar colecciones.
using UnityEngine;                // Importa el espacio de nombres principal de Unity.

public class ScoreManager : MonoBehaviour // Define la clase ScoreManager que hereda de MonoBehaviour.
{
    private ScoreData scoreData; // Declara una variable privada para almacenar los datos de puntuación.

    private void Awake() // Método que se ejecuta cuando el objeto se inicializa.
    {
        var json = PlayerPrefs.GetString("scores", "{}"); // Obtiene una cadena JSON de PlayerPrefs y la almacena en la variable 'json'.
        scoreData = JsonUtility.FromJson<ScoreData>(json); // Convierte la cadena JSON en un objeto ScoreData y lo asigna a 'scoreData'.
    }

    public IEnumerable<Score> GetHighScores() // Método para obtener las puntuaciones más altas.
    {
        return scoreData.scores.OrderByDescending(keySelector: x => x.score); // Devuelve la lista de puntuaciones ordenada por la puntuación descendente.
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
    public void AddScore(Score score) // Método para agregar una puntuación a la lista de puntuaciones.
    {
        scoreData.scores.Add(score); // Agrega la puntuación 'score' a la lista 'scores' en 'scoreData'.
    }

    public void ClearScores() // Método para borrar todas las puntuaciones.
    {
        scoreData.scores.Clear(); // Borra todos los elementos de la lista 'scores' en 'scoreData'.
    }

    private void OnDestroy() // Método que se ejecuta cuando el objeto se destruye.
    {
        SaveScore(); // Llama al método SaveScore para guardar los datos de puntuación.
    }

    public void SaveScore() // Método para guardar los datos de puntuación.
    {
        var json = JsonUtility.ToJson(scoreData); // Convierte 'scoreData' a una cadena JSON y la almacena en 'json'.
        PlayerPrefs.SetString("scores", json);     // Guarda la cadena JSON en PlayerPrefs bajo la clave "scores".
    }

    internal string GetPlayerNameWithScore(int highestScore)
    {
        throw new NotImplementedException();
    }
}
