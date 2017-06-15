﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTile : MonoBehaviour
{

    public static bool moving = false;
    public static bool notColliding = true;

    // Use this for initialization
    void Start ()
    {
        transform.position = new Vector3 (Values.spawn[1], 0, 0);
        transform.localScale = new Vector2 (Values.width / 3, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collided)
    {
        notColliding = false;
        if (collided.gameObject.GetComponent<Block>().GetColor() == 1)
        {
            Values.addOne();
            Debug.Log(Values.score);
        }
        else if (collided.gameObject.GetComponent<Block>().GetColor() != 3)
        {
            //Time.timeScale = 0;
        }
    }

    void OnTriggerExit2D(Collider2D collided)
    {
        notColliding = true;
    }

    public bool Colliding()
    {
        return notColliding;
    }

    public void externalSwap(float time, Vector3 targetPosition)
    {
        StartCoroutine(Swap(time, targetPosition));
    }

    IEnumerator Swap(float time, Vector3 targetPosition)
    {
        moving = true;
        float i = 0;
        while (i < 1)
        {
            i += Time.deltaTime / time;
            transform.position = Vector3.Lerp(transform.position, targetPosition, i);
            targetPosition.y -= Time.deltaTime * Values.fallingSpeed;
            //test2.position = Vector3.Lerp(test2.position, tempPos1, i);
            yield return 0;
        }
        moving = false;
    }
}
