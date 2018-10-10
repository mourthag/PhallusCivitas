using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Gamelogic
{
    public class LevelController : MonoBehaviour
    {

        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private List<Player> _players = new List<Player>();

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }

        public void Respawn(int playerId)
        {
            foreach (var player in _players)
            {
                if (player.PlayerId == playerId)
                {
                    player.transform.position = GetRespawnPosition();
                }
            }
        }


        private Vector3 GetRespawnPosition()
        {
            var respawnRect = _levelConfig.GetRespawnArea();
            var vec = new Vector3(Random.Range(respawnRect.xMin, respawnRect.xMax), Random.Range(respawnRect.yMin, respawnRect.yMax));
            return vec;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            var respawnArea = _levelConfig.GetRespawnArea();
            var topLeft = new Vector3(respawnArea.xMin, respawnArea.yMax);
            var topRight = new Vector3(respawnArea.xMax, respawnArea.yMax);
            var bottomLeft = new Vector3(respawnArea.xMin, respawnArea.yMin);
            var bottomRight = new Vector3(respawnArea.xMax, respawnArea.yMin);
            
            Gizmos.DrawLine(topLeft, topRight);
            Gizmos.DrawLine(topRight, bottomRight);
            Gizmos.DrawLine(bottomRight, bottomLeft);
            Gizmos.DrawLine(bottomLeft, topLeft);
        }

    }
}
