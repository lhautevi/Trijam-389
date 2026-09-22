using UnityEngine;

public class Cone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.PlayerSeen();
            }
        }
    }

    public  void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.PlayerUnseen();
            }
        }
    }
}
