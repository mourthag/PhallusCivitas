using UnityEngine;

namespace Gamelogic
{
    [RequireComponent(typeof(TeamIdentifier))]
    public class PlayerHealth : MonoBehaviour
    {

        private bool _isInvincible;
        private TeamIdentifier _identifier;

        private void Start()
        {
            _identifier = GetComponent<TeamIdentifier>();
            _isInvincible = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(_isInvincible) return;

            var otherIdentifier = other.gameObject.GetComponent<TeamIdentifier>();
            if (!otherIdentifier) return;
            if(otherIdentifier.GetTeamId() != _identifier.GetTeamId())
                Debug.Log("Ded");
        }
    }
}
