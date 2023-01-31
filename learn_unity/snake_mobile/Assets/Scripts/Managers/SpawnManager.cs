using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject speedPrefab;

    public Transform topWall;
    public Transform leftWall;
    public Transform rightWall;
    public Transform bottomWall;


    private void Start()
    {
        InvokeRepeating("SpawnFood", 3, 4);
        InvokeRepeating("SpawnSpeed", 7, 10);
    }

    void SpawnFood()
    {
        if (Snake.instance.isAlive)
        {
            int x = (int)Random.Range(leftWall.position.x, rightWall.position.x);
            int y = (int)Random.Range(topWall.position.y, bottomWall.position.y);

            Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity, this.gameObject.transform);
        }
    }

    void SpawnSpeed()
    {
        if (Snake.instance.isAlive)
        {
            int x = (int)Random.Range(leftWall.position.x, rightWall.position.x);
            int y = (int)Random.Range(topWall.position.y, bottomWall.position.y);

            Instantiate(speedPrefab, new Vector2(x, y), Quaternion.identity, this.gameObject.transform);
        }
    }
}
