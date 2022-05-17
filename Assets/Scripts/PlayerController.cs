using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10f;
    public CharacterController controller;
    public Transform cam;
    public GameObject muzzleflash;
    private float fireRate = 50f;
    private float nexttimetofire;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        // Vector3 Movement = new Vector3(x, 0, z);
        // transform.Translate(Movement * -speed * Time.deltaTime);
        //if (Movement.magnitude >= 0.1f)
        //{
        //    float Angle = Mathf.Atan2(Movement.x, Movement.z) * Mathf.Rad2Deg;
        ////    ////    transform.rotation = Quaternion.Euler(0, Angle, 0);
        //Vector3 movDir = Quaternion.Euler(0, Angle, 0) * Vector3.forward;

        //}
        Fire();
    }
    void Fire()
    {
        RaycastHit hit;
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 100, Color.black);

        if (Input.GetMouseButton(0) && Time.time>=nexttimetofire)
        {
            nexttimetofire = Time.time + 1 / fireRate;
            muzzleflash.SetActive(true);
            StartCoroutine(Deactivate());
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
            {
                Instantiate(muzzleflash, hit.point, muzzleflash.transform.rotation);
                Damage dam = hit.transform.GetComponent<Damage>();
                if (dam != null)
                {
                    dam.damage(20);
                }
            }
        }

    }
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 Movement = transform.right * x + transform.forward * z;
        controller.Move(Movement * -speed * Time.deltaTime);
    }
    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(0.05f);
        muzzleflash.SetActive(false);
    }
}