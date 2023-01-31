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

    public List<Transform> tail = new List<Transform>();

    public float speed = 0.4f;
    float speedUpgrade = 0.02f;

    public bool ate = false;
    public bool isAlive = true;

    public GameObject tailPrefab;
    public GameObject gameOverCanvas;

    public ParticleSystem foodPickUpParticle;

    private void Start()
    {
        //InvokeRepeating("Move", 0.3f, 0.4f);
        Time.fixedDeltaTime = speed;
    }

    private void Update()
    {
        Time.fixedDeltaTime = speed;

        //Movement input
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            InputKeyboard();
        else if (Application.platform == RuntimePlatform.Android)
            SwipeDetector.OnSwipe += Swipe;
    }

    private void FixedUpdate()
    {
        Move();
    }

    void InputKeyboard()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right;
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;
    }

    void Swipe(SwipeData data)
    {
        switch (data.Direction)
        {
            case SwipeDirection.Up:
                dir = Vector2.up;
                break;

            case SwipeDirection.Down:
                dir = -Vector2.up;
                break;

            case SwipeDirection.Left:
                dir = -Vector2.right;
                break;

            case SwipeDirection.Right:
                dir = Vector2.right;
                break;
            default:
                break;
        }
    }

    void Move()
    {
        if (isAlive)
        {
            Vector2 v = transform.position;

            transform.Translate(dir);
            if (ate)
            {
                foodPickUpParticle.transform.position = transform.position;
                foodPickUpParticle.Play();

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
        SceneManager.LoadScene("Game01");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            ate = true;
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Speed")
        {
            speed -= speedUpgrade;
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Snake")
        {
            isAlive = false;
            gameOverCanvas.SetActive(true);
        }

        switch (collision.tag)
        {
            case "Food":
                ate = true;
                Destroy(collision.gameObject);
                break;

            case "Speed":
                if (speed >= 0.02)
                {
                    speed -= speedUpgrade;
                    Destroy(collision.gameObject);
                }
                break;

            case "Snake":
                ScoreManager.instance.SaveScore();
                isAlive = false;
                gameOverCanvas.SetActive(true);
                break;

            case "Wall":
                ScoreManager.instance.SaveScore();
                isAlive = false;
                gameOverCanvas.SetActive(true);
                break;

            default:
                break;
        }
    }
}
