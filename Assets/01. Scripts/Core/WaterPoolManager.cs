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
            Debug.LogError("�ټ��� Ǯ �Ŵ����� ����ǰ� �ֽ��ϴ�.");

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
