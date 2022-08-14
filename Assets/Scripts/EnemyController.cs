using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform targ;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(targ.position, transform.position);
        if(dist < 3.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targ.position, speed * Time.deltaTime);
        }
    }
}
