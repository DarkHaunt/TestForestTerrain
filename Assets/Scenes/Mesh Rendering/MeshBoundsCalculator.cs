using UnityEngine;


[RequireComponent(typeof(MeshCollider))]
public class MeshBoundsCalculator : MonoBehaviour
{
    [SerializeField] private MeshFilter _mesh;

    private void OnValidate()
    {
        transform.localPosition = Vector3.zero;
        transform.localScale = _mesh.mesh.bounds.size;
    }
}
