using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets instance;
    public static GameAssets Instance { 
        get
        {
            if (instance == null)
            {
                Resources.Load<GameAssets>("GameAssets");
            }
            return instance;
        }
        private set { } }

    public Transform pfEnemy;
}
