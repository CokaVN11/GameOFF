using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] items;

    private float _timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime;

    public GameObject player;

    private List<GameObject> spawned = new();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        if (_timeBtwSpawn <= 0)
        {
            var rand = Random.Range(0, items.Length);
            var rand_x = Random.Range(-5, 5);
            spawned.Add(Instantiate(items[rand], new Vector3(rand_x, position.y, position.z), Quaternion.identity));

            _timeBtwSpawn = startTimeBtwSpawn;
            //if (startTimeBtwSpawn > minTime) startTimeBtwSpawn -= decreaseTime;
            //else startTimeBtwSpawn = minTime;
            startTimeBtwSpawn = (startTimeBtwSpawn > minTime) ? startTimeBtwSpawn - decreaseTime : minTime;
        }
        else _timeBtwSpawn -= Time.deltaTime;

        spawned.RemoveAll(item => item == null);

        foreach (GameObject item in spawned)
        {
            Animator item_anim = item.GetComponent<Animator>();
            item_anim.SetBool("takeOff", player.GetComponent<PlayerController>().takeOff);
        }
    }

    
}
