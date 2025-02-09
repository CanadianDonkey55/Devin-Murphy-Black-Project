using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    [Header("Walking")]
    private Rigidbody2D rb;
    public float speed = 5f;
    public float horizontalInput;
    public float verticalInput;
    public Animator playerAnimations;
    public AnimatorControllerParameter[] parameters;
    public AudioClip[] footsteps;
    public float footstepSoundCooldown = 0.2f;


    [Header("Shooting")]
    public float InputMax = 1;
    public GameObject bullet;
    public GameObject Gun;

    [Header("Sprites")]
    private new SpriteRenderer renderer;
    public SpriteRenderer gunRenderer;
    public Sprite back;
    public Sprite front;
    public Sprite left;
    public Sprite right;
    public Sprite backRight;
    public Sprite backLeft;
    public Sprite frontRight;
    public Sprite frontLeft;
    public Sprite gunNormal;
    public Sprite gunAbove;

    [Header("Input Delay")]
    public float diagonalDelay = 0.2f; // Delay in seconds
    private float diagonalTimer = 0f;
    private float lastHorizontalInput = 0f;
    private float lastVerticalInput = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        cooldown = footstepSoundCooldown;
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

        PlayWalkSound();

        GunCode();
    }

    void GunCode()
    {
        if (Mathf.Abs(horizontalInput) > 0 && Mathf.Abs(verticalInput) > 0)
        {
            lastHorizontalInput = horizontalInput;
            lastVerticalInput = verticalInput;
            diagonalTimer = diagonalDelay;
        }
        else if (Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0)
        {
            // Reset diagonal if enough time has passed since one input was released
            if (diagonalTimer > 0)
            {
                diagonalTimer -= Time.deltaTime;
                horizontalInput = lastHorizontalInput;
                verticalInput = lastVerticalInput;
            }
            else
            {
                // Update last valid input for single directions
                if (Mathf.Abs(horizontalInput) > 0) lastHorizontalInput = horizontalInput;
                if (Mathf.Abs(verticalInput) > 0) lastVerticalInput = verticalInput;
            }
        }

        if (horizontalInput > 0)
        {
            InputMax = 1;
            gunRenderer.sprite = gunNormal;
            Directional(right, new Vector3(0, 0, 0), new Vector3(0, 0, 0), false, new Vector3(0.281f, -0.063f, 0));           
            Gun.transform.localScale = new Vector3(Mathf.Abs(Gun.transform.localScale.x), Gun.transform.localScale.y, Gun.transform.localScale.z);
            Gun.GetComponent<SpriteRenderer>().sortingOrder = 101;           
        }
        else if (horizontalInput < 0)
        {
            InputMax = -1;
            gunRenderer.sprite = gunNormal;
            Directional(left, new Vector3(0, 0, 0), new Vector3(0, 0, 0), false, new Vector3(-0.281f, -0.063f, 0));
            Gun.transform.localScale = new Vector3(-Mathf.Abs(Gun.transform.localScale.x), Gun.transform.localScale.y, Gun.transform.localScale.z);
            Gun.GetComponent<SpriteRenderer>().sortingOrder = 99; 
        }

        if (verticalInput > 0)
        {
            InputMax = 1;
            gunRenderer.sprite = gunAbove;
            Directional(back, new Vector3(0, 0, 180), new Vector3(0, 0, 90), true, new Vector3(0.433f, 0.031f, 0));
            Gun.transform.localScale = new Vector3(Mathf.Abs(Gun.transform.localScale.x), Gun.transform.localScale.y, Gun.transform.localScale.z);
            Gun.GetComponent<SpriteRenderer>().sortingOrder = 99;
            
        }
        else if (verticalInput < 0)
        {
            InputMax = -1;
            gunRenderer.sprite = gunAbove;
            Directional(front, new Vector3(0, 0, 0), new Vector3(0, 0, 90), true, new Vector3(-0.375f, -0.3f, 0));
            Gun.transform.localScale = new Vector3(Mathf.Abs(Gun.transform.localScale.x), Gun.transform.localScale.y, Gun.transform.localScale.z);
            Gun.GetComponent<SpriteRenderer>().sortingOrder = 101;         
        }

        if (horizontalInput > 0 && verticalInput > 0)
        {
            gunRenderer.sprite = gunNormal;
            Directional(backRight, new Vector3(0, 0, 45), new Vector3(0, 0, 45), false, new Vector3(0.315f, -0.05f, 0));
            Gun.GetComponent<SpriteRenderer>().sortingOrder = 101;
        }
        if (horizontalInput < 0 && verticalInput > 0)
        {
            gunRenderer.sprite = gunNormal;
            Directional(backLeft, new Vector3(0, 0, 135), new Vector3(0, 0, 135), true, new Vector3(0.289f, 0.006f, 0));
            Gun.GetComponent<SpriteRenderer>().sortingOrder = 99;
        }
        if (horizontalInput > 0 && verticalInput < 0)
        {
            gunRenderer.sprite = gunNormal;
            Directional(frontRight, new Vector3(0, 0, -45), new Vector3(0, 0, 135), false, new Vector3(0.06f, -0.171f, 0));
            Gun.GetComponent<SpriteRenderer>().sortingOrder = 101;
        }
        if (horizontalInput < 0 && verticalInput < 0)
        {
            gunRenderer.sprite = gunNormal;
            Directional(frontLeft, new Vector3(0, 0, -135), new Vector3(0, 0, 45), true, new Vector3(-0.412f, -0.191f, 0));
            Gun.GetComponent<SpriteRenderer>().sortingOrder = 99;
        }
    }

    float cooldown;

    void PlayWalkSound()
    {
        AudioClip whichFootstep = footsteps[Random.Range(0, footsteps.Length)];

        if ((horizontalInput != 0 || verticalInput != 0) && cooldown <= 0)
        {
            AudioSource.PlayClipAtPoint(whichFootstep, transform.position, 1);
            cooldown = footstepSoundCooldown;
        }

        cooldown -= Time.deltaTime;
    }

    void Directional(Sprite characterSprite, Vector3 gunRot, Vector3 bulletRot, bool gunYFlip, Vector3 gunPos)
    {
        Gun.transform.localRotation = Quaternion.Euler(gunRot);
        bullet.transform.rotation = Quaternion.Euler(bulletRot);
        Gun.GetComponent<SpriteRenderer>().flipY = gunYFlip;
        renderer.sprite = characterSprite;
        Gun.transform.localPosition = gunPos;
    }   
}