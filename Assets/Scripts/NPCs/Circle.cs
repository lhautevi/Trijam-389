using UnityEngine;

public class Circle : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sheep"))
            player.IncrementNearby(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sheep"))
            player.DecrementNearby(collision.gameObject);
    }
}
