using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityGB;

public class EmulatorManager : MonoBehaviour
{
	public Renderer ScreenRenderer;
	public Image ScreenImage;
	[SerializeField]
	private Camera _camera;
	private GameObject _cameraGameObject;
	
	private bool _isRunning;

	public EmulatorBase Emulator
	{
		get;
		private set;
	}

	private Dictionary<KeyCode, EmulatorBase.Button> _keyMapping;

	// Use this for initialization
	void Start()
	{
		// Init Keyboard mapping
		_keyMapping = new Dictionary<KeyCode, EmulatorBase.Button>();
		_keyMapping.Add(KeyCode.UpArrow, EmulatorBase.Button.Up);
		_keyMapping.Add(KeyCode.DownArrow, EmulatorBase.Button.Down);
		_keyMapping.Add(KeyCode.LeftArrow, EmulatorBase.Button.Left);
		_keyMapping.Add(KeyCode.RightArrow, EmulatorBase.Button.Right);
		_keyMapping.Add(KeyCode.Z, EmulatorBase.Button.A);
		_keyMapping.Add(KeyCode.X, EmulatorBase.Button.B);
		_keyMapping.Add(KeyCode.Space, EmulatorBase.Button.Start);
		_keyMapping.Add(KeyCode.LeftShift, EmulatorBase.Button.Select);


		// Load emulator
		IVideoOutput drawable = new DefaultVideoOutput();
		IAudioOutput audio = GetComponent<DefaultAudioOutput>();
		ISaveMemory saveMemory = new DefaultSaveMemory();
		Emulator = new Emulator(drawable, audio, saveMemory);
		//ScreenRenderer.material.mainTexture = ((DefaultVideoOutput) Emulator.Video).Texture;
		ScreenImage.material.mainTexture = ((DefaultVideoOutput) Emulator.Video).Texture;

		gameObject.GetComponent<AudioSource>().enabled = false;
		ScreenImage.gameObject.SetActive(false);
		_cameraGameObject = _camera.gameObject;
		_cameraGameObject.SetActive(false);
	}

	public void EnterArcade()
	{
		_cameraGameObject.SetActive(true);
	}
	
	public void StartArcade(string filename)
	{
		ScreenImage.gameObject.SetActive(true);
		StartCoroutine(LoadRom(filename));
		_isRunning = true;
		_cameraGameObject.SetActive(true);
	}
	
	public void StopArcade()
	{
		ScreenImage.gameObject.SetActive(true);
		StopAllCoroutines();
		_isRunning = false;
		_cameraGameObject.SetActive(false);
	}

	void Update()
	{
		if (_isRunning)
		{
			// Input
			foreach (KeyValuePair<KeyCode, EmulatorBase.Button> entry in _keyMapping)
			{
				if (Input.GetKeyDown(entry.Key))
					Emulator.SetInput(entry.Value, true);
				else if (Input.GetKeyUp(entry.Key))
					Emulator.SetInput(entry.Value, false);
			}

			if (Input.GetKeyDown(KeyCode.T))
			{
				byte[] screenshot = ((DefaultVideoOutput) Emulator.Video).Texture.EncodeToPNG();
				File.WriteAllBytes("./screenshot.png", screenshot);
				Debug.Log("Screenshot saved.");
			}
		}
	}



	private IEnumerator LoadRom(string filename)
	{
		string path = System.IO.Path.Combine(Application.streamingAssetsPath, filename);
		Debug.Log("Loading ROM from " + path + ".");

		if (!File.Exists (path)) {
			Debug.LogError("File couldn't be found.");
			yield break;
		}

		WWW www = new WWW("file://" + path);
		yield return www;

		if (string.IsNullOrEmpty(www.error))
		{
			Emulator.LoadRom(www.bytes);
			StartCoroutine(Run());
		} else
			Debug.LogError("Error during loading the ROM.\n" + www.error);
	}

	private IEnumerator Run()
	{
		gameObject.GetComponent<AudioSource>().enabled = true;
		while (true)
		{
			// Run
			Emulator.RunNextStep();

			yield return null;
		}
	}
}
