
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PatrolMRUV : MonoBehaviour
{

    [SerializeField] private int aceleration;
    [SerializeField] private TMP_Text textVelocity;
    [SerializeField] private Point[] arrayPoints;
    [SerializeField] private float delay = 1f;
    Rigidbody rb;
    private float velocity = 0f;
    private int currentPoint = 0;
    private Vector3 direction;
    private float currentTime = 0f;
    bool isMoving = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        SetText(0);
       transform.position  = arrayPoints[currentPoint].Position;
        currentPoint++;

    }
    private void FixedUpdate()
    {   
        if (isMoving)
        {
            currentTime += Time.fixedDeltaTime;
            velocity = aceleration * currentTime;
            SetText(velocity);
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
        currentPoint =(currentPoint + 1)% arrayPoints.Length;
        currentTime = 0;
        velocity = 0f;
        isMoving = true;
    }

 

    private void SetText(float velocity)
    {
        textVelocity.text = "Velocidad: " + (int)velocity;
    }
}
