using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float JumpPower;
    public int Score;
    [SerializeField] float silver = 10f;
    [SerializeField] float booster = 30f;
    [SerializeField] float gold = 12f;

    public ItemType ItemType => itemType;
    [SerializeField] ItemType itemType;
    private void Start()
    {
        switch (itemType)
        {
            case ItemType.Silver:
                JumpPower = silver;
                Score = 5;
                break;
            case ItemType.Booster:
                JumpPower = booster;
                Score = 20;
                break;
            case ItemType.Gold:
                JumpPower = gold;
                Score = 10;
                break;
            default:
                JumpPower = 0f;
                break;
        }
    }
}
