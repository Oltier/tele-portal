using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

    public float TimeToDestroy = 5.0f;

	// Update is called once per frame
	void Update () {
        TimeToDestroy -= Time.deltaTime;
        Destroy(this.gameObject, TimeToDestroy);
	}
}
