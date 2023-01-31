using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public static Snake instance { get; set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    Vector2 dir = Vector2.right;

    List<Transform> tail = new List<Transform>();

    public bool ate = false;
    public bool isAlive = true;

    public GameObject tailPrefab;
    public GameObject gameOverCanvas;

    private void Start()
    {
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right;
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
        if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;
    }

    void Move()
    {
        if (isAlive)
        {
            Vector2 v = transform.position;

            transform.Translate(dir);
            if (ate)
            {
                GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);

                tail.Insert(0, g.transform);

                ate = false;
            }
            else if (tail.Count > 0)
            {
                tail.Last().position = v;

                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Food"))
        {
            ate = true;
            Destroy(collision.gameObject);
        }
        else if (collision.name.StartsWith("SnakeHead") || collision.name.StartsWith("Tail") || collision.name.Contains("Wall"))
        {
            isAlive = false;
            gameOverCanvas.SetActive(true);
        }
    }
}
