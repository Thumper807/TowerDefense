using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed = 15f;
    public Transform target;
    public float damage = 1f;
    public float radius = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (target == null)
        {
            // Enemy must have died.
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distThisFrame)
        {
            //we reached the target
            DoBulletHit();
        }
        else
        {
            //move towards target
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetRotation =  Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);

        }	
	}


    private void DoBulletHit()
    {
        if (radius == 0)
        {
            target.GetComponent<enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider c in cols)
            {
                enemy e = c.GetComponent<enemy>();
                if (e != null)
                {
                    e.TakeDamage(damage);
                    //e.GetComponent<enemy>().TakeDamage(damage);
                }
            }
        }

        // Get rid of bullet.
        Destroy(gameObject);
    }
}
