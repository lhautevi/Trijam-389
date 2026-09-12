using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private float verticalInput;
    private float horizontalInput;

    public float speed;
    private Bounds bounds;
    public BoxCollider2D penBounds;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        bounds = penBounds.bounds;
}

    // Update is called once per frame
    void Update()
    {
        
        //deplacement
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rigidbody.position += new Vector2(horizontalInput,verticalInput)* speed * Time.deltaTime;

        rigidbody.position = new Vector3(Mathf.Clamp(rigidbody.position.x, bounds.min.x, bounds.max.x), Mathf.Clamp(rigidbody.position.y, bounds.min.y, bounds.max.y));
        

    }
}
