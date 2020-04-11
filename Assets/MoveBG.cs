using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{   
    public Transform currentTargetVector, start, myTransform;
    public float movementSpeed;
    private bool isLeft = true;


    void FixedUpdate()
    {
        if (isLeft)
        {
            myTransform.position = Vector2.MoveTowards(myTransform.position, currentTargetVector.position, Time.fixedDeltaTime * movementSpeed);
            if (myTransform.position == currentTargetVector.position)
                isLeft = false;
        }
        else if (!isLeft) 
        {
            myTransform.position = Vector2.MoveTowards(myTransform.position, start.position, Time.fixedDeltaTime * movementSpeed);
            if (myTransform.position == start.position)
                isLeft = true;
        }
    }
}
