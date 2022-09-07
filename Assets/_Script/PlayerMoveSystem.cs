using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMoveSystem
{
    Joystick joystick;
    Player player;

    [SerializeField] float speed = 7.5f;
    [SerializeField] float lerpValue = 0.25f;

    Vector2 direction;
    Vector2 moveResult;

    public void Initialize(Player player)
    {
        this.player = player;
        joystick = UIManager.instance.Joystick;
    }

    public void Move()
    {
        if (joystick.IsDrag == false)
        {
            return;
        }

        direction.x = joystick.Horizontal;
        player.transform.right = Vector2.Lerp(player.transform.right,
                                              direction,
                                              lerpValue);

        moveResult = speed * Time.deltaTime * direction;
        player.transform.Translate(moveResult);
    }
}
