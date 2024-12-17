using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class Pitfall : MonoBehaviour
{
    public float resetTimer = 1f;
    public Tilemap tilemap;
    public GameObject playerParent;

    // Start is called before the first frame update
    void Start()
    {
        playerParent = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pitfall")
        {
            Debug.Log("hehehehaw");
            playerParent.GetComponent<Animator>().SetBool("falling", true);
            if (!gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }

            PlayerMovement playerMovement = playerParent.GetComponent<PlayerMovement>();
            playerMovement.enabled = false;
            playerParent.GetComponent<PlayerAttack>().enabled = false;

            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                
                
                Vector3 offset = new Vector3(0.5f, 0.5f, 0);
                playerParent.transform.position = tilemap.WorldToCell(hitPosition);
                playerParent.transform.position += offset;
            }

            Debug.Log(tilemap.WorldToCell(hitPosition));

            if (playerParent.GetComponent<PlayerHealth>().resettingScene == true)
            {
                playerParent.transform.position = new Vector2(playerParent.transform.position.x - 1, playerParent.transform.position.y);
                playerParent.GetComponent<Animator>().SetBool("falling", false);
                playerMovement.enabled = true;
                playerParent.GetComponent<PlayerAttack>().enabled = true;
                hitPosition = Vector3.zero;
                playerParent.GetComponent<PlayerHealth>().resettingScene = false;
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //Debug.Log(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
