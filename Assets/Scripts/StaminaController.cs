using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public int weight;
    public TMP_Text weightDisplay;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        weightDisplay.text = "Weight: " + weight.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Uncollectable"))
        {
            int point = other.GetComponent<ItemController>().point;
            weight += point;
        }
    }
}
