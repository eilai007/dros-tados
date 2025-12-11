using UnityEngine;

public class shoot : MonoBehaviour
{
    public int pelletCount = 24;
    public float angle = 10f;
    public float damage = 10f;
    public float range = 10f;
    public float fireRate = 2f;

    public Transform firePoint;  

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + (1f / fireRate);
            Shoot();
        }
    }

    void Shoot()
    {
        for (int i = 0; i < pelletCount; i++)
        {
            ShootPellet();
        }
    }

    void ShootPellet()
    {
        Vector3 direction = GetRandomSpreadDirection(firePoint);
        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, direction, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawLine(firePoint.position, hit.point, Color.red, 1f);
            if (hit.transform.tag == "enemy")
            {
                
            }
        }
    }

    Vector3 GetRandomSpreadDirection(Transform firePoint)
    {
        float spreadRadius = Mathf.Tan(angle * Mathf.Deg2Rad);
        Vector2 randomPoint = Random.insideUnitCircle * spreadRadius;
    
        Vector3 direction = firePoint.forward + firePoint.up * randomPoint.y + firePoint.right * randomPoint.x;
        return direction.normalized;
    }
}