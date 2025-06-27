using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    private GameController gameController;

    void Start(){
        gameController = FindObjectOfType<GameController>();
    }

    void Update(){
        if(gameController != null && gameController.GameStarted()){
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal,0.0f, moveVertical);
            transform.Translate(movement * moveSpeed * Time.deltaTime,Space.World);

            transform.Rotate(0,rotationSpeed * Time.deltaTime,0);
        }    
    }
}
