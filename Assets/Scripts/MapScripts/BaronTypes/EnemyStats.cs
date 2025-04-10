using UnityEngine;

[CreateAssetMenu(fileName = "NewMapEnemy", menuName = "NewMapEnemy")]
public class EnemyStats : ScriptableObject
{
	public int Difficulty;
	public int Loot;
	public string BaronName;
	public Sprite BaronImage;
	public string Events;
}
