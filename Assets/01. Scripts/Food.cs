using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private FoodSpawner parent;
    public void SetParent(FoodSpawner p)
    {
        parent = p;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        parent.DecreaseFoodCount();

        parent = null;
        gameObject.SetActive(false);
    }
}
