using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform cam = Camera.main.transform;
        Vector3 camPos = new Vector3(cam.position.x, cam.position.y, cam.position.z)-cam.transform.forward * 20;

        transform.LookAt(camPos);
    }
}
