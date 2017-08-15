using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGhost : MonoBehaviour, Ghost{
    SteeringBehavior steeringBehavior;
    Pacman pacman;

    private int calculateDistanceToPacman()
    {
        return ((int)Vector3.Distance(pacman.getPacmanPosition(), gameObject.transform.position));
    }

    private void checkKill()
    {
        if (calculateDistanceToPacman() == 0) {

        }
    }


    void Start () {
        GameObject goPacman = GameObject.FindGameObjectWithTag("pacman");
        pacman = goPacman.GetComponent<Pacman>();
        steeringBehavior = gameObject.AddComponent<SteeringBehavior>();
        steeringBehavior.pacman = pacman;
        steeringBehavior.speed = 50;
        steeringBehavior.alive = true;

        GameObject plano = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plano.name = "RedGhost";
        plano.transform.rotation = Quaternion.Euler(-90,0,0);
        gameObject.transform.rotation = Quaternion.Euler(-90, 0, 0);
  
        gameObject.transform.position= new Vector3(260, -40, -4);
        //plano.transform.position = new Vector3(260, -50, -4);
        plano.transform.position = gameObject.transform.position;// new Vector3(260, -50, -4);

        plano.GetComponent<MeshRenderer>().material.color = Color.cyan;
        plano.transform.parent = transform;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
