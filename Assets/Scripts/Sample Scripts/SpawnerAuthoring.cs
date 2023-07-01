using Unity.Entities;
using UnityEngine;

/// <summary>
/// このMonoBehaviourコンポーネントをSubSceneにあるEmptyオブジェクトにアタッチして下さい
/// </summary>
public class SpawnerAuthoring : MonoBehaviour
{
	[SerializeField]
	private GameObject _prefab;

	/// <summary>
	/// Entityへの変換処理を記述します。
	/// これはゲーム再生時に実行されます。
	/// </summary>
	class Baker : Baker<SpawnerAuthoring>
	{
		public override void Bake(SpawnerAuthoring authoring)
		{
			// アタッチされたオブジェクトに事前に要していたコンポーネントを追加します。
			AddComponent(new SpawnComponent()
			{
				// GetEntityを使用することで、MonoBehaviourオブジェクトをEntityに変換し、ECSコンポーネントに設定します。
				Prefab = GetEntity(authoring._prefab)
			});
		}
	}
}