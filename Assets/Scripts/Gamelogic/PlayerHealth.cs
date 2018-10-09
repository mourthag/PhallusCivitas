using Entities;
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
    }
}
