using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

/// <summary>
/// SystemBase���p�����邱�ƂŁA�V�X�e���Ƃ��ēo�^���邱�Ƃ��ł��܂�
/// partial�ɂ��Ă���̂�Unity���Ŏ�����������鏈�������̃N���X�ɓK�p���邽�߂ɕK�{�ł�
/// </summary>
public partial class SpawnSystem : SystemBase
{
	/// <summary>
	/// ���t���[�����s����܂�
	/// </summary>
	protected override void OnUpdate()
	{
		Entities
			.WithAll<SpawnComponent>()
			.WithStructuralChanges()
			.ForEach((Entity entity, ref SpawnComponent component) =>
			{
				// Entity�𐶐����܂�
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

				// �����������I�������A�R���|�[�l���g���폜���܂�
				EntityManager.RemoveComponent<SpawnComponent>(entity);
			})
			.Run();
	}
}