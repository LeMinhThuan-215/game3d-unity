using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 10f;
    public float desiredHeight = 5f;
    public float rotationSpeed = 2f;

    void Update()
    {
        // terrain height
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit))
        {
            float terrainHeight = hit.point.y;
            transform.position = new Vector3(transform.position.x, terrainHeight + desiredHeight, transform.position.z);
        }

        // move
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float movementSpeed = Input.GetKey(KeyCode.LeftShift) ? (speed*2) : speed;

        Vector3 movement = new Vector3(horizontal, 0, vertical) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        //mouse rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * rotationSpeed, Space.World);
        transform.Rotate(Vector3.left, mouseY * rotationSpeed, Space.Self);
        
    }
}