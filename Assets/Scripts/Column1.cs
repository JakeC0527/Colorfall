﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column1 : MonoBehaviour {

	public GameObject RedBlock;
	public GameObject GreenBlock;
	public GameObject BlueBlock;
    public GameObject InvisibleBlock;
    public GameObject Instance;
	public int whichColor;

	void Start () {
		InvokeRepeating ("Spawn", Values.spawnTime, Values.spawnTime);
	}

	void Spawn ()
	{
		whichColor = Random.Range (0, 7);
		if (whichColor == 0 || whichColor == 1)
        {
            Instance = Instantiate (RedBlock, new Vector3 (Values.spawn[0], Values.height+1, 0), Quaternion.identity);
            Instance.GetComponent<Block>().SetColor(0);

		}
		else if (whichColor == 2 || whichColor == 3)
        {
			Instance = Instantiate (GreenBlock, new Vector3 (Values.spawn[0], Values.height+1, 0), Quaternion.identity);
            Instance.GetComponent<Block>().SetColor(1);
        }
		else if (whichColor == 4 || whichColor == 5)
        {
			Instance = Instantiate (BlueBlock, new Vector3 (Values.spawn[0], Values.height+1, 0), Quaternion.identity);
            Instance.GetComponent<Block>().SetColor(2);
        }
        else if (whichColor == 6)
        {
            Instance = Instantiate(InvisibleBlock, new Vector3(Values.spawn[0], Values.height+1, 0), Quaternion.identity);
            Instance.GetComponent<Block>().SetColor(3);
        }
	}

}