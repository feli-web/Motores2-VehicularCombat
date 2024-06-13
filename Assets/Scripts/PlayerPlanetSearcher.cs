using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlanetSearcher : MonoBehaviour
{
    public Transform planetRed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = planetRed.position;
        targetPosition.z = transform.position.z; // Ensure the Z position is the same as the object's

        Vector3 direction = (targetPosition - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
