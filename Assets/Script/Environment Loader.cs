using UnityEngine;

public class EnvironmentLoader : MonoBehaviour
{
    public GameObject Environment;
    public GameObject Layer1Background;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(Environment, Vector3.zero, Quaternion.identity);
        Instantiate(Layer1Background, new Vector3(0,0,-2), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
