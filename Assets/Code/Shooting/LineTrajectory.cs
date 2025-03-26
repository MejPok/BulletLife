using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTrajectory : MonoBehaviour 
{
    public LineRenderer lineRenderer; // Reference to the LineRenderer component
    public float lineLength = 10f;    // The length of the trajectory line
    public float speed = 10f;         // Speed of the bullet
    public PlayerGun playerGun;
    bool canRender = false;

    void Update()
    {
        if(!canRender){
            return;
        }
        // Get the direction from the joystick input (assuming a top-down view, Vector2 should be fine)
        Vector2 direction = playerGun.shotPosition;

        // If the direction is not zero, update the line
        if (direction.magnitude > 0.3f)
        {
            DrawTrajectory(direction, playerGun.transform);
        }
        else
        {
            lineRenderer.enabled = false; // Disable line if there's no movement input
        }
    }

    void DrawTrajectory(Vector2 direction, Transform transform)
    {
        // Enable the LineRenderer
        lineRenderer.enabled = true;

        // Set the start position of the line (player's position)
        lineRenderer.SetPosition(0, transform.position);

        // Calculate the end position of the trajectory (bullet travel)
        Vector3 endPosition = (Vector2)transform.position + direction * lineLength;

        // Set the end position of the line
        lineRenderer.SetPosition(1, endPosition);
    }

    public void StartLine(){
        canRender = true;
        lineRenderer.enabled = true;
    }
    public void EndLine(){
        canRender = false;
        lineRenderer.enabled = false;
    }
}
