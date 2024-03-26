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
    public GameObject player;
    public Sprite defaultDirection;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput > 0)
        {
            horizontalInputMax = 1;
            verticalInputMax = 0;
            defaultDirection = player.GetComponent<PlayerMovement>().right;
        }
        else if (horizontalInput < 0)
        {
            horizontalInputMax = -1;
            verticalInputMax = 0;
            defaultDirection = player.GetComponent<PlayerMovement>().left;
        } 
        else if (horizontalInput == 0)
        {
            horizontalInputMax = 0;
        }

        if (verticalInput > 0)
        {
            verticalInputMax = 1;
            horizontalInputMax = 0;
            defaultDirection = player.GetComponent<PlayerMovement>().back;
        }
        else if (verticalInput < 0)
        {
            verticalInputMax = -1;
            horizontalInputMax = 0;
            defaultDirection = player.GetComponent<PlayerMovement>().front;
        } 
        else if (verticalInput == 0)
        {
            verticalInputMax = 0;
        }

        playerAnimator.SetFloat("horizontalSpeed", horizontalInputMax);
        playerAnimator.SetFloat("verticalSpeed", verticalInputMax);

        if (verticalInput == 0 && horizontalInput == 0)
        {
            player.GetComponent<SpriteRenderer>().sprite = defaultDirection;
        }

        


        /*  if (verticalInput < 0 && horizontalInput == 0)
          {
              FacingDirection("Front", true);
          } 
          else
          {
              foreach (AnimatorControllerParameter parameter in playerAnimator.parameters)
              {
                  playerAnimator.SetBool(parameter.name, false);
              }
          }

          if (verticalInput > 0 && horizontalInput == 0)
          {
              FacingDirection("Back", true);
          }
          else
          {
              foreach (AnimatorControllerParameter parameter in playerAnimator.parameters)
              {
                  playerAnimator.SetBool(parameter.name, false);
              }
          }

          if (verticalInput == 0 && horizontalInput > 0)
          {
              FacingDirection("Right", true);
          }
          else
          {
              foreach (AnimatorControllerParameter parameter in playerAnimator.parameters)
              {
                  playerAnimator.SetBool(parameter.name, false);
              }
          }

          if (verticalInput == 0 && horizontalInput < 0)
          {
              FacingDirection("Left", true);
          }
          else
          {
              foreach (AnimatorControllerParameter parameter in playerAnimator.parameters)
              {
                  playerAnimator.SetBool(parameter.name, false);
              }
          }*/
    } 

   // void FacingDirection(string dir, bool ft)
    //{
   //     playerAnimator.SetBool("isWalking" + dir, ft);
   // }
}
