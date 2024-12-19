using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Array de prefabs de obstáculos
    public int poolSize = 10; // Tamaño del pool por cada tipo de obstáculo
    private List<GameObject> pool; // Lista de objetos en el pool

    void Awake()
    {
        pool = new List<GameObject>();

        // Inicializar el pool con todos los tipos de obstáculos
        for (int i = 0; i < objectPrefabs.Length; i++)
        {
            for (int j = 0; j < poolSize; j++)
            {
                GameObject obj = Instantiate(objectPrefabs[i]);
                obj.SetActive(false); // Inactivar inicialmente
                pool.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject()
    {
        // Verificar que el array objectPrefabs tenga elementos
        if (objectPrefabs.Length == 0)
        {
            Debug.LogError("No prefabs asignados en ObjectPool.");
            return null;
        }

        // Buscar un objeto inactivo en el pool y devolverlo
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // Si no hay objetos inactivos disponibles, crear uno nuevo
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject newObj = Instantiate(objectPrefabs[randomIndex]);
        newObj.SetActive(false); // Inactivar inicialmente
        pool.Add(newObj);
        return newObj;
    }

}
