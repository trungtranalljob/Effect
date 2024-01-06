using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTextureLoop : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lineRenderer;
    [SerializeField]
    private Texture[] textures;

    private int animationStep;

    [SerializeField] private float fps = 30f;
    private float fpsCounter;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        fpsCounter += Time.deltaTime;
        if (fpsCounter >= 1f/fps) 
        {
            animationStep++;
            if (animationStep == textures.Length)
                animationStep = 0; 
            lineRenderer.material.SetTexture("_MainTex", textures[animationStep]);
            fpsCounter = 0f;
        }
    }
}
