using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    public GameObject exitPortal = null;
    private bool teleporting = false;
    public AudioClip PortSound;

    void Awake()
    {
        GetComponent<AudioSource>().clip = PortSound;
    }

    public void TeleportTarget(GameObject obj)
    {
        GetComponent<AudioSource>().Play();
        obj.transform.position = transform.position + (transform.right * 2) - (transform.up * 0.65f);
        obj.GetComponent<Rigidbody>().velocity = obj.GetComponent<Rigidbody>().velocity.magnitude * transform.right;
        if (this.CompareTag("Blue"))
            obj.transform.rotation = GameObject.FindWithTag("Blue").transform.rotation;
        else
            obj.transform.rotation = GameObject.FindWithTag("Orange").transform.rotation;
        teleporting = true;
    }

    private void OnTriggerStay(Collider c)
    {
        if (c.name == "Player")
        {
            if (!teleporting)
            {
                exitPortal.GetComponent<Teleport>().TeleportTarget(c.gameObject);


            }
            teleporting = false;
        }
    }

    void Update()
    {
        if (this.CompareTag("Blue"))
            exitPortal = GameObject.FindWithTag("Orange");
        else
            exitPortal = GameObject.FindWithTag("Blue");
    }
}
