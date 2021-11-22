using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public List<GameObject> ChangeableObjects;

    private List<IChangeable> _changeableObjects = new List<IChangeable>();

    private void Start()
    {
        for(int i = 0; i < ChangeableObjects.Count; i++)
        {
            var changeableObjects = ChangeableObjects[i].GetComponent<IChangeable>();
            _changeableObjects.Add(changeableObjects);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            for(int i = 0; i < _changeableObjects.Count; i++)
            {
                _changeableObjects[i].Next();
            }
        }
    }
}
