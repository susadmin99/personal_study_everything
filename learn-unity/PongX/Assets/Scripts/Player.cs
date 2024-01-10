using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] float moveForce;

    EventTrigger moveUpBtn;
    EventTrigger moveDownBtn;

    Rigidbody rb;
    bool isUpCollide, isDownCollide;

    private void Start()
    {
        moveUpBtn = ResourcesController.Instance.upBtn.GetComponent<EventTrigger>();
        moveDownBtn = ResourcesController.Instance.downBtn.GetComponent<EventTrigger>();

        EventTrigger.Entry upEntryMove = new EventTrigger.Entry();
        upEntryMove.eventID = EventTriggerType.PointerDown;
        upEntryMove.callback.AddListener((data) => { MoveUp((PointerEventData)data); });
        moveUpBtn.triggers.Add(upEntryMove);

        EventTrigger.Entry downEntryMove = new EventTrigger.Entry();
        downEntryMove.eventID = EventTriggerType.PointerDown;
        downEntryMove.callback.AddListener((data) => { MoveDown((PointerEventData)data); });
        moveDownBtn.triggers.Add(downEntryMove);

        EventTrigger.Entry upEntryStop = new EventTrigger.Entry();
        upEntryStop.eventID = EventTriggerType.PointerUp;
        upEntryStop.callback.AddListener((data) => { StopMove((PointerEventData)data); });
        moveUpBtn.triggers.Add(upEntryStop);

        EventTrigger.Entry downEntryStop = new EventTrigger.Entry();
        downEntryStop.eventID = EventTriggerType.PointerUp;
        downEntryStop.callback.AddListener((data) => { StopMove((PointerEventData)data); });
        moveDownBtn.triggers.Add(downEntryStop);

        rb = GetComponent<Rigidbody>();

    }

    void MoveUp(PointerEventData data)
    {
        rb.AddForce(new Vector3(0, moveForce, 0), ForceMode.VelocityChange);
    }

    void MoveDown(PointerEventData data)
    {
        rb.AddForce(new Vector3(0, -moveForce, 0), ForceMode.VelocityChange);
    }

    void StopMove(PointerEventData data)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "TopBarrier")
            isUpCollide = true;

        if (collision.collider.name == "BottomBarrier")
            isDownCollide = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == "TopBarrier")
            isUpCollide = false;

        if (collision.collider.name == "BottomBarrier")
            isDownCollide = false;
    }
}
