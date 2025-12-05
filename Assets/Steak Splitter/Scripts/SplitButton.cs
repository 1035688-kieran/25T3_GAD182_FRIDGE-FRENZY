using UnityEngine;
using UnityEngine.UI;

public class SplitButton : MonoBehaviour
{
    [SerializeField] SteakSpawner FrozenSteakSpawnPoint;
    [SerializeField] SoundEffectsManager SoundsEffectsManager;


    public BoxCollider2D myBoxCollider;
    public Button myButton;
    public GameObject CompletionCardTemplate;

    public int randomTimesPressed = 0;
    public int actualTimesPressed = 0;
    public int successfulSplit = 0;


    void Start()
    {
        randomTimesPressed = Random.Range(3, 11);

        myBoxCollider.enabled = true;
        CompletionCardTemplate.SetActive(false);
    }

    void Update()
    {
        if (actualTimesPressed == randomTimesPressed)
        {
            randomTimesPressed = Random.Range(3, 11);
            actualTimesPressed = 0;

            myBoxCollider.enabled = false;

            myButton.interactable = false;
        }
    }

    public void OnButtonPressed()
    {
        actualTimesPressed += 1;
        Debug.Log("Hello");
        SoundsEffectsManager.GetComponent<SoundEffectsManager>().Play();
    }

    public void ActivateButton()
    {
        if (successfulSplit == 2)
        {
            Debug.Log("Win!");
            CompletionCardTemplate.SetActive(true);
        }
        else
        {
            myButton.interactable = true;

            myBoxCollider.enabled = true;

            FrozenSteakSpawnPoint.GetComponent<SteakSpawner>().StartGame();

            successfulSplit += 1;
        }
    }
}
