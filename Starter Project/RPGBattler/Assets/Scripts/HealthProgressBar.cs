using UnityEngine;
using System.Collections;

public class HealthProgressBar : MonoBehaviour {

	public ProgressBar healthBar;
	public Damageable damageableSprite;
		
	void Update () 
	{
		healthBar.setProgress(damageableSprite.health);	
	}
}
