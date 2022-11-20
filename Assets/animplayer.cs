using UnityEngine;
using System.Collections;

public class animplayer : MonoBehaviour {

    public void startAudioInicio() { GameController.Instance.durningAnimacionInicio(); }
    public void endAudioInicio() { GameController.Instance.endAnimacionInicio(); }
    public void startAudioFin() { GameController.Instance.duringAnimacionFinal(); }

}
