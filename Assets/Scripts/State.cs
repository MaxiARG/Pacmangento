using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State {

    void execute();
    void enter();
    void exit();
}
