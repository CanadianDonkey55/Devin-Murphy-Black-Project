using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnimations : MonoBehaviour
{
    public Animator playerAnimator;

    public float horizontalInput;
    public float verticalInput;
    public float horizontalInputMax;
    public float verticalInputMax;
    public float lastVerticalSpeed;
    public float lastHorizontalSpeed;
    public GameObject player;
    public Sprite defaultDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput > 0)
        {
            horizontalInputMax = 1;
            lastHorizontalSpeed = 1;
            lastVerticalSpeed = 0;
            verticalInputMax = 0;
            defaultDirection = player.GetComponent<PlayerMovement>().right;
            playerAnimator.SetBool("walking", true);
        }
        else if (horizontalInput < 0)
        {
            horizontalInputMax = -1;
            lastHorizontalSpeed = -1;
            lastVerticalSpeed = 0;
            verticalInputMax = 0;
            defaultDirection = player.GetComponent<PlayerMovement>().left;
            playerAnimator.SetBool("walking", true);
        } 
        else if (horizontalInput == 0)
        {
            horizontalInputMax = 0;
        }

        if (verticalInput > 0)
        {
            verticalInputMax = 1;
            lastVerticalSpeed = 1;
            lastHorizontalSpeed = 0;
            horizontalInputMax = 0;
            defaultDirection = player.GetComponent<PlayerMovement>().back;
            playerAnimator.SetBool("walking", true);
        }
        else if (verticalInput < 0)
        {
            verticalInputMax = -1;
            lastVerticalSpeed = -1;
            lastHorizontalSpeed = 0;
            horizontalInputMax = 0;
            defaultDirection = player.GetComponent<PlayerMovement>().front;
            playerAnimator.SetBool("walking", true);
        } 
        else if (verticalInput == 0)
        {
            verticalInputMax = 0;
        }

        if (verticalInput > 0 && horizontalInput > 0)
        {
            verticalInputMax = 1;
            lastVerticalSpeed = 1;
            horizontalInputMax = 1;
            lastHorizontalSpeed = 1;
            defaultDirection = player.GetComponent<PlayerMovement>().backRight;
            playerAnimator.SetBool("walking", true);
        }
        if (verticalInput > 0 && horizontalInput < 0)
        {
            verticalInputMax = 1;
            lastVerticalSpeed = 1;
            horizontalInputMax = -1;
            lastHorizontalSpeed = -1;
            defaultDirection = player.GetComponent<PlayerMovement>().backLeft;
            playerAnimator.SetBool("walking", true);
        }
        if (verticalInput < 0 && horizontalInput > 0)
        {
            verticalInputMax = -1;
            lastVerticalSpeed = -1;
            horizontalInputMax = 1;
            lastHorizontalSpeed = 1;
            defaultDirection = player.GetComponent<PlayerMovement>().frontRight;
            playerAnimator.SetBool("walking", true);
        }
        if (verticalInput < 0 && horizontalInput < 0)
        {
            verticalInputMax = -1;
            lastVerticalSpeed = -1;
            horizontalInputMax = -1;
            lastHorizontalSpeed = -1;
            defaultDirection = player.GetComponent<PlayerMovement>().frontLeft;
            playerAnimator.SetBool("walking", true);
        }

        playerAnimator.SetFloat("horizontalSpeed", horizontalInputMax);
        playerAnimator.SetFloat("verticalSpeed", verticalInputMax);
        playerAnimator.SetFloat("lastVerticalSpeed", lastVerticalSpeed);
        playerAnimator.SetFloat("lastHorizontalSpeed", lastHorizontalSpeed);

        if (verticalInput == 0 && horizontalInput == 0)
        {
            player.GetComponent<SpriteRenderer>().sprite = defaultDirection;
            playerAnimator.SetBool("walking", false);
        }
    } 
}
