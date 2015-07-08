using UnityEngine;
using System.Collections;

public class PlayerInformations : MonoBehaviour 
{

	public string name;
	public float stamina;
	public float speed;
	public bool male;

	public PlayerInformations(string name, float stamina, float speed, bool male)
	{
		this.name = name;
		this.stamina = stamina;
		this.speed = speed;
		this.male = male;
	}
}
