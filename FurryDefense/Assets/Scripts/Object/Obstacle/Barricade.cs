using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BarricadeDir
{
    NORTH, SOUTH, EAST, WEST
}

public class Barricade : MonoBehaviour
{
    [SerializeField]
    private BarricadeDir _direction;
    private string _monsterTag = "Monster";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_monsterTag))
        {
            Monster monster = collision.GetComponent<Monster>();
            Vector3 dirPos = GetRandomDirection();
            monster.ChangeMoveDirection(dirPos);
        }
    }

    private Vector3 GetRandomDirection()
    {
        float beginAngle;
        float endAngle;
        switch (_direction)
        {
            case BarricadeDir.NORTH:
                beginAngle = 195;
                endAngle = 345;
                break;
            case BarricadeDir.SOUTH:
                beginAngle = 15;
                endAngle = 165;
                break;
            case BarricadeDir.EAST:
                beginAngle = 105;
                endAngle = 255;
                break;
            case BarricadeDir.WEST:
                beginAngle = 285;
                endAngle = 435;
                break;
            default:
                beginAngle = 0;
                endAngle = 0;
                break;
        }
        float randAngle = Random.Range(beginAngle, endAngle) * Mathf.Deg2Rad;
        //Debug.Log(randAngle);
        return new Vector3(Mathf.Cos(randAngle), Mathf.Sin(randAngle));
    }
}
