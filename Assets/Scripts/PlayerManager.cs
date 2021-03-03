using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Material PlayerMat;
    public PlayerState playerState;
    public LevelState levelState;

    public List<GameObject> collidedList;

    public Transform collectedPoolTransform;
    public enum PlayerState
    {
        Stop,
        Move,
        Attack
    }
    public enum LevelState
    {
        NotFinished,
        Finished
    }
 
}
