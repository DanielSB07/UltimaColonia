using UnityEngine;

public class DetectCollisions2D : MonoBehaviour
{
    // valor de puntos que otorga este enemigo al destruirse
    [SerializeField] private int pointValue = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // verifica si el impacto fue provocado por un proyectil
        if (other.CompareTag("Projectile"))
        {
            // suma los puntos al marcador si el juego sigue activo
            if (GameManager.Instance != null && !GameManager.Instance.IsGameOver)
            {
                GameManager.Instance.AddScore(pointValue);
            }

            // destruye el proyectil y este enemigo de la escena
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}