using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    [SerializeField] private BallPool ballPool;
    [SerializeField] private TMP_InputField numberInput;
    [SerializeField] private TextMeshProUGUI wrongInputText;
    [SerializeField] private TextMeshProUGUI Canvas;
    private int num;
    private Vector3 point = Vector3.one;
    private float radius;
    private string message = "Please enter the number correctly";

    public void Update()
    {
        if (numberInput.text != "")
        {
            num = int.Parse(numberInput.text);
            radius = num;
        }    
    }

    public void SpawnBalls() 
    {
        /*if(numberInput.text != "")
        {
            wrongInputText.text = message;
            Debug.Log(message);
        }
        else 
        {*/
            CreateEnemiesAroundPoint(num, point, radius);
        //}
    }

    public void CreateEnemiesAroundPoint(int num, Vector3 point, float radius)
    {
        Debug.Log($"num:{num} point:{point} radius:{radius}");
        for (int i = 0; i < num; i++)
        {
            var radians = 2 * Mathf.PI / num * i;
            var vertical = Mathf.Sin(radians);
            var horizontal = Mathf.Cos(radians);
            var spawnDir = new Vector3(horizontal, 0, vertical);
            var spawnPos = point + spawnDir * radius;
            var Ball = ballPool.GetPooledObject(); //Instantiate(BallPrefab, spawnPos, Quaternion.identity) as GameObject;
            Ball.transform.position = spawnPos;
            Ball.transform.rotation = Quaternion.identity;
            Ball.transform.LookAt(point);
            Ball.transform.Translate(new Vector3(0, Ball.transform.localScale.y / 2, 0));
            Ball.gameObject.SetActive(true);
        }
    }
}
