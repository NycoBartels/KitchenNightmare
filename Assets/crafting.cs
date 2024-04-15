using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class crafting : MonoBehaviour
{
    public GameObject checkbox;
    private string datacollection;
    private GameObject Spawny;
    private AudioSource _audio;
    [SerializeField] private ParticleSystem cookingVFX;
    [SerializeField]private Transform spawnpoint;
    private List<GameObject> documentation = new List<GameObject>();

    public string spawnstring;

    [SerializeField] private GameObject soupsoup;
    [SerializeField] private GameObject soupsoupsoup;
    [SerializeField] private GameObject soupsoupsoupsoup;
    [SerializeField] private GameObject drumsticksoup;
    [SerializeField] private GameObject twoheartsandaliver;
    [SerializeField] private GameObject meatsassortment;


    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        //check every second.
        //InvokeRepeating("Triggered", 0, 1f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "food")
        {
            Debug.Log("Triggered by: " + other.name);
            documentation.Add(other.gameObject);
            Debug.Log("Documentation now reads: ");
            foreach (GameObject o in documentation)
            {
                Debug.Log(o.name);
            }
            if (documentation.Count > 1) {
                Triggered(); //RING THE ALLARM!
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "food")
        {
            documentation.Remove(other.gameObject); 
        }
    }

    private void Triggered()
    {
        //whipe string
        spawnstring = "";

        //fill in right string
        for (int i = 0; i < documentation.Count; i++)
        {
            spawnstring += documentation[i].gameObject.name;
        }
        //trigger spawner
        Spawner(spawnstring);
    }




    private void Spawner(string input)
    {
        //yes its hardcoded ;_; shame on me

        switch (input)
        {
            // ALL THE SOUP SOUPS
            case "soupsoupsoupsoupsoupsoupsoupsoup":
                Spawny = soupsoupsoupsoup;
                SpawnAndDelete(input);
                break;
            case "soupsoupsoupsoup":
                Spawny = soupsoupsoup;
                SpawnAndDelete(input);

                break;
            case "soupsoup":
                Spawny = soupsoup;
                SpawnAndDelete(input);
                break;


            // TWO HEARTS AND LIVER
            case "heartheartliver":
                Spawny = twoheartsandaliver;
                SpawnAndDelete("twoheartsandaliver");
                break;
            case "heartliverheart":
                Spawny = twoheartsandaliver;
                SpawnAndDelete("twoheartsandaliver");
                break;
            case "liverheartheart":
                Spawny = twoheartsandaliver;
                SpawnAndDelete("twoheartsandaliver");
                break;


            // MEAT ASSORTMENT
            case "ribsdrumstickbone":
                Spawny = meatsassortment;
                SpawnAndDelete("assortmentofmeats");
                break;
            case "drumstickribsbone":
                Spawny = meatsassortment;
                SpawnAndDelete("assortmentofmeats");
                break;
            case "bonedrumstickribs":
                Spawny = meatsassortment;
                SpawnAndDelete("assortmentofmeats");
                break;
            case "drumstickboneribs":
                Spawny = meatsassortment;
                SpawnAndDelete("assortmentofmeats");
                break;
            case "boneribsdrumstick":
                Spawny = meatsassortment;
                SpawnAndDelete("assortmentofmeats");
                break;
            case "ribsbonedrumstick":
                Spawny = meatsassortment;
                SpawnAndDelete("assortmentofmeats");
                break;

            // DRUM STICK SOUP
            case "drumsticksoup":
                Spawny = drumsticksoup;
                SpawnAndDelete("drumsticksoup");
                break;
            case "soupdrumstick":
                Spawny = drumsticksoup;
                SpawnAndDelete("drumsticksoup");
                break;




            default: Debug.Log("Incorrect combo: " + spawnstring); break;
        }
    }

    private void SpawnAndDelete(string input)
    {
        //spawn item
        StartCoroutine(SpawnDelayed(input));
        //destroy the other items
        for (int i = 0; i < documentation.Count; i++)
        {
            Destroy(documentation[i].gameObject);
        }
        documentation.Clear();

    }
    private IEnumerator SpawnDelayed(string input) {
        var goToSpawn = Spawny;
        _audio.Play();
        cookingVFX.Play();
        yield return new WaitForSeconds(4.2f);
        var newSpawn = Instantiate(goToSpawn, spawnpoint.position, Quaternion.identity);
        newSpawn.gameObject.name = input;
        newSpawn.gameObject.tag = "food";
    }
}
