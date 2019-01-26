using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMaskPool : MonoBehaviour
{
    public static LightMaskPool Instance;

    [SerializeField] private GameObject poolObject;

    private List<GameObject> objectList;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        objectList = new List<GameObject>();
    }

    public GameObject Generate(Vector3 position)
    {
        GameObject nonActiveObject;
        if ((nonActiveObject = GetNonActiveObject()) != null)
        {
            nonActiveObject.SetActive(true);
            nonActiveObject.transform.position = position;
            nonActiveObject.transform.localRotation = Quaternion.identity;

            return nonActiveObject;
        }

        //Debug.Log("Rubbles are FullActive. Generate New Rubble.");
        return GenerateNewObject(position);
    }

    private GameObject GenerateNewObject(Vector3 position)
    {
        var obj = Instantiate(poolObject, position, Quaternion.identity);
        obj.transform.parent = transform;

        objectList.Add(obj);
        return obj;
    }

    private GameObject GetNonActiveObject()
    {
        foreach (var obj in objectList)
        {
            if (!obj.activeSelf)
                return obj;
        }

        return null;
    }
}
