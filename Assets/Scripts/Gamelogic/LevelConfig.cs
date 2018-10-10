using UnityEngine;

namespace Gamelogic
{

    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Game/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {

        [SerializeField] private Rect _possibleRespawns;

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }

        public Rect GetRespawnArea()
        {
            return _possibleRespawns;
        }
    }
}
