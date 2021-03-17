using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class third_person_movement : MonoBehaviour
{

    public CharacterController controller;
    public float Movement_Speed = 10f;
    public Transform Player;
    public Camera mainCamera;
    void start(){
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDirection();
        playerMovement();
    }

    void playerMovement(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, -1f, vertical).normalized;

        if(direction.magnitude >= 0.1f){
            object p = controller.Move(direction * Movement_Speed * Time.deltaTime);
        }
    }

    void playerDirection(){
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y , pointToLook.z));
        }
    }
}
