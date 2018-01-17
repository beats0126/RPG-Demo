using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertRegularMesh : MonoBehaviour {

    [ContextMenu("Convert to Regular Mesh")]
    void Convert()
    {
        //add component to the mesh object
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        meshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;
        meshRenderer.sharedMaterials = skinnedMeshRenderer.sharedMaterials;

        DestroyImmediate(skinnedMeshRenderer);
        DestroyImmediate(this);
    }
}
