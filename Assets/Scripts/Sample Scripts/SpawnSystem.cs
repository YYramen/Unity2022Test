using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

/// <summary>
/// SystemBaseを継承することで、システムとして登録することができます
/// partialにしているのはUnity側で自動生成される処理をこのクラスに適用するために必須です
/// </summary>
public partial class SpawnSystem : SystemBase
{
	/// <summary>
	/// 毎フレーム実行されます
	/// </summary>
	protected override void OnUpdate()
	{
		Entities
			.WithAll<SpawnComponent>()
			.WithStructuralChanges()
			.ForEach((Entity entity, ref SpawnComponent component) =>
			{
				// Entityを生成します
				for (int y = 0; y < 50; ++y)
				{
					for (int z = 0; z < 100; ++z)
					{
						for (int x = 0; x < 100; ++x)
						{
							Entity instantiateEntity = EntityManager.Instantiate(component.Prefab);
							EntityManager.SetComponentData(instantiateEntity, new Translation()
							{
								Value = new float3(x, y, z) * 1.5f
							});
						}
					}
				}

				// 生成処理が終わったら、コンポーネントを削除します
				EntityManager.RemoveComponent<SpawnComponent>(entity);
			})
			.Run();
	}
}