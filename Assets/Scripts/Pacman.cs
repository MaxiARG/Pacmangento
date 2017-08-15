using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pacman : MonoBehaviour {
    public float speed;
    Vector3 direccion = Vector3.zero;
    public int lives;
    bool isHunter = false;
    int xAbs;
    int yAbs;
	int mXPos;
	int mYPos;
	enum DIR{izquierda,derecha,arriba,abajo,neutro,wall};
	DIR miDireccion;
	Vector3 dirSolicitada=Vector3.zero;

	void Start () {
		miDireccion = DIR.neutro;
		Mathf.Clamp(speed, 0f, 56f);
	}

    public void solicitarCambioDeDireccion(Vector3 direccionSolicitada){dirSolicitada = direccionSolicitada;}

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
		if (!tileDireccionSolicitadaEsValido (direccion)) 
			miDireccion = DIR.neutro;
		
	}
	public bool tileDireccionSolicitadaEsValido(Vector3 dir){	
		if (dir.x == 1)return Mapa.mapa [mYPos, mXPos+1] == 1;
		if (dir.x == -1)return Mapa.mapa [mYPos, mXPos-1] == 1;
		/////// EN Y///////
		if (dir.z == 1)return Mapa.mapa [mYPos-1, mXPos] == 1;
		if (dir.z == -1)return Mapa.mapa [mYPos+1, mXPos] == 1;

		return false;
	}
	private void actualizarCoordenadas(){
		if (alineadoEnX () && alineadoEnY ()) {
			mXPos = (int)Mathf.Abs (transform.position.x)/10;
			mYPos=(int) Mathf.Abs(transform.position.y)/10;
		}
	}

	private void move(){
		if (miDireccion != DIR.neutro)
			transform.Translate (direccion * speed *Time.deltaTime);
    }
	public Vector3 getPacmanPosition(){
		return new Vector3 (mXPos, mYPos, -4); //el -4 es porque es la posicion z de los enemigos
	}

	//USADO PARA SINCRONIZAR CON EL GRID.
	public bool alineadoEnY(){return (int) Mathf.Abs(transform.position.y)% 10 == 0;}
	public bool alineadoEnX(){return (int) Mathf.Abs(transform.position.x)% 10 == 0;}





	void Update () {
		actualizarCoordenadas ();
		accionarCambioDeDireccion ();
        move();
	}
}
