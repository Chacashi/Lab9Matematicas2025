using System.Collections;
using TMPro;
using UnityEngine;

public class PatrolMRU : MonoBehaviour
{

    [SerializeField] private TMP_Text textVelocity;
    [SerializeField] private Point[] arrayPoints;
    [SerializeField] private float delay = 1f;
    Rigidbody rb;
    private float velocity = 0f;
    private int currentPoint = 0;
    private Vector3 direction;
    bool isMoving = true;
    float distance = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        transform.position = arrayPoints[currentPoint].Position;
        currentPoint++;
        SetParameters();

    }
    private void FixedUpdate()
    {
        if (isMoving)
        {
            
           
            direction = (arrayPoints[currentPoint].Position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * velocity * Time.fixedDeltaTime);

            if (Vector3.Distance(rb.position, arrayPoints[currentPoint].Position) < 0.5f)
            {
                StartCoroutine(ChanguePoint());
            }
        }
    }

    IEnumerator ChanguePoint()
    {
        isMoving = false;
        yield return new WaitForSeconds(delay);
        currentPoint = (currentPoint + 1) % arrayPoints.Length;
        SetParameters();
        isMoving = true;
        
    }

    void SetParameters()
    {
        distance = Vector3.Distance(arrayPoints[currentPoint].Position, transform.position);
        velocity = distance / arrayPoints[currentPoint].TimeForArrive;
        SetText(velocity);
    }


    private void SetText(float velocity)
    {
        textVelocity.text = "Velocidad: " + (int)velocity;
    }
}
