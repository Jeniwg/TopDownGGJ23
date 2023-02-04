using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyFieldOfView fieldOfView;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fieldOfView.SetAimDirection(Vector3.forward);
        fieldOfView.SetOrigin(transform.position);
    }
}
