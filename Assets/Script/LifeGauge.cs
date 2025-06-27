using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{
    public static LifeGauge Instance;

    public Image[]heartImages;

    void Awake(){
        if(Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    public void UpdateHearts(int remainingHearts){
        for(int i = 0; i < heartImages.Length; i++){
           heartImages[i].enabled = i < remainingHearts;
        }
    }
}
