using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject foodPrefab;

    public Transform topWall;
    public Transform leftWall;
    public Transform rightWall;
    public Transform bottomWall;


    private void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
    }

    void Spawn()
    {
        if (Snake.instance.isAlive)
        {
            int x = (int)Random.Range(leftWall.position.x, rightWall.position.x);
            int y = (int)Random.Range(topWall.position.y, bottomWall.position.y);

            Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity, this.gameObject.transform);
        }
    }
}
