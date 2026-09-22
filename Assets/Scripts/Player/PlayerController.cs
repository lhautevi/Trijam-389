using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private float verticalInput;
    private float horizontalInput;

    public float speed;
    private Bounds bounds;
    public BoxCollider2D penBounds;


    public int sheepThreshold;


    private bool isCamouflaged;
    private SpriteRenderer sprite;
    public Color colorCamouflaged;
    public Color colorNormal;

    public GameObject meatPrefab;
    private List<GameObject> sheepsNearby = new List<GameObject>();


    private int currentSheepsNearby;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        bounds = penBounds.bounds;
        sprite = GetComponent<SpriteRenderer>();
  
    }

    // Update is called once per frame
    void Update()
    {
        
        //deplacement
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rigidbody.position += new Vector2(horizontalInput,verticalInput)* speed * Time.deltaTime;

        rigidbody.position = new Vector3(Mathf.Clamp(rigidbody.position.x, bounds.min.x, bounds.max.x), Mathf.Clamp(rigidbody.position.y, bounds.min.y, bounds.max.y));

        
        isCamouflaged = sheepsNearby.Count >= sheepThreshold;
        sprite.color= isCamouflaged? colorCamouflaged : colorNormal;

        if (Input.GetButtonDown("Jump"))
        {
            if (sheepsNearby.Count > 0)
            {
                GameObject victim = FindClosestSheep();
                if (!(GameManager.Instance.SeeingPlayer()))
                {
                    EatSheep(victim);
                }
            }
            
        }
    }

    public GameObject FindClosestSheep()
    {
        GameObject current = null;
        if (sheepsNearby.Count > 0)
        {
            float distanceMin = Mathf.Infinity;
            
            foreach (GameObject sheep in sheepsNearby)
            {
                float distance = Vector3.Distance(sheep.transform.position, transform.position);
                if (distance < distanceMin)
                {
                    distanceMin = distance;
                    current = sheep;
                }
            }
        }
        return current;
    }

    public void EatSheep(GameObject sheep)
    {
        DecrementNearby(sheep);
        Instantiate(meatPrefab, sheep.transform.position, Quaternion.identity);
        Destroy(sheep);
        GameManager.Instance.score ++;
        Debug.Log(GameManager.Instance.score);
    }

    public void IncrementNearby(GameObject sheep)
    {
        sheepsNearby.Add(sheep);
    }

    public void DecrementNearby(GameObject sheep)
    {
        sheepsNearby.Remove(sheep);
    }
}
