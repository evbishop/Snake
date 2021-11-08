using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    [SerializeField] float speed = 3f, rotationSpeed = 180f, speedChange = 0.5f;
    [SerializeField] GameObject tailPrefab;

    public float Speed { get { return speed; } }
    public List<GameObject> Tails { get; } = new List<GameObject>();

    void Start()
    {
        Tails.Add(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border")) SceneManager.LoadScene(0);
    }

    public void AddTail()
    {
        Instantiate(tailPrefab, Tails[Tails.Count-1].transform.position, Quaternion.identity);
        speed += speedChange;
    }
}
