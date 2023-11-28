using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float maxLength = 10f;
    [SerializeField] private GameObject startBeam;
    [SerializeField] private GameObject endBeam;


    private LineRenderer lineRenderer;
    
    
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        ParticleSystem[] particles= transform.GetComponentsInChildren<ParticleSystem>();
       
    }
    void Start()
    {
        UpdateEndPosition();
    }
        

    // Update is called once per frame
    void Update()
    {
        UpdateEndPosition();
    }


    private void UpdatePosition(Vector2 startPosition, Vector2 direction)
    {
        direction = direction.normalized;
        transform.position = startPosition;
        float rotationZ = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(0,0,rotationZ*Mathf.Rad2Deg);
    }
    
    private void UpdateEndPosition()
    {
        Vector2 startPosition = transform.position;
        float rotationZ = transform.rotation.eulerAngles.z;
        rotationZ = Mathf.Deg2Rad;

        Vector2 direction = new Vector2(Mathf.Cos(rotationZ), Mathf.Sin(rotationZ));

        RaycastHit2D hit = Physics2D.Raycast(startPosition, direction.normalized);

        float length = maxLength;
        float beamEndRotation = 180f;

                
        if (hit)
        {
            
            length = (hit.point - startPosition).magnitude;
            beamEndRotation = Vector2.Angle(direction, hit.normal);
            Debug.Log(beamEndRotation);
        }
        lineRenderer.SetPosition(1, new Vector2(length, 0));


        Vector2 endPosition = startPosition + length*direction;
        startBeam.transform.position = startPosition;
        endBeam.transform.position = endPosition;
        endBeam.transform.rotation = Quaternion.Euler(0, 0, beamEndRotation);

    }
}
