using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFieldOfView : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;
    private Mesh mesh;
    private float fov;
    private Vector3 origin;
    private float startingAngle;
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
        fov = 70f;
    }
    private void Update()
    {
        int rayCount = 25;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 25f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2d = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);



            if (raycastHit2d.collider == null)
            {
                //No hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                //hit
                if (raycastHit2d.collider.CompareTag("Player"))
                {
                    SceneM var = new SceneM();
                    var.LoadScene(2);
                }
                vertex = raycastHit2d.point;
            }

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 dir)
    {
        startingAngle = GetAngleFromVectorFLoat(dir) + 45;
    }

    private static Vector3 GetVectorFromAngle(float angle)
    {
        //angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private static float GetAngleFromVectorFLoat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
    }
}
