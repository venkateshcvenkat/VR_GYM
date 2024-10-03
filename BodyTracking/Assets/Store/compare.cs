using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneMovementComparison : MonoBehaviour
{
    public GameObject character1; // Reference to character 1 GameObject
    public GameObject character2; // Reference to character 2 GameObject
    public string[] bonesToCompare; // Names of bones to compare (specify in Inspector)

    private Transform[] character1Bones; // Array to store character 1 bone transforms
    private Transform[] character2Bones; // Array to store character 2 bone transforms
    private Vector3[] initialPositions1; // Initial positions of character 1 bones
    private Vector3[] initialPositions2; // Initial positions of character 2 bones
    private Quaternion[] initialRotations1; // Initial rotations of character 1 bones
    private Quaternion[] initialRotations2; // Initial rotations of character 2 bones

   [SerializeField] float movementMagnitude1;
   [SerializeField ]float movementMagnitude2;
    public float compar;
    void Start()
    {
        // Get all bone transforms of character 1 and 2
        character1Bones = GetBoneTransforms(character1);
        character2Bones = GetBoneTransforms(character2);

        // Initialize arrays for initial positions and rotations
        initialPositions1 = GetInitialPositions(character1Bones);
        initialPositions2 = GetInitialPositions(character2Bones);
        initialRotations1 = GetInitialRotations(character1Bones);
        initialRotations2 = GetInitialRotations(character2Bones);

        // Ensure bone arrays are not empty
        if (character1Bones.Length == 0 || character2Bones.Length == 0)
        {
            Debug.LogWarning("Character bones not found.");
            return;
        }
    }

    void Update()
    {
        // Compare bone movements
        CompareBoneMovements();

    }

    void CompareBoneMovements()
    {
        // Iterate through each bone to compare
        for (int i = 0; i < bonesToCompare.Length; i++)
        {
            string boneName = bonesToCompare[i];

            // Find corresponding bone in character 1 and character 2
            Transform bone1 = FindBoneByName(character1Bones, boneName);
            Transform bone2 = FindBoneByName(character2Bones, boneName);

            // If bones are found, compare their movements
            if (bone1 != null && bone2 != null)
            {
                // Calculate movement since start
                Vector3 movement1 = bone1.position - initialPositions1[i];
                Vector3 movement2 = bone2.position - initialPositions2[i];

                // Calculate rotation change since start
                Quaternion rotationChange1 = Quaternion.Inverse(initialRotations1[i]) * bone1.rotation;
                Quaternion rotationChange2 = Quaternion.Inverse(initialRotations2[i]) * bone2.rotation;

                // Optionally, you can compare the magnitude of movements or rotation changes
                 movementMagnitude1 = movement1.magnitude;
                 movementMagnitude2 = movement2.magnitude;

              

                // Example comparison based on movement magnitude
                if (movementMagnitude1>movementMagnitude2)
                {
                    Debug.Log($"Bone '{boneName}' of character 1 has moved more than character 2.");
                    // Perform action or logging based on comparison result
                }
                else
                {
                    Debug.Log("Less");
                }

                if(movementMagnitude1 == movementMagnitude2)
                {
                    Debug.Log("sameAction");
                }

                if (movementMagnitude1 < movementMagnitude2)
                {
                    Debug.Log("2overmove");
                }
            }
            else
            {
                Debug.LogWarning($"Bone '{boneName}' not found in both characters.");
            }


            /*compar = movementMagnitude1 - movementMagnitude2;

            if (compar > 0.04)
            {
                Debug.Log("increase");
            }
            if (compar < -0.009)
            {
                Debug.Log("decrease");
            }
            if((compar > -0.01) &&  (compar < 0.039))
            {           
                Debug.Log("sameAction");
            }*/
        }
    }

    Transform[] GetBoneTransforms(GameObject character)
    {
        if (character == null)
        {
            Debug.LogWarning("Character GameObject is null.");
            return new Transform[0];
        }
        else
        {
            return character.GetComponentsInChildren<Transform>();
        }
    }

    Vector3[] GetInitialPositions(Transform[] bones)
    {
        Vector3[] initialPositions = new Vector3[bones.Length];
        for (int i = 0; i < bones.Length; i++)
        {
            initialPositions[i] = bones[i].position;
        }
        return initialPositions;
    }

    Quaternion[] GetInitialRotations(Transform[] bones)
    {
        Quaternion[] initialRotations = new Quaternion[bones.Length];
        for (int i = 0; i < bones.Length; i++)
        {
            initialRotations[i] = bones[i].rotation;
        }
        return initialRotations;
    }

    Transform FindBoneByName(Transform[] bones, string boneName)
    {
        foreach (Transform bone in bones)
        {
            if (bone.name == boneName)
            {
                return bone;
            }
        }
        return null;
    }
}