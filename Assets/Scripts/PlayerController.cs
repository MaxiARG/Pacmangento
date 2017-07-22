using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Pacman pacman;
    private Vector3 direction=Vector3.zero;

	void Start () {
        pacman = GetComponent<Pacman>();
        if (pacman == null) print("Pacman es Null");
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            direction = new Vector3(1,0,0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = new Vector3(-1,0,0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = new Vector3(0,0,1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = new Vector3(0,0,-1);
        }
		pacman.solicitarCambioDeDireccion(direction);
      
    }
}
