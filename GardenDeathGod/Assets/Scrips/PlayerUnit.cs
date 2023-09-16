using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Entity
{
    [Header("Components")]
    [SerializeField]
    private GridManager gridManager;

    [Header("Settings")]
    [SerializeField]
    private int startPosX;
    [SerializeField]
    private int startPosY;

    [Header("States")]
    [SerializeField]
    private int currPosX;
    [SerializeField]
    private int currPosY;

    // Start is called before the first frame update
    private void Start()
    {
        MoveTo(startPosX, startPosY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveTo(int x, int y)
    {
        transform.position = gridManager.GetPosOfGrid(x, y);
        currPosX = x;
        currPosY = y;
    }
}
