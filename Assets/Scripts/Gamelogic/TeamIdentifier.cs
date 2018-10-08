using UnityEngine;

namespace Gamelogic
{
    public class TeamIdentifier : MonoBehaviour
    {

        [SerializeField] private int _teamId;

        public int GetTeamId()
        {
            return _teamId;
        }
    }
}
