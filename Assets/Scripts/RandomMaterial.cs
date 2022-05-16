using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    public SkinnedMeshRenderer[] topSkinnedMeshRenderers;
    public Material[] topMaterials;

    [Space]
    public SkinnedMeshRenderer[] bottomSkinnedMeshRenderers;
    public Material[] bottomMaterials;


    public void AssignMaterials()
    {
        AssignTopMaterials();
        AssignBottomMaterials();
    }


    public void AssignTopMaterials()
    {
        for (int i = 0; i < topSkinnedMeshRenderers.Length; i++)
        {
            topSkinnedMeshRenderers[i].material = topMaterials[Random.Range(0, topMaterials.Length)];
        }
    }

    public void AssignBottomMaterials()
    {
        for (int i = 0; i < topSkinnedMeshRenderers.Length; i++)
        {
            bottomSkinnedMeshRenderers[i].material = bottomMaterials[Random.Range(0, bottomMaterials.Length)];
        }
    }
}
