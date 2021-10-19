using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //캐릭터 레벨
    private int level;
    //초식동물 포인트
    [SerializeField]
    private int plantsPoint;
    //최대 초식동물 포인트(포인트가 최대포인트까지 가면 초식동물 진화가능)
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
