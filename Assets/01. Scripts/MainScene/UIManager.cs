using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance 
    {
        get 
        {
            if (instance == null)
            {
                Debug.LogError("UI 매니저가 존재하지 않습니다");
            }

            return instance;
        }
    }

    public Image HpGage;
    public Image WaterGage;
    public Image ExpGage;

    public CanvasGroup LevelupCanvas;
    public Canvas levelup;
    public Button SelectAnimalBtn;

    private float time;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {

    }

    public void SetHpBar(float hp)
    {
        //print("hp = " + hp);
        HpGage.transform.localScale = new Vector3(Mathf.Clamp(hp, 0f, 1f), 1f, 1f);
    }

    public void SetWaterBar(float water)
    {
        //print("water = " + water);
        WaterGage.transform.localScale = new Vector3(Mathf.Clamp(water, 0f, 1f), 1f, 1f);
    }

    public void SetExpBar(float Exp)
    {
        //print("Exp = " + Exp);
        ExpGage.transform.localScale = new Vector3(Mathf.Clamp(Exp, 0f, 1f), 1f, 1f);
    }
}
