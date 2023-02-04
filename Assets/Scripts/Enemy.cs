using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyFieldOfView fieldOfView;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private float minY;

    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = GetRandomPoint();
        gameObject.transform.position = target * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objectPos = transform.position;

        /*Vector3 targ = target;

        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));*/

        Vector3 aimdir = target - objectPos;

        fieldOfView.SetAimDirection(aimdir);
        fieldOfView.SetOrigin(objectPos);

        if (Vector3.Distance(objectPos, target) < 0.1)
        {
            target = GetRandomPoint();
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(objectPos, target, 10 * Time.deltaTime);
        }

    }

    private Vector3 GetRandomPoint()
    {
        Vector3 finalPoint;
        finalPoint = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        Debug.Log(finalPoint);
        return finalPoint;
    }
}
