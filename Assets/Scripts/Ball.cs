using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float force;

    private bool firstTouch;
    public Camera cam;
    public Game game;
    public Rigidbody2D rb;
    public CircleCollider2D coll2D;
    public Transform imageTransform;

    public GameObject firstMessage;

    private float radius = 1.2f;
    private float x, y;
    private float rotationSpeed = 0.0f;

    private IEnumerator ResetCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        SetBallSize();
        radius *= radius;
        firstTouch = true;
    }

    private void Update()
    {
        imageTransform.Rotate(Vector3.back * rotationSpeed);
    }

    public void SetBallSize()
    {
        float aspect = cam.aspect;
        if (aspect < 0.56f)
            transform.localScale *= 1.15f * aspect + 0.356f;
    }

    private void OnMouseDown()
    {
        if (firstTouch)
        {
            firstTouch = false;
            firstMessage.SetActive(false);
        }

        game.AddScore();
        x = transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        y = Mathf.Sqrt(radius - x * x);
        rotationSpeed = x * 4;
        rb.AddForce(new Vector2(x, y / 2).normalized * force, ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Ground"))
        {
            game.Reset();
        }
    }
}
