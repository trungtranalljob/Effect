using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTexture : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private Texture[] textures;
    private int animationStep;

    [SerializeField] private float fps = 30f;
    private float fpsCounter;
    private bool completed = false;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(completed)
            return;
        fpsCounter += Time.deltaTime;
        if (fpsCounter >= 1f/ fps) 
        {
            animationStep++;
            if( animationStep == textures.Length )
            {
                completed = true;
                return;
            }

            lineRenderer.material.SetTexture("_MainTex", textures[animationStep]);

            fpsCounter = 0f;
        }
    }
}
