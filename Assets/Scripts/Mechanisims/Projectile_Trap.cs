using UnityEngine;

public class Projectile_Trap : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] private float spawnTime;
    private float timer = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(projectile, transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= spawnTime)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            timer = 0;
        }
        
    }
}
