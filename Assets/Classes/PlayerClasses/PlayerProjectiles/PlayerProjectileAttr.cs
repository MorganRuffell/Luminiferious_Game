using Luminfiarious.Enemies;
using Luminfiarious.Supers;
using UnityEngine;

namespace Luminfiarious.Gameplay
{
	[RequireComponent(typeof(Rigidbody))]
	[DisallowMultipleComponent]
	class PlayerProjectileAttr : DamageParent
	{
		#region PlayerProjectile Attr
			[Header("Player Projectile Controller")]
			[Range(0,500), Tooltip("How much damage as a float will the players projectile be able to do to the enemy.")]
			public float Damage = 20.0f;
			[Space]

			[SerializeField]
			public float force = 50.0f;

			[SerializeField]
			public float Lifetime = 30.0f;

			public Rigidbody BulletCollisionRb;
			
			public string targetTag;
		#endregion

		public void Awake()
		{
			targetTag = "Enemy";

		}

		public void Start()
		{
			BulletCollisionRb = GetComponent<Rigidbody>();
			BulletCollisionRb.AddForce(transform.right * force, ForceMode.Impulse);
		
			//Invoke();
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.CompareTag(targetTag) && collision.gameObject.GetComponent<EnemyHealth>())
			{
				collision.gameObject.GetComponent<EnemyHealth>().TakeDamage((int) Damage);
				Invoke("Despawn",1.0f);

			}

			if (collision.gameObject.CompareTag("Enviroment"))
			{
				Invoke("Despawn", Lifetime);
			}

		}

		private void Despawn()
		{
			Destroy(gameObject);
		}
	}
}
