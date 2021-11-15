using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 3f;

    enum eState
    {
        idle,
        walk,
        trace,
        attack,
    }
    eState state_cur = eState.idle;

    void Start()
    {
        State_start(eState.idle);
    }


    void Update()
    {
        State_Update();



        //transform.LookAt(target.transform);
        //transform.position += transform.forward * 1.0f * Time.deltaTime;
    }

    void State_start(eState state)
    {
        state_cur = state;
        switch (state)
        {
            case eState.idle:
                break;
            case eState.walk:
                break;
            case eState.trace:
                break;
            case eState.attack:
                break;
        }
    }

    void State_Update()
    {
        switch(state_cur)
        {
            case eState.idle:
                if (target != null && Vector3.Distance(target.transform.position, transform.position) < 5.0f)
                    State_start(eState.trace);
                break;
            case eState.walk:
                if(target != null && Vector3.Distance(target.transform.position,transform.position) < 4.0f)
                    State_start(eState.trace);
                transform.position += transform.forward * 0.5f * Time.deltaTime;
                break;
            case eState.trace:
                if (target != null && Vector3.Distance(target.transform.position, transform.position) > 8.0f)
                    State_start(eState.idle);
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 2.0f);
                    Vector2 direction = new Vector2(
                    transform.position.x - target.transform.position.x,
                    transform.position.y - target.transform.position.y
                    );


                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
                    Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
                    transform.rotation = rotation;
                break;
            case eState.attack:
                break;
        }
    }

}


