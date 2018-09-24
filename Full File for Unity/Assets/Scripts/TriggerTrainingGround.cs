using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerTrainingGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("1_TrainingGround");
        }        
    }
}
