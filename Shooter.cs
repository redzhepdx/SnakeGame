using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	
	public int MachineGunAmmoCount = 20;

	private bool isReloading = false; //Reloading gun 

	private float reloadTime = 1.5f; //Reload time of gun

	private float MachineGunFireRate = 0.1f;//MachineGuns fire speed
	private float MachineGunNextFire = 0f;//MachineGuns next fire time

	public enum Gun{MachineGun};

	[HideInInspector]
	public Transform FocusBombTarget;

	[HideInInspector]
	public int power;

	[HideInInspector]
	public int Damage;

	public Gun gun = Gun.MachineGun;

	//Reference to AudioClip to play
	public AudioClip shootVoice;

	AudioSource clip;

	void Awake()
	{
		power = 150;
		Damage = 3;
	}

	void Update()
	{

		while (Input.GetKey(KeyCode.Mouse0) && Time.time >= MachineGunNextFire && !isReloading)
		{
			MachineGunNextFire = Time.time + MachineGunFireRate;

			GameObject MachineGunAmmo = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;

			// if the projectile does not have a rigidbody component, add one
			if (!MachineGunAmmo.GetComponent<Rigidbody>())
			{
				MachineGunAmmo.AddComponent<Rigidbody>();
			}
			// Apply force to the newProjectile's Rigidbody component if it has one
			MachineGunAmmo.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);

			MachineGunAmmoCount--;

			//Check For Ammo Count
			if (MachineGunAmmoCount <= 0)
			{
				isReloading = true;
				Invoke("ReloadGun", reloadTime * 2);
			}
		}
	}

	void ReloadGun()
	{
		isReloading = false;
		MachineGunAmmoCount = 20;
	}
}

