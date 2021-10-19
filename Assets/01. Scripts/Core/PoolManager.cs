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
            Debug.LogError("�ټ��� Ǯ �Ŵ����� ����ǰ� �ֽ��ϴ�.");

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
