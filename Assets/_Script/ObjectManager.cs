using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject boosterPrefab;

    GameObject[] coin;
    GameObject[] booster;

    private void Awake()
    {
        booster = new GameObject[3];
        coin = new GameObject[50];

        Generate();
    }

    private void Generate()
    {
        for (int index = 0; index < coin.Length; index++)
        {
            coin[index] = Instantiate(coinPrefab);
            coin[index].SetActive(false);
        }
        for (int i = 0; i < booster.Length; i++)
        {
            booster[i] = Instantiate(boosterPrefab);
            booster[i].SetActive(false);

        }
    }
}
