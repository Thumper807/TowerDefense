using UnityEngine;
using System.Collections;

public class tower : MonoBehaviour {

    Transform turretTransform;

    public float range = 10f;

    public GameObject bulletPrefab;
    public float damage = 1;
    public float radius = 0;

    float fireCooldown = 0.5f;
    float fireCooldownLeft = 0f;

    public int cost = 5;

	// Use this for initialization
	void Start () 
    {
        turretTransform = transform.Find("turret");
	}
	
	// Update is called once per frame
	void Update () 
    {
        enemy[] enemies = GameObject.FindObjectsOfType<enemy>();

        enemy nearestEnemy = null;
        float dist = Mathf.Infinity;

        foreach (enemy e in enemies)
        {
            float d = Vector3.Distance(this.transform.position , e.transform.position);

            if (d < range && (nearestEnemy == null || d < dist))
            {
                nearestEnemy = e;
                dist = d;
            }
        }

        if (nearestEnemy == null)
        {
            //Debug.Log("No enemies?");
            return;
        }

        Vector3 dir = nearestEnemy.transform.position - this.transform.position;

        Quaternion lookRot = Quaternion.LookRotation(dir);

        turretTransform.rotation = Quaternion.Lerp(turretTransform.rotation, lookRot, Time.deltaTime * 5);


        Debug.Log(Quaternion.Angle(lookRot, turretTransform.rotation).ToString());

        if (Quaternion.Angle(lookRot, turretTransform.rotation) < 1)
        {
            // close enough to shoot.
        }

        fireCooldownLeft -= Time.deltaTime;
        if (fireCooldownLeft <= 0 && dir.magnitude <= range && Quaternion.Angle(lookRot, turretTransform.rotation) < 25)
        {
            fireCooldownLeft = fireCooldown;
            ShootAt(nearestEnemy);
        }
	}

    private void ShootAt(enemy e)
    {
        Vector3 start = this.transform.position;
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, new Vector3(start.x, start.y + .5f, start.z), this.transform.rotation);

        Bullet b = bulletGO.GetComponent<Bullet>();
        b.target = e.transform;
        b.damage = damage;
        b.radius = radius;
    }
}
