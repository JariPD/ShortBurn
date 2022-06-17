using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour
{
    //[SerializeField] private LayerMask layerToHit;
    [Header("References")]
    [SerializeField] private GameObject beam;
    [SerializeField] private Prism prism;
    private ParticleSystem particle;
    private Animator anim;

    [Header("Ray settings")]
    [SerializeField] private float rayStartDistance = 1;
    [SerializeField] private float rayMaxDistance = 4;
    [SerializeField] private float raySpeed;
    private float rayTimer;

    private RaycastHit hit;
    private float boilTimer = 0;
    private float burnTimer = 0;

    [Header("Beam cooldown settings")]
    [SerializeField] private float cooldown = 7.5f;
    [SerializeField] private float interval = 3;
    private float currentCooldown = 0;
    private bool shootBeam = true;

    private bool allowCoroutine = true;
    private float currentRayDistance;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 origin = transform.position;                               //origin of the ray
        Vector3 direction = transform.TransformDirection(Vector3.forward); //direction for the ray

        if (Input.GetKey(KeyCode.Mouse0) && shootBeam)
        {
            if (allowCoroutine)
            {
                allowCoroutine = false;
                StartCoroutine(ShootBeam());
            }

            //starts timer that slowly increases raycast distance
            rayTimer += Time.deltaTime;

            //starts timer that keeps track for how long the beam has been fired
            currentCooldown += Time.deltaTime;

            //starts cooldown if beam is done shooting
            if (currentCooldown >= cooldown)
                StartCoroutine(beamInterval());

            currentRayDistance = Mathf.Lerp(rayStartDistance, rayMaxDistance, rayTimer / raySpeed);
            if (Physics.Raycast(origin, direction, out hit, currentRayDistance)) //draws a ray going forwards from the object
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

                        //starts coroutine that gets audiosource with fire and boiling sfx
                        StartCoroutine(StartSFX());

                        //allows player to be launched
                        hit.transform.GetComponentInParent<BoilingPuzzle>().IsBoiling = true;

                        boilTimer = 0;
                    }
                }

                if (hit.transform.CompareTag("Burnable") || hit.transform.CompareTag("Plant"))
                {
                    burnTimer += Time.deltaTime;

                    Mathf.Lerp(hit.transform.GetComponent<MeshRenderer>().material.color.a, 0, burnTimer);

                    if (burnTimer >= 2)
                    {
                        hit.transform.gameObject.SetActive(false);

                        burnTimer = 0;
                    }
                }

                if (hit.transform.CompareTag("Prism"))
                {
                    prism = hit.transform.GetComponentInChildren<Prism>();
                    prism.ActivateLightBeams = true;
                }
            }
            else
                prism.ActivateLightBeams = false;
        }
        else
        {
            //turns off light beams from puzzle 2
            prism.ActivateLightBeams = false;

            //sets animation state
            anim.SetBool("BeamActive", false);

            //turns off the beam
            beam.SetActive(false);

            //resets ray timer
            rayTimer = 0;

            //stops playing beam sound effect
            AudioManager.instance.Stop("Beam");

            allowCoroutine = true;
        }
    }

    IEnumerator ShootBeam()
    {
        //sets animation state
        anim.SetBool("BeamActive", true);

        yield return new WaitForSeconds(1.6f);

        //turns on beam
        beam.SetActive(true);

        //beam sound effect
        AudioManager.instance.Play("Beam");

        //play screenshake effect
        StartCoroutine(CameraShake.instance.Shake(0.15f, .025f));
    }

    IEnumerator beamInterval()
    {
        allowCoroutine = false;
        shootBeam = false;
        currentCooldown = 0;

        yield return new WaitForSeconds(interval);

        allowCoroutine = true;
        shootBeam = true;
    }

    IEnumerator StartSFX()
    {
        var sounds = hit.transform.GetComponents<AudioSource>();

        //plays fire sfx
        sounds[0].Play();

        yield return new WaitForSeconds(3);

        //plays boiling sfx
        sounds[1].Play();
    }

#if (UNITY_EDITOR)
    private void OnDrawGizmos()
    {
        Vector3 dir = transform.TransformDirection(Vector3.forward) * currentRayDistance;

        Gizmos.color = Color.cyan;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Gizmos.DrawRay(transform.position, dir);
        }
    }
#endif
}

