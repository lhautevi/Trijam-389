using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform camera;
    public Transform player;
    public float offset = -10f;
    private bool playerSeen = false;
    public int score = 0;

    public void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        camera.position = player.position + new Vector3(0f, 0f, offset);
    }

    public void PlayerSeen()
    {
        playerSeen = true;

    }
    public void PlayerUnseen()
    {
        playerSeen = false;
    }

    public bool SeeingPlayer()
    {
        return playerSeen;
    }
}
