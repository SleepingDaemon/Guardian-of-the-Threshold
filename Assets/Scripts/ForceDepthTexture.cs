using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ForceDepthTexture : MonoBehaviour
{
    private void OnEnable()
    {
        Camera cam = GetComponent<Camera>();
        cam.depthTextureMode |= DepthTextureMode.Depth;
    }
}
