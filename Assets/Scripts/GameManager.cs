using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayableDirector playableDirectorRejas, playableDirectorPuertas;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    [ContextMenu(nameof(Puzzle1))]
    public void Puzzle1 ()
    {
      playableDirectorRejas.Play ();
    }


    [ContextMenu(nameof(Puzzle2))]
    public void Puzzle2()
    {
        playableDirectorPuertas.Play();
    }
}
