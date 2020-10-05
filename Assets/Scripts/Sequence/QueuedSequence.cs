﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueuedSequence
{
    private List<SequenceNote> _notes = new List<SequenceNote>();
    public void AddNote(SequenceNote note)
    {
        _notes.Add(note);
    }
    public void RemoveNote(SequenceNote note)
    {
        _notes.Remove(note);
    }
    public bool HasActiveNotes()
    {
        return _notes.Count > 0;
    }

    static private int ID_GUID = 0;
    public int ID { get; private set; }

    public QueuedSequence()
    {
        ID = ID_GUID++;
    }

    public bool IsMostlyGivenHitScoreOrBetter(SequenceNote.HitScore hitScore)
    {
        int majorityCount = _notes.Count / 2 + 1;
        int activeCount = 0;
        foreach(var note in _notes)
        {
            if(note.GetHitScore() >= hitScore)
            {
                if(++activeCount >= majorityCount)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool HasAnyNotHitNotes()
    {
        foreach(var note in _notes)
        {
            if(note.GetHitScore() == SequenceNote.HitScore.NOT_HIT)
            {
                return true;
            }
        }
        return false;
    }
}