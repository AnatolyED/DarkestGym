using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for managing battle round actions
/// </summary>
public class RoundManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private int _round = 1;

    private void Start()
    {
        
    }

    #region Events
    /// <summary>
    /// Invokes when turn goes to another player
    /// </summary>
    public event System.Action OnNextRound;
    #endregion
}
