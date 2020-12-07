using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float gravity = -10;

    public void Attract(Transform body)
    {
        Vector3 gravityUp = (body.position-transform.position).normalized;//vector pointing to center of planet
        Vector3 bodyUp = body.up;//vector pointing up of the object we control

        body.GetComponent<Rigidbody>().AddForce(gravityUp*gravity);//force pointing to the center of the planet

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp,gravityUp)*body.rotation;//calculation for rotation to be made
        body.rotation = Quaternion.Slerp(body.rotation,targetRotation,50*Time.deltaTime);//rotating the player 

    }
}
