using UnityEngine;

public class BugMovement : MonoBehaviour
{
    public float speed = 500f; // Increase speed to 5f
    private Transform target;
    private Vector3 startingPosition;

    void Start()
    {
        target = GameObject.Find("Dollars").transform; // Replace with the name of your button GameObject
        startingPosition = transform.position; // Save the starting position
    }

    void Update()
    {
        if (target != null)
        {
            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // Check if the bug has reached the target
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                // Move the bug back to its starting position
                transform.position = startingPosition;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Dollars") // Replace with your button's name
        {
            UpdateMoney updateMoney = FindObjectOfType<UpdateMoney>();
            updateMoney.DeductMoney(15);

            // Move the bug back to its starting position
            transform.position = startingPosition;
        }
        else if (collision.gameObject.name == "Wall") // Replace with your wall's name
        {
            // Move the bug back to its starting position
            ResetPosition();
        }
    }

    // Public method to reset the bug's position when clicked
    public void ResetPosition()
    {
        transform.position = startingPosition;
    }

    private void OnMouseDown()
    {
        // Call ResetPosition() when the bug is clicked
        ResetPosition();
    }
}
