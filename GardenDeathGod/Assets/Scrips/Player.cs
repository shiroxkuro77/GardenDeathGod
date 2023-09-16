using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Player : Entity
{
    private enum PlayerState { IDLE, SELECTING };
    [Header("States")]
    [SerializeField]
    private PlayerState playerState;

    private void Update()
    {
        switch (playerState)
        {
            case PlayerState.IDLE:
                break;
            case PlayerState.SELECTING:
                
                break;
        }
    }
}
