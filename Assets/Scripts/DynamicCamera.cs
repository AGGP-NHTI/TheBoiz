using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    private Transform cam_obj;
    private Vector2 cam_pos;
    private Vector2 plr_pos;
    private Vector2 dist;
    private Vector2 mouse_pos;
    private Vector2 ab;
    public GameObject plr;

    void Start()
    {
        cam_obj = gameObject.transform;
    }

    
    void Update()
    {
        plr_pos = new Vector2(plr.transform.position.x, plr.transform.position.y);
        mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cam_pos = (mouse_pos + plr_pos) / 2;
        cam_obj.position = new Vector3(cam_pos.x, cam_pos.y, -10);
    }
}
