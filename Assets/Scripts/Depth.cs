using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depth : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float maxTime = .1f;
    public bool runOnlyOnce;
    private new Renderer[] renderer;

    private void LateUpdate()
    {
        renderer = FindObjectsOfType<Renderer>();
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = maxTime;

            foreach (var rend in renderer)
            {
                rend.sortingOrder = (int)((rend.transform.position.y + rend.transform.position.z) * -100);
            }
            if (runOnlyOnce)
                Destroy(this);
        }


    }
}
