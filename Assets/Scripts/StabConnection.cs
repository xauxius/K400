using UnityEngine;

public class StabConnection
{
    public GameObject Stabber;
    public GameObject Stabbed;
    public ConfigurableJoint Joint;
    private Vector3 anchor = new Vector3(0, 0, 0);

    private StabConnection(GameObject stabber, GameObject stabbed, ConfigurableJoint joint)
    {
        Stabber = stabber;
        Stabbed = stabbed;
        Joint = joint;
    }

    public static StabConnection CreateConnection(GameObject stabber, GameObject stabbed, Axis freeAxis)
    {
        var joint = stabber.AddComponent<ConfigurableJoint>();

        joint.xMotion = freeAxis == Axis.X ? ConfigurableJointMotion.Free : ConfigurableJointMotion.Locked;
        joint.yMotion = freeAxis == Axis.Y ? ConfigurableJointMotion.Free : ConfigurableJointMotion.Locked;
        joint.zMotion = freeAxis == Axis.Z ? ConfigurableJointMotion.Free : ConfigurableJointMotion.Locked;
        joint.angularXMotion = ConfigurableJointMotion.Locked;
        joint.angularYMotion = ConfigurableJointMotion.Locked;
        joint.angularZMotion = ConfigurableJointMotion.Locked;

        joint.linearLimit = new SoftJointLimit {limit = 0.1f}; // Galbūt reiks pažiūrėt kokį limitą čia uždėt

        joint.connectedBody = stabbed.gameObject.GetComponent<Rigidbody>();

        return new StabConnection(stabber, stabbed, joint);
    }

    public void LimitAxis()
    {
        Joint.xMotion = ConfigurableJointMotion.Locked;
        Joint.anchor = anchor;
    }

    public void FreeAxis()
    {
        Joint.xMotion = ConfigurableJointMotion.Limited;
        Joint.anchor = anchor;
    }
}