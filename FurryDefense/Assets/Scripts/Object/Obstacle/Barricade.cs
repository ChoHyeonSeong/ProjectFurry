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
    private BarricadeDir _dir;
    private string _monsterTag = "Monster";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger enter");
        if (collision.CompareTag(_monsterTag))
        {
            Monster monster = collision.GetComponent<Monster>();
            Vector3 dir = GetRandomDirection();
            Debug.Log(dir);
            monster.ChangeMoveDirection(dir);
        }
    }

    private Vector3 GetRandomDirection()
    {
        float beginAngle;
        float endAngle;
        switch (_dir)
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
                beginAngle = 285;
                endAngle = 435;
                break;
            case BarricadeDir.WEST:
                beginAngle = 105;
                endAngle = 255;
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
