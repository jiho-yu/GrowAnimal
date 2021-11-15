using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int Addhp = 75;
    public int Addexp = 60;
    private FoodSpawner parent;
    public void SetParent(FoodSpawner p)
    {
        parent = p;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            parent.DecreaseFoodCount();

            parent = null;
            gameObject.SetActive(false);

            collision.transform.GetComponent<PlayerMove>().AddHp(Addhp);
            collision.transform.GetComponent<PlayerMove>().AddExp(Addexp);
        }

    }
}
