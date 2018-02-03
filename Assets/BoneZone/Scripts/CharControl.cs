using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharControl : NetworkBehaviour
{

    public float speed = 5.0f;
    Animator a;
    Rigidbody2D r;
    Vector3 old_pos;
    Vector3 mousePos;
    Vector3 playerPos;
    Vector3 dir;
    float angle;
    public GameObject projectile;

    // Use this for initialization
    void Start () {
        a = GetComponent<Animator>();
        r = GetComponent<Rigidbody2D>();
        old_pos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (this.transform.position != this.old_pos)
        {
            this.a.SetBool("state", true);
            this.old_pos = this.transform.position;
        }
        else { this.a.SetBool("state", false); }
        if (!isLocalPlayer)
        {
            return;
        }
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 7.0f;
        } else {speed = 5.0f; }

        mousePos = Input.mousePosition;
        playerPos = Camera.main.WorldToScreenPoint(transform.position);
        dir = mousePos - playerPos;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        //    bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * 10);
        //}
    }
}