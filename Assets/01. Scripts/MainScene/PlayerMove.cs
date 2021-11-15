using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public RectTransform mouseCursor;

    [Header("체력관련")]
    public int hp = 0;
    public int maxHp = 1000;

    [Header("물관련")]
    public int water = 0;
    public int maxWater = 1000;

    [Header("경험치관련")]
    public int Exp = 0;
    public int maxExp = 1000;
    public bool IsLevelup = false;

    [Header("공격력 관련")]
    public int atk = 150;

    private int level;
    public Text levelTxt;
    
    public float speed;
    public float rotateSpeed = 8f;
    private float angle;
    public Vector2 mouse;
    public Vector2 targetPosition;

    private void Start()
    {
        UIManager.Instance.levelup.gameObject.SetActive(false);
        level = 0;

        targetPosition = transform.position;
        mouseCursor.gameObject.SetActive(false);

        UIManager.Instance.SetHpBar((float)hp / (float)maxHp);
        UIManager.Instance.SetWaterBar((float)water / (float)maxWater);
        UIManager.Instance.SetExpBar((float)Exp / (float)maxExp);

        StartCoroutine("countTime", 2f);

        //플레이어 변경 시키기
        //SpriteRenderer spriteR = gameObject.GetComponent<SpriteRenderer>();

        //Sprite[] sprites = Resources.LoadAll<Sprite>("Assets/03.Character/Back");
        //spriteR.sprite = sprites[0];
    }

    private void Update()
    {
        //transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));


        this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Get_MouseInput();
        Update_Moving();

        GameEnd();

        if((float)Exp / (float)maxExp == 1)
        {
            Levelup();
            Exp = 0;
        }
    }

    private void Get_MouseInput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            targetPosition = mouse;

            mouseCursor.gameObject.SetActive(true);
            mouseCursor.position = Input.mousePosition;
            Vector2 myPos = transform.position;
            angle = Mathf.Atan2(mouse.y - myPos.y, mouse.x - myPos.x) * Mathf.Rad2Deg;
        }
    }

    private void Update_Moving()
    {
        //rectTrans.position = Vector3.Lerp(rectTrans.position, targetTrans.position, speed);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * rotateSpeed);

        Vector2 mouseWorldPoint = Camera.main.ScreenToWorldPoint(mouseCursor.position);

        if ((mouseWorldPoint - (Vector2)transform.position).magnitude < 0.2f)
        {
            mouseCursor.gameObject.SetActive(false);
        }
    }

    IEnumerator countTime(float delayTime)
    {
        while (true)
        {
            hp = hp - 8;
            water = water - 6;
            UIManager.Instance.SetHpBar((float)hp / (float)maxHp);
            UIManager.Instance.SetWaterBar((float)water / (float)maxWater);
            yield return new WaitForSeconds(delayTime);
        }
    }

        public void AddHp(int value)
        {
            hp += value;
            hp = Mathf.Clamp(hp, 0, maxHp);

            UIManager.Instance.SetHpBar((float)hp / (float)maxHp);
        }

    public void AddWater(int wvalue)
    {
        water += wvalue;
        water = Mathf.Clamp(water, 0, maxWater);

        UIManager.Instance.SetWaterBar((float)water / (float)maxWater);
    }

    public void AddExp(int Expvalue)
    {
        Exp += Expvalue;
        Exp = Mathf.Clamp(Exp, 0, maxExp);

        UIManager.Instance.SetExpBar((float)Exp / (float) maxExp);
    }

    public void Levelup()
    {
        level++;
        levelTxt.text = "Level : " + level;
        IsLevelup = true;
        if (IsLevelup == true)
        {
            UIManager.Instance.LevelupCanvas.alpha = 1;
            UIManager.Instance.levelup.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void selectNext()
    {
        Time.timeScale = 1;
        UIManager.Instance.LevelupCanvas.alpha = 0;
        UIManager.Instance.levelup.gameObject.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("EnemyAnimal"))
        {
            hp = hp - 100;
        }
    }

    public void GameEnd()
    {
        if(hp <= 0 || water <= 0)
        {
            SceneManager.LoadScene("GameoverScene");
        }
    }
}
