using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour {

    public float rotationSpeed = 100;
    public GameObject verticalObject;

    void Update()
    {
        //Get the imput from out horizontal and vertical axises 
        float hor = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
        float ver = Input.GetAxis("Vertical") * Time.deltaTime * rotationSpeed;

        //rotates this object around the horizontal axis
        transform.Rotate(Vector3.up, hor);
        //rotates the vertical object in a vertical axis
        verticalObject.transform.Rotate(Vector3.right, ver);

    }
}
