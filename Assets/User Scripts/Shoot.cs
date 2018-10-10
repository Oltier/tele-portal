using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public float AnimationSpeed = 1.0f;
    public int shootSpeed = 500;
    public float ShootDelay = 0.5f;
    private float ShootTime = 0.0f;

    public Transform BlueBullet;
    public Transform OrangeBullet;

	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1"))
        {
            if (Time.time >= ShootTime)
            {
                GetComponent<Animation>().Stop();
                GetComponent<Animation>().Play();
                GetComponent<Animation>()["ShootAnim"].speed = AnimationSpeed;
                Transform bullet;
                bullet = Instantiate(BlueBullet, transform.position + (this.transform.forward), Quaternion.identity) as Transform;
                bullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * shootSpeed);
                ShootTime = Time.time + ShootDelay;
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (Time.time >= ShootTime)
            {
                GetComponent<Animation>().Stop();
                GetComponent<Animation>().Play();
                GetComponent<Animation>()["ShootAnim"].speed = AnimationSpeed;
                Transform bullet;
                bullet = Instantiate(OrangeBullet, transform.position + (this.transform.forward), Quaternion.identity) as Transform;
                bullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * shootSpeed);
                ShootTime = Time.time + ShootDelay;
            }
        }
	}
}
