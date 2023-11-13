using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] private Camera _cam;
    [SerializeField] private GameObject _highFoodPrefab;
    [SerializeField] private GameObject _lowFoodPrefab;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnFood(_lowFoodPrefab);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SpawnFood(_highFoodPrefab);
        }
    }

    private void SpawnFood(GameObject foodPrefab)
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Instantiate(foodPrefab, hit.point + Vector3.up * 2, Quaternion.identity);
        }

    }
}
