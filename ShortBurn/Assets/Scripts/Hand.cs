using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private float rayDistance = 10;
    //[SerializeField] private LayerMask layerToHit;
    [SerializeField] private GameObject beam;
    [SerializeField] private Prism prism;

    private RaycastHit hit;
    private ParticleSystem particle;
    private float boilTimer = 0;
    private float burnTimer = 0;

    private float cooldown = 0;
    private float interval = 3;

    void Update()
    {
        Vector3 origin = transform.position;                               //origin of the ray
        Vector3 direction = transform.TransformDirection(Vector3.up); //direction for the ray

        if (Input.GetKey(KeyCode.Mouse0) && cooldown <= 0)
        {
            cooldown += Time.deltaTime;

            if (cooldown >= 8.5)
            {
                StartCoroutine(beamInterval());
            }

            //turns on beam template
            beam.SetActive(true);

            //beam sound effect
            AudioManager.instance.Play("Beam");

            //play screenshake effect
            StartCoroutine(CameraShake.instance.Shake(0.15f, .025f));

            if (Physics.Raycast(origin, direction, out hit, rayDistance)) //draws a ray going forwards from the object
            {
                //play beam vfx

                if (hit.transform.CompareTag("Plank"))
                    hit.transform.GetComponent<PlankPuzzle>().MoveObject = true;

                if (hit.transform.CompareTag("Brick"))
                    hit.transform.gameObject.GetComponent<MoveObjectPuzzle>().MoveObject = true;

                if (hit.transform.CompareTag("DryRack"))
                    hit.transform.GetComponent<MoveObjectPuzzle>().MoveObject = true;

                if (hit.transform.CompareTag("Rope"))
                {
                    burnTimer += Time.deltaTime;

                    if (burnTimer >= 2)
                    {
                        hit.transform.GetComponentInParent<WindowPuzzle>().CloseWindow = true;

                        burnTimer = 0;
                    }
                }

                if (hit.transform.CompareTag("Kettle"))
                {
                    particle = hit.transform.GetComponentInChildren<ParticleSystem>();

                    boilTimer += Time.deltaTime;

                    if (boilTimer >= 3)
                    {
                        //play fire particle
                        particle.Play();

                        //allows player to be launched
                        hit.transform.GetComponent<BoilingPuzzle>().IsBoiling = true;

                        boilTimer = 0;
                    }
                }

                if (hit.transform.CompareTag("Burnable"))
                {
                    burnTimer += Time.deltaTime;

                    if (burnTimer >= 2)
                    {
                        hit.transform.gameObject.SetActive(false);

                        burnTimer = 0;
                    }
                }

                if (hit.transform.CompareTag("Prism"))
                {
                    prism = hit.transform.GetComponent<Prism>();
                    prism.ActivateLightBeams = true;
                }
            }
            else
                prism.ActivateLightBeams = false;
        }
        else
        {
            //turns off the beam
            beam.SetActive(false);

            //stops playing beam sound effect
            AudioManager.instance.Stop("Beam");

            //turns off light beams from puzzle 2
            prism.ActivateLightBeams = false;
        }
    }

    IEnumerator beamInterval()
    {
        yield return new WaitForSeconds(interval);

        cooldown = 0;
    }

#if (UNITY_EDITOR)
    private void OnDrawGizmos()
    {
        Vector3 dir = transform.TransformDirection(Vector3.up) * rayDistance;

        Gizmos.color = Color.cyan;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Gizmos.DrawRay(transform.position, dir);
        }
    }
#endif
}

