using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FPSCharacter : MonoBehaviour
{
    public float speed = 5f;
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 fwd = transform.forward;
        //y 变量是上下位置，所以不用管它，暂时就这么招吧。
        Vector3 f = new Vector3(fwd.x, 0, fwd.z).normalized;
        Vector3 r = transform.right;
        Vector3 move = f * z + r * x;
        transform.position += move * speed * Time.deltaTime;
    }
    private void MouseLook()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = -Input.GetAxis("Mouse Y");
        Quaternion qx = Quaternion.Euler(0, mx, 0);
        Quaternion qy = Quaternion.Euler(my, 0, 0);
        //为啥这俩货顺序是反着的呢？我不理解，让我看看先
        transform.rotation = qx * transform.rotation;
        transform.rotation = transform.rotation * qy;
        float angle = transform.eulerAngles.x;
        if(angle > 180) { angle -= 360; }
        if(angle < -180) { angle += 360; }
        if (angle > 80)
        {
            Debug.Log("A" + transform.eulerAngles.x);
            transform.eulerAngles = new Vector3(80, transform.eulerAngles.y, 0);
        }
        if (angle < -80)
        {
            Debug.Log("B"+transform.eulerAngles.x);
            transform.eulerAngles = new Vector3(-80, transform.eulerAngles.y, 0);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        Move();
        MouseLook();

    }
}
