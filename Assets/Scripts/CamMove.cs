using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamMove : MonoBehaviour
{
    public float zoomMin, zoomMax, right, left, up, down;
 

    void FixedUpdate()
    {
            if (Input.mousePosition.x >= Screen.width - 5.3f && transform.position.x < right)
                transform.Translate(Vector3.right * 7.5f * Time.fixedDeltaTime);
            if (Input.mousePosition.x <= 3f && transform.position.x > left)
                transform.Translate(Vector3.left * 7.5f * Time.fixedDeltaTime);
            if (Input.mousePosition.y >= Screen.height - 2.3f && transform.position.y < up)
                transform.Translate(Vector3.up * 7.5f * Time.fixedDeltaTime);
            if (Input.mousePosition.y <= 3f && transform.position.y > down)
                transform.Translate(Vector3.down * 7.5f * Time.fixedDeltaTime);

        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - Input.GetAxis("Mouse ScrollWheel"), zoomMin, zoomMax);
    }

}
