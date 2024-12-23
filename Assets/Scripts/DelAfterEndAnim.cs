using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelAfterEndAnim : MonoBehaviour
{
    private Animator _anim; 

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void DestroyAfterAnim()
    { 
        Destroy(gameObject);
    }
}
