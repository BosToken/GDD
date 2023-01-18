using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    KAKI player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("KAKI").GetComponent<KAKI>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position -= new Vector3 (9f*Time.deltaTime, 0, 0);
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x -= player.velocity.x * Time.fixedDeltaTime;
        if (pos.x < -20)
        {
            pos.x = 13;
        }
        transform.position = pos;
    }
}
