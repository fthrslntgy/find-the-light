using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Animator m_Animator;
    public GameObject prefab;
    void Start()
    {
        //Get the Animator, which you attach to the GameObject you intend to animate.
        m_Animator = gameObject.GetComponent<Animator>();
        Instantiate(prefab, new Vector3(-3.72f, -1.42f, 2.2f), Quaternion.identity);
    }

    void Update()
    {
        //When entering the Jump state in the Animator, output the message in the console
        
    }
}
