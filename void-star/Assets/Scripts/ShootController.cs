using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{

    public Material aimingStar;
    public GameObject bullets;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();

    }

    private void OnPostRender()
    {
        DrawRecent(Screen.width / 2, Screen.height / 2, 10, 10);
    }

    private void DrawRecent(float x, float y, float width, float height)
    {
        aimingStar.SetPass(0);
        GL.LoadOrtho();
        GL.Begin(GL.QUADS);
        GL.Vertex(new Vector3(x / Screen.width, y / Screen.height, 0));
        GL.Vertex(new Vector3(x / Screen.width, (y + height) / Screen.height, 0));
        GL.Vertex(new Vector3((x + width) / Screen.width, (y + height) / Screen.height, 0));
        GL.Vertex(new Vector3((x + width) / Screen.width, y / Screen.height, 0));
        GL.End();
    }


    private void Shoot()
    {
        Vector3 direction = transform.TransformDirection(Vector3.up);
        if (Input.GetMouseButtonDown(0))
        {
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
            Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject bullet = Instantiate(bullets, bulletPosition, Quaternion.identity) as GameObject;
            bullet.transform.LookAt(targetPoint);
            Rigidbody bulletRigibody = bullet.GetComponent<Rigidbody>();
            bulletRigibody.velocity = bullet.transform.forward * 50;
            Destroy(bullet, 3f);
        }

    }
}
