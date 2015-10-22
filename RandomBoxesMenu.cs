using UnityEngine;
using System.Collections;

public class RandomBoxesMenu : MonoBehaviour {

	public GameObject Box1;
	public GameObject Box2;

	public Animator BoxAnim;
	public Animator Box2Anim;
	
	IEnumerator BoxLooping(){

		//activate animation
		BoxAnim.SetTrigger("Fade");
		Vector2 Scale = Box1.transform.localScale;
		Scale.x = Random.Range(0.3f, 0.5f);
		Scale.y = Scale.x;
		Box1.transform.localScale = Scale;
		
		Box2Anim.SetTrigger("Fade2");
		Vector2 Scale2 = Box2.transform.localScale;
		Scale2.x = Random.Range(0.3f, 0.5f);
		Scale2.y = Scale2.x;
		Box2.transform.localScale = Scale2;

		yield return new WaitForSeconds(1.2f);
		StartCoroutine(BoxLooping());
		
	}
	
	// Update is called once per frame
	void Start () {
		StartCoroutine(BoxLooping());
	}
}
