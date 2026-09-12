using UnityEngine;
using UnityEngine.UIElements;

public class Sheepwander : MonoBehaviour
{
    Vector2 direction;
    private float timer = 0;
    private float waitTime;
    private bool isMoving = false;
    private Bounds bounds;
    public BoxCollider2D penBounds;

    public float speed;
    private void Awake()
    {
        bounds =penBounds.bounds;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime) 
        {
            timer = 0;
            isMoving = !isMoving;
            
            if (isMoving)
            {
                direction = Random.insideUnitCircle;
                direction.Normalize();
                waitTime = Random.Range(0.5f, 1.5f);
            } else
            {
                waitTime = Random.Range(3f, 5f);
            }
        }
        if (isMoving)
        {
            transform.position += (Vector3)direction * speed * Time.deltaTime;
            transform.position = new Vector3 (Mathf.Clamp(transform.position.x, bounds.min.x, bounds.max.x), Mathf.Clamp(transform.position.y, bounds.min.y, bounds.max.y));
            
        }

    }
}
