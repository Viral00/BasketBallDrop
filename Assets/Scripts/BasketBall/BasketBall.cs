using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBall : MonoBehaviour
{
    private int FallSpeed;
    public event Action BallScore;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground") 
        {
            BallScore?.Invoke();
        }
    }
}
