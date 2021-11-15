using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button cat;
    public Button monkey;
    public Button ox;

    public GameObject player;
    void Start()
    {
        cat.onClick.AddListener(() =>
            {
                player.GetComponent<SpriteRenderer>().sprite = cat.GetComponent<Image>().sprite;
            });
        monkey.onClick.AddListener(() =>
            {
                player.GetComponent<SpriteRenderer>().sprite = monkey.GetComponent<Image>().sprite;
            });        
        ox.onClick.AddListener(() =>
            {
                player.GetComponent<SpriteRenderer>().sprite = ox.GetComponent<Image>().sprite;
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
