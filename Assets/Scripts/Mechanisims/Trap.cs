using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 iniDirection;
    [SerializeField] private int timeChangeDirection;
    
    private Vector3 currentDirection;
    
    
    private float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentDirection = iniDirection;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= timeChangeDirection)
        {
            currentDirection *= -1;
            timer = 0;
        }
        else
        {
            transform.Translate(currentDirection * speed * Time.deltaTime);
        }
       
    }
}
