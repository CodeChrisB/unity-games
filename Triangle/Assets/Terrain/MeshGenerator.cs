using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    Color[] colors;

    public int xSize = 400;
    public int zSize = 400;

    public const int _NB_POINTS = 100;
    public const int _DEPTH = 100;

    public Gradient gradient;
    public float minTerrainHeight;
    public float maxTerrainHeight;
    private WorleyNoise ws;
    private UnityEngine.Random random;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        ws = new WorleyNoise();
        ws.GenerateMap(_NB_POINTS, xSize, zSize, _DEPTH);
        random = new UnityEngine.Random();
        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for(int i =0, z = 0; z <= zSize; z++)
        {
            for (int x = 0;x <= xSize; x++)
            {
                float y = ws.GetValue((int)(x * Math.PI), 10*z);
                vertices[i] = new Vector3(x, y, z);
                i++;
                if (y > maxTerrainHeight)
                    maxTerrainHeight = y;
                else if (y < minTerrainHeight)
                    minTerrainHeight = y;
            }
        }

        triangles = new int[xSize*zSize*6];

        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        colors = new Color[vertices.Length];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for(int x = 0; x <= xSize; x++)
            {
                float height =Mathf.InverseLerp(minTerrainHeight,maxTerrainHeight, vertices[i].y);
                colors[i] = gradient.Evaluate(height);
                i++;
              
            }
        }

      
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;

        for (int i = 0; i < vertices.Length; i++)
            Gizmos.DrawSphere(vertices[i], .1f);
    }
}
