using UnityEngine;

public class DestroyOutOfBounds2D : MonoBehaviour
{
    // limites de pantalla
    [SerializeField] private float lowerBound = -10.0f;
    [SerializeField] private float upperBound = 20.0f;

    // activador de resta de vidas
    [SerializeField] private bool reportGameOver = false;

    private void Update()
    {
        // si el objeto cae por debajo de la pantalla
        if (transform.position.y < lowerBound)
        {
            // resta 1 vida si es enemigo y la partida sigue activa
            if (reportGameOver && GameManager.Instance != null && !GameManager.Instance.IsGameOver)
            {
                GameManager.Instance.LoseLife();
            }
            Destroy(gameObject);
        }
        // si el objeto sube por encima de la pantalla
        else if (transform.position.y > upperBound)
        {
            Destroy(gameObject);
        }
    }
}