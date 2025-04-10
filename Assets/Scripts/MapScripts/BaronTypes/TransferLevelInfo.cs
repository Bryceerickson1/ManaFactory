using UnityEngine;

public class TransferLevelInfo : MonoBehaviour
{
    public static TransferLevelInfo instance;
	public EnemyStats Enemy;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

	public void StoreEnemy(EnemyStats _Enemy) {Enemy = _Enemy;}
}
