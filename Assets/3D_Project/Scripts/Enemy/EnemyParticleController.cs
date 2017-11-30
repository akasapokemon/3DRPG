using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticleController : MonoBehaviour {

	public GameObject Enemy;
	ParticleSystem Particle;
	bool oneTime = false;

	// Use this for initialization
	void Start () {

		Particle = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {

		ParticlePlay ();
	}

	void ParticlePlay () {
		if (Enemy.GetComponent<EnemyStatus> ().getHit) {
			if (oneTime == false) {
				Particle.Play ();
				oneTime = true;
			}
		} else {
			oneTime = false;
		}
	}
}
