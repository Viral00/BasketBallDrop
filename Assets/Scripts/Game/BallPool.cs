using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    [SerializeField] private GameObject BallPrefab;
    private List<GameObject> poolBall = new List<GameObject>();
    private int amountToPool = 100;

    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject ball = Instantiate(BallPrefab);
            ball.SetActive(false);
            poolBall.Add(ball);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolBall.Count; i++)
        {
            if (!poolBall[i].activeInHierarchy)
            {
                return poolBall[i];
            }
        }
        return null;
    }
}
