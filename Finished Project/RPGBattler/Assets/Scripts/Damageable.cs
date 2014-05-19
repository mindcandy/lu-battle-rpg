using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {

	public float health = 1.0f;
	public float timetoDisplayText = 1.0f;

	public void adjustHealth(float amount)
	{
		health = Mathf.Clamp(health + amount, 0.0f, 1.0f);
		if(amount < 0)
		{
			GetComponent<Animator>().SetTrigger("Hit");
  			showDamageText((amount * -100).ToString());
		}
		if(health == 0.0f)
		{
			Destroy(gameObject);
		}
	}

	private void showDamageText(string damage)
	{
		GetComponentInChildren<TextMesh>().text = damage;
		Invoke ("resetDamageText",timetoDisplayText);
	}

	void resetDamageText()
	{
		GetComponentInChildren<TextMesh>().text = "";
	}

}
