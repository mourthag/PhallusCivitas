using System.Collections;
using System.Collections.Generic;
using Gamelogic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour
{

    [SerializeField] private Vector3 _projectileSpeed;

    public void SetSpeed(Vector3 projectileSpeed)
    {
        _projectileSpeed = projectileSpeed;
    }
	
	// Update is called once per frame
	void Update ()
	{

	    transform.position +=  _projectileSpeed * Time.deltaTime;

	}
}
