using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CompositeSelectionResponse : MonoBehaviour, ISelectionResponse, IChangeable
{

    [SerializeField] private GameObject selectionResponseHolder;

    private List<ISelectionResponse> _selectionResponse;
    private int _currentIndex;
    private Transform _selection;

    private void Start()
    {
         var selectionResponses = selectionResponseHolder.GetComponents<ISelectionResponse>();

        _selectionResponse = selectionResponses.ToList();

    }

    [ContextMenu(itemName:"Next")]
    public void Next()
    {
        _selectionResponse[_currentIndex].OnDeselect(_selection);
        _currentIndex = (_currentIndex + 1) % _selectionResponse.Count;
        _selectionResponse[_currentIndex].OnSelect(_selection);
    }

    public void OnDeselect(Transform selection)
    {
        _selection = null;
        if (HasSelection()) 
        {
            _selectionResponse[_currentIndex].OnDeselect(selection);
        }

    }

    public void OnSelect(Transform selection)
    {
        _selection = selection;
        if (HasSelection())
        {
            _selectionResponse[_currentIndex].OnSelect(selection);
        }

    }

    private bool HasSelection()
    {
        return _currentIndex > -1 && _currentIndex < _selectionResponse.Count;
    }
}
