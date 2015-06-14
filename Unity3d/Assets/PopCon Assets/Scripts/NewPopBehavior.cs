using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewPopBehavior : MonoBehaviour {
	public Transform PopPrefab;
	public KeyCode newKey = KeyCode.N;

	private InputField inputField;
	private CanvasRenderer[] renderers;
	private int newPopInd=0;

	private bool isInputMode = false;
	public bool IsInputMode{
		get{return isInputMode;}
	}

	void Start () {
		inputField = gameObject.GetComponent<InputField> ();
		//inputField.onEndEdit.AddListener (Submit);

		ArrayList l_renderers = new ArrayList ();

		foreach(var renderer in gameObject.GetComponentsInChildren<CanvasRenderer> ())
			l_renderers.Add(renderer);
		l_renderers.Add (gameObject.GetComponent<CanvasRenderer> ());
		renderers = l_renderers.ToArray (typeof(CanvasRenderer)) as CanvasRenderer[];
		SetVisible (false);
	}

	private bool SetVisible(bool visible){
		if (!visible)
			inputField.text = "";
		else
			inputField.ActivateInputField ();
		inputField.enabled = visible;
		foreach(var renderer in renderers)
			renderer.SetAlpha (visible ? 1f : 0f);
		return visible;
	}

	public Transform newPop(string name, string text, bool dupBelow=true){
		var newpos = Camera.main.GetComponent<MainCamBehavior> ().NewPopPosition;
		if (Physics.CheckSphere (newpos, 0.5f)) newpos.y+= (dupBelow?-1:1) * 1.5f;
		var i = 0;
		while (Physics.CheckSphere (newpos, 0.5f)) {
			i++;
			newpos += Camera.main.transform.right * (i % 2 - 0.5f) * 1.5f * i;
			print(Camera.main.transform.right);
			print ((i % 2 - 0.5f) * 1.5f * i);
			print(Camera.main.transform.right*(i % 2 - 0.5f) * 1.5f * i);
			print (newpos);
		}
		var pop = (Transform) Instantiate (PopPrefab, newpos, Quaternion.identity);
		pop.name = name;
		pop.Find ("PopName").GetComponent<TextMesh> ().text = text;

		return pop;
	}

	void Submit(string line){
		if (line.Trim() == "")
			return;
		var p = newPop("Pop" + (newPopInd++).ToString (), line.Trim ()).position;
		Application.ExternalCall ("newPop", line, p.x, p.y, p.z);
		//setVisible (isInputMode = false);
	}

	void Update () {
		if(Input.GetKeyDown (KeyCode.Return) && isInputMode && inputField.isActiveAndEnabled){
			Submit (inputField.text);
			SetVisible (isInputMode = false);
		}else if (Input.GetKeyDown (newKey) && !isInputMode) {
			SetVisible (isInputMode = true);
			inputField.ActivateInputField();
		} else if (Input.GetKeyDown (KeyCode.Escape)) {
			SetVisible (isInputMode = false);
		}
	}
}
