using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class movement : MonoBehaviour
{
    public float forwardSpeed = 3f;
    public float horizontalSpeed = 2f;
    private Rigidbody rb;
    private PlatformSpawner platformSpawner;
    public GameObject explosionPrefab;
    public Score score;
    public GameManager gameManager;


    void Start()
    {


        rb = GetComponent<Rigidbody>();
        platformSpawner = FindObjectOfType<PlatformSpawner>();
        if (score == null)
        {
            score = FindObjectOfType<Score>();
        }
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * horizontalSpeed;

        rb.velocity = new Vector3(moveHorizontal, rb.velocity.y, rb.velocity.z);

        // ieskom pasvirimo kampa, kad padaryt speedup'a 
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            Vector3 slopeNormal = hit.normal;

            Vector3 slopeDirection = Vector3.Cross(Vector3.Cross(slopeNormal, Vector3.down), slopeNormal).normalized;

            rb.AddForce(slopeDirection * 9f, ForceMode.Acceleration);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FallZone")
        {
            Debug.Log("Mire");
            StartCoroutine(DeathSequence());
        }
    }
    IEnumerator DeathSequence()
    {

        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        foreach (Rigidbody rb in explosion.GetComponentsInChildren<Rigidbody>())
        {
            rb.AddExplosionForce(300f, transform.position, 50f);
            rb.AddForce(Random.insideUnitSphere * 3f, ForceMode.Impulse);
        }

        if (platformSpawner != null)
        {
            platformSpawner.enabled = false;

        }
        Camera.main.GetComponent<follow_camera>().enabled = false;

        Destroy(gameObject);

        if (score != null)
        {
            score.PlayerDied();
        }

        if (gameManager != null)
        {
            gameManager.PlayerDied();
        }

        yield return new WaitForSeconds(2f);

        Time.timeScale = 0;
    }

}
