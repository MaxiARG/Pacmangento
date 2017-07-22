using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TileCreator : MonoBehaviour {

    public GameObject bloqueNegro;
	public GameObject bloquePurpura;
    public GameObject bloqueVioleta;
	int[,] mapa = Mapa.mapa;

    void Start () {
		spawnTiles();
    }

	void spawnTiles(){
		for (int Y = 0; Y <28; Y++) {

			for (int X = 0; X < 36; X++) {
				print (Y + " " + X);
				//yield return new WaitForSeconds(0.000001f);
				if (mapa[X,Y] == 2) {
					GameObject go = Instantiate(bloqueVioleta, new Vector2(Y * 10,-X*10), Quaternion.Euler(-90,0,0));
					go.transform.parent = this.transform; 
				}
				if (mapa[X,Y] == 4) {
					GameObject go = Instantiate(bloquePurpura, new Vector2(Y * 10,-X*10), Quaternion.Euler(-90,0,0));
					go.transform.parent = this.transform; 
				}

				if (mapa[X,Y] == 1){
					GameObject go=Instantiate(bloqueNegro, new Vector2(Y * 10,- X * 10), Quaternion.Euler(-90, 0, 0));
					go.transform.parent = this.transform;
				}
			}

		}
	}
	private void tilePrinter(){
		string fila=" ";
		for (int fil = 0; fil < 36; fil++) {
			print ("Fila " + fil);
			for (int col = 0; col < 28; col++) {
				fila += Mapa.mapa [fil, col];
			}
			print (fila);
			fila=" ";
		}
	}
}
