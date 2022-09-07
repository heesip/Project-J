using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerMoveSystem playerMoveSystem = new PlayerMoveSystem();

    Rigidbody2D playerRigidbody;
    Item item;
    [SerializeField] UIManager uIManager;
    float maxY;
    [SerializeField] float jumpPower = 10.0f;
    [SerializeField] bool isDead;
    [SerializeField] bool isBooster;
    [SerializeField] float boosting = 2.5f;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    IEnumerator Start()
    {
        playerMoveSystem.Initialize(this);
        yield return new WaitForSeconds(3f);
        //Jump(jumpPower);
    }


    private void FixedUpdate()
    {
        if (!isDead)
        {
            playerMoveSystem.Move();
            CamOut();
            MoveCam();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDead && collision.gameObject.CompareTag(AllTagLayer.Item))
        {

            item = collision.GetComponent<Item>();
            var velo_y = playerRigidbody.velocity;

            switch (item.ItemType)
            {
                case ItemType.Silver:
                    if (!isBooster)
                    {
                        VelocityZero();
                        Jump(item.JumpPower);
                    }
                    break;
                case ItemType.Booster:
                    StopBoosterCo();
                    VelocityZero();
                    boosterCoHandle = StartCoroutine(BossterCo());
                    break;
            }
            Destroy(collision.gameObject);
        }
    }

    void CamOut()
    {
        if (isDead)
        {
            return;
        }

        Vector3 camView = Camera.main.WorldToScreenPoint(transform.position);
        if (camView.y < 10)
        {
            isDead = true;
            GameOver();
        }
    }

    void GameOver()
    {
        if (!isDead)
        {
            return;
        }
        uIManager.GameoverUI.SetActive(true);
    }
    void MoveCam()
    {
        if (isDead)
        {
            return;
        }

        if (transform.position.y > maxY)
        {
            maxY = transform.position.y;

            Camera.main.transform.position = new Vector3(0, maxY - 2.5f, -10);
        }
    }
    Coroutine boosterCoHandle;
    IEnumerator BossterCo()
    {
        isBooster = true;
        Jump(item.JumpPower);
        yield return new WaitForSeconds(boosting);
        isBooster = false;
        StopBoosterCo();
    }
    void StopBoosterCo()
    {
        if(boosterCoHandle != null)
        {
            StopCoroutine(boosterCoHandle);
        }
    }
    private void Jump(float jumpPower)
    {
        playerRigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void VelocityZero()
    {
        var velo_y = playerRigidbody.velocity;
        velo_y.y = 0;
        playerRigidbody.velocity = velo_y;
    }
}
