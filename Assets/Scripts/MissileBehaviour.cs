using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour
{
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MixedRealityPlayspace").transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody selfRB = GetComponent<Rigidbody>();
        selfRB.velocity = transform.forward * 3;

        Vector3 lookPos = player.transform.position - transform.position - new Vector3(0f, 0.125f, 0f); //CONSTANTLY UPDATES PLAYER POSITION
        Quaternion facerotation = Quaternion.LookRotation(lookPos);
        transform.rotation = facerotation;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerCollider") //LOSES HP IF COLLIDES WITH PLAYER
        {
            Destroy(gameObject);
            detector.doMissileDamage();
            if(detector.playerHealth <= 0) //STOPS IS PLAYER DIES
            {
                Application.Quit();
            }
        }
        else if (collision.gameObject.name == "Sheild") //NOTHING IF COLLIDES WITH SHEILD
        {
            Destroy(gameObject);
        } else //IGNORES COLLISIONS FROM SURROUNDINGS
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
