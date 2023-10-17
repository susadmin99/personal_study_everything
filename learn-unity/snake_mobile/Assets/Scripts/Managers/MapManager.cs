using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Transform topWall;
    public Transform leftWall;
    public Transform rightWall;
    public Transform bottomWall;

    private void Start()
    {
        SetWallSize();
        SetWallPosition();
    }

    void SetWallSize()
    {
        topWall.localScale = new Vector2(ScreenSize.GetScreenToWorldWidth+2, 1);
        leftWall.localScale = new Vector2(1, ScreenSize.GetScreenToWorldHeight-5);
        rightWall.localScale = new Vector2(1, ScreenSize.GetScreenToWorldHeight-5);
        bottomWall.localScale = new Vector2(ScreenSize.GetScreenToWorldWidth+2, 1);
    }

    void SetWallPosition()
    {
        topWall.position = new Vector2(-0.5f,ScreenSize.GetScreenToWorldHeight/2);
        leftWall.position = new Vector2(Mathf.Round(-ScreenSize.GetScreenToWorldWidth / 2 - 1), 2);
        rightWall.position = new Vector2(Mathf.Round(ScreenSize.GetScreenToWorldWidth / 2 - 1), 2);
        bottomWall.position = new Vector2(-0.5f, -ScreenSize.GetScreenToWorldHeight/2+5);
    }
}
