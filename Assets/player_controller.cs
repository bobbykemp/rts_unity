using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

	public Camera camera;

	public GameObject soldier;

	public Animator animator;

	bool can_move = true;

	void Start(){
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		animator.
		if(Input.GetMouseButtonDown(0)){
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit)){
				//Move our game object to the point that was hit
				Vector2 target = hit.point;

				if(can_move){
					//Debug.DrawLine (soldier.transform.position, target);
					StartCoroutine (Move (target));
				}
			}
		}
	}

	IEnumerator Move(Vector2 target){

		can_move = false;

		float speed = 1f;
		float step = speed * Time.deltaTime;

		while (Vector2.Distance(soldier.transform.position, target) > 0.05f) {
			soldier.transform.position = Vector2.MoveTowards (soldier.transform.position, target, step);

			yield return null;
		}

		Debug.Log ("Target reached");

		can_move = true;
	}
}
