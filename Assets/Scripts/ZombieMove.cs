using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour
{
    public GameObject heart;
    private GameObject player;
    public int zombieLife;
    private float distance;
    private int zombieDeathScore=10;
    private GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FPSController");    
        controller = GameObject.Find("Scripts").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < 10f )
        {
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");

        }

    }

    public void OnCollisionEnter(Collision c)
    {
        if(c.collider.gameObject.tag.Equals("bullet"))
        {
            zombieLife--;
            if (zombieLife == 0)
            {
                controller.ScoreAdd(zombieDeathScore);
                Instantiate(heart,transform.position,Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.670f);

            }
        }
    }
}
