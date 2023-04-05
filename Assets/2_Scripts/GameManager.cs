using ExitGames.Client.Photon;
using GameCreator.Runtime.Characters;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;

namespace Com.MyCompany.MyGame
{
#pragma warning disable 649

	/// <summary>
	/// Game manager.
	/// Connects and watch Photon Status, Instantiate Player
	/// Deals with quiting the room and the game
	/// Deals with level loading (outside the in room synchronization)
	/// </summary>
	public class GameManager : MonoBehaviourPunCallbacks, IOnEventCallback
	{
		#region Public Fields

		static public GameManager Instance;

		public PlayerController localPlayerController;
		public ArcadeManager arcadeManager;

		public void EnterArcade()
		{
			localPlayerController.GetInArcade(true);
		}

		public void ExitArcade()
		{
			localPlayerController.GetInArcade(false);
		}

		public void EnterPainting()
		{
			localPlayerController.GetInPainting(true);
		}

		public void ExitPainting()
		{
			localPlayerController.GetInPainting(false);
		}

		public void EnterBuildingMode()
		{
			localPlayerController.GetInBuildingMode(true);
		}

		public void ExitBuildingMode()
		{
			localPlayerController.GetInBuildingMode(false);
		}
		
		public void ExitMouseUIMode()
		{
			localPlayerController.GetInMouseUIMode(false);
		}

		public void EnterMouseUIMode()
		{
			localPlayerController.GetInMouseUIMode(true);
		}

		#endregion

		#region Private Fields

		private GameObject instance;

		[Tooltip("The prefab to use for representing the local player")] [SerializeField]
		private GameObject localPlayerPrefab;
		
		[Tooltip("The prefab to use for representing the other players")] [SerializeField]
		private GameObject otherPlayerPrefab;

		#endregion

		#region MonoBehaviour CallBacks

		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity during initialization phase.
		/// </summary>
		void Start()
		{
			Instance = this;

			// in case we started this demo with the wrong scene being active, simply load the menu scene
			if (!PhotonNetwork.IsConnected)
			{
				SceneManager.LoadScene("Launcher");

				return;
			}

			if (localPlayerPrefab == null)
			{
				// #Tip Never assume public properties of Components are filled up properly, always check and inform the developer of it.

				Debug.LogError(
					"<Color=Red><b>Missing</b></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'",
					this);
			}
			else
			{
				if (PlayerManager.LocalPlayerInstance == null)
				{
					Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
					
					SpawnPlayer();
				}
				else
				{
					Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
				}
			}
		}

		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity on every frame.
		/// </summary>
		void Update()
		{
			// "back" button of phone equals "Escape". quit app if that's pressed
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				QuitApplication();
			}
		}

		#endregion

		#region Photon Callbacks

		/// <summary>
		/// Called when a Photon Player got connected. We need to then load a bigger scene.
		/// </summary>
		/// <param name="other">Other.</param>
		public override void OnPlayerEnteredRoom(Player other)
		{
			Debug.Log("OnPlayerEnteredRoom() " + other.NickName); // not seen if you're the player connecting
		}

		/// <summary>
		/// Called when a Photon Player got disconnected. We need to load a smaller scene.
		/// </summary>
		/// <param name="other">Other.</param>
		public override void OnPlayerLeftRoom(Player other)
		{
			Debug.Log("OnPlayerLeftRoom() " + other.NickName); // seen when other disconnects
		}

		/// <summary>
		/// Called when the local player left the room. We need to load the launcher scene.
		/// </summary>
		public override void OnLeftRoom()
		{
			SceneManager.LoadScene("Launcher");
		}

		#endregion

		#region Public Methods

		public bool LeaveRoom()
		{
			return PhotonNetwork.LeaveRoom();
		}

		public void QuitApplication()
		{
			Application.Quit();
		}

		#endregion
		
		private void SpawnPlayer()
		{
			var localPlayer = Instantiate(localPlayerPrefab, new Vector3(0f, 5f, 0f),
				Quaternion.identity);
			localPlayerController = localPlayer.GetComponent<PlayerController>();
			var character = localPlayer.GetComponent<Character>();
			character.IsPlayer = true;
			
			var photonView = localPlayer.GetComponent<PhotonView>();

			if (PhotonNetwork.AllocateViewID(photonView))
			{
				var data = new object[]
				{
					localPlayer.transform.position, localPlayer.transform.rotation, photonView.ViewID
				};

				var raiseEventOptions = new RaiseEventOptions
				{
					Receivers = ReceiverGroup.Others,
					CachingOption = EventCaching.AddToRoomCache
				};
				
				PhotonNetwork.RaiseEvent(Events.CustomManualInstantiationEventCode, data, raiseEventOptions, SendOptions.SendReliable);
			}
			else
			{
				Debug.LogError("Failed to allocate a ViewId.");

				Destroy(localPlayer);
			}
		}
		
		public void OnEvent(EventData photonEvent)
		{
			if (photonEvent.Code == Events.CustomManualInstantiationEventCode)
			{
				var data = (object[]) photonEvent.CustomData;

				var player = Instantiate(otherPlayerPrefab, (Vector3) data[0], (Quaternion) data[1]);
				var photonView = player.GetComponent<PhotonView>();
				photonView.ViewID = (int) data[2];
			}
		}
	}
}