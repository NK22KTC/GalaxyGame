using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ReverseMesh : MonoBehaviour  //TestWall
{
    public bool removeExistingColliders = true;

    bool changedCollider;

    void Start()
    {
        changedCollider = removeExistingColliders;

        if(removeExistingColliders) CreateInvertedMeshCollider();
    }

    public void CreateInvertedMeshCollider()
    {
        RemoveExistingColliders();
        InvertMesh();

        gameObject.AddComponent<MeshCollider>();
    }

    private void RemoveExistingColliders()
    {
        Collider[] colliders = GetComponents<Collider>();
        for (int i = 0; i < colliders.Length; i++)
            DestroyImmediate(colliders[i]);
    }

    private void InvertMesh()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if(changedCollider != removeExistingColliders)
        {
            CreateInvertedMeshCollider();
            changedCollider = removeExistingColliders;
        }
    }
}
