using UnityEngine;

public class Sheperd : MonoBehaviour
{
    public float minWaitTime, maxWaitTime;
    public float rotationSpeed;

    private float timer;
    private float waitTime;
    private float currentAngleDeg;
    private float targetAngleDeg;
 

    private Transform coneVisual;

    private void Awake()
    {
        coneVisual = transform.GetChild(0);
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waitTime) 
        {
            timer = 0;
            waitTime = Random.Range(minWaitTime, maxWaitTime);
            targetAngleDeg = Random.Range(0, 360);
        }

        currentAngleDeg = Mathf.MoveTowardsAngle(currentAngleDeg, targetAngleDeg, rotationSpeed*Time.deltaTime);

        coneVisual.rotation = Quaternion.Euler(0, 0, currentAngleDeg +90 );

    }
}
