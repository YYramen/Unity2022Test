using Unity.Entities;
using UnityEngine;

/// <summary>
/// ����MonoBehaviour�R���|�[�l���g��SubScene�ɂ���Empty�I�u�W�F�N�g�ɃA�^�b�`���ĉ�����
/// </summary>
public class SpawnerAuthoring : MonoBehaviour
{
	[SerializeField]
	private GameObject _prefab;

	/// <summary>
	/// Entity�ւ̕ϊ��������L�q���܂��B
	/// ����̓Q�[���Đ����Ɏ��s����܂��B
	/// </summary>
	class Baker : Baker<SpawnerAuthoring>
	{
		public override void Bake(SpawnerAuthoring authoring)
		{
			// �A�^�b�`���ꂽ�I�u�W�F�N�g�Ɏ��O�ɗv���Ă����R���|�[�l���g��ǉ����܂��B
			AddComponent(new SpawnComponent()
			{
				// GetEntity���g�p���邱�ƂŁAMonoBehaviour�I�u�W�F�N�g��Entity�ɕϊ����AECS�R���|�[�l���g�ɐݒ肵�܂��B
				Prefab = GetEntity(authoring._prefab)
			});
		}
	}
}