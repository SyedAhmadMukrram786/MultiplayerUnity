using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{

    private NetworkVariable<int> RandomNumber = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public override void OnNetworkSpawn()
    {
        RandomNumber.OnValueChanged += (int previouseValue, int newValue) =>
        {
            Debug.Log(OwnerClientId + " Random Number: " + RandomNumber.Value);
        };
    }
    private void Update()
    {
        if (!IsOwner) return;
    
        if (Input.GetKeyDown(KeyCode.T))
        {
            RandomNumber.Value = Random.Range(0, 100);
        }

        Vector3 moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) moveDir.z = +1f;
        if (Input.GetKey(KeyCode.A)) moveDir.x = -1f;
        if (Input.GetKey(KeyCode.D)) moveDir.x = +1f;
        if (Input.GetKey(KeyCode.S)) moveDir.z = -1f;

        float moveSpeed = 5f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
