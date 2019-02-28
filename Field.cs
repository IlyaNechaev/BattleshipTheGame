using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private GameObject prefabCell;
    private GameObject _cell;

    void Start()
    {
        int letter;
        int digit;
        float sizeX = 0.75f;
        float sizeY = 0.75f;
        float leftDownCornerX = this.gameObject.transform.position.x - (4.5f * sizeX);
        float leftDownCornerY = this.gameObject.transform.position.y - (4.5f * sizeY);

        float rightUpperCornerX = leftDownCornerX + 9 * sizeX;
        float rightUpperCornerY = leftDownCornerY + 9 * sizeX;

        digit = 49;
        for (float x = leftDownCornerX; x <= rightUpperCornerX; x += sizeX, digit += 1)
        {
            letter = 74;
            for (float y = leftDownCornerY; y <= rightUpperCornerY; y += sizeY, letter -= 1)
            {
                _cell = Instantiate(prefabCell) as GameObject;
                _cell.transform.position = new Vector3(x, y);
                Cells cell = _cell.gameObject.GetComponent<Cells>();
                cell.setID((char)letter, (char)digit);
                cell.setStatus(Cells.Status.EMPTY);
            }
        }

    }
}
