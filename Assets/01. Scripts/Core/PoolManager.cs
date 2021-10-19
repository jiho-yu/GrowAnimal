using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public Food foodPrefab;
    private List<Food> list = new List<Food>();

    public static PoolManager instance = null;
    private void Awake()
    {
        if (instance != null)
            Debug.LogError("다수의 풀 매니저가 실행되고 있습니다.");

        instance = this;
        
    }

    public Food GetFood()
    {
        Food food = list.Find(x => !x.gameObject.activeSelf);
        if(food == null)
        {
            food = Instantiate(foodPrefab, transform);
            list.Add(food);
        }
        food.gameObject.SetActive(true);
        return food;
    }
}
