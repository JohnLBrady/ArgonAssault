using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int hitPoints = 5;
    [SerializeField] int score = 50;

    ScoreBoard scoreBoard;
    GameObject spawnAtRuntime;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        spawnAtRuntime = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidBody();
    }

    private void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    private void OnParticleCollision(GameObject other)
    {
        HitEnemy();
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints -= 1;
        if(hitPoints < 1){
            KillEnemy();
            scoreBoard.IncreasScore(score);
        }
    }

    private void HitEnemy(){
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = spawnAtRuntime.transform;
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathFX, transform.position, Quaternion.identity);
        vfx.transform.parent = spawnAtRuntime.transform;
        Destroy(gameObject);
    }
}
