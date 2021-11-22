using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] public Sprite defaultImage;
    [SerializeField] public Sprite highlightImage;

    public Image CursorPointImage;

    public void OnDeselect(Transform selection)
    {
        if(CursorPointImage != null)
        {
            CursorPointImage.sprite = defaultImage;
            CursorPointImage.transform.localScale = new Vector3(1, 1, 1);
            CursorPointImage.color = Color.red;
        }
    }

    public void OnSelect(Transform selection)
    {
        if(CursorPointImage != null)
        {
            CursorPointImage.sprite = highlightImage;
            CursorPointImage.transform.localScale = new Vector3(3, 3, 3);
            CursorPointImage.color = Color.blue;
        }
    }
}
