using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBehaviour : MonoBehaviour
{
    [SerializeField]
    float runDistance = 2f;
    [SerializeField]
    float speed = 0.1f;

    Animator animator;
    float idleTimer;
    float nextMoveTimer;
    Vector3 destination;
    Vector3 originalPos;
    bool firstMove = true;

    void Start()
    {
        SetIdleTimer();
        SetNextMoveTimer();
        animator = GetComponent<Animator>();
        originalPos = transform.position;
    }

    void Update()
    {
        if (animator.GetBool("Turn Head") || animator.GetBool("Eat"))
        {

        }
        else if (animator.GetBool("Run"))
        {

            transform.position = Vector3.MoveTowards(transform.position, destination, speed);
            if (transform.position == destination)
            {
                animator.SetBool("Run", false);
                SetNextMoveTimer();
            }
        }
        else
        {
            idleTimer -= Time.deltaTime;
            nextMoveTimer -= Time.deltaTime;
            if (nextMoveTimer <= 0)
            {
                animator.SetBool("Run", true);
                Quaternion rotation = Quaternion.Euler(0, Random.Range(-90, 90), 0);
                if (firstMove)
                {
                    destination = transform.position +  rotation * (runDistance * 0.5f * Vector3.forward);
                    firstMove = false;
                }
                else
                {
                    Vector3 directionToOrigin = (originalPos - transform.position).normalized;
                    destination = transform.position + rotation * (runDistance * directionToOrigin);
                }
                Vector3 direction = (destination - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(direction);
            }
            else if (idleTimer <= 0)
            {
                if (Random.value < 0.5)
                {
                    animator.SetBool("Turn Head", true);
                }
                else
                {
                    animator.SetBool("Eat", true);
                }
            }
        }

    }

    void SetIdleTimer()
    {
        idleTimer = Random.Range(0.5f, 2f);
    }

    void SetNextMoveTimer()
    {
        nextMoveTimer = Random.Range(1, 4);
    }

    public void IdleAnimationEnded()
    {
        animator.SetBool("Turn Head", false);
        animator.SetBool("Eat", false);
        SetIdleTimer();
    }
}
