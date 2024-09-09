using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObject : MonoBehaviour
{
    public static bool isInteracted = false;
    [SerializeField] public static bool onObject = false;
    public bool onThisObject = false;
    public Material mat;
    public HiddenObjectsManager manager;
    private Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<HiddenObjectsManager>();
        originalColor = mat.color;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (onObject)
        {
            if (onThisObject)
            {
                mat.color = Color.Lerp(Color.white, Color.yellow, 0.5f);
                if(isInteracted)
                {
                    mat.color = Color.white;
                    ItemFound();
                }
            }
            else
            {
                mat.color = Color.white;
            }
        }
        else
        {
            onThisObject = false;
            mat.color = Color.white;
        }
        if(isInteracted && !onObject)
        {
            isInteracted=false;
        }
    }
    
    public void CSEnter()
    {
        onObject = true;
        onThisObject = true;
        Debug.Log("An Object is in the crosshair");
    }

    public void ItemFound()
    {
        mat.color = Color.white;
        /*
        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        */
        onThisObject=false;
        onObject=false;
        Destroy(gameObject);
        Debug.Log("Item Found!");
        manager.ReloadList();
    }
    
    
}
