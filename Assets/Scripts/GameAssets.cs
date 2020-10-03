﻿using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameAssets: MonoBehaviour
    {
        private static GameAssets _i;

        public static GameAssets i {
            get
            {
                if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
                return _i;
            }
        }

        public SoundAudioClip[] SoundClip;

        [Serializable]
        public class SoundAudioClip {
            public SoundManager.Sound Sound;
            public AudioClip AudioClip;
        }
    }
}
