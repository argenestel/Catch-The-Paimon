using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class Paimon : MonoBehaviour
{

    public GameObject bar;
    public int Time;

    public delegate void OnHealth();
    public static event OnHealth OnHealthEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        AnimateBar();
    }
    
    public void AnimateBar()
    {
        LeanTween.scaleX(bar, 0, Time).setOnComplete(OnHealthReduce);
    }
    void OnHealthReduce()
    {
        Destroy(gameObject);
        var PSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        PSystem.Play();
        if (OnHealthEvent != null)
        {
            Debug.Log("OnHealthCalled");
            OnHealthEvent();
        }
    }
}
