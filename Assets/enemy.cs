using UnityEngine;

public class enemy : MonoBehaviour
{
    public float hp = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("Enemy took " + damage + " damage.");
        hp-=damage;
        if (hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy died.");
        Destroy(gameObject);
    }
}
