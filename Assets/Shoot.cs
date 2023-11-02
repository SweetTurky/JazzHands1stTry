using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPosition;

    public float bulletSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabablePistol = GetComponent<XRGrabInteractable>();
        grabablePistol.activated.AddListener(regularShot);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void regularShot(ActivateEventArgs arg)
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = spawnPosition.position;
        newBullet.GetComponent<Rigidbody>().velocity = spawnPosition.forward * bulletSpeed;

        Destroy(newBullet, 5);
    }

}
