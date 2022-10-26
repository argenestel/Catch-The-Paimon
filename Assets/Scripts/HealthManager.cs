using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DentedPixel;

public class HealthManager : MonoBehaviour
{

    public int _health = 3;
    public TextMeshProUGUI Lives;

    public delegate void OnGameOver();
    public static event OnGameOver OnGameOverEvent;
    void OnEnable()
    {
        Paimon.OnHealthEvent += ChangeHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        Lives.text = _health.ToString();
    }

    private void ChangeHealth()
    {
        _health--;
        OnLiveChange();
    }
    void OnLiveChange()
    {
        if(_health == 0)
        {
            Debug.Log("You Lose");
            if(OnGameOverEvent != null)
            {
                OnGameOverEvent();
            }
        }
    }

    void OnDisable()
    {
        Paimon.OnHealthEvent -= ChangeHealth;
    }
}
