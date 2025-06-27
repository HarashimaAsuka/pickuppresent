using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelController : MonoBehaviour
{
    public string sceneName;
    public GameObject objectToRotate;
    public float rotationSpeed = 360.0f;

    public void OnButtonPress()
    {
        StartCoroutine(RotateObjectAndChangeScene());
    }

    private IEnumerator RotateObjectAndChangeScene()
    {
        float rotationTime = 2.0f;
        float elapsedTime = 0.0f;

        while (elapsedTime < rotationTime)
        {
            if (objectToRotate != null)
            {
                objectToRotate.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}


















































// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class SelectLevelController : MonoBehaviour
// {
//    public string sceneName;
//    public GameObject objectToRotate;
//    public float rotationSpeed = 360.0f;

//    public void OnButtonPress(){
//     StartCoroutine(RotateObjectAndChangeScene());
//    }

//     private IEnumerator RotateObjectAndChangeScene(){
//         float rotationTime = 2.0f;
//         float elapsedTime = 0.0f;

//         while (elapsedTime < rotationTime){
//             if(objectToRotate != null){
//                 objectToRotate.transform.Rotate(Vector3.up,rotationSpeed * Time.deltaTime);
//             }
//             elapsedTime += Time.deltaTime;
//             yield return null;
//         }

//         SceneManager.LoadScene(sceneName);
//     }
// }
