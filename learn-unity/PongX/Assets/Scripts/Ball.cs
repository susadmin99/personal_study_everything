using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] Vector3 startForce;

    Vector3 lastVelocity;
    Rigidbody rb;

    int forceX;
    int forceY;

    private void Start()
    {
        startForce = new Vector3(Random.Range(10, 20), Random.Range(Random.Range(-10,-3), Random.Range(3, 10)), 0);

        rb = GetComponent<Rigidbody>();
        rb.AddForce(startForce, ForceMode.Impulse);
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "LeftGoal")
        {
            ParticleSystem goalEffect = Instantiate(ResourcesController.Instance.goalExplosion, transform.position, Quaternion.identity);
            goalEffect.Play();
            Destroy(gameObject);
            UIManager.Instance.GoalScored(UIManager.Sides.Right);
        }

        if (collision.collider.tag == "RightGoal")
        {
            ParticleSystem goalEffect = Instantiate(ResourcesController.Instance.goalExplosion, transform.position, Quaternion.identity);
            goalEffect.Play();
            Destroy(gameObject);
            UIManager.Instance.GoalScored(UIManager.Sides.Left);
        }

        if (collision.collider.tag == "Player")
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.GetContact(0).normal);

            rb.velocity = direction * Mathf.Max(speed, 5f);
        }

        if (collision.collider.tag == "Enemy")
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.GetContact(0).normal);

            rb.velocity = (direction * Mathf.Max(speed, 0f)) * 1.05f;
        }
    }
}
