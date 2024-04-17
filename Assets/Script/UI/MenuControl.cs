using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    //[SerializeField] private int _delay;

    [SerializeField] private Canvas _mineMenu;
    [SerializeField] private Canvas _gameplay;

    [SerializeField] private Game _game;

    public void StartGame()
    {
        _mineMenu.gameObject.SetActive(false);
        _gameplay.gameObject.SetActive(true);
        _game.StartGame();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
