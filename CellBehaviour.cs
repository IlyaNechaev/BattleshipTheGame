using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _cellON;
    [SerializeField] private GameObject _cellOFF;
    [SerializeField] private GameObject _cellNot;

    public enum Status { SHIP, EMPTY, CLICKED, TEST }

    private string _ID; // Идентификатор
    private Status _status;

    void Start()
    {
        _cellNot.gameObject.SetActive(false);
    }

    void OnMouseOver()
    {
        if (_cellOFF.activeSelf && _status != Status.CLICKED)
            _cellOFF.SetActive(false);
    }

    void OnMouseExit()
    {
        if (!_cellOFF.activeSelf && _status != Status.CLICKED)
            _cellOFF.SetActive(true);
    }

    void OnMouseDown()
    {
        if (_cellON.activeSelf && _status != Status.CLICKED)
            _cellON.SetActive(false);
    }

    void OnMouseUp()
    {
        switch (_status)
        {
            case Status.SHIP:
                _cellNot.gameObject.SetActive(true);
                _status = Status.CLICKED;
                break;
            case Status.EMPTY:
                _cellON.gameObject.SetActive(true);
                _status = Status.CLICKED;
                break;
        }
    }

    // Установить идентификатор
    public void setID(char ID1, char ID2) { _ID = ID1.ToString() + ID2.ToString(); }
    public void setID(string ID) { _ID = ID; }

    // Установить статус
    public void setStatus(Status status) { _status = status; }
    public void setStatus(int status) { _status = (Status)status; }
}
