using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class GeneralStabbing: MonoBehaviour
{
    [SerializeField] private Axis freeAxis;

    public List<RayCaster> rayCasters;
    
    public StabManager stabManager;

    void Start()
    {
        rayCasters = gameObject.GetComponentsInChildren<RayCaster>().ToList();

        stabManager = new StabManager(gameObject, freeAxis);
    }

    private void Update()
    {
        foreach (var rayCaster in rayCasters)
        {
            RaycastHit hit;
            var didHit = Physics.Raycast(rayCaster.GetRay(), out hit, rayCaster.RayDistance);

            if (didHit)
            {
                var stabbed = hit.collider.gameObject;

                if (stabManager.SuitableForStab(stabbed))
                {
                    stabManager.ProcessRayStabbing(hit);
                } else if (hit.distance <= 0.005) {
                    Cut();
                }
            }
        }

        UpdateExtra();
    }

    public void CleanubStabConnections()
    {
        foreach (StabConnection stabConnection in stabManager.stabConnections)
        {
            Destroy(stabConnection.Joint);
        }
        stabManager.stabConnections = new List<StabConnection>();
    }

    public abstract void UpdateExtra();

    public virtual void Cut()
    {

    }
}