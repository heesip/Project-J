using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public Joystick Joystick => joystick;
    [SerializeField] Joystick joystick;
    public GameObject GameoverUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        GameoverUI.SetActive(false);
    }
}
