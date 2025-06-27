using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageController : MonoBehaviour
{
   public string sceneName;

   public void GoToNextScene(){
        SceneManager.LoadScene(sceneName);
    }


}
