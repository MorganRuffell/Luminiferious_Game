using Luminfiarious.Enemies;
using Luminfiarious.Cameras;
using Luminfiarious.Character;
using Luminfiarious.Gameplay;
using Luminfiarious.Manager;
using Luminfiarious.Supers;
using Luminfiarious.UI;
using UnityEngine;
using UnityEngine.AI;

namespace Luminfiarious.Enemies
{
	[RequireComponent(typeof(EnemyHealth))]
	[RequireComponent(typeof(EnemyDamageScript))]
	public class EnemyControllerClass : MonoBehaviour
	{
		public float patrolTime = 15;
		public float aggroRange = 10;
		[Space]
		[Space]
		public Transform[] waypoints;
		[Space]
		public AudioSource Audio;
		
		[Tooltip("This is the index of the waypoint array")]
		private int index; //The current waypoint index in the waypoints array

		float speed, agentSpeed; //Current agent speed and NavMeshAgent component speed
		
		Transform Player;
		Animator animator;
		NavMeshAgent agent;


		private void Awake()
		{
			animator = GetComponent<Animator>();
			agent = GetComponent<NavMeshAgent>();
			
			if (agent != null)
			{
				agentSpeed = agent.speed;	
			}

			Player = GameObject.FindGameObjectWithTag("Player").transform;
			index = Random.Range(0, waypoints.Length);

			if (waypoints.Length > 0)
			{
				InvokeRepeating("Patrol", 0, patrolTime);
			}

		}

		private void Update()
		{
			agent.destination = waypoints[index].position;

			agent.speed = agentSpeed / 2;

			if (Player != null && Vector3.Distance(transform.position, Player.position) < aggroRange)
			{
				agent.destination = Player.position;
				agentSpeed = agentSpeed + 3;
			}

		}

		public void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				HandleCollision();
			}
		}

		private void HandleCollision()
		{
			Audio.Play();
		}


		void Patrol()
		{
			index = index == waypoints.Length - 1 ? 0 : index + 1;
		}

	}
}


