using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotationAnimator : MonoBehaviour
{
 
    public Transform camPos;
    public Transform mouseSpherePos;
    public Transform weapon;
    public float angle;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Assumes there's a collider on the ground or object you want to hit.
            Vector3 mousePos = hit.point;
            mouseSpherePos.position = mousePos; // Show hit position
            Vector3 direction = (mousePos - transform.position).normalized;
            //weapon.forward = new Vector3(-direction.x,0,-direction.z);
           


            // Adjust direction by camera's rotation to make it relative to camera's view
            Vector3 cameraRelativeDirection = camPos.InverseTransformDirection(direction);
            angle = Mathf.Atan2(cameraRelativeDirection.x, cameraRelativeDirection.z) * Mathf.Rad2Deg;

            
        }
        FaceCamera();
        
    }

    public int GetSector(float angle)
    {
       
        // Ensure angle is within 0-360 range
        angle = ((angle + 360+225) - 45 ) % 360;

        // Calculate sprite index based on angle; assumes sprites are ordered 0, 45, 90, ..., 315 degrees
        int index = Mathf.RoundToInt((angle / 90)) % 4;
        return index;
    }
    void FaceCamera()
    {
        Vector3 directionToCamera = camPos.position - transform.position;
        directionToCamera.y = 0; // Ignore the y-axis to prevent tilting
        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // Smooth rotation towards the camera
    }
}
