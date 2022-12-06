using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NaughtyAttributes;

public class EnemyManager : MonoBehaviour
{

    [ShowNonSerializedField] GameObject Player;
    [SerializeField] float damage = 20f;
    public float health = 100f;
    NavMeshAgent AI;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        AI = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        AI.destination = Player.transform.position;
    }
    public void Hit(float damage)
    {
        health -= damage;
        death();
    }
    void death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<PlayerMovment>().HitPlayer(damage);
        }
    }
}