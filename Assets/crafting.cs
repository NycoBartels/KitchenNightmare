using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crafting : MonoBehaviour
{
    public GameObject[] checkbox;
    private string datacollection;





    public void Triggered()
    {
        //whipe previous string
        //add data from each box on which string is inside.
        //trigger spawner
    }

    private void Spawner(string input)
    {
        //yes its hardcoded ;_; shame on me

        switch (input)
        {
            case "soupsoupsoupsoup":
                // spawn soupsoupsoupsoup
                break;
            case "soupsoupsoup":
                // spawn soupsoupsoup
                break;
            case "soupsoup":
                // spawn soupsoup
                break;



            case "heartheartliver":
                // spawn twoheartsandaliver
                break;
            case "heartliverheart":
                // spawn twoheartsandaliver
                break;
            case "liverheartheart":
                // spawn twoheartsandaliver
                break;



            case "ribsdrumstickbone":
                // spawn twoheartsandaliver
                break;
            case "drumstickribsbone":
                // spawn twoheartsandaliver
                break;
            case "bonedrumstickribs":
                // spawn twoheartsandaliver
                break;
            case "drumstickboneribs":
                // spawn twoheartsandaliver
                break;
            case "boneribsdrumstick":
                // spawn twoheartsandaliver
                break;
            case "ribsbonedrumstick":
                // spawn twoheartsandaliver
                break;



            default: break;
        }
    }
}
