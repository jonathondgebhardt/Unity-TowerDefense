using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject standardTurret;

    private GameObject turretToBuild;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        turretToBuild = standardTurret;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
