using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    KAKI player;
    Text distanceText;
    private void Awake()
    {
        player = GameObject.Find("Character").GetComponent<KAKI>();
        distanceText = GameObject.Find("UI").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.FloorToInt(player.distance);
        distanceText.text = distance + " : m";
    }
}