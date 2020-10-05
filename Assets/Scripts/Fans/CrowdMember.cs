﻿using Assets.Scripts;
using UnityEngine;

public class CrowdMember : MonoBehaviour
{
    public float MoveSpeed;

    private Vector3 _bandPosition;

    private void Start()
    {
        _bandPosition = GetRandomBandMemberObject();
    }

    public void Update()
    {
        MoveToBandMember();
    }

    private void MoveToBandMember()
    {
        var step = CalcMoveSpeed();

        transform.position = Vector3.MoveTowards(transform.position, _bandPosition, step);
    }

    private float CalcMoveSpeed()
    {
        return MoveSpeed * Time.deltaTime;
    }

    private Vector3 GetRandomBandMemberObject()
    {
        BandMember bandMember = BandManager.Get().GetRandomBandMember();
        return bandMember.transform.position;
    }

    private void UpdateTrackMute(AudioManager.Music track)
    {
        FindObjectOfType<AudioManager>().Mute(track);
        PlayerController.Get().UpdateCanTurnOnTrack(AudioManager.Music.Bass, false);
    }

    private void UpdateTrackUnMute(AudioManager.Music track)
    {
        PlayerController.Get().UpdateCanTurnOnTrack(track, true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        return;

        var instrument = collision.gameObject.GetComponent<BandProperties>().Instrument[0];

        //Bass Collision
        if (instrument == AudioManager.Music.Bass)
        {
            UpdateTrackMute(AudioManager.Music.Bass);
        }

        //Chords Collision
        if (instrument == AudioManager.Music.Chords)
        {
            UpdateTrackMute(AudioManager.Music.Chords);
        }

        //Drums Collision
        if (instrument == AudioManager.Music.Drums)
        {
            UpdateTrackMute(AudioManager.Music.Drums);
        }

        //LeadMelody  Collision
        if (instrument == AudioManager.Music.Lead)
        {
            UpdateTrackMute(AudioManager.Music.Lead);
            UpdateTrackMute(AudioManager.Music.Melody);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        return;

        var instrument = collision.gameObject.GetComponent<BandProperties>().Instrument[0];

        //Bass Collision
        if (instrument == AudioManager.Music.Bass)
        {
            UpdateTrackUnMute(AudioManager.Music.Bass);
        }

        //Chords Collision
        if (instrument == AudioManager.Music.Chords)
        {
            UpdateTrackUnMute(AudioManager.Music.Chords);
        }

        //Drums Collision
        if (instrument == AudioManager.Music.Drums)
        {
            UpdateTrackUnMute(AudioManager.Music.Drums);
        }

        //LeadMelody  Collision
        if (instrument == AudioManager.Music.Lead)
        {
            UpdateTrackUnMute(AudioManager.Music.Lead);
            UpdateTrackUnMute(AudioManager.Music.Melody);
        }
    }
}