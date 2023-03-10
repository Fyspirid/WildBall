using UnityEngine;

public class BridgeCracked : MonoBehaviour
{
    [SerializeField] private GameObject[] bridgeParts;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //�������� ����� �����, �� ����
            int randomIndex = Random.Range(0, bridgeParts.Length);
            GameObject randomBridgeParts = bridgeParts[randomIndex];
            
            //����� ���������� � ��������� � Unity � ������ � ����������� ����
            Renderer renderer = randomBridgeParts.GetComponent<Renderer>();
            renderer.material.SetColor("_Color", Color.red);
            
            //��������� ����� ����� ����� ������� �������� 
            Destroy(randomBridgeParts, 0.5f);
        }
    }
}
