using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float HP = 100;
    public Slider Healthbar;
    public GameObject Screen;
    public Vector3 originalScale;

    private float smoothSpeed = 0.3f;

    void Start()
    {
    }

    void Update()
    {
        Healthbar.value = HP;
        if (HP == 0)
        {
            Screen.SetActive(true);
        }
        
    }

    public void ApplyDamage(float damage)
    {
        HP -= damage;
        Debug.Log(damage);
    }
}