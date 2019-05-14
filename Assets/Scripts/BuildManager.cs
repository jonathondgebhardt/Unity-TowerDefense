using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject standardTurret;
    public GameObject missileLauncher;

    private GameObject turretToBuild;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
