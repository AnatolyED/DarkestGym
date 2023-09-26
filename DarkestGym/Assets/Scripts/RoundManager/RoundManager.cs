using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for managing battle round actions
/// </summary>
public class RoundManager : MonoBehaviour
{
    /// <summary>
    /// Invokes when turn goes to another player
    /// </summary>
    public event System.Action OnNextRound;
}
