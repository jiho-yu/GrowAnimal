using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //ĳ���� ����
    private int level;
    //�ʽĵ��� ����Ʈ
    [SerializeField]
    private int plantsPoint;
    //�ִ� �ʽĵ��� ����Ʈ(����Ʈ�� �ִ�����Ʈ���� ���� �ʽĵ��� ��ȭ����)
    private int maxPlantsPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plantsPoint >= maxPlantsPoint)
        {
            level++;
        }
    }

    private void OnCollisionEnter2D(Collision2D plants)
    {
        if (plants.gameObject.tag == "Plants")
        {
            plantsPoint += 10;
        }
    }
}
