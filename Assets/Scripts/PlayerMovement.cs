using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public float horizontalInput;
    public float verticalInput;

    [Header("Shooting")]
    public float InputMax = 1;
    public GameObject bullet;
    public GameObject Gun;

    [Header("Sprites")]
    private new SpriteRenderer renderer;
    public Sprite back;
    public Sprite front;
    public Sprite left;
    public Sprite right;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rb.MovePosition((Vector2)transform.position + new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime);

        GunCode();
    }

    void GunCode()
    {
        if (horizontalInput > 0)
        {
            InputMax = 1;
            Gun.transform.localRotation = Quaternion.Euler(0, 0, 0);
            bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
            Gun.transform.localScale = new Vector3(Mathf.Abs(Gun.transform.localScale.x), Gun.transform.localScale.y, Gun.transform.localScale.z);
            Gun.GetComponent<SpriteRenderer>().flipY = false;
            renderer.sprite = right;
            Gun.transform.localPosition = new Vector3(0.281f, -0.063f, 0);
            Gun.GetComponent<SpriteRenderer>().sortingOrder = 101;
        }
        else if (horizontalInput < 0)
        {
            InputMax = -1;
            Gun.transform.localRotation = Quaternion.Euler(0, 0, 0);
            bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
            Gun.transform.localScale = new Vector3(-Mathf.Abs(Gun.transform.localScale.x), Gun.transform.localScale.y, Gun.transform.localScale.z);
            Gun.GetComponent<SpriteRenderer>().flipY = false;
            renderer.sprite = left;
            Gun.transform.localPosition = new Vector3(-0.281f, -0.063f, 0);
            Gun.GetComponent<SpriteRenderer>().sortingOrder = 99;
        }

        if (verticalInput > 0)
        {
            InputMax = 1;
            Gun.transform.localRotation = Quaternion.Euler(0, 0, 90);
            bullet.transform.rotation = Quaternion.Euler(0, 0, 90);
            Gun.transform.localScale = new Vector3(Mathf.Abs(Gun.transform.localScale.x), Gun.transform.localScale.y, Gun.transform.localScale.z);
            Gun.GetComponent<SpriteRenderer>().flipY = true;
            renderer.sprite = back;
            Gun.transform.localPosition = new Vector3(0.433f, 0.031f, 0);
            Gun.GetComponent<SpriteRenderer>().sortingOrder = 99;
        }
        else if (verticalInput < 0)
        {
            InputMax = -1;
            Gun.transform.localRotation = Quaternion.Euler(0, 0, -90);
            bullet.transform.rotation = Quaternion.Euler(0, 0, 90);
            Gun.transform.localScale = new Vector3(Mathf.Abs(Gun.transform.localScale.x), Gun.transform.localScale.y, Gun.transform.localScale.z);
            Gun.GetComponent<SpriteRenderer>().flipY = true;
            renderer.sprite = front;
            Gun.transform.localPosition = new Vector3(-0.375f, -0.3f, 0);
            Gun.GetComponent<SpriteRenderer>().sortingOrder = 101;
        }
    }

    
}

