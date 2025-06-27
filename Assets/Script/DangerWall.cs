using UnityEngine;

public class DangerWall : MonoBehaviour
{
	void OnCollisionEnter(Collision hit){
		if(hit.gameObject.CompareTag("Player")){
			GameController gameController = FindObjectOfType<GameController>();
			gameController.HitDangerWall();
		}
	}
	public float rotationSpeed = 100.0f;
	private void Update(){
		Vector3 currentRotation = transform.rotation.eulerAngles;

		currentRotation.z += rotationSpeed * Time.deltaTime;

		// currentRotation.x = 0;
		// currentRotation.z = 0;

		transform.rotation = Quaternion.Euler(currentRotation);
	}
}








































// using UnityEngine;
// using System.Collections;
// using UnityEngine.SceneManagement;

// public class DangerWall : MonoBehaviour
// {
// 	// オブジェクトと接触した時に呼ばれるコールバック
// 	void OnCollisionEnter (Collision hit)
// 	{
// 		// 接触したオブジェクトのタグが"Player"の場合
// 		if (hit.gameObject.CompareTag ("Player")) {

// 			// 現在のシーン番号を取得
// 			int sceneIndex = SceneManager.GetActiveScene().buildIndex;

// 			// 現在のシーンを再読込する
// 			SceneManager.LoadScene(sceneIndex);
// 		}
// 	}
// }