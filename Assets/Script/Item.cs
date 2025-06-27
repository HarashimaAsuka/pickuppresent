using UnityEngine;

public class Item : MonoBehaviour
{
	void OnTriggerEnter(Collider hit){
		if(hit.CompareTag("Player")){
			GameController gameController = FindObjectOfType<GameController>();
			gameController.CollectItem();
			Destroy(gameObject);
		}
	}

public float rotationSpeed = 100.0f;
	private void Update(){
		Vector3 currentRotation = transform.rotation.eulerAngles;

		currentRotation.y += rotationSpeed * Time.deltaTime;

		// currentRotation.x = 0;
		// currentRotation.z = 0;

		transform.rotation = Quaternion.Euler(currentRotation);
	}
}