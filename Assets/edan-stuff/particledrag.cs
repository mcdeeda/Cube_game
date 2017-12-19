using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particledrag : MonoBehaviour {
    public PlayerMovement movement;
    public ParticleSystem particles;
	// Use this for initialization
	void Start () {
        particles.Stop();
	}
	
	// Update is called once per frame
	void Update () {
        if (movement.isOnWall)
        {
            if (movement.wallSide == "Left")
            {
                var sh = particles.shape;
                sh.position = new Vector3(-0.5f, 0, -0.2f);
                particles.Play();
            }
            if (movement.wallSide == "Right")
            {
                var sh = particles.shape;
                sh.position = new Vector3(0.5f, 0, -0.2f);
                particles.Play();
            }
        }
        else
        {
            particles.Stop();
        }
    }
    public void explodeCube()
    {
        var sh = particles.shape;
        sh.position = new Vector3(0, 0, 0);
        var em = particles.emission;
        em.rateOverTime = 10000;
        particles.Play();
    }
}
