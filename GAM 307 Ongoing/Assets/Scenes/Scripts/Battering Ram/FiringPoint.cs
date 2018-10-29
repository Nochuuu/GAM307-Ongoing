using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour {

    public GameObject projectilePrefab;
	public GameObject projectileFire;
	public GameObject projectileIce;
	public GameObject projectileLightning;

    public GameObject firingPoint;


	public int fireCount = 10;
	public int iceCount = 10;
	public int lightningCount = 10;

	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
			FireWeapon ();
        }

        // Bit shift the index of the layer "MyCustomRaycastLayer" to get a bit mask
        // The ~ operator does this, it inverts a bitmask to collide against everything except layer "MyCustomRaycastLayer".
        int layerMask = 1 << LayerMask.NameToLayer("MyCustomRaycastLayer");
        layerMask = ~layerMask;
        
        float maxDistance = 100;
        Ray ray = new Ray(this.transform.position, Vector3.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            //Get info from our hitInfo regarding what the ray has hit
           // Debug.Log("We are hitting: " + hitInfo.collider.gameObject.name);
        }
    }


	public void ChangeWeapon(string weaponName)
	{
		if (weaponName == "Fire" && fireCount > 0) 
		{
			projectilePrefab = projectileFire;
			FireWeapon ();
			fireCount--;
		}
		if (weaponName == "Ice" && iceCount > 0)
		{
			projectilePrefab = projectileIce;
			FireWeapon ();
			iceCount--;
		}
		if (weaponName == "Lightning" && lightningCount > 0)
		{
			projectilePrefab = projectileLightning;
			FireWeapon ();
			lightningCount--;
		}
	}


	void FireWeapon()
	{
		GameObject projectileInstance;
		projectileInstance = Instantiate(projectilePrefab, firingPoint.transform.position, firingPoint.transform.rotation) as GameObject;
		projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.transform.forward * 1000);
		Destroy(projectileInstance, 5f);
	}

}
