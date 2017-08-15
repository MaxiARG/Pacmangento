using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehavior : MonoBehaviour {
	public float speed;
	Vector3 direccion = Vector3.zero;
	Vector3 targetTile= Vector3.zero; 
	public Pacman pacman;
	public bool alive;
    bool isHunter = true;
	int xPos;
	int yPos;
	enum DIR{izquierda,derecha,arriba,abajo,neutro};
	DIR miDireccion;
	Vector3 dirSolicitada=Vector3.zero;

	//Vector3 nextTileMasCorto;

	void Start () {
        miDireccion = DIR.neutro;
		targetTile = pacman.getPacmanPosition();
		Mathf.Clamp(speed, 0f, 56f);
	}
	//USADO PARA SINCRONIZAR CON EL GRID.
	public bool alineadoEnY(){return (int) Mathf.Abs(transform.position.y)% 10 == 0;}
	public bool alineadoEnX(){return (int) Mathf.Abs(transform.position.x)% 10 == 0;}

	private void actualizarCoordenadas(){
		if (alineadoEnX () && alineadoEnY ()) {
			xPos = (int) Mathf.Abs (transform.position.x)/10;
			yPos = (int) Mathf.Abs (transform.position.y)/10;
		}
	}
	private int calculateDistanceToPacmanFrom(Vector3 nextTile){
		return ((int)Vector3.Distance(pacman.getPacmanPosition(), nextTile));
    }
	private void calcularGiroDeDistanciaMasCorta(){
		int distanciaMasCorta = 999;

		Vector3 tIzquierda = new Vector3 (xPos-1, yPos,-4);
		Vector3 tDerecha = new Vector3 (xPos+1, yPos,-4);

		Vector3 tArriba = new Vector3 (xPos, yPos-1,-4);
		Vector3 tAbajo = new Vector3 (xPos, yPos+1,-4);

		if (tileDireccionSolicitadaEsValido (new Vector3(-1,0,0)) && miDireccion!=DIR.derecha) {
			if(calculateDistanceToPacmanFrom(tIzquierda)<distanciaMasCorta){
				distanciaMasCorta = calculateDistanceToPacmanFrom (tIzquierda);
				if (distanciaMasCorta == 0) {
					dirSolicitada = Vector3.zero;
				}else
				dirSolicitada = new Vector3 (-1, 0, 0);
			}
		}
		if (tileDireccionSolicitadaEsValido (new Vector3(1,0,0))&& miDireccion!=DIR.izquierda) {
			if(calculateDistanceToPacmanFrom(tDerecha)<distanciaMasCorta){
				distanciaMasCorta = calculateDistanceToPacmanFrom (tDerecha);
				dirSolicitada = new Vector3 (1, 0, 0);
			}
		}
		if (tileDireccionSolicitadaEsValido (new Vector3(0,0,1))&& miDireccion!=DIR.abajo) {
			if(calculateDistanceToPacmanFrom(tArriba)<distanciaMasCorta){
				distanciaMasCorta = calculateDistanceToPacmanFrom (tArriba);
				if (distanciaMasCorta == 0) {
					dirSolicitada = Vector3.zero;
				}else
					dirSolicitada = new Vector3 (0, 0,1);
			}
		}
		if (tileDireccionSolicitadaEsValido (new Vector3(0,0,-1)) && miDireccion!=DIR.arriba) {
			if(calculateDistanceToPacmanFrom(tAbajo)<distanciaMasCorta){
				distanciaMasCorta = calculateDistanceToPacmanFrom (tAbajo);
				if (distanciaMasCorta == 0) {
					dirSolicitada = Vector3.zero;
				}else
				dirSolicitada = new Vector3 (0, 0,-1);
			}
		}
		accionarCambioDeDireccion ();
	}
	public bool tileDireccionSolicitadaEsValido(Vector3 dir){	
		if (dir.x == 1)return Mapa.mapa [yPos, xPos+1] == 1;
		if (dir.x == -1)return Mapa.mapa [yPos, xPos-1] == 1;
		/////// EN Y///////
		if (dir.z == 1)return Mapa.mapa [yPos-1, xPos] == 1;
		if (dir.z == -1)return Mapa.mapa [yPos+1, xPos] == 1;

		return false;
	}
	public void accionarCambioDeDireccion(){
		bool solicitaMoverseEnX = dirSolicitada.x == 1 || dirSolicitada.x == -1;
		bool solicitaMovierseEnY = dirSolicitada.z == 1 || dirSolicitada.z== -1;

		if (solicitaMoverseEnX && alineadoEnY () && tileDireccionSolicitadaEsValido (dirSolicitada)) {
			direccion = dirSolicitada;
			if (dirSolicitada.x == 1)
				miDireccion = DIR.derecha;
			if (dirSolicitada.x == -1)
				miDireccion = DIR.izquierda;

		} 
		if (solicitaMovierseEnY && alineadoEnX () && tileDireccionSolicitadaEsValido (dirSolicitada)) {
			direccion = dirSolicitada;
			if (dirSolicitada.z == 1)
				miDireccion = DIR.arriba;
			if (dirSolicitada.z == -1)
				miDireccion = DIR.abajo;
		} 
		if (dirSolicitada == Vector3.zero) {
			miDireccion = DIR.neutro;
			direccion = Vector3.zero;
		}
		if (!tileDireccionSolicitadaEsValido (direccion)) 
			miDireccion = DIR.neutro;

	}
	private void move(){
        transform.Translate (direccion * speed * Time.deltaTime);
	}

	void Update () {
        actualizarCoordenadas();
        calcularGiroDeDistanciaMasCorta();
        move ();
	}
}
