using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
   public GameObject resetCanvas;

   public void OnClickButton(){
    resetCanvas.gameObject.SetActive(true);
    Time.timeScale = 0f;
   }
}
