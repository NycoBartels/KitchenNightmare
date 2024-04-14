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
            Triggered(); //RING THE ALLARM!
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "food")
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
            case "soupsoupsoupsoup":
                Spawny = soupsoupsoupsoup;
                SpawnAndDelete();
                break;
            case "soupsoupsoup":
                Spawny = soupsoupsoup;
                SpawnAndDelete();

                break;
            case "soupsoup":
                Spawny = soupsoup;
                SpawnAndDelete();
                break;



            case "heartheartliver":
                Spawny = twoheartsandaliver;
                SpawnAndDelete();
                break;
            case "heartliverheart":
                Spawny = twoheartsandaliver;
                SpawnAndDelete();
                break;
            case "liverheartheart":
                Spawny = twoheartsandaliver;
                SpawnAndDelete();
                break;



            case "ribsdrumstickbone":
                Spawny = meatsassortment;
                SpawnAndDelete();
                break;
            case "drumstickribsbone":
                Spawny = meatsassortment;
                SpawnAndDelete();
                break;
            case "bonedrumstickribs":
                Spawny = meatsassortment;
                SpawnAndDelete();
                break;
            case "drumstickboneribs":
                Spawny = meatsassortment;
                SpawnAndDelete();
                break;
            case "boneribsdrumstick":
                Spawny = meatsassortment;
                SpawnAndDelete();
                break;
            case "ribsbonedrumstick":
                Spawny = meatsassortment;
                SpawnAndDelete();
                break;

            case "drumsticksoup":
                Spawny = drumsticksoup;
                SpawnAndDelete();
                break;
            case "soupdrumstick":
                Spawny = drumsticksoup;
                SpawnAndDelete();
                break;




            default: Debug.Log("Incorrect combo: " + spawnstring); break;
        }
    }

    private void SpawnAndDelete()
    {
        //spawn item
        var newSpawn = Instantiate(Spawny, spawnpoint.position, Quaternion.identity);
        print(newSpawn + "Spawned!");
        //destroy the other items
        for (int i = 0; i < documentation.Count; i++)
        {
            Destroy(documentation[i].gameObject);
        }
        documentation.Clear();

    }
}
