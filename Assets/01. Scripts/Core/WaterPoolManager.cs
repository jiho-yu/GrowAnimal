using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPoolManager : MonoBehaviour
{
    public Water waterPrefab;
    private List<Water> list = new List<Water>();

    public static WaterPoolManager instance = null;
    private void Awake()
    {
        if (instance != null)
            Debug.LogError("다수의 풀 매니저가 실행되고 있습니다.");

        instance = this;

    }

    public Water GetWater()
    {
        Water water = list.Find(x => !x.gameObject.activeSelf);
        if (water == null)
        {
            water = Instantiate(waterPrefab, transform);
            list.Add(water);
        }
        water.gameObject.SetActive(true);
        return water;
    }
}
