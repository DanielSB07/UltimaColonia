using System.Collections;
using UnityEngine;

public class SpawnManager2D : MonoBehaviour
{
    [Header("Configuracion de Enemigos")]
    // lista de prefabs de enemigos a generar
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Posicion de Aparicion (Spawn)")]
    // limites y coordenadas para la aparicion
    [SerializeField] private float spawnRangeX = 6.0f;
    [SerializeField] private float spawnPosY = 8.0f;
    [SerializeField] private float spawnPosZ = 0.0f;

    [Header("Dificultad Progresiva")]
    // tiempos para controlar la aceleracion del juego
    [SerializeField] private float spawnInterval = 3.0f;
    [SerializeField] private float minSpawnInterval = 1.0f;
    [SerializeField] private float difficultyRate = 0.05f;

    private void Start()
    {
        // inicia el ciclo de aparicion al empezar
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        // espera inicial antes de la primera oleada
        yield return new WaitForSeconds(2f);

        while (true)
        {
            // detiene la generacion si el juego termino
            if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
            {
                yield break;
            }

            // genera un enemigo aleatorio
            SpawnRandomEnemy();

            // espera el tiempo actual del intervalo
            yield return new WaitForSeconds(spawnInterval);

            // reduce el tiempo de espera para aumentar la dificultad
            if (spawnInterval > minSpawnInterval)
            {
                spawnInterval -= difficultyRate;
            }
        }
    }
    private void SpawnRandomEnemy()
    {
        // valida que existan prefabs configurados
        if (enemyPrefabs == null || enemyPrefabs.Length == 0) return;

        // elige un enemigo al azar del arreglo
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        if (enemyPrefabs[enemyIndex] != null)
        {
            // calcula la posicion con x aleatorio y coordenadas fijas en y, z
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

            // instancia el enemigo seleccionado en la escena
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
}