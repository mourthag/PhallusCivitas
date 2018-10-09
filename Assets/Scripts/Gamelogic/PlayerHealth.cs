using Entities;
using UnityEngine;

namespace Gamelogic
{
    [RequireComponent(typeof(Player))]
    public class PlayerHealth : MonoBehaviour
    {

        private bool _isInvincible;
        private Player _player;

        private void Start()
        {
            _player = GetComponent<Player>();
            _isInvincible = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(_isInvincible) return;

            var otherIdentifier = other.gameObject.GetComponent<TeamIdentifier>();
            if (!otherIdentifier) return;
            if (otherIdentifier.GetTeamId() != _player.TeamId())
                _player.Die();
        }
    }
}
