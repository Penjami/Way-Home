using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMainScene : MonoBehaviour
{
    public void OnButtonPress() {
        Application.LoadLevel(1);
    }
}
