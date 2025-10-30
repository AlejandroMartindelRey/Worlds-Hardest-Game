using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField]private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = new Vector3(0, 0, 10);

        gameObject.transform.eulerAngles += movementDirection * speed * Time.deltaTime;

        //gameObject.transform.position += movementDirection * speed*  Time.deltaTime;

    }
}
