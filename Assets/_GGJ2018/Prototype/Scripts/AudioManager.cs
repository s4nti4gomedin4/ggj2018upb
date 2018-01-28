using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource m_playerMoveSound;
	public AudioSource m_playerEatingSound;
	public AudioSource m_playerGrowSound;
	public AudioSource m_playerSpitOutSound;
	public AudioSource m_enemyMoveSound;
	public AudioSource m_enemyGrowSound;
	public AudioSource m_enemyDeathSound;
	public AudioSource m_towerLaser;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//Stop All Player Sounds
	public void PlayerStopAllSounds()
	{
		if (m_playerMoveSound.isPlaying) {
			m_playerMoveSound.Stop ();
		}
		if (m_playerEatingSound.isPlaying) {
			m_playerEatingSound.Stop ();
		}
		if (m_playerGrowSound.isPlaying) {
			m_playerGrowSound.Stop ();
		}
		if (m_playerSpitOutSound.isPlaying) {
			m_playerSpitOutSound.Stop ();
		}
	}

	//Stop All Enemy Sounds
	public void EnemyStopAllSounds()
	{
		if (m_enemyMoveSound.isPlaying) {
			m_enemyMoveSound.Stop ();
		}
		if (m_enemyGrowSound.isPlaying) {
			m_enemyGrowSound.Stop ();
		}
		if (m_enemyDeathSound.isPlaying) {
			m_enemyDeathSound.Stop ();
		}
	}

	//Player Sounds//

	// Player Move Sound
	public void PlayerMoveSoundPlay(bool loop)
	{
		PlayerStopAllSounds ();
		m_playerMoveSound.loop = loop;
		m_playerMoveSound.Play ();
	}

	//Player Eating Sound
	public void PlayerEatingSoundPlay(bool loop)
	{
		PlayerStopAllSounds ();
		m_playerEatingSound.loop = loop;
		m_playerEatingSound.Play ();
	}

	// Player Grow Sound
	public void PlayerGrowSoundPlay(bool loop)
	{
		PlayerStopAllSounds ();
		m_playerGrowSound.loop = loop;
		m_playerGrowSound.Play ();
	}

	//Player Spit Out Sound
	public void PlayerSpitOutSoundPlay(bool loop)
	{
		PlayerStopAllSounds ();
		m_playerSpitOutSound.loop = loop;
		m_playerSpitOutSound.Play ();
	}

	//Enemy Sounds

	//Enemy Move Sound
	public void EnemyMoveSoundPlay(bool loop)
	{
		EnemyStopAllSounds ();
		m_enemyMoveSound.loop = loop;
		m_enemyMoveSound.Play ();
	}

	//Enemy Grow Sound
	public void EnemyGrowSoundPlay(bool loop)
	{
		EnemyStopAllSounds ();
		m_enemyGrowSound.loop = loop;
		m_enemyGrowSound.Play ();
	}

	//Enemy Death Sound
	public void EnemyDeathSoundPlay(bool loop)
	{
		EnemyStopAllSounds ();
		m_enemyDeathSound.loop = loop;
		m_enemyDeathSound.Play ();
	}

	//Tower Laser Sound
	public void TowerLaserSoundPlay(bool loop)
	{
		m_towerLaser.Stop ();
		m_towerLaser.loop = loop;
		m_towerLaser.Play ();
	}
}
