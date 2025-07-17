using UnityEngine;

public class FocusCameraOnPlayer : MonoBehaviour
{
    public Transform playerPos;
    public float distanceFromPlayer = 10f; // Adjust as needed
    public float rotationSpeed = 90f; // Degrees per second

    void Update()
    {
        if (playerPos == null)
        {
            playerPos = GameObject.FindWithTag("Player").transform; // Using FindWithTag for efficiency
        }
        else
        {
            // Move the camera to maintain the set distance from the player but keep the original height
            Vector3 cameraPosition = playerPos.position - transform.forward * distanceFromPlayer;
            transform.position = new Vector3(cameraPosition.x, transform.position.y, cameraPosition.z);

            // Rotate camera left or right when Q or E is pressed
            if (Input.GetKey(KeyCode.Q))
            {
                transform.RotateAround(playerPos.position, Vector3.up, -rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                transform.RotateAround(playerPos.position, Vector3.up, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
