using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleRise : MonoBehaviour
{

    public float _speed;
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }
}
