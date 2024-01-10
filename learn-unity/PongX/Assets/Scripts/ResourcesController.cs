using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesController : MonoBehaviour
{
    public static ResourcesController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        LoadFromResources();
    }

    void LoadFromResources()
    {
        goalExplosion = Resources.Load<ParticleSystem>("GoalEffect");
    }

    [SerializeField] public Transform upBtn;
    [SerializeField] public Transform downBtn;

    [SerializeField] public Transform ball;


    public ParticleSystem goalExplosion;
}
