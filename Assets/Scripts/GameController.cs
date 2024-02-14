using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject zombie;
    private float timeMeter;
    private float zombieSpawnTime=5f;
    public Text scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        timeMeter = zombieSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeMeter -= Time.deltaTime;
        if(timeMeter < 0)
        {
            Vector3 pos = new Vector3 (Random.Range(506f,712f), 25f, Random.Range(413f,679f));
            Instantiate(zombie,pos,Quaternion.identity);
            timeMeter=zombieSpawnTime;

        }
    }

    public void ScoreAdd(int p)
    {
        score += p;
        scoreText.text = " " + score;

    }
}
