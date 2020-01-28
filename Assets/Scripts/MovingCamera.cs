using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;


    public void exit()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(-pos.x * dragSpeed, -pos.y * dragSpeed);

        transform.Translate(move, Space.World);

        //Debug.Log(Input.mouseScrollDelta);
        if(Input.GetAxis("Mouse ScrollWheel")> 0.0f)
        {
            transform.Translate(Vector3.forward);
        }else if(Input.GetAxis("Mouse ScrollWheel") < 0.0f)
        {
            transform.Translate(Vector3.back);
        }
    }

}
