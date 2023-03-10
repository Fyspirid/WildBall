using UnityEngine;

public class BridgeCracked : MonoBehaviour
{
    [SerializeField] private GameObject[] bridgeParts;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //случайая часть моста, из трех
            int randomIndex = Random.Range(0, bridgeParts.Length);
            GameObject randomBridgeParts = bridgeParts[randomIndex];
            
            //берем ифнормацию о материале с Unity и красим в необходимый цвет
            Renderer renderer = randomBridgeParts.GetComponent<Renderer>();
            renderer.material.SetColor("_Color", Color.red);
            
            //разрушаем часть моста после секунды задержки 
            Destroy(randomBridgeParts, 0.5f);
        }
    }
}
