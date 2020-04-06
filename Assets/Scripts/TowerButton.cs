using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
	public GameObject towerObj;
	public Sprite dragSprite;

	public GameObject TowerObject
	{
		   get
		{
			return towerObj;
		}
	}

	public Sprite DragSprite
	{
		get
		{
			return dragSprite;
		}
	}


}
