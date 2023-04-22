using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody enemyRb;
    public GameObject playerGoal;
    int waveCount = SpawnManagerX.waveCount;

    public int markEnemy = 0;
    public int markPlayer = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * waveCount);
    }

    private void OnCollisionEnter(Collision other) // can doc lai logic cua ham nay
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
            markPlayer++;
            Debug.Log("Mark Player: " + markPlayer.ToString());
        }
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
            markEnemy++;
            Debug.Log("Mark Enemy: " + markEnemy.ToString()); // tai sao luon in ra 1
        }
    }
}
