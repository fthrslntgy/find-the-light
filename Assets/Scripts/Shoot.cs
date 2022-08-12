using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
   Animator m_Animator;

    void Start()
    {
        //Get the Animator, which you attach to the GameObject you intend to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //When entering the Jump state in the Animator, output the message in the console
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Run N"))
        {
            Debug.Log("Run N");
        }
    }
}
