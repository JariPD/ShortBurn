using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private float rayDistance = 10;
    //[SerializeField] private LayerMask layerToHit;
    [SerializeField] private GameObject beam;
    [SerializeField] private Prism prism;

    private RaycastHit hit;
    private float boilTimer = 0;
    private float burnTimer = 0;

    void Update()
    {
        Vector3 origin = transform.position;                               //origin of the ray
        Vector3 direction = transform.TransformDirection(Vector3.up); //direction for the ray

        if (Input.GetKey(KeyCode.Mouse0))
        {
            beam.SetActive(true);

            //play screenshake effect
            StartCoroutine(CameraShake.instance.Shake(0.15f, .025f));

            if (Physics.Raycast(origin, direction, out hit, rayDistance)) //draws a ray going forwards from the object
            {
                //play beam vfx
                //beam template

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
                    boilTimer += Time.deltaTime;

                    if (boilTimer >= 3)
                    {
                        hit.transform.GetComponent<BoilingPuzzle>().LaunchPlayer = true;

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
            beam.SetActive(false);
            prism.ActivateLightBeams = false;
        }
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

