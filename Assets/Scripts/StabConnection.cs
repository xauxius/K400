using UnityEngine;

public class StabConnection
{
    public GameObject Stabber;
    public GameObject Stabbed;
    private ConfigurableJoint joint;
    private Vector3 anchor = new Vector3(0, 0, 0);

    private StabConnection(GameObject stabber, GameObject stabbed, ConfigurableJoint joint)
    {
        Stabber = stabber;
        Stabbed = stabbed;
        this.joint = joint;
    }

    public static StabConnection CreateConnection(GameObject stabber, GameObject stabbed)
    {
        var joint = stabber.AddComponent<ConfigurableJoint>();

        joint.xMotion = ConfigurableJointMotion.Free;
        joint.yMotion = ConfigurableJointMotion.Locked;
        joint.zMotion = ConfigurableJointMotion.Locked;
        joint.angularXMotion = ConfigurableJointMotion.Locked;
        joint.angularYMotion = ConfigurableJointMotion.Locked;
        joint.angularZMotion = ConfigurableJointMotion.Locked;

        joint.linearLimit = new SoftJointLimit {limit = 0.1f}; // Galbūt reiks pažiūrėt kokį limitą čia uždėt

        joint.connectedBody = stabbed.gameObject.GetComponent<Rigidbody>();

        return new StabConnection(stabber, stabbed, joint);
    }

    public void LimitAxis()
    {
        joint.xMotion = ConfigurableJointMotion.Locked;
        joint.anchor = anchor;
    }

    public void FreeAxis()
    {
        joint.xMotion = ConfigurableJointMotion.Limited;
        joint.anchor = anchor;
    }
}