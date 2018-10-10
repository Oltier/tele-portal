using UnityEngine;
using System.Collections;

public class BluePortalOpen : MonoBehaviour {

    public GameObject Blue;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("CanBeShot"))
        {
            Destroy(this.gameObject);
            GameObject prevPortals = GameObject.FindWithTag("Blue");
            Destroy(prevPortals);
            GameObject BluePortal = Instantiate(Blue, transform.position + (other.transform.right * 0.7f), other.transform.rotation) as GameObject;
        }
        else
            Destroy(this.gameObject);
    }

}
