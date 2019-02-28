using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Cell Behaviour/Cell Off")]
[RequireComponent(typeof(BoxCollider2D))]

public class Cells : MonoBehaviour
{
    [SerializeField] private GameObject _cellON;
    [SerializeField] private GameObject _cellCLICKED;
    [SerializeField] private GameObject _cellGREEN;
    [SerializeField] private GameObject _cellRED;

    public enum Status { SHIP, EMPTY, CLICKED }

    private string _ID; // Идентификатор
    private Status _status;
    private bool _preparationMode;

    // Задает начальные значения
    void Start()
    {
        _cellON?.SetActive(false);
        _cellCLICKED?.SetActive(false);
        _cellGREEN?.SetActive(false);
        _cellRED?.SetActive(false);
        _preparationMode = true;
        _status = Status.EMPTY;

        this.gameObject.SetActive(true);
    }

    // 
    void OnMouseOver()
    {        
        if (_status == Status.EMPTY && !_cellGREEN.activeSelf && _preparationMode)
        {
            _cellGREEN.SetActive(true);
        }
        else if (_status == Status.SHIP && !_cellRED.activeSelf && _preparationMode)
        {
            _cellRED.SetActive(true);
        }
        else if (!_cellON.activeSelf && !_preparationMode)
        {
            _cellON.SetActive(true);
        }
    }

    // 
    void OnMouseExit()
    {
        if (_cellON.activeSelf)
            _cellON.SetActive(false);
        else if (_cellGREEN.activeSelf)
            _cellGREEN.SetActive(false);
        else if (_cellRED.activeSelf)
            _cellRED.SetActive(false);
    }

    // Нажатие на клетку
    void OnMouseDown()
    {
        if (!_cellCLICKED.activeSelf)
        {
            _cellCLICKED.SetActive(true);
            Debug.Log(_ID);
        }
    }

    void OnMouseUp()
    {
        if (_cellCLICKED.activeSelf)
        {
            _cellCLICKED.SetActive(false);
        }
    }

    // Установить идентификатор
    public void setID(char ID1, char ID2) { _ID = ID1.ToString() + ID2.ToString(); }
    public void setID(string ID) { _ID = ID; }

    // Установить статус
    public void setStatus(Status status) { _status = status; }
    public void setStatus(int status) { _status = (Status)status; }
}
