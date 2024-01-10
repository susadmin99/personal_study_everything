using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    Transform topBarrier;
    Transform bottomBarrier;

    private void Start()
    {
        topBarrier = transform.GetChild(0).GetComponent<Transform>();
        bottomBarrier = transform.GetChild(1).GetComponent<Transform>();

    }

    void CreateMap()
    {
        topBarrier.localScale = new Vector3(Screen.width/100, 1, 1);
        topBarrier.position = new Vector3(0, Screen.height/100, 12);
        topBarrier.gameObject.SetActive(true);
    }
}
