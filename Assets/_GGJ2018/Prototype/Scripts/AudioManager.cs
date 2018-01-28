using System;
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

    public HitBox m_Hitbox;

    private void OnEnable()
    {
        PlayerMovement.onPlayerMoving += OnPlayermoveHandler;
        PlayerMovement.onPlayerStop += OnPlayerStopHandler;
        EnemyManager.onEnemyMove += OnEnemyMove;
        Infectable.OnDeath += OndeathEnemy;
        Infectable.OnLevelUp += OnLevelUpPlayer;
    }



    public void OnDisable()
    {
        PlayerMovement.onPlayerMoving -= OnPlayermoveHandler;
        PlayerMovement.onPlayerStop -= OnPlayerStopHandler;
        EnemyManager.onEnemyMove -= OnEnemyMove;
        Infectable.OnDeath -= OndeathEnemy;
        Infectable.OnLevelUp -= OnLevelUpPlayer;
    }
    // Use this for initialization
    void Start () {
        m_Hitbox.onLevelUp += OnEating;
	}
    private void OnLevelUpPlayer()
    {
        EnemyGrowSoundPlay(false, false);
    }
    private void OnEnemyMove()
    {
        EnemyMoveSoundPlay(false, false);
    }
    private void OndeathEnemy()
    {
        EnemyDeathSoundPlay(false, false);
    }
    private void OnEating()
    {
        if (m_Hitbox.m_Level > 2)
        {
            PlayerEatingSoundPlay(false, false);
            PlayerGrowSoundPlay(false, false);
        }
       
    }

    // Update is called once per frame
    void Update () {
		
	}
    void OnPlayermoveHandler(){
        PlayerMoveSoundPlay(false,false);
    }
    private void OnPlayerStopHandler()
    {
        PlayerMoveSoundStop();
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
    public void PlayerMoveSoundPlay(bool loop,bool repeat)
	{
        PlaySound(m_playerMoveSound, loop, repeat);
	}

   

    public void PlayerMoveSoundStop()
    {

        if(m_playerMoveSound.isPlaying){
            m_playerMoveSound.Stop();
        }

    }

	//Player Eating Sound
    public void PlayerEatingSoundPlay(bool loop,bool repeat)
	{
        PlaySound(m_playerEatingSound,loop,repeat);
	}

	// Player Grow Sound
    public void PlayerGrowSoundPlay(bool loop,bool repeat)
	{
        PlaySound(m_playerGrowSound,loop,repeat);
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
    public void EnemyMoveSoundPlay(bool loop,bool repeat)
	{
        PlaySound(m_enemyMoveSound, loop, repeat);
	}

	//Enemy Grow Sound
	public void EnemyGrowSoundPlay(bool loop,bool repeat)
	{
		
        PlaySound(m_enemyGrowSound,loop,repeat);
	}

	//Enemy Death Sound
    public void EnemyDeathSoundPlay(bool loop,bool repeat)
	{
        PlaySound(m_enemyDeathSound,loop,repeat);
	}

	//Tower Laser Sound
	public void TowerLaserSoundPlay(bool loop)
	{
		m_towerLaser.Stop ();
		m_towerLaser.loop = loop;
		m_towerLaser.Play ();
	}

    public void PlaySound(AudioSource _sound, bool loop, bool repeat)
    {

        if (_sound == null)
        {
            return;
        }
        _sound.loop = loop;
        if (repeat)
            _sound.Play();
        else if (!_sound.isPlaying)
            _sound.Play();
    }
}
