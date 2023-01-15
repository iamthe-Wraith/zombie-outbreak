using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

[Tooltip("Manages the player's hitpoints and alive state.")]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    private StarterAssetsInputs _startAssets;
    private GameOverMenu _gameOverMenu;
    private bool _isAlive = true;
    public bool IsAlive { get { return _isAlive; } }
    private float _startingHitPoints;

    private void Start()
    {
        _startAssets = GetComponent<StarterAssetsInputs>();
        _gameOverMenu = GameObject.FindGameObjectWithTag("GameSession").GetComponent<GameOverMenu>();
        _startingHitPoints = hitPoints;
    }

    public void Reset()
    {
        hitPoints = _startingHitPoints;
        _isAlive = true;
        SetStarterAssetsActive(_isAlive);
    }

    public void TakeDamage(float damage)
    {
        if (!_isAlive) return;

        hitPoints -= damage;

        // TODO: add animation for being hit.

        if (hitPoints <= 0)
        {
            ProcessDeath();
        }
    }

        private void ProcessDeath()
    {
        _isAlive = false;

        SetStarterAssetsActive(_isAlive);

        if (_gameOverMenu)
        {
            _gameOverMenu.Show();
        }
    }

    private void SetStarterAssetsActive(bool isActive)
    {
        if (_startAssets == null) return;

        if (isActive)
        {
            _startAssets.Enable();
        }
        else
        {
            _startAssets.Disable();
        }
    }
}
