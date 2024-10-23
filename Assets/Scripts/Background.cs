using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform canvas;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera cam = Camera.main;
        float height = 4f * cam.orthographicSize;
        float width = (2f * cam.orthographicSize) * cam.aspect;

        transform.position = player.position;
        transform.localScale = new Vector2(width, height);
    }
}
