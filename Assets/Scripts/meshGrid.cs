using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[ExecuteAlways]
public class meshGrid : MonoBehaviour
{
    public int GridSize;
    public Mesh mesh;
    public List<Vector3> verticies;

    public List<int> indicies;
    void Awake()
    {
        MeshFilter filter = gameObject.GetComponent<MeshFilter>();
        mesh = new Mesh();
        verticies = new List<Vector3>();
        indicies = new List<int>();
        for (int i = 0; i <= GridSize; i++)
        {
            verticies.Add(new Vector3(i, 0, 0));
            verticies.Add(new Vector3(i, 0, GridSize));

            indicies.Add(4 * i + 0);
            indicies.Add(4 * i + 1);

            verticies.Add(new Vector3(0, 0, i));
            verticies.Add(new Vector3(GridSize, 0, i));

            indicies.Add(4 * i + 2);
            indicies.Add(4 * i + 3);
        }

        mesh.vertices = verticies.ToArray();
        mesh.SetIndices(indicies.ToArray(), MeshTopology.Lines, 0);
        filter.mesh = mesh;
       
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Sprites/Default"));
        //meshRenderer.material.color = Color.white;

        Debug.Log("mesh: " + mesh.vertexCount);
    }
}
