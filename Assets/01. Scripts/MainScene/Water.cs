using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public int Addwater = 75;
    public int Addexp = 60;
    private WaterSpawner parent;
    public void SetParent(WaterSpawner p)
    {
        parent = p;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            parent.DecreaseWaterCount();

            parent = null;
            gameObject.SetActive(false);

            collision.transform.GetComponent<PlayerMove>().AddWater(Addwater);
            collision.transform.GetComponent<PlayerMove>().AddExp(Addexp);
        }
    }
}
