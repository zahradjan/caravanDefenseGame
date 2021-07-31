using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private float size = 1f;

    private float xStart = 0;
    private float zStart = 0;
    private float xEnd = 20;
    private float zEnd = 20;

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3(
            (float)xCount * size,
            (float)yCount * size,
            (float)zCount * size);

        result += transform.position;

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (float x = xStart; x < xEnd; x += size)
        {
            for (float z = zStart; z < zEnd; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, 0.1f);
            }

        }
    }
    public float GetSize()
    {
        return size;
    }
}
