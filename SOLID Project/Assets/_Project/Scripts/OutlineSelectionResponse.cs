using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineSelectionResponse : MonoBehaviour, ISelectionResponse
{
    public void OnSelect(Transform selection)
    {
        if(selection != null)
        {
            var outline = selection.GetComponent<Outline>();
            if (outline != null) outline.OutlineWidth = 10;
        }

    }

    public void OnDeselect(Transform selection)
    {

        if(selection != null)
        {
            var outline = selection.GetComponent<Outline>();
            if (outline != null) outline.OutlineWidth = 0;
        }

    }
}
