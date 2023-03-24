using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AutoRotate : MonoBehaviour
{
    [SerializeField] public float fadeTime = 1.0f;
    [SerializeField] private float speed = 60f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,speed * Time.deltaTime,0,Space.Self);
    }
    

}
