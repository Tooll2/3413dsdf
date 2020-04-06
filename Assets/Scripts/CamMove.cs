using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamMove : MonoBehaviour
{
    public float zoomMin;
    public float zoomMax;

    void FixedUpdate()
    {
            if (Input.mousePosition.x >= Screen.width - 5.3f && transform.position.x < 10.36f)
                transform.Translate(Vector3.right * 7.5f * Time.fixedDeltaTime);
            if (Input.mousePosition.x <= 3f && transform.position.x > -10.68)
                transform.Translate(Vector3.left * 7.5f * Time.fixedDeltaTime);
            if (Input.mousePosition.y >= Screen.height - 2.3f && transform.position.y < 14.29)
                transform.Translate(Vector3.up * 7.5f * Time.fixedDeltaTime);
            if (Input.mousePosition.y <= 3f && transform.position.y > -13.87)
                transform.Translate(Vector3.down * 7.5f * Time.fixedDeltaTime);

        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }


    void Zoom (float inc)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - inc, zoomMin, zoomMax);
    }
}
