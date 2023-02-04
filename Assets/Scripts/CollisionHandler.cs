using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem explosionParticles;
    


    void OnTriggerEnter(Collider other)
    {
        PlayerCrash();
    }

    private void PlayerCrash()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        explosionParticles.Play();
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadScene", loadDelay);
    }

    void ReloadScene(){
        int thisScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(thisScene);
    }

}
