using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SAP2D;

public class WPManager : MonoBehaviour
{
	public Transform[] Waypoints;

	public float pointDistance;

	private int wpIndex = 0;
	private bool wp1 = false;
	private Transform transform;
	private SAP2DAgent agent;

	private void Start()
	{
		transform = GetComponent<Transform>();
		agent = GetComponent<SAP2DAgent>();

		agent.Target = Waypoints[wpIndex];
	}

	void FixedUpdate()
	{
		if (wp1 == false)
		{
			if (Vector2.Distance(transform.position, Waypoints[wpIndex].position) < pointDistance)
			{
				wp1 = true;
				wpIndex++;
				agent.Target = Waypoints[wpIndex];
			}
		}
		if (wpIndex == 1)
		{
			if (Vector2.Distance(transform.position, Waypoints[wpIndex].position) < pointDistance)
			{
				wpIndex++;
				agent.Target = Waypoints[wpIndex];
			}

		}
		
	}

}
