using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyPatrol : MonoBehaviour
{
    private Creature creature;
    public Transform[] patrolPoints;

    private int currentPatrolIndex = 0;

    private void Start()
    {
        creature = GetComponent<Creature>();
    }

    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0)
            return;
        Vector2 patrolDirection = (patrolPoints[currentPatrolIndex].position - transform.position).normalized;
        Move(patrolDirection);

        if (Vector2.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }

        if (creature.RB.velocity.x < 0)
        {
            creature.SpriteRenderer.flipX = false;
        }
        else if (creature.RB.velocity.x > 0)
        {
            creature.SpriteRenderer.flipX = true;
        }
    }

    public void Move(Vector2 direction)
    {
        if (!creature.IsDead)
        {
            creature.RB.velocity = new Vector2(direction.x * creature.MoveSpeed, creature.RB.velocity.y);
            creature.Anime.SetFloat("Speed", Mathf.Abs(creature.RB.velocity.x));
        }
        

    }
}

