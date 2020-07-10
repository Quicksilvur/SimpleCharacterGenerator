using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleCharacterGenerator
{
    // Enumerator for debugging references
    public enum SelectionType
    {
        Skin,
        Hair,
        Undershirt,
        Shirt,
        Trousers,
        Pants,
        Socks,
        Shoes
    }

    public class SCG : MonoBehaviour
    {
        // Debugging
        public SelectionType selection;

        // For SpriteRenderer edits
        public int selectionInt;
        
        // All of the UI buttons (Skin, Change Type, etc)
        public Button[] buttons = new Button[9];

        // The sprites of the clothing
        public SpriteRenderer[] spr = new SpriteRenderer[9];

        // Sliders
        public GameObject[] dials = new GameObject[3];

        // Random
        public GameObject random;

        // Gender swap
        public GameObject gender;

        // Clothes
        public Sprite[] hairs = new Sprite[5];
        public Sprite[] undershirts = new Sprite[3];
        public Sprite[] shirts = new Sprite[3];
        public Sprite[] trousers = new Sprite[11];
        public Sprite[] pants = new Sprite[5];
        public Sprite[] socks = new Sprite[6];
        public Sprite[] shoes = new Sprite[6];

        // For the Gender Swap object
        public Sprite[] genders = new Sprite[2];

        // Value of the sprite used from the Sprite arrays
        public int[] typeSelections = new int[7];

        // Is a guy?
        public bool male;

        // Selects skin
        void ChangeTo_Skin()
        {
            selection = SelectionType.Skin;
            selectionInt = 0;
            SelectionChange();
        }

        // Selects hair
        void ChangeTo_Hair()
        {
            selection = SelectionType.Hair;
            selectionInt = 1;
            SelectionChange();
        }

        // Selects undershirt (or just T-shirt)
        void ChangeTo_Undershirt()
        {
            selection = SelectionType.Undershirt;
            selectionInt = 2;
            SelectionChange();
        }

        // Selects the overlaying top (or jacket)
        void ChangeTo_Shirt()
        {
            selection = SelectionType.Shirt;
            selectionInt = 3;
            SelectionChange();
        }

        // Selects trousers (or "pants" for you American viewers)
        void ChangeTo_Trousers()
        {
            selection = SelectionType.Trousers;
            selectionInt = 4;
            SelectionChange();
        }

        // Selects underwear (not really necessary but freedom of choice I guess)
        void ChangeTo_Pants()
        {
            selection = SelectionType.Pants;
            selectionInt = 5;
            SelectionChange();
        }

        // Selects socks
        void ChangeTo_Socks()
        {
            selection = SelectionType.Socks;
            selectionInt = 7;
            SelectionChange();
        }

        // Selects shoes
        void ChangeTo_Shoes()
        {
            selection = SelectionType.Shoes;
            selectionInt = 8;
            SelectionChange();
        }

        // Changes the type of clothing selected
        void ChangeType()
        {
            switch (selectionInt)
            {
                case 1: // Hair
                    typeSelections[1]++;
                    if (typeSelections[1] > hairs.Length - 1) typeSelections[1] = 0;
                    spr[1].sprite = hairs[typeSelections[1]];
                    break;
                case 2: // Undershirt
                    typeSelections[2]++;
                    if (typeSelections[2] > undershirts.Length - 1) typeSelections[2] = 0;
                    spr[2].sprite = undershirts[typeSelections[2]];
                    break;
                case 3: // Shirt
                    typeSelections[3]++;
                    if (typeSelections[3] > shirts.Length - 1) typeSelections[3] = 0;
                    spr[3].sprite = shirts[typeSelections[3]];
                    break;
                case 4: // Trousers
                    typeSelections[4]++;
                    if (typeSelections[4] > trousers.Length - 1) typeSelections[4] = 0;
                    spr[4].sprite = trousers[typeSelections[4]];
                    break;
                case 5: // Underwear
                    typeSelections[5]++;
                    if (typeSelections[5] > pants.Length - 1) typeSelections[5] = 0;
                    spr[5].sprite = pants[typeSelections[5]];
                    break;
                case 7: // Socks
                    typeSelections[7]++;
                    if (typeSelections[7] > socks.Length - 1) typeSelections[7] = 0;
                    spr[7].sprite = socks[typeSelections[7]];
                    break;
                case 8: // Shoes
                    typeSelections[8]++;
                    if (typeSelections[8] > shoes.Length - 1) typeSelections[8] = 0;
                    spr[8].sprite = shoes[typeSelections[8]];
                    break;
            }
        }

        // For random preset generation, over 2 septendecillion combinations here
        void RandomR()
        {
            int sel = selectionInt;
            selectionInt = 0;
            spr[1].sprite = hairs[Random.Range(0, hairs.Length)];
            spr[2].sprite = undershirts[Random.Range(0, undershirts.Length)];
            spr[3].sprite = shirts[Random.Range(0, shirts.Length)];
            spr[4].sprite = trousers[Random.Range(0, trousers.Length)];
            spr[5].sprite = pants[Random.Range(0, pants.Length)];
            spr[7].sprite = socks[Random.Range(0, socks.Length)];
            spr[8].sprite = shoes[Random.Range(0, shoes.Length)];
            for (var i = 0; i < 6; i++)
            {
                spr[i].color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                SelectionChange();
                selectionInt++;
            }
        }

        // When sliders are adjusted
        void SelectionChange()
        {
            dials[0].transform.position = new Vector3(2.45f + (spr[selectionInt].color.r * 5.1f), 1f, 0f);
            dials[1].transform.position = new Vector3(2.45f + (spr[selectionInt].color.g * 5.1f), 0f, 0f);
            dials[2].transform.position = new Vector3(2.45f + (spr[selectionInt].color.b * 5.1f), -1f, 0f);
        }

        // Initialisation
        void Start()
        {
            buttons[0].onClick.AddListener(ChangeTo_Skin);
            buttons[1].onClick.AddListener(ChangeTo_Hair);
            buttons[2].onClick.AddListener(ChangeTo_Undershirt);
            buttons[3].onClick.AddListener(ChangeTo_Shirt);
            buttons[4].onClick.AddListener(ChangeTo_Trousers);
            buttons[5].onClick.AddListener(ChangeTo_Pants);
            buttons[7].onClick.AddListener(ChangeTo_Socks);
            buttons[8].onClick.AddListener(ChangeTo_Shoes);
            buttons[6].onClick.AddListener(ChangeType);
        }

        // Keeps the sliders in their slots
        float ClampF(float value, float min, float max)
        {
            if (value < min) value = min;
            if (value > max) value = max;
            return value;
        }

        // The magic!
        void Update()
        {
            // Used for getting the cursor's position in the world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Because Unity likes to default mouse position to z: -10...
            mousePosition.z += 10f;
            // Not even sure why I included this but I thought a male with those stringy trousers looked daft, no offence
            // The hair is reasonable though
            if (male)
            {
                if (spr[1].sprite == hairs[0] || spr[1].sprite == hairs[1]) spr[1].sprite = hairs[2];
                if (spr[4].sprite == trousers[4] || spr[4].sprite == trousers[5]) spr[4].sprite = trousers[6];
                if (spr[5].sprite == pants[2] || spr[5].sprite == pants[3]) spr[5].sprite = pants[0];
            }
            else
            {
                if (spr[1].sprite == hairs[2] || spr[1].sprite == hairs[3]) spr[1].sprite = hairs[0];
            }
            // Controls the sliders
            if (Input.GetMouseButton(0))
            {
                foreach (GameObject dial in dials)
                {
                    if (Vector3.Distance(dial.transform.position, mousePosition) < 0.3f)
                    {
                        dial.transform.position = new Vector3(mousePosition.x, dial.transform.position.y, dial.transform.position.z);
                        dials[0].transform.position = new Vector3(ClampF(dials[0].transform.position.x, 2.45f, 7.55f), 1f, 0f);
                        dials[1].transform.position = new Vector3(ClampF(dials[1].transform.position.x, 2.45f, 7.55f), 0f, 0f);
                        dials[2].transform.position = new Vector3(ClampF(dials[2].transform.position.x, 2.45f, 7.55f), -1f, 0f);
                        float r = dials[0].transform.position.x - 2.45f;
                        float g = dials[1].transform.position.x - 2.45f;
                        float b = dials[2].transform.position.x - 2.45f;
                        spr[selectionInt].color = new Color(r / 5.1f, g / 5.1f, b / 5.1f);
                    }
                }
            }
            // Used for button controls
            if (Input.GetMouseButtonDown(0))
            {
                if (Vector3.Distance(random.transform.position, mousePosition) < 0.3f) RandomR();
                if (Vector3.Distance(gender.transform.position, mousePosition) < 0.3f)
                {
                    male = (male ? false : true);
                    spr[6].sprite = (male ? genders[0] : genders[1]);
                }
            }
        }
    }
}