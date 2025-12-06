using UnityEngine;

public class StartGameSteakSplitter : MonoBehaviour
{
    [SerializeField] SteakSpawner FrozenSteakSpawnPoint;

    public GameObject InstructionCardTemplate;
    
    void Start()
    {
        InstructionCardTemplate.SetActive(true);
    }

    public void PressStart()
    {
        InstructionCardTemplate.SetActive(false);

        FrozenSteakSpawnPoint.GetComponent<SteakSpawner>().SpawnSteak();
    }
}
