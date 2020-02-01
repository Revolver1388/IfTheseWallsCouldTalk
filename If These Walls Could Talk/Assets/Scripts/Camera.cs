using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Camera main;
    Vector3 damp;
    [SerializeField]
    float cam_Speed;
    float cam_Dist = -10;
    [SerializeField]
    float distFromScreen;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        if (!main) main = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0) camBehavior();
    }

    void camBehavior()
    {
        if (transform.position.z < -11 || transform.position.z > -9) transform.position = new Vector3(transform.position.x, transform.position.y, cam_Dist);
        transform.position = Vector3.SmoothDamp(transform.position, transform.position - (transform.forward - (transform.right * horizontal) - (transform.up * vertical) * distFromScreen), ref damp, cam_Speed);
    }
}
