using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMover : MonoBehaviour
{
    private new Transform transform;
    [SerializeField] private Vector3 start;

    void Start()
    {
        transform = GetComponent<Transform>();
        StartCoroutine(ArrowMover1());
    }

    public IEnumerator ArrowMover1()
    {
        for (int i = 0; i <= 1; i++)
        {
            for (int y = 0; y <= 5; y++)
            {
                yield return new WaitForSecondsRealtime(1);
                transform.position += new Vector3(-1, 0, 0);
            }
            if (i == 0)
            transform.position = start;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Destroy(gameObject);
    }
}
