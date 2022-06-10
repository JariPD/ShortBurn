using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour
{
    //[SerializeField] private LayerMask layerToHit;
    [Header("References")]
    [SerializeField] private GameObject beam;
    [SerializeField] private Prism prism;
    private ParticleSystem particle;

    [Header("Ray settings")]
    [SerializeField] private float rayDistance = 10;

    private RaycastHit hit;
    private float boilTimer = 0;
    private float burnTimer = 0;

    [Header("Beam cooldown settings")]
    [SerializeField] private float cooldown = 7.5f;
    [SerializeField] private float interval = 3;
    private float currentCooldown = 0;
    private bool shootBeam = true;

    void Update()
    {
        Vector3 origin = transform.position;                               //origin of the ray
        Vector3 direction = transform.TransformDirection(Vector3.up); //direction for the ray

        if (Input.GetKey(KeyCode.Mouse0) && shootBeam)
        {
            //startCooldown = true;

            currentCooldown += Time.deltaTime;

            if (currentCooldown >= cooldown)
                StartCoroutine(beamInterval());

            //turns on beam template
            beam.SetActive(true);

            //beam sound effect
            AudioManager.instance.Play("Beam");

            //play screenshake effect
            StartCoroutine(CameraShake.instance.Shake(0.15f, .025f));

            if (Physics.Raycast(origin, direction, out hit, rayDistance)) //draws a ray going forwards from the object
            {
                if (hit.transform.CompareTag("Brick") || hit.transform.CompareTag("DryRack"))
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

                        //gets audiosource with fire sfx
                        //hit.transform.GetComponent<AudioSource>().Play();

                        var pp = hit.transform.GetComponents<AudioSource>();
                        pp[0].Play();

                        //allows player to be launched
                        hit.transform.GetComponentInParent<BoilingPuzzle>().IsBoiling = true;

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

            //resets beam cooldown
            currentCooldown = 0;

            //stops playing beam sound effect
            AudioManager.instance.Stop("Beam");

            //turns off light beams from puzzle 2
            prism.ActivateLightBeams = false;
        }
    }

    IEnumerator beamInterval()
    {
        shootBeam = false;
        currentCooldown = 0;

        yield return new WaitForSeconds(interval);

        shootBeam = true;
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

