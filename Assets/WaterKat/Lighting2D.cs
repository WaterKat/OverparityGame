using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting2D : MonoBehaviour
{/*
    public int Resolution = 12;
    public int Distance = 5;

    private void Start()
    {
        GetComponent<MeshFilter>().mesh = CreateRadialMesh();
        GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().mesh;
    }

    Mesh CreateRadialMesh()
    {
        Vector2 originVector = transform.position;

        Vector3[] vertexList = new Vector3[Resolution+1];
        

        vertexList[0] = new Vector3(0, 0, 0);

        for (int i = 1; i <= Resolution; i++)
        {
            float rayLength = Distance;
            RaycastHit2D raycastHit2D;
            
            raycastHit2D = Physics2D.Raycast(originVector, new Vector2(Mathf.Cos(2 * Mathf.PI / Resolution * i), Mathf.Sin(2 * Mathf.PI / Resolution * i)),Distance);
            if (raycastHit2D != null)
            {
                rayLength = Vector2.Distance(transform.position, raycastHit2D.point);
            }

            vertexList[i] = new Vector2(Mathf.Cos(2 * Mathf.PI / Resolution * i), Mathf.Sin(2 * Mathf.PI / Resolution * i))*rayLength;
        }

        int[] vertexEdge = new int[Resolution * 3];

        for (int j = 0; j < Resolution; j++)
        {
            vertexEdge[j] = 0;
            vertexEdge[j + 1] = (int)Mathf.Repeat((2 * j) + 1,Resolution);
            vertexEdge[j + 2] = (int)Mathf.Repeat((2 * j) + 2, Resolution);
        }

        Vector2[] meshUvs = new Vector2[Resolution+1];
        for (int i = 0; i < Resolution; i++)
        {
            meshUvs[i] = Vector2.Lerp(Vector2.zero, Vector2.one, i / (float)Resolution);
        }
        Vector3[] meshNormals = new Vector3[Resolution + 1];
        for (int i = 0; i < Resolution; i++)
        {
            meshNormals[i] = Vector3.up;
        }
        Mesh mesh = new Mesh();
        mesh.name = "NewMesh";
       // mesh.SetVertices(vertexList);
        mesh.vertices = vertexList;
        mesh.SetTriangles(vertexEdge,0);
        mesh.uv = meshUvs;
        mesh.normals = meshNormals;
        return mesh;
    }
    */
}
