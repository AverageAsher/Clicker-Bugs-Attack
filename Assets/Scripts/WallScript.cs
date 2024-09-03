using UnityEngine;

public class WallScript : MonoBehaviour
{
    public Vector2 startingPosition;

    // This method resets the pug's position to the starting point.
    public void ResetPosition()
    {
        transform.position = startingPosition;
    }

    // This method is triggered when the pug collides with another object.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the pug collided with the wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            ResetPosition();
        }
    }
}