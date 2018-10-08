using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entities;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _minCameraSize;
    [SerializeField] private float _maxCameraSize;
    [SerializeField] private Camera _camera;
    private Vector3 _centerposition;
    
	
	// Update is called once per frame
	void Update ()
	{
	    var players = FindObjectsOfType<Player>();
        _centerposition = Vector3.zero;
	    float maxDistance = 0;

	    for (var index = 0; index < players.Length; index++)
	    {
	        var player = players[index];
	        _centerposition += player.transform.position;

	        for (var i = index; i < players.Length; i++)
	        {
	            var otherPlayer = players[i];
	            var dist = Vector3.Distance(player.transform.position, otherPlayer.transform.position);

                if (dist > maxDistance)
                {
                    maxDistance = dist;
                }
	        }
	    }
	    if (players.Length > 0)
	    {
	        _centerposition = _centerposition / players.Length;
        }
        

	    var size = Mathf.Clamp( maxDistance / 2, _minCameraSize, _maxCameraSize);
	    _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, size, 0.1f);
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(_centerposition.x, 0, -10), .2f);


        //TODO: Restrict cameraposition to screen
	}

}
