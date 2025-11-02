using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private int speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

  
}
