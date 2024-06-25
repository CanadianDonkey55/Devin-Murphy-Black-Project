using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    BoxCollider2D triggerBox;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        triggerBox = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            door.SetActive(true);
        }
    }
}
