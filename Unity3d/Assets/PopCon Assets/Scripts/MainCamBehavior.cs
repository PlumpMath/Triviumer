using UnityEngine;
using System.Collections;

public class MainCamBehavior : MonoBehaviour {

	private KeyCode[] keys = {KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.S, KeyCode.R, KeyCode.F};
	private Vector3[] moves = {Vector3.left, Vector3.right, Vector3.forward, Vector3.back, Vector3.up, Vector3.down};
	private KeyCode[] rotateKeys = {KeyCode.Q, KeyCode.E};
	private Vector3[] rotateMoves = {Vector3.down, Vector3.up}; //down = left turn, up = right turn

	private float newPopDistance;
	public float NewPopDistance{ get { return newPopDistance; } }
	public Vector3 NewPopPosition { get { return ghostTransform.position; } }// transform.position + transform.forward * newPopDistance;}}
	private NewPopBehavior newPopBehavior;
	private ModPopBehavior modPopBehavior;
	private Transform ghostTransform;
	public float turnSpeed = 30f;
	public float moveSpeed = 50f;
	void Start () {
		newPopDistance = transform.FindChild ("GhostPopSphere").localPosition.magnitude;
		newPopBehavior = GameObject.Find ("InputField").GetComponent<NewPopBehavior> ();
		modPopBehavior = GameObject.Find ("GameObject").GetComponent<ModPopBehavior> ();
		ghostTransform = GameObject.Find ("GhostPopSphere").transform;
	}
	private Collider focusedObj = null;
	public Collider FocusedObj{ get { return focusedObj; } }
	void Update () {
		if (newPopBehavior.IsInputMode)
			return;
		/*if (modPopBehavior.Grabbed != null) {
			modPopBehavior.Grabbed.transform.parent = transform;
			var c = ghostTransform.GetComponent<Renderer> ().material.color;
			c.a = 0f;
			ghostTransform.GetComponent<Renderer> ().material.color = c;
		} else {
			modPopBehavior.Grabbed.transform.parent = null;
			var c = ghostTransform.GetComponent<Renderer> ().material.color;
			c.a = .47f;
			ghostTransform.GetComponent<Renderer> ().material.color = c;
		}*/
		// free move in space
		for (int i = 0; i < keys.Length; i++)
			if (Input.GetKey (keys [i]))
				transform.Translate (moves [i] * moveSpeed);//new Vector3 (moves[i, 0] / 2f, moves[i, 1] / 2f));
		// turn around
		for (int i = 0; i < rotateKeys.Length; i++)
			if (Input.GetKey (rotateKeys [i]))
				transform.RotateAround (transform.position + transform.forward * newPopDistance, rotateMoves [i], 100 * Time.deltaTime * turnSpeed);

		if (Physics.CheckSphere (ghostTransform.position, 0.55f)) {
			var objs = Physics.OverlapSphere (ghostTransform.position, 0.55f);
			var obj = objs[0];
			var minDis = (obj.transform.position - ghostTransform.position).sqrMagnitude;
			foreach(Collider c in objs){
				var dis = (c.transform.position-ghostTransform.position).sqrMagnitude;
				if(dis < minDis){
					obj = c;
					minDis = dis;
				}
			}
			
			obj.GetComponent<MeshRenderer> ().material.color = new Color (0.5f, 0, 0);
			if(focusedObj && focusedObj!=obj)
				focusedObj.GetComponent<MeshRenderer> ().material.color = new Color (1, 1, 1);
			focusedObj = obj;
		} else if (focusedObj) {
			focusedObj.GetComponent<MeshRenderer> ().material.color = new Color (1, 1, 1);
			focusedObj = null;
		}
	}
	public void GoTo(string arg){
		var args = arg.Split (',');
		var x = float.Parse (args [0]);
		var y = float.Parse (args [1]);
		var z = float.Parse (args [2]);
		transform.position = new Vector3(x,y,z) - ghostTransform.localPosition;
	}

}