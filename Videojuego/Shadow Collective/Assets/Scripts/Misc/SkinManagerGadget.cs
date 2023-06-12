/*
    Script that handles the gadget selection for the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Networking;

public class SkinManagerGadget : MonoBehaviour
{
    [SerializeField] public SpriteRenderer sr;
    private List<Sprite> skins = new List<Sprite>();
    private List<ShortGadget> gadgetsToChoose;
    private List<ShortGadget> activeGadgets = new List<ShortGadget>();
    private int selectedSkin = 0;

    public void Start()
    {
        // pupulate gadgets to choose depending on the class
        switch (PlayerPrefs.GetInt("player_type_number"))
        {
            case 1: // cybergladiator
                gadgetsToChoose = new List<ShortGadget> {new ShortGadget(1), new ShortGadget(2), new ShortGadget(3)};
                break;

            case 2: // codebreaker
                gadgetsToChoose = new List<ShortGadget> {new ShortGadget(4), new ShortGadget(5), new ShortGadget(6)};
                break;

            case 3: // ghostwalker
                gadgetsToChoose = new List<ShortGadget> {new ShortGadget(7), new ShortGadget(8), new ShortGadget(9)};
                break;

            default: // we shouldn't reach here
                gadgetsToChoose = new List<ShortGadget> {new ShortGadget(1), new ShortGadget(2), new ShortGadget(3)};
                break;
        }

        // get the active gadgets from player prefs
        string jsonActiveGadgets = PlayerPrefs.GetString("gadgets");
        if (jsonActiveGadgets != "")
        {
            ShortGadgetList shortGadgetList = JsonUtility.FromJson<ShortGadgetList>(jsonActiveGadgets);

            activeGadgets = shortGadgetList.gadgets;


            foreach (ShortGadget activeGadget in activeGadgets)
            {
                print("ActiveGadget: " + activeGadget.gadget_id);
                foreach (ShortGadget gadget in gadgetsToChoose)
                {
                    if (activeGadget.gadget_id == gadget.gadget_id)
                    {
                        gadgetsToChoose.Remove(gadget);
                        break;
                    }
                }
            }
        }

        // populate the skins list
        foreach (ShortGadget gadget in gadgetsToChoose)
        {
            print("to chose: " + gadget.gadget_id);
            skins.Add(Resources.Load<Sprite>("GadgetSprites/" + gadget.gadget_id));
        }

        print("skins count: " + skins.Count); 
        sr.sprite = skins[selectedSkin];
    }

    public void NextOption()
    {
        selectedSkin += 1;
        if(selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
    }

    public void BackOption()
    {
        selectedSkin -= 1;
        if(selectedSkin < 0)
        {
            selectedSkin = skins.Count - 1;
        }
        sr.sprite = skins[selectedSkin];
    }
    
    // function for select button -> should add the gadget to the player prefs and load the next level
    public void Select()
    {
        activeGadgets.Add(new ShortGadget(gadgetsToChoose[selectedSkin].gadget_id));
        
        PlayerPrefs.SetString("gadgets", JsonUtility.ToJson(new ShortGadgetList(activeGadgets)));

        
        // load the next level
        switch(PlayerPrefs.GetString("level_achieved"))
        {
            case "Level2":
                SceneManager.LoadScene("Level2");
                break;
            case "LevelB":
                SceneManager.LoadScene("LevelB");
                break;
            default: // we shouldn't reach here
                SceneManager.LoadScene("Level1");
                break;
        }
    }
}
