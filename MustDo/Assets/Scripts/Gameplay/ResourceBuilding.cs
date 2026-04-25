using System.Threading;
using UnityEngine;

public class ResourceBuilding : MonoBehaviour
{
    SO_MOCKUP so_mockup;
    int wood = 0;

    float timer = 0;
    void Start()
    {
        so_mockup = GetComponent<SO_MOCKUP>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            ProduceResource();
            timer -= 1f;
        }
    }

    void ProduceResource()
    {

        if (so_mockup != null )
        {
            ResourceManager.Instance.AddWood(so_mockup.buildingData.farm.wood);
        }
    }

    
}
