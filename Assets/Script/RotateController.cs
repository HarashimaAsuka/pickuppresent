using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateController : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public float delayTime = 2.0f;
    public float cameraMoveSpeed = 1.0f;
    public Vector3 newCameraPosition = new Vector3(0, 0, 0);
    public Transform targetObject;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 初期化処理が必要な場合はここに追加
    }

    private void Update()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.y += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(currentRotation);

        if (Input.GetMouseButtonDown(0))
        {
            rotationSpeed = 400.0f;
            StartCoroutine(DelaydeSceneLoad("Select"));
        }
    }

    IEnumerator DelaydeSceneLoad(string sceneName)
    {
        Vector3 initialPosition = Camera.main.transform.position;
        Vector3 targetPosition = newCameraPosition;
        float elapsedTime = 0f;

        while (elapsedTime < delayTime)
        {
            float t = elapsedTime / delayTime;
            Camera.main.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

            if (targetObject != null)
            {
                Camera.main.transform.LookAt(targetObject);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Camera.main.transform.position = targetPosition;
        SceneManager.LoadScene(sceneName);
    }
}


























































// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class RotateController : MonoBehaviour
// {
//     public float rotationSpeed = 100.0f;
//     public float delayTime = 2.0f;
//     public float cameraMoveSpeed = 1.0f;
//     public Vector3 newCameraPosition = new Vector3(0,0,0);
//     public Transform targetObject;

//     private void OnEnable(){
//         SceneManager.sceneLoaded += OnSceneLoaded;
//     }

//     private void OnDisable(){
//         SceneManager.sceneLoaded -= OnSceneLoaded;
//     }

//     private void Start(){
//         InitializeScene();
//     }

//     private void OnSceneLoaded(Scene scene,LoadSceneMode mode){
//         InitializeScene();
//     }

//     void InitializeScene(){
//         // ここに初期化処理
//         rotationSpeed = 100.0f;
//         delayTime = 2.0f;
//         cameraMoveSpeed = 1.0f;
//         Vector3 newCameraPosition = new Vector3(0,0,0);
//     }

// 	private void Update(){
// 		Vector3 currentRotation = transform.rotation.eulerAngles;
// 		currentRotation.y += rotationSpeed * Time.deltaTime;
// 		transform.rotation = Quaternion.Euler(currentRotation);

//         if(Input.GetMouseButtonDown(0)){
//             rotationSpeed = 400.0f;
//             StartCoroutine(DelaydeSceneLoad("Select"));
//         }
// 	}

//     IEnumerator DelaydeSceneLoad(string sceneName){
//         Vector3 initialPosition = Camera.main.transform.position;
//         Vector3 targetPosition = newCameraPosition;
//         float elapsedTime = 0f;

//         while (elapsedTime < delayTime){
//             float t = elapsedTime / delayTime;
//             Camera.main.transform.position = Vector3.Lerp(initialPosition,targetPosition,t);

//             if(targetObject != null){
//                 Camera.main.transform.LookAt(targetObject);
//             }

//             elapsedTime += Time.deltaTime;
//             yield return null;
//         }
        
//         Camera.main.transform.position = targetPosition;

//         SceneManager.LoadScene(sceneName);
//     }
// }