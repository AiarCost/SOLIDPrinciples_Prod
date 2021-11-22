﻿using UnityEngine;

public class SelectionManager : MonoBehaviour
{

    private IRayProvider _rayProvider;
    private ISelector _selector;
    private ISelectionResponse _selectionResponse;

    private Transform _currentSelection;

    private void Awake()
    {
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
        _selectionResponse = GetComponent<ISelectionResponse>();
    }
    private void Update()
    {
        //Deselection/Selection response
        if (_currentSelection != null)
        {
            _selectionResponse.OnDeselect(_currentSelection);
        }

        //Cereating a Ray
        var ray = _rayProvider.CreateRay();
        _selector.Check(ray);
        _currentSelection = _selector.GetSelection();

        //Deselection/Selection response
        if (_currentSelection != null)
        {
            _selectionResponse.OnSelect(_currentSelection);
        }
    }



}
