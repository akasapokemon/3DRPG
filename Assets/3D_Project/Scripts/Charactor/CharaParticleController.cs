using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaParticleController : MonoBehaviour {

	public GameObject Player;
	ParticleSystem Particle;
	bool oneTime = false;


	void Start () {
		Particle = GetComponent<ParticleSystem> ();
	}


	void Update () {
		ParticlePlay ();
	}


	void ParticlePlay () {
		if (Player.GetComponent<CharaStatus> ().getHit) {
			if (oneTime == false) {
				Particle.Play ();
				oneTime = true;
			}
		} else {
			oneTime = false;
		}
	}

}
