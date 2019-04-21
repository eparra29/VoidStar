using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{

    public GameObject bullets;
    public GameObject battleSfx;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        battleSfx = GameObject.Find("BattleSfx");
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();

    }

    //private void OnPostRender()
    //{
    //    DrawRecent(Screen.width / 2, Screen.height / 2, 10, 10);
    //}

    //private void DrawRecent(float x, float y, float width, float height)
    //{
    //    aimingStar.SetPass(0);
    //    GL.LoadOrtho();
    //    GL.Begin(GL.QUADS);
    //    GL.Vertex(new Vector3(x / Screen.width, y / Screen.height, 0));
    //    GL.Vertex(new Vector3(x / Screen.width, (y + height) / Screen.height, 0));
    //    GL.Vertex(new Vector3((x + width) / Screen.width, (y + height) / Screen.height, 0));
    //    GL.Vertex(new Vector3((x + width) / Screen.width, y / Screen.height, 0));
    //    GL.End();
    //}


    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {


            if (PlayerPrefs.GetInt(Utils.AIMING_STYLE) < 2 )
            {
                battleSfx.GetComponents<AudioSource>()[0].Play();
            }
            else if (PlayerPrefs.GetInt(Utils.AIMING_STYLE) == 2)
            {
                battleSfx.GetComponents<AudioSource>()[1].Play();
            }



            Vector3 targetPoint;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                targetPoint = hitInfo.point;
            }
            else
            {
                Debug.Log(Camera.main.transform.forward);
                targetPoint = Camera.main.transform.forward * 1000;
            }
            Vector3 bulletPosition = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1.5f, Camera.main.transform.position.z);
            GameObject bullet = Instantiate(bullets, bulletPosition, Quaternion.identity) as GameObject;
            bullet.transform.LookAt(targetPoint);
            Rigidbody bulletRigibody = bullet.GetComponent<Rigidbody>();
            bulletRigibody.velocity = bullet.transform.forward * 150;
            Destroy(bullet, 3f);
        }

    }
}
