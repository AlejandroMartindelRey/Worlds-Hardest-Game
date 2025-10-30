using UnityEngine;

public class Notes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [Header("My Stats")]
    [SerializeField] private int numberA = 5;
    [SerializeField]private string myName = "Alejandro";   
    [SerializeField]private char solutionFirPuzzle = 'X';

    [Header("Other Stats")]
    [SerializeField]private float numberWithDecimals = 3.3f;    
    [SerializeField]private bool poisioned = true;  
    [SerializeField] private int example = 3;

    private int randomNumer;

    private float randomFloatNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomNumer = Random.Range(0, 101);
        randomFloatNumber = Random.Range(0.5f, 50.8f); 
        Debug.Log(this.gameObject.name);
        
        // Transformations 
        this.gameObject.transform.position = new Vector3(10 ,5, 7);
        this.gameObject.transform.eulerAngles = new Vector3(30 ,45, 50);
        this.gameObject.transform.localScale = new Vector3(20, 20, 20);
    }

    // Update is called once per frame
    void Update()
    {
        // Gameobject moves along Y axis 1 unit / 3 second (Time.deltaTime = "Per second")
        this.gameObject.transform.position += new Vector3(0, 1, 0) * 3f * Time.deltaTime;
    }
    
}
