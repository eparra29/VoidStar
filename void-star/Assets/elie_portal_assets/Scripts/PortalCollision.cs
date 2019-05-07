using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {

        if (col.collider.tag == "Player")
        {
            col.gameObject.SetActive(false);
            StartCoroutine("NextScene");
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2.6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
