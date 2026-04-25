using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public MasterSO masterSO;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if(masterSO != null)
        {
            Debug.Log("GameManager : " + masterSO.name );
        }
    }
}
