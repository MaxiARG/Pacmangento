using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour {

    List<Ghost> listaDeFantasmas;

    private void Start(){
        listaDeFantasmas = new List<Ghost>();
    }

    private void Update() {
        if (listaDeFantasmas.Count < 1) {
           // spawnGhost
        }
    }

    public void spawnGhost(GhostType type)
    {
        switch (type)
        {
            case (GhostType.Rojo):
                break;
            case (GhostType.Purpura):
                break;
        }
    }
}
