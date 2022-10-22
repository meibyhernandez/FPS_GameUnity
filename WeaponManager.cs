using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject PlayerCam;
    public float range = 100f;
    public float damageWeapon = 25f;

    public Animator playerAnimator; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerAnimator.GetBool("isShooting")){

            playerAnimator.SetBool("isShooting", false);
        
        }


        if (Input.GetButtonDown("Fire1"))
        {
            // Debug.Log("Shoot");
            Shoot();
            
        }
    }

    void Shoot()
    {
        playerAnimator.SetBool("isShooting", true);

        RaycastHit hit;

        if (Physics.Raycast(PlayerCam.transform.position, transform.forward, out hit, range))
        {
            //Debug.Log("Hit");
            Enemy_manager enemyManager = hit.transform.GetComponent<Enemy_manager>();   

            if(enemyManager != null)
            {
                enemyManager.Hit(damageWeapon);
            }
        }
    }
}
