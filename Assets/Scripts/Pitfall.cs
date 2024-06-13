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
            gameObject.GetComponentInParent<Animator>().SetBool("falling", true);
            PlayerMovement playerMovement = gameObject.GetComponentInParent<PlayerMovement>();
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
