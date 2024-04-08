using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCoinForSin : MonoBehaviour
{
    public GameObject coin;
    public Transform EnemyPso;
    [SerializeField] int numberOfCoins = 6;
    [SerializeField] float frequency = 3f; // Tần số của đường cong sin
    [SerializeField] float amplitude = 0.5f; // Biên độ của đường cong sin
    [SerializeField] float distanceBetweenCoins = 1f; // Khoảng cách giữa các đồng xu

    private void Start()
    {
        SpanCoins();
    }

    public void SpanCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            // Tính toán vị trí x cho đồng xu, đều dần từ trái sang phải
            float x = EnemyPso.position.x + i * distanceBetweenCoins;
            // Tính toán vị trí y cho đồng xu theo hình dạng của đường cong sin
            float y = EnemyPso.position.y + amplitude * Mathf.Sin(frequency * x);
            // Vị trí z giữ nguyên hoặc thay đổi tùy theo nhu cầu của bạn
            float z = EnemyPso.position.z;
            Vector3 spawnPosition = new Vector3(x, y, z);
            // Tạo một đồng xu tại vị trí tính toán
            Instantiate(coin, spawnPosition, Quaternion.identity);
        }
    }
}
