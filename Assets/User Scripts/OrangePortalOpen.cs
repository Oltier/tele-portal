using UnityEngine;
using System.Collections;

public class OrangePortalOpen : MonoBehaviour {

    public GameObject Orange;


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("CanBeShot"))
        {
            Destroy(this.gameObject);
            GameObject prevPortals = GameObject.FindWithTag("Orange");
            Destroy(prevPortals);
            GameObject OrangePortal = Instantiate(Orange, transform.position + (other.transform.right * 0.7f), other.transform.rotation) as GameObject;
        }
        else
            Destroy(this.gameObject);
    }

}
