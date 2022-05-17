using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private float mouse_X;
    private float mouse_Y;
    float xrotation;
    float yrotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mouse_X = Input.GetAxis("Mouse X")*1000*Time.deltaTime;
        mouse_Y = Input.GetAxis("Mouse Y") * 1000 * Time.deltaTime;
        transform.position = player.transform.position;
        xrotation -= mouse_Y;
        yrotation += mouse_X;
        xrotation = Mathf.Clamp(xrotation, -90, 30);
        transform.rotation=Quaternion.Euler(xrotation,yrotation,0);
        player.Rotate(Vector3.up * mouse_X);
    }
}
