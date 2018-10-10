using System;
using Entities;
using UniRx;
using UnityEngine;

namespace Gamelogic
{ 
    public class PlayerHealth : MonoBehaviour
    {

        private bool _isInvincible;
        [SerializeField]private Player _player;

        private void Start()
        {
            _isInvincible = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(_isInvincible) return;

            var otherIdentifier = other.gameObject.GetComponent<TeamIdentifier>();
            if (!otherIdentifier) return;
            if (otherIdentifier.TeamId != _player.TeamId())
                _player.Die();
        }

        public void SetInvincible(bool value)
        {
            _isInvincible = value;
        }

        public void SetInvincible(float timespan)
        {
            _isInvincible = true;
            Observable.Timer(TimeSpan.FromSeconds(timespan)).Subscribe(_ => _isInvincible = false);
        }
    }
}
