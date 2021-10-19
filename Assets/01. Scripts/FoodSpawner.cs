using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public float genTime = 2f;
    public float radius = 2f;
    private float nextGenTime = 0f;

    public int maxCount = 5;
    private int currentCount = 0;
    

    private void Start()
    {
        nextGenTime = Time.time + Random.Range(genTime, genTime + 1f);
    }

    private void Update()
    {
        if(Time.time > nextGenTime && currentCount < maxCount)
        {
            currentCount++;
            nextGenTime = Time.time + Random.Range(genTime, genTime + 1f);
            Food food = PoolManager.instance.GetFood();
            food.SetParent(this);

            float degree = Random.Range(0, 360f);
            Vector2 pos = new Vector2(Mathf.Sin(degree * Mathf.Deg2Rad), Mathf.Cos(degree * Mathf.Deg2Rad));
            
            food.transform.position = transform.position + (Vector3)(pos *  Random.Range(1,radius));
        }
    }

    public void DecreaseFoodCount()
    {
        currentCount--;
    }
}
