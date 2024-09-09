using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

//this scipt is used to make the camera rotate around the specified position to give a better view of the skybox
public class MainMenuCamera : MonoBehaviour
{
    [SerializeField] private Transform respect;
    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    public float cameraSpeed=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(respect.position, rotationAxis, cameraSpeed * Time.deltaTime);
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
