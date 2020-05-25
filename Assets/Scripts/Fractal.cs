using System;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;


public class Fractal : MonoBehaviour
{
    public Mesh mesh;
    public Material material;
    public int maxDepth = 4;
    public float childScale = 0.5f;
    private int depth;

    private void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        if (depth < maxDepth)
        {
            new GameObject("Fractal Child")
                .AddComponent<Fractal>().Initialize(this, Vector3.up);
            new GameObject("Fractal Child")
                .AddComponent<Fractal>().Initialize(this, Vector3.right);
        }
    }

    private void Initialize(Fractal parent, Vector3 direction)
    {
        this.mesh = parent.mesh;
        this.material = parent.material;
        this.maxDepth = parent.maxDepth;
        this.childScale = parent.childScale;
        this.depth = parent.depth + 1;
        this.transform.parent = parent.transform;
        this.transform.localScale = Vector3.one * childScale;
        this.transform.localPosition = direction * (0.5f + 0.5f * childScale);
    }
}
