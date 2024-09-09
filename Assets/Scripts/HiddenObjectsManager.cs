using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HiddenObjectsManager : MonoBehaviour
{
   
    [SerializeField] public List<HiddenObject> hiddenObjects = new List<HiddenObject>();
    public int hiddenObjectsCount;

    public void Start()
    {
        ReloadList();
        hiddenObjectsCount = hiddenObjects.Count;
    }

    public void ReloadList()
    {
        hiddenObjects = FindObjectsByType<HiddenObject>(FindObjectsInactive.Exclude,FindObjectsSortMode.None).ToList();
    }
    
    public void InteractionHit()
    {
       HiddenObject.isInteracted = true;
    }
}
