using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public int numberOfEnemies;
    public float timeToSpawn;
    public GameObject enemy;
    public GameObject InGameUI;
    private bool readyToSpawn;
    private int enemiesAlive;

    void Start()
    {
        readyToSpawn = true;
        enemiesAlive = numberOfEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        if(readyToSpawn)
        {
            Spawn();
            Invoke("makeReady", timeToSpawn);
        }
    }

    private void Spawn()
    {
        if(numberOfEnemies > 0)
        {
            float x_axis = Random.Range(-3.1f, 3.1f); //hard coded!
            Vector2 position = new Vector2(x_axis, 4.7f);

            GameObject temp = Instantiate(enemy, position, Quaternion.identity);
            temp.GetComponent<enemy1_controller>().setSpawner(gameObject);
            temp.GetComponent<enemy1_controller>().loadDiet(enemy1_controller.Diet.MEAT);

            readyToSpawn = false;
            numberOfEnemies--;
        }

    }

    private void makeReady()
    {
        readyToSpawn = true;
    }

    public void enemyDie()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
            InGameUI.GetComponent<InGameUI_controller>().Win(); //has to be fixed, if GameOver then cannot win
        }
    }
}
