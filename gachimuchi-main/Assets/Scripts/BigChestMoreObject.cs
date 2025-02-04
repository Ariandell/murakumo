using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigChestMoreObject : MonoBehaviour
{
    public GameObject[] items;
    public Transform[] spawnPoint;
    public float spawnRadius = 1f;
    public float closeDelay = 1f; // �������� ����� ��������� �������

    private bool isOpen = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isOpen)
        {
            if (Vector2.Distance(transform.position, Player.Instance.transform.position) <= spawnRadius)
            {
                animator.SetTrigger("chest");
                SpawnItems();
                isOpen = true;
                StartCoroutine(CloseChest());
            }
        }
    }

    private void SpawnItems()
    {
        if (items.Length == 0 || spawnPoint.Length == 0)
        {
            Debug.LogWarning("�����");
            return;
        }

        if (items.Length != spawnPoint.Length)
        {
            Debug.LogWarning("ʳ������ ��'���� �� ����� ������ �� �������");
            return;
        }

        for (int i = 0; i < items.Length; i++)
        {
            Instantiate(items[i], spawnPoint[i].position, Quaternion.identity);
        }
    }



    // �������� ��� �������� �������
    IEnumerator CloseChest()
    {
        yield return new WaitForSeconds(closeDelay);
        animator.SetTrigger("close");
    }
}
