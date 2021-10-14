using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public RectTransform mouseCursor;

    public float speed;
    public float rotateSpeed = 8f;
    private float angle;
    public Vector2 mouse;
    public Vector2 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
        mouseCursor.gameObject.SetActive(false);
    }

    private void Update()
    {
        //transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        

        this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Get_MouseInput();
        Update_Moving();
    }

    private void Get_MouseInput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            targetPosition = mouse;

            mouseCursor.gameObject.SetActive(true);
            mouseCursor.position = Input.mousePosition;
            Vector2 myPos = transform.position;
            angle = Mathf.Atan2(mouse.y - myPos.y, mouse.x - myPos.x) * Mathf.Rad2Deg;
        }
    }

    private void Update_Moving()
    {
        //rectTrans.position = Vector3.Lerp(rectTrans.position, targetTrans.position, speed);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * rotateSpeed);

        Vector2 mouseWorldPoint = Camera.main.ScreenToWorldPoint( mouseCursor.position);

        if( (mouseWorldPoint - (Vector2)transform.position).magnitude < 0.2f )
        {
            mouseCursor.gameObject.SetActive(false);
        }
    }
}
