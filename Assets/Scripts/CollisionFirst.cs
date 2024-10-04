using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionFirst : MonoBehaviour
{
    [SerializeField] float delaynextschene = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip failure;
    [SerializeField] ParticleSystem finishParticle;
    [SerializeField] ParticleSystem failParticle;
    

    AudioSource audioSoruce;
    ParticleSystem particle;
    bool control = false;
    bool crash = false;
    void Start()
    {
        audioSoruce = GetComponent<AudioSource>();
        particle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        KeyControl();
    }

    void KeyControl()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            AfterSceneLoad();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            crash = !crash;
        }
    }


    void StartGameAgain()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        //o an aktif olan sahneyi tekrardan baslatir.

    }

    void AfterSceneLoad()
    {
        int currentsceneload = SceneManager.GetActiveScene().buildIndex;
        int afterSceneload = currentsceneload + 1;
        if (afterSceneload == SceneManager.sceneCountInBuildSettings)
        {
            afterSceneload = 0;
            //burda en sonki sahneden sonra tekrar basa gitmek icin
            //aktif olan sahneden 1 sonraki sahnenin toplam sahne sayisina esit olup olmadigini kontrol ettik
        }
        SceneManager.LoadScene(afterSceneload);
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (control || crash)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartSuccess();
                break;
            default:
                StartFail();
                break;
        }
    }
    bool KeyDownisC()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            return true;
        }
        else { return false; }
    }
    void StartFail()
    {
        control = true;
        audioSoruce.PlayOneShot(failure);
        failParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("StartGameAgain", delaynextschene);

        //Invoke metodu sahne yenilenirken biraz bekler ve oyle yenilenir.
    }
    void StartSuccess()
    {
        control = true;
        audioSoruce.PlayOneShot(success);
        finishParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("AfterSceneLoad", delaynextschene);
    }
}
